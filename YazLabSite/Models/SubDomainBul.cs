using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace YazLabSite.Models
{
    public class SubDomainBul
    {
        public List<string> altAlanAdiBul(string gelenUrl)
        {
            List<string> altUrleler = new List<string>();

            WebClient client = new WebClient();
            string url = gelenUrl;
            Uri urlDomain = new Uri(url);

            string aranacak = urlDomain.Host;
            string downloadString="";
            try
            {
                 downloadString = client.DownloadString(url);//parametre olarak gelcek -- HTML olarak content indirilir
            }
            catch
            {
                
            } 
            

            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes); //indirilen HTML utf-8 e çevrildi. Yapılmasa da olur zira ingilizce yaptık sonradan.

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString);

            


            if (htmlDoc.DocumentNode.SelectNodes("//a[@href]") != null)
            {
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//a[@href]"))
                {

                    string hrefValue = node.GetAttributeValue("href", string.Empty);

                    if (hrefValue.Contains(aranacak))
                    {
                        altUrleler.Add(hrefValue);
                        
                    }
                        


                }
            }

            return altUrleler;
        }
    }
}