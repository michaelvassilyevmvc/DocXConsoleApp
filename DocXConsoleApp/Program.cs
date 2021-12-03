using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.Linq;
using DocXConsoleApp.Models;

namespace DocXConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string pathBigData = @"C:\Users\FAMILY\Downloads\BigData.docx";
            string pathSmallData = @"C:\Users\FAMILY\Documents\Результ.docx";

            List<Competition> result = new List<Competition>();
            using (var doc = WordprocessingDocument.Open(pathBigData, false))
            {

                List<Table> tables = doc.MainDocumentPart.Document.Body.Elements<Table>().ToList();
                List<string> chapters = new List<string>();

                //Table table = doc.MainDocumentPart.Document.Body.Elements<Table>().First();

                foreach (Table table in tables)
                {
                    IEnumerable<TableRow> rows = table.Elements<TableRow>();
                    string chapterName = string.Empty;

                    foreach (TableRow row in rows)
                    {
                        List<TableCell> cells = row.Descendants<TableCell>().ToList();
                        if (cells.Count() == 1) { 
                            chapterName = cells.FirstOrDefault().InnerText;
                            chapters.Add(chapterName);
                        }

                        if (cells.Count() < 9) continue;

                        Competition competition = new Competition
                        {
                            Name = cells[0].InnerText,
                            DateAndPlace = cells[1].InnerText,
                            Organization = cells[2].InnerText,
                            Count = cells[3].InnerText,
                            AthleteCount = cells[4].InnerText,
                            TrainerCount = cells[5].InnerText,
                            JudgesCount = cells[6].InnerText,
                            OrganizerFirm = cells[7].InnerText,
                            SendFirm = cells[8].InnerText,
                            Chapter = chapterName
                        };

                        result.Add(competition);
                    }

                    var tmp = chapters;
                }

                


                

                
            }
        }
    }
}
