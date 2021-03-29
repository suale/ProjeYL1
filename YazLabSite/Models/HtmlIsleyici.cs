using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace YazLabSite.Models
{
    class HtmlIsleyici
    {

        public int cumleSayisi = 0;
        public  List<string> kelimeler = new List<string>();

        public void htmlIsle(HtmlDocument htmlDoc)
        {
            if (htmlDoc.DocumentNode.SelectNodes("//p") != null)
            {

                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//p"))
                {
                    string[] cumleler = node.InnerText.Split('.');
                    int toplamCumle = cumleler.Length;

                    cumleSayisi = cumleSayisi + toplamCumle;

                    string[] cumleKelime = node.InnerText.Split(' ');
                    foreach (var item in cumleKelime)
                    {
                        if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                        {

                            kelimeler.Add(item.ToLower());

                        }
                    }
                }
            }

            var xpath = "//*[self::h1 or self::h2 or self::h3 or self::h4 or self::h5 or self::h6]";

            if (htmlDoc.DocumentNode.SelectNodes(xpath) != null)
            {
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes(xpath))
                {

                    cumleSayisi++;

                    string[] cumleKelime = node.InnerText.Split(' ');
                    foreach (var item in cumleKelime)
                    {
                        if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                        {
                            kelimeler.Add(item.ToLower());
                        }


                    }

                }
            }



            if (htmlDoc.DocumentNode.SelectNodes("//title") != null)
            {
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//title"))
                {

                    cumleSayisi++;
                    string[] cumleKelime = node.InnerText.Split(' ');
                    foreach (var item in cumleKelime)
                    {
                        if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                        {
                            kelimeler.Add(item.ToLower());
                        }


                    }

                }
            }

            if (htmlDoc.DocumentNode.SelectNodes("//meta") != null)
            {
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//meta"))
                {
                    cumleSayisi++;
                    string icerik = node.GetAttributeValue("content", "");
                    string[] cumleKelime = icerik.Split(' ');

                    foreach (var item in cumleKelime)
                    {
                        if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                        {

                            kelimeler.Add(item.ToLower());

                        }


                    }

                }
            }



            if (htmlDoc.DocumentNode.SelectNodes("//img") != null)
            {
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//img"))
                {
                    cumleSayisi++;
                    string icerik = node.GetAttributeValue("alt", "");
                    string[] cumleKelime = icerik.Split(' ');

                    foreach (var item in cumleKelime)
                    {
                        if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                        {

                            kelimeler.Add(item.ToLower());

                        }


                    }

                }
            }





           
        }


    }
}
