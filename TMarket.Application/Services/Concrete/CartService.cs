using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMarket.Application.CustomValidator.Abstract;
using TMarket.Application.DomainModels;
using TMarket.Persistence.DbModels;
using TMarket.Persistence.UnitOfWork;

namespace TMarket.Application.Services.Concrete
{
   public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationDictionary _validationDictionary;
        private readonly IConfiguration _config;

        public CartService(IUnitOfWork unitOfWork, IValidationDictionary validationDictionary,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _validationDictionary = validationDictionary;
            _config = configuration;
        }

        public IEnumerable<CartDTO> GetAllAsyncWithNoTracking()
        {
            var items = _unitOfWork.CartRepository.GetAll(p => p,
                p => !p.IsDeleted,
                p => p.OrderBy(x => x.Id),
                source => source
                .Include(o => o.CartProducts)
                .ThenInclude(o => o.Product),
                true);
            return items;
        }

        public async Task<bool> InsertOrderAsync(CartDomain cart)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var products = await _unitOfWork.ProductRepository.GetAllAsyncWithTracking();
                var users = await _unitOfWork.UserRepository.GetAllAsyncWithNoTracking();

                var user = users.FirstOrDefault(x => x.Id == cart.UserId);

                if (user == null)
                {
                    _validationDictionary.AddError("UserId", "შეყვანილი იუზერი არ არსებობს!");
                    return false;
                }

                var NewCart = new CartDTO { UserId = cart.UserId, };
                await _unitOfWork.CartRepository.InsertAsync(NewCart);

                if (!await AddOrderProduct(cart, products.ToList(), NewCart.Id))
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }

                await _unitOfWork.SaveChangesAsync();

                var jobId = BackgroundJob.Schedule(() => DeleteCart(NewCart.Id),
                    TimeSpan.FromMinutes(_config.GetValue<int>("CartOptions:CartExpireTimeInMinute")));

                await _unitOfWork.CommitAsync();

                return true;

            } catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        protected async Task<bool> AddOrderProduct(CartDomain cart, List<ProductDTO> products, int cartId)
        {
            List<int> productIds = cart.CartProducts.Select(x => x.ProductId).ToList();

            for (int i = 0; i < productIds.Count; i++)
            {
                var productId = productIds[i];
                var product = products.FirstOrDefault(x => x.Id == productId && x.IsAvailable);
                var CartQuantity = cart.CartProducts.Single(x => x.ProductId == productId).Quantity;

                if (!IsValidProduct(product, CartQuantity, productId, i))
                {
                    continue;
                }

                product.AvailableCount -= CartQuantity;

                if (product.AvailableCount == 0)
                {
                    product.IsAvailable = false;
                }

                await _unitOfWork.CartProductRepository.InsertAsync(new CartProductDTO { CartId = cartId, ProductId = productId, Quantity = CartQuantity });
            }


            return _validationDictionary.IsValid;
        }

        protected bool IsValidProduct(ProductDTO product, int orderQuantity, int productId, int orderNumber)
        {
            if (product == null)
            {
                _validationDictionary.AddError($"OrderProduct[{orderNumber}].ProductId", $"შეყვანილი პროდუქტი არ არსებობს!");
            }

            if (product?.AvailableCount < orderQuantity)
            {
                _validationDictionary.AddError($"OrderProduct[{orderNumber}].Quantity", $"შეკვეთილი პროდუქტის რაოდენობა ({orderQuantity}) აღემატება არსებულ მარაგს ({product?.AvailableCount})");
            }

            return _validationDictionary.IsValid;
        }

        public async Task DeleteCart(int id)
        {
            await _unitOfWork.CartRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
