using AutoMapper;
using INDWalks.API.Model.Domain;
using INDWalks.API.Model.DTO;
using INDWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        public IWalksRepository walksRepository;
        public IMapper mapper;
        public WalksController(IWalksRepository walksRepository,IMapper mapper)
        {
            this.walksRepository = walksRepository;
            this.mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy = null, [FromQuery] bool? IsAccending=true,[FromQuery] int pageNumber=1, [FromQuery] int pageSize=10)
        {
            var walkDomian = await walksRepository.GetAllAsync(filterOn,filterQuery,sortBy,IsAccending ?? true,pageNumber,pageSize);

            var walkDto = mapper.Map<List<WalksDto>>(walkDomian);

            return Ok(walkDto);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var walkDomain = await walksRepository.GetByIdAsync(id);
            if(walkDomain == null)
            {
                return BadRequest();
            }
            var walkDto = mapper.Map<WalksDto>(walkDomain);

            return Ok(walkDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddWalksDto addWalksDto)
        {
            if(ModelState.IsValid)
            {
                var walkDomain = mapper.Map<Walks>(addWalksDto);
                walkDomain = await walksRepository.createAsync(walkDomain);

                var walkDto = mapper.Map<WalksDto>(walkDomain);

                return Ok(walkDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateWalkDto updateWalkDto)
        {
            if (ModelState.IsValid)
            {
                var walkDomain = mapper.Map<Walks>(updateWalkDto);

                walkDomain = await walksRepository.updateAsync(id, walkDomain);

                var walkDto = mapper.Map<WalksDto>(walkDomain);

                return Ok(walkDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var walkDomain = await walksRepository.DeleteAsync(id);

            var walkDto = mapper.Map<WalksDto>(walkDomain);

            return Ok(walkDto);
        }


    }
}
