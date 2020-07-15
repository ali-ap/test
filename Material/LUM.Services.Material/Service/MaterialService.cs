using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LUM.Services.Material.Common.Behavior;
using LUM.Services.Material.Model.Query;
using LUM.Services.Material.Model.Request;
using LUM.Services.Material.Model.Response;
using LUM.Services.Material.Repository;
using LUM.Services.Material.Type;

namespace LUM.Services.Material.Service
{
    public class MaterialService : IMaterialService
    {
        private readonly MaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialService(MaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        [BindingModelValidation]
        public Task<string> AddAsync(CreateMaterialBindingModel requestModel)
        {
            return _materialRepository.AddAsync(_mapper.Map<Domain.Material>(requestModel));
        }

        public Task DeleteAsync(string id)
        {
            return _materialRepository.DeleteAsync(id);
        }

        public async Task<GetMaterialResponseModel> GetById(string id)
        {
            return _mapper.Map<GetMaterialResponseModel>(await _materialRepository.GetAsync(id));
        }

        public async Task<List<GetMaterialResponseModel>> GetByPredicate(Expression<Func<Domain.Material, bool>> predicate)
        {
            return (await _materialRepository.FindAsync(predicate))
                .Select(x => _mapper.Map<GetMaterialResponseModel>(x)).ToList();
        }

        public async Task<PagedResult<GetMaterialResponseModel>> SearchByName(SearchMaterialByNameQueryModel query)
        {
            var result = await _materialRepository.SearchByNameAsync(query);
            return PagedResult<GetMaterialResponseModel>
                .Create(result.data.Select(x => _mapper.Map<GetMaterialResponseModel>(x)).ToList(),
                    query.Page, query.Results,
                    Convert.ToInt32(Math.Ceiling((double)result.statistics.TotalResults / query.Results)),
                    result.statistics.TotalResults);
        }
        [BindingModelValidation]
        public Task UpdateAsync(UpdateMaterialBindingModel bindingModel)
        {
            return _materialRepository.UpdateAsync(_mapper.Map<Domain.Material>(bindingModel));
        }


    }
}

