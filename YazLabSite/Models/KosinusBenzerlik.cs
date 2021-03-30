using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace YazLabSite.Models
{
    public class KosinusBenzerlik
    {
        public double BenzerlikBul(List<WordAndFreq> Vektor1, List<WordAndFreq> Vektor2)
        {
            double sonuc = 0;

            

            List<WordAndFreq> ortakListe1 = new List<WordAndFreq>();
            List<WordAndFreq> ortakListe2 = new List<WordAndFreq>();

      
            int ortakListeSayi = 0;
            for (int i = 0; i < Vektor1.Count; i++)
            {
                for (int j = 0; j < Vektor2.Count; j++)
                {
                    if (Vektor1[i].Word == Vektor2[j].Word)
                    {
                        ortakListe1.Add(Vektor1[i]);
                        ortakListe2.Add(Vektor2[j]);
                        ortakListeSayi++;
                    }

                }
            }
      

            if (ortakListe1.Count != 0)
            {
                double ust = 0;
                double alt1 = 0;
                double alt2 = 0;
                double kokAlt1 = 0;
                double kokAlt2 = 0;
               
                    for (int i = 0; i < ortakListe1.Count/3; i++)
                    {
                        ust += ortakListe1[i].Frequency * ortakListe2[i].Frequency;
                        alt1 += Math.Pow(ortakListe1[i].Frequency, 2);
                        alt2 += Math.Pow(ortakListe2[i].Frequency, 2);


                    }
                
               

                kokAlt1 = Math.Sqrt(alt1);
                kokAlt2 = Math.Sqrt(alt2);
                sonuc = ust / kokAlt1 * kokAlt2;
            }
            else
                sonuc = 0;

            sonuc = Math.Cos(sonuc);
            sonuc = (sonuc + 1) * 50;

            return sonuc;
        }
    }
}