using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazLabSite.Models
{
     class AgirlikliKelimeListesi
    {
        public List<WordAndWeight> AgirlikliListeYap(List<WordAndFreq> KelimeFrekans, int kelimeSayi, int cumleSayi)
        {
            TfIdfCalculator agirlikHesap = new TfIdfCalculator();

            List<WordAndWeight> weihtedKelimeler = new List<WordAndWeight>();

            foreach (var item in KelimeFrekans)
            {

                WordAndWeight weightedKelime = new WordAndWeight();
                weightedKelime.Weight = agirlikHesap.Calculate((float)item.Frequency, (float)kelimeSayi, (float)cumleSayi);
                weightedKelime.Word = item.Word;
                weihtedKelimeler.Add(weightedKelime);
            }


            return weihtedKelimeler;
        }


    }
}
