using System;    

namespace UIMAYE.classes
{
    public class LocalLog
    {
        public int id { get; set; }
        public string projeAdi { get; set; }
        public string gorevAdi { get; set; }
        public DateTime baslangicTarihi { get; set; }
        public DateTime bitisTarihi { get; set; }   
        public int gorevID { get; set; }
        public int projeID { get; set; }
        public int toplamSure { get; set; }
        public int beklemeSuresi { get; set; }
        public int toplamMola { get; set; }
    }
}