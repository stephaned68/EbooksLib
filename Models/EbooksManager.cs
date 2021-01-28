using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace EbooksLib.Models
{
    class EbooksManager
    {
        public static List<Ebooks> GetAll()
        {
            List<Ebooks> ebooksList;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = (string header, int index) => header.ToLower(),
            };
            using (var reader = new StreamReader("ebooks.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                ebooksList = csv.GetRecords<Ebooks>().ToList();
            }
            return ebooksList;
        }
    }
}
