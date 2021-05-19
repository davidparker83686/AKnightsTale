using System;
using System.Collections.Generic;
using AKnightsTale.Models;
using AKnightsTale.Services;
using Microsoft.AspNetCore.Mvc;

namespace AKnightsTale.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class Castle : ControllerBase
  {
    private readonly CastlesService _service;

    public CastlesController(CastlesService services)
    {
      _service = services;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Castle>> GetAll()
    {
      try
      {
        IEnumerable<Castle> castles = _service.GetAll();
        return Ok(castles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Castle> GetById(int id)
    {
      try
      {
        Castle castle = _service.GetById(id);
        return Ok(castle);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Castle> Create([FromBody] Castle newCastle)
    {
      try
      {
        Castle castle = _service.Create(newCastle);
        return Ok(castle);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{Id}")]
    public ActionResult<Castle> Update(int id, [FromBody] Castle update)
    {
      try
      {
        update.Id = id;
        Castle updated = _service.Update(update);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> DeleteCastle(int id)
    {
      try
      {
        _service.DeleteCastle(id);
        return Ok("Delorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}
