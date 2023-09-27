using System.Collections.Generic;
using System.Linq;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Models;

namespace Stereograph.TechnicalTest.Api.Utils;

public class EfPeopleRepository : IPeopleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EfPeopleRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public List<EPerson> Get(string firstName, string lastName, string email, string address, string city)
    {
        var query = _dbContext.People.Where(p => p.FirstName.Contains(firstName ?? "")
                                                 && p.LastName.Contains(lastName ?? "")
                                                 && p.Email.Contains(email ?? "")
                                                 && p.Address.Contains(address ?? "")
                                                 && p.City.Contains(city ?? ""));
        var people = query.ToList();

        return people;
    }

    public EPerson GetById(int id)
    {
        var query = _dbContext.People.Where(p => p.Id == id);
        var person = query.SingleOrDefault();

        return person;
    }


    public void Insert(MPerson newPersonInfo)
    {
        _dbContext.People.Add(new EPerson()
        {
            FirstName = newPersonInfo.FirstName,
            LastName = newPersonInfo.LastName,
            Email = newPersonInfo.Email,
            Address = newPersonInfo.Address,
            City = newPersonInfo.City,
        });
    }

    public void Update(EPerson person, MPerson personInfo)
    {
        person.FirstName = personInfo.FirstName;
        person.LastName = personInfo.LastName;
        person.Email = personInfo.Email;
        person.Address = personInfo.Address;
        person.City = personInfo.City;
    }

    public void Delete(EPerson person)
    {
        _dbContext.People.Remove(person);
    }

    public void DeleteAll()
    {
        var allPeople = _dbContext.People.ToList();
        _dbContext.RemoveRange(allPeople);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}