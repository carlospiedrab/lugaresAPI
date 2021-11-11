using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugarController : ControllerBase
    {
        private readonly ILugarRepository _repo;
        public LugarController(ILugarRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> getLugares()
        {
            var lugares = await _repo.GetLugarAsync();
            return Ok(lugares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {
            return await _repo.GetLugarByIdAsync(id);
        }


    }
}