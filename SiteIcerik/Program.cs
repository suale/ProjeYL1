using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using StopWord;
using NetSpell.SpellChecker.Dictionary;
using System.Linq;

namespace SiteIcerik
{
    class Program
    {
        static void Main(string[] args)
        {


            WebClient client = new WebClient();
            string url = "https://tr.wikipedia.org/wiki/Anasayfa";

            Uri urlDomain = new Uri(url);
            Console.WriteLine("Domain part : " + urlDomain.Host); //Domain ayrıştırır

            string aranacak = urlDomain.Host;
            Console.WriteLine("Aranacak------------>"+aranacak);

            string downloadString = client.DownloadString(url);//parametre olarak gelcek -- HTML olarak content indirilir

            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes); //indirilen HTML utf-8 e çevrildi. Yapılmasa da olur zira ingilizce yaptık sonradan.

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString); //Oluşturulan HtmlDocument tipindeki veriye indirilen html içeriği atanır.

            int cumleSayisi=0; //TF-IDF hesaplamaları için  cümle sayılarının tutulacağı değişken.

            var stopWords = StopWords.GetStopWords("en"); // Metin işlenirken yararı olmayacak kelimelerin ayıklanması adına ingilizce stopwordsun ilgili değişkene atanması.
            
            List<string> kelimeler = new List<string>();

            if (htmlDoc.DocumentNode.SelectNodes("//a[@href]") != null)
            {
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//a[@href]"))
                {

                    string hrefValue = node.GetAttributeValue("href", string.Empty);

                    if (hrefValue.Contains(aranacak))
                        Console.WriteLine(hrefValue);


                }
            }


            //HtmlIsleyici htmlIsleyici1 = new HtmlIsleyici();
            //htmlIsleyici1.htmlIsle(htmlDoc);
            //kelimeler = htmlIsleyici1.kelimeler;
            //cumleSayisi = htmlIsleyici1.cumleSayisi;


            
            //KelimeDuzeltici kelimeDuzeltici1 = new KelimeDuzeltici();
            //kelimeler=kelimeDuzeltici1.kelimeDuzelt(kelimeler, urlDomain);
         
           

            //List<WordAndFreq> kelimeFrekans = new List<WordAndFreq>();
            
            //KelimeFrekansYapici kelimeFrekansYapici1 = new KelimeFrekansYapici();
            //kelimeFrekans=kelimeFrekansYapici1.KelimeFrekansYap(kelimeler);
           

            
            //Console.WriteLine("Kelimeler son "+kelimeler.Count);
         
            //Console.WriteLine("Cümle sayısı: " + cumleSayisi);

        

          

            
            //Console.WriteLine("--------------=======================SIRALI===================----------------------");

            //foreach (var item in kelimeFrekans)
            //{
            //    Console.WriteLine(item.Word + " " + item.Frequency);
            //}

            //TfIdfCalculator agirlikHesap = new TfIdfCalculator();

            //List<WordAndWeight> weihtedKelimeler = new List<WordAndWeight>();

            //AgirlikliKelimeListesi agirlikliKelimeListesi1 = new AgirlikliKelimeListesi();

            //weihtedKelimeler = agirlikliKelimeListesi1.AgirlikliListeYap(kelimeFrekans, kelimeler.Count, cumleSayisi);



            //Console.WriteLine("Agirliklar belli oldu-------------------------------");

            //foreach (var item in weihtedKelimeler)
            //{
            //    Console.WriteLine(item.Word+"---------------"+item.Weight);
            //}
            //Console.WriteLine("??????????????????????????ANAHTAR KELİMELER???????????????????????????????");
            //AnahtarKelimeBelirleyici anahtarKelimeBelirleyici1 = new AnahtarKelimeBelirleyici();
            //List<WordAndFreq> anahtarKelimeler = new List<WordAndFreq>();
            //anahtarKelimeler = anahtarKelimeBelirleyici1.AnahtarKelimeBelirle(weihtedKelimeler, kelimeFrekans);
            //foreach (var item in anahtarKelimeler)
            //{
            //    Console.WriteLine(item.Word+ " ----- "+ item.Frequency);
            //}

            Console.ReadLine();
        }
    }
}
