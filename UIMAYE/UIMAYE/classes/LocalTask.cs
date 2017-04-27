using System;

namespace UIMAYE.classes
{
    public class LocalTask
    {
        public int id { get; set; }
        public string ad { get; set; }
        public int? projeId { get; set; }
        public int? durum { get; set; }
        public int? kaldigiSure { get; set; }
        public bool? oncelik { get; set; }
    }
}