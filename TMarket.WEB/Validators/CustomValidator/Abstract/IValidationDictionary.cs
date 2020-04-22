
using TMarket.WEB.Services.Abstract;

namespace TMarket.WEB.Validators.CustomValidator.Abstract
{
    public interface IValidationDictionary : IService
    {
        void AddError(string Key, string ErrorMessage);
        bool IsValid { get; }
    }
}
