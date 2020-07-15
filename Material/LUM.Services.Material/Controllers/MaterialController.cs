using System.Net;
using System.Threading.Tasks;
using LUM.Services.Material.Model.Query;
using LUM.Services.Material.Model.Request;
using LUM.Services.Material.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace LUM.Services.Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;


        private readonly ILogger<MaterialController> _logger;

        public MaterialController(ILogger<MaterialController> logger, IMaterialService materialService)
        {
            _logger = logger;
            _materialService = materialService;
        }

        /// <summary>
        /// Returns a material
        /// </summary>
        /// <param name="id">The material id</param>
        /// <returns>Material Response Model</returns>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(object))]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return Ok(await _materialService.GetById(id));
        }


        /// <summary>
        /// Returns list of materials
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Material Response Model</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(object))]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            return Ok(await _materialService.SearchByName(new SearchMaterialByNameQueryModel() { Name = name, OrderBy = "Name" }));
        }


        /// <summary>
        /// Create a new material 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        public async Task<IActionResult> Post([FromBody] CreateMaterialBindingModel requestModel)
        {
            return Ok(await _materialService.AddAsync(requestModel));
        }

        /// <summary>
        /// Deletes a material
        /// </summary>
        /// <param name="id">The id of the material that will be deleted</param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _materialService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Updates a material
        /// </summary>
        /// <param name="bindingModel">update material binding model</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(UpdateMaterialBindingModel bindingModel )
        {
            await _materialService.UpdateAsync(bindingModel);
            return Ok();
        }
    }
}
