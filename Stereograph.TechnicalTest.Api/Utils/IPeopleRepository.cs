using System.Collections.Generic;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Models;

namespace Stereograph.TechnicalTest.Api.Utils;

public interface IPeopleRepository
{
    List<EPerson> Get(string firstName, string lastName, string email, string address, string city);
    EPerson GetById(int id);
    void Insert(MPerson newPerson);
    void Update(EPerson person, MPerson personInfo);
    void Delete(EPerson person);
    void DeleteAll();
    void Save();
}