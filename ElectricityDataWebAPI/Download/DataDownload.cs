using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityDataWebAPI.Download
{
    public class DataDownload
    {
        private static readonly Directory directoryWorker = new Directory();
        public static void Download(ILogger logger)
        {
            logger.LogInformation("Download started");
            int matchedFiles = 0;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load($"https://data.gov.lt/dataset/siame-duomenu-rinkinyje-pateikiami-atsitiktinai-parinktu-1000-buitiniu-vartotoju-automatizuotos-apskaitos-elektriniu-valandiniai-duomenys");
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a").Reverse())
            {
                string hrefValue = link.GetAttributeValue("href", string.Empty);
                int currentMonth = DateTime.Now.Month;
                
                if (hrefValue.Contains("download") && hrefValue.Contains(DateTime.Now.Year.ToString()))
                {
                    for (int i = currentMonth; i >= 1; i--)
                    {
                        if (hrefValue.EndsWith(".csv") && (hrefValue.Contains("2022-0" + i) || hrefValue.Contains("2022-" + i)))
                        {
                            matchedFiles += 1;
                            new System.Net.WebClient().DownloadFile("https://data.gov.lt" + hrefValue, directoryWorker.savedFilesLocationAndName + i + directoryWorker.savedFileExt); ///// Edit Directory.cs 
                            logger.LogInformation("File downloaded");
                        }
                        else
                            logger.LogInformation("File not found");
                    }
                }
                if (matchedFiles == 2)
                {
                    logger.LogInformation(matchedFiles.ToString() + "Files downloaded");
                    break;
                }
                    
            }
        }
    }
}
