using CsvHelper.Configuration;
using Stereograph.TechnicalTest.Api.Models;

namespace Stereograph.TechnicalTest.Api.Utils;

public sealed class PersonMap : ClassMap<MPerson>
{
    public PersonMap()
    {
        Map(p => p.FirstName).Name("first_name"); 
        Map(p => p.LastName).Name("last_name");   
        Map(p => p.Email).Name("email");
        Map(p => p.Address).Name("address");
        Map(p => p.City).Name("city");
    }
}