using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Stereograph.TechnicalTest.Api.Models;

namespace Stereograph.TechnicalTest.Api.Utils;

public class CsvService
{
    public IEnumerable<MPerson> ReadCsv(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

        csv.Context.RegisterClassMap<PersonMap>();
        return csv.GetRecords<MPerson>().ToList();
    }
}