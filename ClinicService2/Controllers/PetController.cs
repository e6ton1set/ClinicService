using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase

    {

        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost("add-pet")]
        public IActionResult Create([FromBody] CreatePetRequest createPetRequest)
        {
            Pet pet = new Pet();
            pet.ClientId = createPetRequest.ClientId;
            pet.Name = createPetRequest.Name;
            pet.Birthday = createPetRequest.Birthday;
            return Ok(_petRepository.Create(pet));
        }

        [HttpPut("edit-pet")]
        public IActionResult Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            Pet pet = new Pet();
            pet.PetId = updatePetRequest.PetId;
            pet.ClientId = updatePetRequest.ClientId;
            pet.Name = updatePetRequest.Name;
            pet.Birthday = updatePetRequest.Birthday;
            return Ok(_petRepository.Update(pet));
        }

        [HttpGet("get-all-pets")]
        public IActionResult GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpDelete("delete-pet")]
        public IActionResult Delete([FromQuery] int petId)
        {
            int result = _petRepository.Delete(petId);
            return Ok(result);
        }

        [HttpGet("get/{petId}")]
        public IActionResult GetById([FromRoute] int petId)
        {
            return Ok(_petRepository.GetById(petId));
        }
    }
}
