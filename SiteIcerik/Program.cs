using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using StopWord;
using Iveonik.Stemmers;

namespace SiteIcerik
{
    class Program
    {
        static void Main(string[] args)
        {


            WebClient client = new WebClient();

            string downloadString = client.DownloadString("http://www.stackoverflow.com");//arametre olarak gelcek 

            byte[] bytes = Encoding.Default.GetBytes(downloadString);
            downloadString = Encoding.UTF8.GetString(bytes);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(downloadString);
            //Console.WriteLine(htmlDoc);

            //foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//p//text()"))
            //{
            //    if (!string.IsNullOrEmpty(node.InnerText) && !string.IsNullOrWhiteSpace(node.InnerText))
            //        Console.WriteLine("text=" + node.InnerText);

            //}

            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            var stopWords = StopWords.GetStopWords("en");


            //foreach (var item in stopWords)
            //{
            //    Console.WriteLine(item);
            //}

            //string cumle = "i write a lot of things for my example sentence in here for you ";

            //string cumle2 = cumle.RemoveStopWords("en");
            //Console.WriteLine(cumle);
            //Console.WriteLine(cumle2);

            List<string> kelimeler = new List<string>();
            //kelimeler.Add("jumper");
            //kelimeler.Add("jumped");
            //kelimeler.Add("jumping");
            //kelimeler.Add("writing");
            //kelimeler.Add("wrote");




            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//p//text()"))
            {
                //if (!string.IsNullOrEmpty(node.InnerText) && !string.IsNullOrWhiteSpace(node.InnerText))
                //    Console.WriteLine("text=" + node.InnerText);

                string[] cumleKelime = node.InnerText.Split(' ');
                foreach (var item in cumleKelime)
                {
                    if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                    {
                        kelimeler.Add(item);

                    }

                   
                }

            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------BUTUN KELİMELER---------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            for (int j = 0; j < kelimeler.Count; j++)
            {

                for (int i = 0; i < kelimeler[j].Length; i++)
                {
                    if (Char.IsPunctuation(kelimeler[j][i]))
                      kelimeler[j]=  kelimeler[j].Remove(i,1);

                }
                Console.WriteLine(kelimeler[j]+"AA");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------STOP WORD SİLİNMİŞ---------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");

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


            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("---------TEMİZLENMİŞ ----------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------TEMİZLENMiş-----------------------------------------------");


            foreach (var item in kelimeler)
            {

                Console.WriteLine(item);
            }

            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------KOK BULUNMUŞ-----------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");

            //KokBul(new Iveonik.Stemmers.EnglishStemmer(), kelimeler);


            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");
            //Console.WriteLine("-----------------------------------------------------------------------------------");

            //foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//html//text()"))
            //{
            //    if (!string.IsNullOrEmpty(node.InnerText) && !string.IsNullOrWhiteSpace(node.InnerText))
            //        Console.WriteLine("text=" + node.InnerText);

            //}

            //List<int> sayilar = new List<int>();
            //sayilar.Add(1);
            //sayilar.Add(2);
            //sayilar.Add(3);
            //sayilar.Add(4);
            //sayilar.Add(4);
            //sayilar.Add(5);
            //for (int i = 0; i < sayilar.Count; i++)
            //{
            //    if (sayilar[i] == 4)
            //    {
            //        sayilar.RemoveAt(i);
            //        i -= 1;
            //    }


            //}
            //foreach (var item in sayilar)
            //{
            //    Console.WriteLine(item);
            //}

            //string isim = "ABCDEF";
            //string isim2= isim.Remove(2);
            //Console.WriteLine(isim2);
            
            Console.ReadLine();
        }


        //private static void KokBul(IStemmer stemmer, List<string> words)
        //{
        //    Console.WriteLine("Stemmer: " + stemmer);
        //    foreach (string word in words)
        //    {
        //        Console.WriteLine(word + " --> " + stemmer.Stem(word));
        //    }
        //}





    }
}
