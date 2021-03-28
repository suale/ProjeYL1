using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteIcerik
{
    class AnahtarKelimeBelirleyici
    {

        public List<WordAndFreq> AnahtarKelimeBelirle(List<WordAndWeight> weightedKelimeler, List<WordAndFreq> kelimeFrekans)
        {
            int sinir = 0;
            List<WordAndFreq> anahtarKelimeler = new List<WordAndFreq>();

            weightedKelimeler = weightedKelimeler.OrderByDescending(x => x.Weight).ToList();

            sinir = weightedKelimeler.Count * 2 / 9;

            for (int i = 0; i < sinir; i++)
            {
                WordAndFreq anahtarKelime = new WordAndFreq();
                anahtarKelime.Word = weightedKelimeler[i].Word;
                foreach (var item in kelimeFrekans)
                {
                    if (weightedKelimeler[i].Word == item.Word)
                    {
                        anahtarKelime.Frequency = item.Frequency;
                    }
                }
                anahtarKelimeler.Add(anahtarKelime);
            }

            return anahtarKelimeler;
        }

    }
}
