using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class BLLOgrenci
    {
        public static int BLLOgrenciEkle(EntityOgrenci entityOgrenci)
        {
            if (entityOgrenci.Ad != null && entityOgrenci.Soyad != null &&
                entityOgrenci.Numara != null && entityOgrenci.Fotograf != null && entityOgrenci.Sifre != null)
            {
                return DALOgrenci.OgrenciEkle(entityOgrenci);
            }
            return -1;
        }

        public static List<EntityOgrenci> BLLListele()
        {
            return DALOgrenci.OgrenciListele();
        }

        public static bool BLLOgrenciSil(int p)
        {

            if (p >= 0)
            {
                return DALOgrenci.OgrenciSil(p);
            }
            return false;
        }

        public static List<EntityOgrenci> BLLDetay(int p)
        {
            return DALOgrenci.OgrenciDetay(p);
        }


        public static bool BLLOgrenciGuncelle(EntityOgrenci entityOgrenci)
        {

            if (entityOgrenci.Ad != null && entityOgrenci.Soyad != null &&
                entityOgrenci.Numara != null && entityOgrenci.Fotograf != null && entityOgrenci.Sifre != null && entityOgrenci.Id > 0 && entityOgrenci.Ad != "" && entityOgrenci.Soyad != "" && entityOgrenci.Sifre != "" && entityOgrenci.Numara != "" && entityOgrenci.Fotograf != "")
            {
                return DALOgrenci.OgrenciGuncelle(entityOgrenci);

            }

            return false;
        }
    }
}
