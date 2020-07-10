using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LUM.Services.Material.Model.Request;

namespace LUM.Services.Material.Validation
{
    public class CreateMaterialBindingModelValidator : AbstractValidator<CreateMaterialBindingModel>
    {
        public CreateMaterialBindingModelValidator()
        {
            RuleFor(x => x.FunctionMinTemperature).GreaterThanOrEqualTo(4).LessThanOrEqualTo(80);
            RuleFor(x => x.FunctionMaxTemperature).GreaterThanOrEqualTo(4).LessThanOrEqualTo(80);
        }
    }
}
