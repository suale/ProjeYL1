using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using StopWord;
using System.Linq;

namespace SiteIcerik
{
    class Program
    {
        static void Main(string[] args)
        {


            WebClient client = new WebClient();

            string downloadString = client.DownloadString("http://www.stackoverflow.com");//parametre olarak gelcek 

            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString);
       

     

            var stopWords = StopWords.GetStopWords("en");


            

            List<string> kelimeler = new List<string>();


            NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();

            oDict.DictionaryFile = "en-US.dic";
            //load and initialize the dictionary 
            oDict.Initialize();
           
            NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();

            oSpell.Dictionary = oDict;




            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//p//text()"))
            {


                string[] cumleKelime = node.InnerText.Split(' ');
                foreach (var item in cumleKelime)
                {
                    if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                    {

                        kelimeler.Add(item.ToLower());

                    }


                }

            }


            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//title//text()"))
            {


                string[] cumleKelime = node.InnerText.Split(' ');
                foreach (var item in cumleKelime)
                {
                    if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                    {
                        kelimeler.Add(item.ToLower());
                    }


                }

            }
            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//meta"))
            {

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

          
            for (int j = 0; j < kelimeler.Count; j++)
            {

                for (int i = 0; i < kelimeler[j].Length; i++)
                {
                    if (Char.IsPunctuation(kelimeler[j][i]))
                        kelimeler[j] = kelimeler[j].Remove(i, 1);

                }
               
            }
          

            for (int i = 0; i < kelimeler.Count; i++)
            {
                string silincekMi = kelimeler[i];
                kelimeler[i] = kelimeler[i].RemoveStopWords("en");
                if (silincekMi != kelimeler[i])
                {
                    kelimeler.RemoveAt(i);
                    i -= 1;

                }


            }

            for (int i = 0; i < kelimeler.Count; i++)
            {
                

                if (String.IsNullOrEmpty(kelimeler[i])|| String.IsNullOrWhiteSpace(kelimeler[i]))
                {
                    kelimeler.RemoveAt(i);
                    i -= 1;

                }


            }


            List<WordAndFreq> KelimeSayilari = new List<WordAndFreq>();
            int sayi = 0;

            List<string> kelimelerSon = new List<string>();

            foreach (string item in kelimeler)
            {
                
                if (oSpell.TestWord(item))
                {
                    //Console.WriteLine(item);
                    sayi++;
                    kelimelerSon.Add(item);
                   


                }

                
            }
            Console.WriteLine(kelimeler.Count);
            Console.WriteLine("Kelimeler son "+kelimelerSon.Count);
            Console.WriteLine(sayi);

            for (int i = 0; i < kelimelerSon.Count; i++)
            {
               int kelimeFrekans = 1;
                for (int j = i + 1; j < kelimelerSon.Count; j++)
                {
                    if (String.Equals(kelimelerSon[i], kelimelerSon[j]))
                    {
                        kelimeFrekans++;
                        kelimelerSon.RemoveAt(j);
                        j -= 1;
                    }
                }
                WordAndFreq yeni = new WordAndFreq();
                yeni.Word = kelimelerSon[i];
                yeni.Frequency = kelimeFrekans;
                KelimeSayilari.Add(yeni);
            }


            foreach (var item in kelimelerSon)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------Frekans Listesi--------------------------------");
          
            foreach (var item in KelimeSayilari)
            {
                Console.WriteLine(item.Word+" "+item.Frequency);
            }
            Console.ReadLine();
        }


      




    }
}
