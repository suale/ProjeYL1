using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazLabSite.Models
{
    class KelimeFrekansYapici
    {

        public List<WordAndFreq> KelimeFrekansYap(List<string> kelimeler)
        {
            List<WordAndFreq> KelimeSayilari = new List<WordAndFreq>();

            for (int i = 0; i < kelimeler.Count; i++)
            {
                int kelimeFrekans = 1;
                for (int j = i + 1; j < kelimeler.Count; j++)
                {
                    if (String.Equals(kelimeler[i], kelimeler[j]))
                    {
                        kelimeFrekans++;
                        kelimeler.RemoveAt(j);
                        j -= 1;
                    }
                }
                WordAndFreq yeni = new WordAndFreq();
                yeni.Word = kelimeler[i];
                yeni.Frequency = kelimeFrekans;
                KelimeSayilari.Add(yeni);
            }
            KelimeSayilari = KelimeSayilari.OrderByDescending(x => x.Frequency).ToList();
            return KelimeSayilari;
        }

    }
}
