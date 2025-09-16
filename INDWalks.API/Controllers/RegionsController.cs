using AutoMapper;
using INDWalks.API.Data;
using INDWalks.API.Model.Domain;
using INDWalks.API.Model.DTO;
using INDWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace INDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        public IRegionRepository regionRepository;
        public IMapper mapper;
        public RegionsController(IRegionRepository dbContext,IMapper mapper) {
        this.regionRepository = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions= await regionRepository.GetAllAsync();

            var regionDto=mapper.Map<List<RegionDto>>(regions);


            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            

            if(regionDomain == null)
            {
                return BadRequest();
            }
            var regionDto = mapper.Map<Regions>(regionDomain);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionsDto addRegionsDto)
        {
            if(ModelState.IsValid)
            {
                var regionDomain = mapper.Map<Regions>(addRegionsDto);


                regionDomain = await regionRepository.CreateAsync(regionDomain);

                var regionDto = mapper.Map<RegionDto>(regionDomain);
                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            

            
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            if(ModelState.IsValid)
            {
                var regionDomain = mapper.Map<Regions>(updateRegionDto);

                regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

                if (regionDomain == null)
                {
                    return BadRequest();
                }
                var regionDto = mapper.Map<Regions>(regionDomain);
                return Ok(regionDto);
            }
            else
            {
                return NotFound(ModelState);
            }
            
        }

        [HttpDelete]

        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
           var regionDomain = await regionRepository.DeleteAsync(id);
            if (regionDomain == null)
            {
                return BadRequest();
            }
            var regionDto = mapper.Map<Regions> (regionDomain);
            return Ok(regionDto);
        }

        
    }
}
