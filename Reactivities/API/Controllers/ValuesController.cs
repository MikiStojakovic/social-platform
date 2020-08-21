using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class ValuesController : ControllerBase
 {
  private readonly DataContext _context;

  public ValuesController(DataContext context)
  {
   _context = context;

  }
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Value>>> Get()
  {
   var result = await _context.Values.ToListAsync();
   return Ok(result);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Value>> Get(int id)
  {
   var result = await _context.Values.FindAsync(id);
   return Ok(result);
  }

 }
}