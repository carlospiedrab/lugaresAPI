using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepository _repo;
        
        public PaisController(IPaisRepository repo)
        {
            _repo = repo;                      
        }


        [HttpGet]
        public async Task<ActionResult<List<Pais>>> getPaises()
        {
            var paises = await _repo.GetPaisAsync();
            return Ok(paises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetProduct(int id)
        {
            return await _repo.GetPaisByIdAsync(id);
        }
    }
}