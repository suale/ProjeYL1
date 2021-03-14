using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;


namespace SiteIcerik
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.OutputEncoding = Encoding.GetEncoding("iso-8859-9");
            //Console.InputEncoding = Encoding.GetEncoding("iso-8859-9");
            WebClient client = new WebClient();
            
            string downloadString = client.DownloadString("https://www.stackoverflow.com");//url buraya parametre olarak gelcek 
            //Console.WriteLine(downloadString);
            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString);
            Console.WriteLine(htmlDoc);

            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//body//text()"))
            {
                if (!string.IsNullOrEmpty(node.InnerText)&&!string.IsNullOrWhiteSpace(node.InnerText))
                    Console.WriteLine("text=" + node.InnerText);

            }

            //var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

            //Console.WriteLine(htmlBody.OuterHtml);


            //var html = @"https://www.eksisozluk.com";//url buraya parametre olarak gelcek 
            //Console.WriteLine(downloadString);
            //HtmlWeb web = new HtmlWeb();
            //var htmlDoc = web.Load(html);
            //var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);
            //Console.ReadLine();

            Console.ReadLine();
        }
    }
}
