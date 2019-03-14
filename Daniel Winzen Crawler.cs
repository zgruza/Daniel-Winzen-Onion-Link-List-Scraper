using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace OnionParser
{
    class Program
    {
        static void Main(string[] args)
        {

            char m = '"';
            int links = 0;
            var url = "https://onions.danwin1210.me/onions.php?cat=19&pg=0&lang=en";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var dateq = false;

            int table_column = 0;

            string onion = string.Empty;
            string description = string.Empty;

                ///////////////
                foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                Console.WriteLine("Crawling onions & descriptions from Daniel Winzen Links List" + table.Id);
                foreach (HtmlNode row in table.SelectNodes("//tr[@class='up']"))
                {
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        DateTime result;

                        if (DateTime.TryParse(cell.InnerText, out result))
                        {
                            dateq = true;
                        } else { dateq = false; }



                        using (System.IO.StreamWriter file = File.AppendText("Onions.txt")) {
                            if (table_column == 6)
                            {
                                table_column = 0;
                            }
                            if (table_column == 5)
                            {
                                table_column = 6;
                            }
                            if (table_column == 4)
                            {
                                table_column = 5;
                            }
                            if (table_column == 3)
                            {
                                table_column = 4;
                            }
                            if (table_column == 2)
                            {
                                table_column = 3;
                            }




                            // Description
                            if (table_column == 1 && !cell.InnerText.Contains("<") && dateq == false)
                            {
                                links++;
                                //file.Write(" - " + cell.InnerText + Environment.NewLine);
                                description = System.Uri.EscapeDataString(cell.InnerText); // << URL Encryption for .PHP
                                table_column = 2;
                            }

                            // Onion
                            if (table_column == 0 && !cell.InnerText.Contains("<") && dateq == false)
                                    {
                                // file.Write("(cell.InnerText);
                                onion = cell.InnerText;  
                                            Console.WriteLine(cell.InnerText);
                                table_column = 1;
                                     }

                        if (onion != string.Empty && description != string.Empty)
                            {
                                // Put into SQL Database
                                WebClient put_data = new WebClient();
                                string url_put = "https://domain.com/put_onion.php?onion="+onion+"&des="+description;
                                byte[] html = put_data.DownloadData(url_put);
                                UTF8Encoding utf = new UTF8Encoding();
                                string done_check = utf.GetString(html);

                                onion = string.Empty;
                                description = string.Empty;
                            }
                        }

                    }
                    
                }
                Console.WriteLine("LINKS: | {0} |", links);
            }

            // table.ForEach(i => Console.Write("{0}\t", i));
            System.Threading.Thread.Sleep(60000);
        }
    }
}
