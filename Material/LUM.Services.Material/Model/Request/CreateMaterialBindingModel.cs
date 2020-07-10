using LUM.Services.Material.Common.Behavior;
using LUM.Services.Material.Common.Enum;
using LUM.Services.Material.Validation;

namespace LUM.Services.Material.Model.Request
{
    public class CreateMaterialBindingModel: BindingModel<CreateMaterialBindingModel, CreateMaterialBindingModelValidator>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public Phase Type { get; set; }
        public string Notes { get; set; }
        public float FunctionMaxTemperature { get; set; }
        public float FunctionMinTemperature { get; set; }
        
    }
}
