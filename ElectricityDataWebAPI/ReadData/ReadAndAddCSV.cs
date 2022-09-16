using CsvHelper;
using ElectricityDataWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElectricityDataWebAPI.DB;
using Microsoft.Extensions.Logging;

namespace ElectricityDataWebAPI.ReadData
{
    public class ReadAndAddCSV
    {
        public static Directory directoryWorker = new Directory();

        public static void ReadCSV(ElectricityContext context, ILogger _logger)
        {
            _logger.LogInformation("Started reading");
            for (int i = 1; i <= 12; i++)
            {
                try
                {
                    using (var reader = new StreamReader(directoryWorker.savedFilesLocationAndName + i + directoryWorker.savedFileExt)) ///// Edit Directory.cs 
                    {
                        if (reader != null)
                        {
                            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                            {
                                var records = csv.GetRecords<CSVModel>().ToList();
                                AddToDB(context, records, _logger);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                }    
            }
        }
        public static void AddToDB(ElectricityContext dbContext, List<CSVModel> records, ILogger _logger)
        {
            _logger.LogInformation("Adding Data to DB");
            int addedRec = 0;
            foreach (var row in records)
            {
                if (row.Pminus != null)
                {
                    string type = row.OBT_PAVADINIMAS;
                    double? consumption = row.Pplus;
                    double? generated = row.Pminus;
                    double? difference = generated - consumption;
                    if (type == "Namas" && consumption < 1)
                    {
                        dbContext.Data.Add(new DataModel
                        {
                            Area = row.TINKLAS,
                            Type = row.OBT_PAVADINIMAS,
                            IsLiving = row.OBJ_GV_TIPAS,
                            ObjNumber = row.OBJ_NUMERIS,
                            Consumed = row.Pplus,
                            Date = row.PL_T,
                            Generated = row.Pminus,
                            Difference = difference

                        });
                        dbContext.SaveChanges();
                        addedRec += 1;
                    }
                    if (addedRec == 1000)
                    {
                        _logger.LogInformation("File added to DB");
                        break;
                    }
                       
                } 
            }
        }
    }
}
