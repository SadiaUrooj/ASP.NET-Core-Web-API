using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    //https://localhost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    //now in this class everything has to be authenticated //controller level
    //[Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext,
            IRegionRepository regionRepository, IMapper mapper,
            ILogger<RegionsController> logger) 
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public NZWalksDbContext DbContext { get; }

        //action method
        //GET: https://localhost:port/api/regions
        //hardecoded
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //    var regions = new List<Region>
            //    {
            //        new Region
            //        {
            //        Id = Guid.NewGuid(),
            //        Name = "Auckland Region",
            //        Code = "AKL",
            //        RegionImageUrl = "ncjvjhcbh"

            //        },
            //        new Region
            //        {
            //        Id = Guid.NewGuid(),
            //        Name = "Wellington Region",
            //        Code = "WLG",
            //        RegionImageUrl = "ncjvjhcbh"

            //        }

            //};

            logger.LogInformation("GetAllRegions Action Method was invoked");


            //using the database

            //Get data from Database - Domain Models
            //because of the await the main thread will not be blocked
            //var regions = await dbContext.Regions.ToListAsync();
            var regions = await regionRepository.GetAllAsync();
            logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regions)}");
            //map domain models to DTOs
            //var regionsDto = new List<RegionDTO>();
            //foreach(var region in regions)
            //{
            //    regionsDto.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl



            //    });
            //}

            //map domain models to DTOs + destination - source
            var regionsDto = mapper.Map<List<RegionDTO>>(regions);
            //return DTO's
            return Ok(regionsDto);
        }

        //Get single region (Get Region By ID)
        //GET: https//localhost:port/api/regions/{id}
        [HttpGet]
       // [Authorize(Roles = "Reader")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //normal way /can only used with the id
            //var region = dbContext.Regions.Find(id);


            //Linque/ can be used for other stuff as well
            // var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            //GET region Domain Model From Database
            //var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            //Async method
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl

            //};
            // return Ok(regionDomain);

            var regionDto = mapper.Map<RegionDTO>(regionDomain);

            //return the DTO back to the client
            return Ok(regionDto);
        }

        //POST to create new region
        //POST: https://localhost:port/api/regions
        [HttpPost]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRequestRegionDto addRequestRegionDto)
        {
            //map or convert the DTO to domain Model
            //var regionDomainModel = new Region
            //{
            //    Code = addRequestRegionDto.Code,
            //    Name = addRequestRegionDto.Name,
            //    RegionImageUrl = addRequestRegionDto.RegionImageUrl
            //};

            //this is the return property that comes with the model state and it returns a boolean saying if this model is valid model or not
            if (ModelState.IsValid)
            {
                var regionDomainModel = mapper.Map<Region>(addRequestRegionDto);

                //Use DOmain model to create region
                //extracting
                //await dbContext.Regions.AddAsync(regionDomainModel);
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
                //saving
                //await dbContext.SaveChangesAsync();

                //map domain modal back to dto
                //var regionDto = new RegionDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }


           
        }

        //Update the region
        //PUT: https://localhost:port/api/regions/{id}
        [HttpPut]
       // [Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if(ModelState.IsValid)
            {
                if (updateRegionRequestDto == null)
                {
                    return BadRequest("UpdateRegionRequestDto cannot be null");
                }
                //Map DTO to Domain Model
                //var regionDomainModel = new Region
                //{
                //    Code = updateRegionRequestDto.Code,
                //    Name = updateRegionRequestDto.Name,
                //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
                //};
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                //checks if region exists
                //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);


                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                //Map DTO to Domain model
                //regionDomainModel.Code = updateRegionRequestDto.Code;
                //regionDomainModel.Name = updateRegionRequestDto.Name;
                //regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

                ////use the domain modal to save the changes
                //await dbContext.SaveChangesAsync();

                //convert Domain Model to DTO
                //var regionDto = new RegionDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                //we dont pass domain models to the client but the dto
                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);
                return Ok(regionDto);


            }
            else
            {
                return BadRequest(ModelState);
            }



        }


        //Delete Region
        //DELETE: https://localhost:port/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
      //  [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel== null)
            {
                return NotFound();
            }
            //Delete region - now it's done in repository
            //dbContext.Regions.Remove(regionDomainModel);
            //await  dbContext.SaveChangesAsync();

            //return deleted region back
            //map Domain Model to DTO
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDto);

        }

    }
}
