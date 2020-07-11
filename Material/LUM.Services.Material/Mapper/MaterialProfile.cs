using AutoMapper;
using LUM.Services.Material.Domain;
using LUM.Services.Material.Model.Request;
using LUM.Services.Material.Model.Response;

namespace LUM.Services.Material.Mapper
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<CreateMaterialBindingModel, Domain.Material>()
                .ForMember(dest => dest.Function,
                    opt => opt.MapFrom(src => new Function
                    { MaxTemperature = new Temperature() { Celsius = src.FunctionMaxTemperature }, MinTemperature = new Temperature() { Celsius = src.FunctionMinTemperature } }));

            CreateMap<Domain.Material, GetMaterialResponseModel>()
                .ForMember(des => des.FunctionMaxTemperature, opt => opt.MapFrom(src => src.Function.MaxTemperature.Celsius))
                .ForMember(des => des.FunctionMinTemperature, opt => opt.MapFrom(src => src.Function.MinTemperature.Celsius))
                ;

            CreateMap<CreateMaterialBindingModel, UpdateMaterialBindingModel>();
            CreateMap<GetMaterialResponseModel, UpdateMaterialBindingModel>();

            CreateMap<UpdateMaterialBindingModel, Domain.Material>()
                .ForMember(dest => dest.Function,
                    opt => opt.MapFrom(src => new Function
                        { MaxTemperature = new Temperature() { Celsius = src.FunctionMaxTemperature }, MinTemperature = new Temperature() { Celsius = src.FunctionMinTemperature } }));

        }
    }
}