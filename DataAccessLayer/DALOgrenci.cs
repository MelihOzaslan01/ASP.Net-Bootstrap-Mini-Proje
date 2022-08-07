using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALOgrenci
    {
        public static int OgrenciEkle(EntityOgrenci parametre)
        {
            SqlCommand komut1 = new SqlCommand("insert into TBLOGRENCI(OGRAD,OGRSOYAD,OGRNUMARA,OGRFOTO,OGRSIFRE) values(@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", parametre.Ad);
            komut1.Parameters.AddWithValue("@p2", parametre.Soyad);
            komut1.Parameters.AddWithValue("@p3", parametre.Numara);
            komut1.Parameters.AddWithValue("@p4", parametre.Fotograf);
            komut1.Parameters.AddWithValue("@p5", parametre.Sifre);
            return komut1.ExecuteNonQuery();
        }
        public static List<EntityOgrenci> OgrenciListele()
        {
            List<EntityOgrenci> entityOgrencis = new List<EntityOgrenci>();
            SqlCommand cmd = new SqlCommand("Select * From TBLOGRENCI", Baglanti.bgl);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.Id = Convert.ToInt32(dr["OGRID"].ToString());
                ent.Ad = dr["OGRAD"].ToString();
                ent.Soyad = dr["OGRSOYAD"].ToString();
                ent.Numara = dr["OGRNUMARA"].ToString();
                ent.Fotograf = dr["OGRFOTO"].ToString();
                ent.Sifre = dr["OGRSIFRE"].ToString();
                ent.Bakiye = Convert.ToDouble(dr["OGRBAKIYE"].ToString());
                entityOgrencis.Add(ent);
            }
            dr.Close();
            return entityOgrencis;
        }

        public static bool OgrenciSil(int parametre)
        {
            SqlCommand cmd1 = new SqlCommand("Delete From TBLOGRENCI where OGRID =@p1", Baglanti.bgl);
            if (cmd1.Connection.State != ConnectionState.Open)
            {
                cmd1.Connection.Open();
            }
            cmd1.Parameters.AddWithValue("@p1", parametre);
            return cmd1.ExecuteNonQuery() > 0;


        }

        public static List<EntityOgrenci> OgrenciDetay(int id)
        {
            List<EntityOgrenci> entityOgrencis = new List<EntityOgrenci>();
            SqlCommand cmd2 = new SqlCommand("Select * From TBLOGRENCI Where OGRID=@p1 ", Baglanti.bgl);
            cmd2.Parameters.AddWithValue("@p1", id);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.Ad = dr["OGRAD"].ToString();
                ent.Soyad = dr["OGRSOYAD"].ToString();
                ent.Numara = dr["OGRNUMARA"].ToString();
                ent.Fotograf = dr["OGRFOTO"].ToString();
                ent.Sifre = dr["OGRSIFRE"].ToString();
                ent.Bakiye = Convert.ToDouble(dr["OGRBAKIYE"].ToString());
                entityOgrencis.Add(ent);
            }
            dr.Close();
            return entityOgrencis;

        }

        public static bool OgrenciGuncelle(EntityOgrenci deger)
        {
            SqlCommand cmd3 = new SqlCommand("Update TBLOGRENCI Set OGRAD=@p1,OGRSOYAD=@p2,OGRNUMARA=@p3,OGRFOTO=@p4,OGRSIFRE=@p5 Where OGRID=@p6", Baglanti.bgl);
            if (cmd3.Connection.State != ConnectionState.Open)
            {
                cmd3.Connection.Open();
            }

            cmd3.Parameters.AddWithValue("@p1", deger.Ad);
            cmd3.Parameters.AddWithValue("@p2", deger.Soyad);
            cmd3.Parameters.AddWithValue("@p3", deger.Numara);
            cmd3.Parameters.AddWithValue("@p4", deger.Fotograf);
            cmd3.Parameters.AddWithValue("@p5", deger.Sifre);
            cmd3.Parameters.AddWithValue("@p6", deger.Id);
            return cmd3.ExecuteNonQuery() > 0;
        }

    }
}
