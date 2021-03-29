using HtmlAgilityPack;
using StopWord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YazLabSite.Models;
using YazLabSite.ViewModels;

namespace YazLabSite.Controllers
{
    public class Asama2Controller : Controller
    {
        [Route("Asama2/index")]
        [HttpGet]
        public ActionResult Index()
        {
            Asama2ViewModel asama2ViewModel = new Asama2ViewModel();
            return View(asama2ViewModel);
        }
        [Route("Asama2/index")]
        [HttpPost]
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

            Asama2ViewModel asama2ViewModel = new Asama2ViewModel();

            asama2ViewModel.KeywordListesi = anahtarKelimeler;

            return View(asama2ViewModel);
        }


    }
}