using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIMAYE.Istatistik
{
    public class Raporlama
    {
        public string projeAdi { get; set; }
        public string gorevAdi { get; set; }
        public int toplamSure { get; set; }
        public int toplamMola { get; set; }
        public int toplamBeklemeSuresi { get; set; }
        public DateTime baslamaTarih { get; set; }
        public DateTime bitisTarih { get; set; }
    }
}
