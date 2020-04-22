using Microsoft.AspNetCore.Mvc.Infrastructure;
using TMarket.WEB.Validators.CustomValidator.Abstract;

namespace TMarket.WEB.Validators.CustomValidator.Concrete
{
    public class ModelStateWrapper : IValidationDictionary
    {
        private readonly IActionContextAccessor _actionContextAccessor;

        public ModelStateWrapper(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
        }

        public void AddError(string key, string errorMessage)
        {
            var actionContext = _actionContextAccessor.ActionContext;

            actionContext.ModelState.AddModelError(key, errorMessage);
        }

        public bool IsValid
        {
            get { return _actionContextAccessor.ActionContext.ModelState.IsValid; }
        }
    }
}
