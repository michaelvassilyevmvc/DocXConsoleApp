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
            List<Competition> result = new List<Competition>();
            using (var doc = WordprocessingDocument.Open(@"C:\Users\FAMILY\Documents\Результ.docx", false))
            {
                
                Table table = doc.MainDocumentPart.Document.Body.Elements<Table>().First();

                IEnumerable<TableRow> rows = table.Elements<TableRow>();


                foreach (TableRow row in rows)
                {
                    List<TableCell> cells = row.Descendants<TableCell>().ToList();
                    Competition competition = new Competition
                    {
                        Name =          cells[0].InnerText,
                        DateAndPlace =  cells[1].InnerText,
                        Organization =  cells[2].InnerText,
                        Count =         cells[3].InnerText,
                        AthleteCount =  cells[4].InnerText,
                        TrainerCount =  cells[5].InnerText,
                        JudgesCount =   cells[6].InnerText,
                        OrganizerFirm = cells[7].InnerText,
                        SendFirm =      cells[8].InnerText
                    };

                    result.Add(competition);
                }

                var tmp = result;

                
            }
        }
    }
}
