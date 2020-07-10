using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace LUM.Services.Material.Common.Behavior
{
    public abstract class BindingModel<TModel, TValidator> where TModel : class
        where TValidator : AbstractValidator<TModel>
    {
        public ValidationResult Validate(TModel instance)
        {
            var errorMessage = "";
            var validatorResult = ((AbstractValidator<TModel>)Activator.CreateInstance(typeof(TValidator))).Validate(instance);
            if (!validatorResult.IsValid)
            {
                validatorResult.Errors.ToList().ForEach(x => errorMessage = $"{errorMessage} /n {x.ErrorMessage}");
                throw new ArgumentException(errorMessage);
            }
            return validatorResult;
        }

    }
}
