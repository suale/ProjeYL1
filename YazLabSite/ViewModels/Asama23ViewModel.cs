using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YazLabSite.Models;

namespace YazLabSite.ViewModels
{
    public class Asama23ViewModel
    {
        public List<WordAndFreq> KeywordListesi2 { get; set; }
        public List<WordAndFreq> KeywordListesi { get; set; }
        public string Site1 { get; set; }
        public string Site2 { get; set; }
        public double Benzerlik { get; set; }
    }
}