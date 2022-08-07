using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class EntityOgretmen
    {
        private string ogrtAd;
        private int ogrtId;
        private int ogrtBrans;

        public string OgrtAd { get => ogrtAd; set => ogrtAd = value; }
        public int OgrtId { get => ogrtId; set => ogrtId = value; }
        public int OgrtBrans { get => ogrtBrans; set => ogrtBrans = value; }
    }
}
