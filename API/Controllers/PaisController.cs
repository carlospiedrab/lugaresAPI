using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PaisController(ApplicationDbContext db)
        {
            _db = db;
            
        }


        [HttpGet]
        public async Task<ActionResult<List<Pais>>> getPaises()
        {
            var paises = await _db.Pais.ToListAsync();
            return Ok(paises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetProduct(int id)
        {
            return await _db.Pais.FindAsync(id);
        }
    }
}