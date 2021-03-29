using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YazLabSite.Models
{
    class TfIdfCalculator
    {
        public float Calculate(float kelimeSayisi, float toplamKelimeSayisi, float cumleSayisi)
        {
            float tf = kelimeSayisi / toplamKelimeSayisi;
            float idf = (float)Math.Log(cumleSayisi / kelimeSayisi);

            return (float)(tf * idf);
        }
    }
}
