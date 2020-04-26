using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TMarket.Application.Services.Abstract;
using TMarket.Persistence.DbModels;
using TMarket.WEB.Commands.CategoryCommands;
using TMarket.WEB.RequestModels;

namespace TMarket.WEB.Handlers.CommandHandlers.CategoryHandler
{
    public class UpdateCategoryHandler : IRequestHandler<CategoryUpdateCommand, CategoryRespond>
    {
        private readonly IBaseService<CategoryDTO> _categoryService;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IBaseService<CategoryDTO> categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryRespond> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllAsyncWithNoTracking();
            if (!categories.Any(x => x.Id == request.Id))
            {
                return null;
            }

            var category = MapUser(request);
            var updatedCategory = await _categoryService.UpdateAsync(category);
            return _mapper.Map<CategoryRespond>(updatedCategory);
        }

        private CategoryDTO MapUser(CategoryUpdateCommand request)
        {
            return new CategoryDTO()
            {
                Id = request.Id,
                Name = request.Command.Name
            };
        }
    }
}
