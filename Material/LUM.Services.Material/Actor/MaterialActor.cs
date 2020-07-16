using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using AutoMapper;
using LUM.Services.Material.Command;
using LUM.Services.Material.Model.Query;
using LUM.Services.Material.Model.Request;
using LUM.Services.Material.Model.Response;
using LUM.Services.Material.Repository;
using LUM.Services.Material.Type;

namespace LUM.Services.Material.Actor
{

    public class MaterialActor : ReceiveActor
    {
        private readonly MaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialActor(MaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;

            ReceiveAsync<CreateMaterialBindingModel>(async command =>
            {
                Sender.Tell(await _materialRepository.AddAsync(_mapper.Map<Domain.Material>(command)));
            });

            ReceiveAsync<UpdateMaterialBindingModel>(async command =>
            {
                await _materialRepository.UpdateAsync(_mapper.Map<Domain.Material>(command));
                Sender.Tell("Done!");
            });

            ReceiveAsync<DeleteMaterialCommand>(async command =>
            {
                await _materialRepository.DeleteAsync(command.Id);
                Sender.Tell("Done!");
            });

            ReceiveAsync<GetMaterialByIdCommand>(async command =>
            {
                Sender.Tell(_mapper.Map<GetMaterialResponseModel>(await _materialRepository.GetAsync(command.Id)));
            });

            ReceiveAsync<SearchMaterialByNameQueryModel>(async command =>
            {
                var result = await _materialRepository.SearchByNameAsync(command);
                Sender.Tell(PagedResult<GetMaterialResponseModel>
                    .Create(result.data.Select(x => _mapper.Map<GetMaterialResponseModel>(x)).ToList(),
                        command.Page, command.Results,
                        Convert.ToInt32(Math.Ceiling((double) result.statistics.TotalResults / command.Results)),
                        result.statistics.TotalResults));
            });

        }


    }
}
