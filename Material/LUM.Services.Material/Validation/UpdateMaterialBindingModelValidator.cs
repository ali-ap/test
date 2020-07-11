using FluentValidation;
using LUM.Services.Material.Model.Request;

namespace LUM.Services.Material.Validation
{
    public class UpdateMaterialBindingModelValidator : AbstractValidator<UpdateMaterialBindingModel>
    {
        public UpdateMaterialBindingModelValidator()
        {
            RuleFor(x => x.FunctionMinTemperature).GreaterThanOrEqualTo(4).LessThanOrEqualTo(80).Must((model, field) => field < model.FunctionMaxTemperature);
            RuleFor(x => x.FunctionMaxTemperature).GreaterThanOrEqualTo(4).LessThanOrEqualTo(80).Must((model, field) => field >= model.FunctionMinTemperature); ;
        }
    }
}