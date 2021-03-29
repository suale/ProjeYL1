using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSpell.SpellChecker.Dictionary;
using StopWord;


namespace YazLabSite.Models
{
    class KelimeDuzeltici
    {
        WordDictionary ingSozluk = new WordDictionary();

        



        public List<string> kelimeDuzelt(List<string> kelimeler, Uri urlDomain)
        {

            ingSozluk.DictionaryFile = "en-US.dic";

            ingSozluk.Initialize();

            NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();

            oSpell.Dictionary = ingSozluk;

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
                if (String.IsNullOrEmpty(kelimeler[i]) || String.IsNullOrWhiteSpace(kelimeler[i]))
                {
                    kelimeler.RemoveAt(i);
                    i -= 1;
                }
                if (urlDomain.Host.Contains(kelimeler[i]) == true)
                {
                    kelimeler.RemoveAt(i);
                    i -= 1;
                }
            }

            List<string> kelimelerSon = new List<string>();

            foreach (string item in kelimeler)
            {

                try
                {
                    if (oSpell.TestWord(item))
                    {
                        //Console.WriteLine(item);
                        
                        kelimelerSon.Add(item);
                    }
                }
                catch
                {
                   // Console.WriteLine("Devam");
                }



            }



            return kelimelerSon;
        }

    }
}
