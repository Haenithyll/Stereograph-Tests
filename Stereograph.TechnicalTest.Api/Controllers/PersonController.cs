using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Models;
using Stereograph.TechnicalTest.Api.Utils;

namespace Stereograph.TechnicalTest.Api.Controllers;

[Route("api/people")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPeopleRepository _peopleRepository;
    
    public PersonController(IPeopleRepository repository)
    {
        _peopleRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EPerson>> GetPeople(
        [FromQuery] int? id, 
        [FromQuery] string firstName, 
        [FromQuery] string lastName,
        [FromQuery] string email,
        [FromQuery] string address,
        [FromQuery] string city)
    {
        if (id != null)
            return GetPersonById((int)id);

        var people = _peopleRepository.Get(firstName,lastName,email,address,city);
        
        return people.Count == 0 ? NotFound("No result matches the parameters") : Ok(people);
    }
    
    [HttpGet("id")]
    public ActionResult<IEnumerable<Entities.EPerson>> GetPersonById([FromQuery] int id)
    {
        if (id <= 0)
            return BadRequest("The provided id must be greater than 0");
        
        var person = _peopleRepository.GetById(id);

        return person == null ? NotFound($"Person with id : {id} not found") : Ok(person);
    }
    
    [HttpPost("create")]
    public IActionResult CreateNewPerson([FromBody] MPerson newPerson)
    {
        _peopleRepository.Insert(newPerson);
        _peopleRepository.Save();
        
        return Ok("New person created successfully.");
    }

    [HttpPut("update")]
    public IActionResult UpdatePerson([FromQuery] int id, [FromBody] MPerson newPersonInfo)
    {
        var person = _peopleRepository.GetById(id);

        if (person == null)
            return NotFound($"Person with id : {id} not found");

        _peopleRepository.Update(person, newPersonInfo);
        _peopleRepository.Save();

        return Ok($"Person with id : {id} updated successfully.");
    }

    [HttpDelete("delete")]
    public IActionResult DeletePerson([FromQuery] int id)
    {
        var person = _peopleRepository.GetById(id);

        if (person == null)
            return NotFound($"Person with id : {id} not found");

        _peopleRepository.Delete(person);
        _peopleRepository.Save();

        return Ok($"Person with id : {id} deleted successfully.");
    }

    [HttpDelete("delete/all")]
    public IActionResult DeleteAllPeople()
    {
        _peopleRepository.DeleteAll();
        _peopleRepository.Save();

        return Ok("People cleared successfully.");
    }
}
