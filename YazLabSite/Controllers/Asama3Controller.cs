using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLabSite.Models;
using YazLabSite.ViewModels;
using HtmlAgilityPack;
using StopWord;
using System.Net;
using System.Text;

namespace YazLabSite.Controllers
{
    public class Asama3Controller : Controller
    {

        [Route("Asama3/Index")]
        [HttpGet]
        public ActionResult Index(string gelenUrl)
        {
            WebClient client = new WebClient();
            string url = gelenUrl;

            Uri urlDomain = new Uri(url);


            string downloadString = client.DownloadString(url);//parametre olarak gelcek -- HTML olarak content indirilir

            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes); //indirilen HTML utf-8 e çevrildi. Yapılmasa da olur zira ingilizce yaptık sonradan.

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString); //Oluşturulan HtmlDocument tipindeki veriye indirilen html içeriği atanır.

            int cumleSayisi = 0; //TF-IDF hesaplamaları için  cümle sayılarının tutulacağı değişken.

            var stopWords = StopWords.GetStopWords("en"); // Metin işlenirken yararı olmayacak kelimelerin ayıklanması adına ingilizce stopwordsun ilgili değişkene atanması.

            List<string> kelimeler = new List<string>();

            HtmlIsleyici htmlIsleyici1 = new HtmlIsleyici();
            htmlIsleyici1.htmlIsle(htmlDoc);
            kelimeler = htmlIsleyici1.kelimeler;
            cumleSayisi = htmlIsleyici1.cumleSayisi;

            KelimeDuzeltici kelimeDuzeltici1 = new KelimeDuzeltici();
            kelimeler = kelimeDuzeltici1.kelimeDuzelt(kelimeler, urlDomain);

            List<WordAndFreq> kelimeFrekans = new List<WordAndFreq>();

            KelimeFrekansYapici kelimeFrekansYapici1 = new KelimeFrekansYapici();
            kelimeFrekans = kelimeFrekansYapici1.KelimeFrekansYap(kelimeler);


            TfIdfCalculator agirlikHesap = new TfIdfCalculator();

            List<WordAndWeight> weihtedKelimeler = new List<WordAndWeight>();

            AgirlikliKelimeListesi agirlikliKelimeListesi1 = new AgirlikliKelimeListesi();

            weihtedKelimeler = agirlikliKelimeListesi1.AgirlikliListeYap(kelimeFrekans, kelimeler.Count, cumleSayisi);

            AnahtarKelimeBelirleyici anahtarKelimeBelirleyici1 = new AnahtarKelimeBelirleyici();
            List<WordAndFreq> anahtarKelimeler = new List<WordAndFreq>();
            anahtarKelimeler = anahtarKelimeBelirleyici1.AnahtarKelimeBelirle(weihtedKelimeler, kelimeFrekans);

            Asama3ViewModel asama3ViewModel = new Asama3ViewModel();

            asama3ViewModel.KeywordListesi = anahtarKelimeler;
            asama3ViewModel.Url = gelenUrl;


            return View(asama3ViewModel);
        }

        [Route("Asama3/Index/")]

        [HttpPost]
        public ActionResult Index(string gelenUrl, string gelenUrl2)
        {
            WebClient client = new WebClient();
            string url = gelenUrl;
            string url2 = gelenUrl2;

            Uri urlDomain = new Uri(url);
            Uri urlDomain2 = new Uri(url2);

            string downloadString = client.DownloadString(url);//parametre olarak gelcek -- HTML olarak content indirilir
            string downloadString2 = client.DownloadString(url2);


            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes); //indirilen HTML utf-8 e çevrildi. Yapılmasa da olur zira ingilizce yaptık sonradan.
            byte[] bytes2 = Encoding.Default.GetBytes(downloadString2);
            downloadString2 = Encoding.UTF8.GetString(bytes2);


            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString); //Oluşturulan HtmlDocument tipindeki veriye indirilen html içeriği atanır.
            var htmlDoc2 = new HtmlDocument();
            htmlDoc2.LoadHtml(downloadString2);

            int cumleSayisi = 0; //TF-IDF hesaplamaları için  cümle sayılarının tutulacağı değişken.
            int cumleSayisi2 = 0;

            var stopWords = StopWords.GetStopWords("en"); // Metin işlenirken yararı olmayacak kelimelerin ayıklanması adına ingilizce stopwordsun ilgili değişkene atanması.

            List<string> kelimeler = new List<string>();
            List<string> kelimeler2 = new List<string>();

            HtmlIsleyici htmlIsleyici1 = new HtmlIsleyici();
            htmlIsleyici1.htmlIsle(htmlDoc);
            kelimeler = htmlIsleyici1.kelimeler;
            cumleSayisi = htmlIsleyici1.cumleSayisi;
            HtmlIsleyici htmlIsleyici2 = new HtmlIsleyici();
            htmlIsleyici2.htmlIsle(htmlDoc2);
            kelimeler2 = htmlIsleyici2.kelimeler;
            cumleSayisi2 = htmlIsleyici2.cumleSayisi;


            KelimeDuzeltici kelimeDuzeltici1 = new KelimeDuzeltici();
            kelimeler = kelimeDuzeltici1.kelimeDuzelt(kelimeler, urlDomain);
            KelimeDuzeltici kelimeDuzeltici2 = new KelimeDuzeltici();
            kelimeler2 = kelimeDuzeltici2.kelimeDuzelt(kelimeler2, urlDomain2);

            List<WordAndFreq> kelimeFrekans = new List<WordAndFreq>();
            List<WordAndFreq> kelimeFrekans2 = new List<WordAndFreq>();


            KelimeFrekansYapici kelimeFrekansYapici1 = new KelimeFrekansYapici();
            kelimeFrekans = kelimeFrekansYapici1.KelimeFrekansYap(kelimeler);
            KelimeFrekansYapici kelimeFrekansYapici2 = new KelimeFrekansYapici();
            kelimeFrekans2 = kelimeFrekansYapici2.KelimeFrekansYap(kelimeler2);

            TfIdfCalculator agirlikHesap = new TfIdfCalculator();
            TfIdfCalculator agirlikHesap2 = new TfIdfCalculator();

            List<WordAndWeight> weihtedKelimeler = new List<WordAndWeight>();
            List<WordAndWeight> weihtedKelimeler2 = new List<WordAndWeight>();

            AgirlikliKelimeListesi agirlikliKelimeListesi1 = new AgirlikliKelimeListesi();
            AgirlikliKelimeListesi agirlikliKelimeListesi2 = new AgirlikliKelimeListesi();

            weihtedKelimeler = agirlikliKelimeListesi1.AgirlikliListeYap(kelimeFrekans, kelimeler.Count, cumleSayisi);
            weihtedKelimeler2 = agirlikliKelimeListesi2.AgirlikliListeYap(kelimeFrekans2, kelimeler2.Count, cumleSayisi2);

            AnahtarKelimeBelirleyici anahtarKelimeBelirleyici1 = new AnahtarKelimeBelirleyici();
            List<WordAndFreq> anahtarKelimeler = new List<WordAndFreq>();
            anahtarKelimeler = anahtarKelimeBelirleyici1.AnahtarKelimeBelirle(weihtedKelimeler, kelimeFrekans);
            AnahtarKelimeBelirleyici anahtarKelimeBelirleyici2 = new AnahtarKelimeBelirleyici();
            List<WordAndFreq> anahtarKelimeler2 = new List<WordAndFreq>();
            anahtarKelimeler2 = anahtarKelimeBelirleyici2.AnahtarKelimeBelirle(weihtedKelimeler2, kelimeFrekans2);

            Asama23ViewModel asama23ViewModel = new Asama23ViewModel();

            asama23ViewModel.KeywordListesi = anahtarKelimeler;
            asama23ViewModel.KeywordListesi2 = anahtarKelimeler2;

            //return View(asama23ViewModel);
            return RedirectToAction("Son", "Asama3", new { gelenUrl=gelenUrl, gelenUrl2=gelenUrl2 });



        }


        public ActionResult Son(string gelenUrl, string gelenUrl2)
        {
            WebClient client = new WebClient();
            string url = gelenUrl;
            string url2 = gelenUrl2;

            Uri urlDomain = new Uri(url);
            Uri urlDomain2 = new Uri(url2);

            string downloadString = client.DownloadString(url);//parametre olarak gelcek -- HTML olarak content indirilir
            string downloadString2 = client.DownloadString(url2);


            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes); //indirilen HTML utf-8 e çevrildi. Yapılmasa da olur zira ingilizce yaptık sonradan.
            byte[] bytes2 = Encoding.Default.GetBytes(downloadString2);
            downloadString2 = Encoding.UTF8.GetString(bytes2);


            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString); //Oluşturulan HtmlDocument tipindeki veriye indirilen html içeriği atanır.
            var htmlDoc2 = new HtmlDocument();
            htmlDoc2.LoadHtml(downloadString2);

            int cumleSayisi = 0; //TF-IDF hesaplamaları için  cümle sayılarının tutulacağı değişken.
            int cumleSayisi2 = 0;

            var stopWords = StopWords.GetStopWords("en"); // Metin işlenirken yararı olmayacak kelimelerin ayıklanması adına ingilizce stopwordsun ilgili değişkene atanması.

            List<string> kelimeler = new List<string>();
            List<string> kelimeler2 = new List<string>();

            HtmlIsleyici htmlIsleyici1 = new HtmlIsleyici();
            htmlIsleyici1.htmlIsle(htmlDoc);
            kelimeler = htmlIsleyici1.kelimeler;
            cumleSayisi = htmlIsleyici1.cumleSayisi;
            HtmlIsleyici htmlIsleyici2 = new HtmlIsleyici();
            htmlIsleyici2.htmlIsle(htmlDoc2);
            kelimeler2 = htmlIsleyici2.kelimeler;
            cumleSayisi2 = htmlIsleyici2.cumleSayisi;


            KelimeDuzeltici kelimeDuzeltici1 = new KelimeDuzeltici();
            kelimeler = kelimeDuzeltici1.kelimeDuzelt(kelimeler, urlDomain);
            KelimeDuzeltici kelimeDuzeltici2 = new KelimeDuzeltici();
            kelimeler2 = kelimeDuzeltici2.kelimeDuzelt(kelimeler2, urlDomain2);

            List<WordAndFreq> kelimeFrekans = new List<WordAndFreq>();
            List<WordAndFreq> kelimeFrekans2 = new List<WordAndFreq>();


            KelimeFrekansYapici kelimeFrekansYapici1 = new KelimeFrekansYapici();
            kelimeFrekans = kelimeFrekansYapici1.KelimeFrekansYap(kelimeler);
            KelimeFrekansYapici kelimeFrekansYapici2 = new KelimeFrekansYapici();
            kelimeFrekans2 = kelimeFrekansYapici2.KelimeFrekansYap(kelimeler2);

            TfIdfCalculator agirlikHesap = new TfIdfCalculator();
            TfIdfCalculator agirlikHesap2 = new TfIdfCalculator();

            List<WordAndWeight> weihtedKelimeler = new List<WordAndWeight>();
            List<WordAndWeight> weihtedKelimeler2 = new List<WordAndWeight>();

            AgirlikliKelimeListesi agirlikliKelimeListesi1 = new AgirlikliKelimeListesi();
            AgirlikliKelimeListesi agirlikliKelimeListesi2 = new AgirlikliKelimeListesi();

            weihtedKelimeler = agirlikliKelimeListesi1.AgirlikliListeYap(kelimeFrekans, kelimeler.Count, cumleSayisi);
            weihtedKelimeler2 = agirlikliKelimeListesi2.AgirlikliListeYap(kelimeFrekans2, kelimeler2.Count, cumleSayisi2);

            AnahtarKelimeBelirleyici anahtarKelimeBelirleyici1 = new AnahtarKelimeBelirleyici();
            List<WordAndFreq> anahtarKelimeler = new List<WordAndFreq>();
            anahtarKelimeler = anahtarKelimeBelirleyici1.AnahtarKelimeBelirle(weihtedKelimeler, kelimeFrekans);
            AnahtarKelimeBelirleyici anahtarKelimeBelirleyici2 = new AnahtarKelimeBelirleyici();
            List<WordAndFreq> anahtarKelimeler2 = new List<WordAndFreq>();
            anahtarKelimeler2 = anahtarKelimeBelirleyici2.AnahtarKelimeBelirle(weihtedKelimeler2, kelimeFrekans2);

            Asama23ViewModel asama23ViewModel = new Asama23ViewModel();

            asama23ViewModel.KeywordListesi = anahtarKelimeler;
            asama23ViewModel.KeywordListesi2 = anahtarKelimeler2;
            return View(asama23ViewModel);
        }

    }
}