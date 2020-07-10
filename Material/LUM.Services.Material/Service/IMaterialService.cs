using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LUM.Services.Material.Model.Query;
using LUM.Services.Material.Model.Request;
using LUM.Services.Material.Model.Response;
using LUM.Services.Material.Type;

namespace LUM.Services.Material.Service
{
    public interface IMaterialService
    {
        Task<string> AddAsync(CreateMaterialBindingModel requestModel);
        Task DeleteAsync(string id);
        Task<GetMaterialResponseModel> GetById(string id);
        Task<List<GetMaterialResponseModel>> GetByPredicate(Expression<Func<Domain.Material, bool>> predicate);
        Task<PagedResult<GetMaterialResponseModel>> SearchByName(SearchMaterialByNameQueryModel query);
        Task UpdateAsync(UpdateMaterialBindingModel material);
    }
}