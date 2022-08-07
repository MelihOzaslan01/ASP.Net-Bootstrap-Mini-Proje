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
    public class DALDers
    {
        public static List<EntityDers> DersListele()
        {
            List<EntityDers> entityOgrencis = new List<EntityDers>();
            SqlCommand cmd = new SqlCommand("Select * From TBLDERSLER", Baglanti.bgl);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {
                EntityDers ent = new EntityDers();
                ent.Id = Convert.ToInt32(dr2["DERSID"].ToString());
                ent.DersAd = dr2["DERSAD"].ToString();
                ent.Max = Convert.ToInt32(dr2["DERSMAKSKONT"].ToString());
                ent.Min = Convert.ToInt32(dr2["DERSMINKONT"].ToString());

                entityOgrencis.Add(ent);
            }
            dr2.Close();
            return entityOgrencis;
        }

        public static int TalepEkle(EntityBasvuruForm entityBasvuruForm)
        {
            SqlCommand cmd3 = new SqlCommand("insert into TBLBASVURUFORMU (OGRENCIID,DERSID) values(@p1,@p2)", Baglanti.bgl);
            cmd3.Parameters.AddWithValue("@p1", entityBasvuruForm.BasOgrId);
            cmd3.Parameters.AddWithValue("@p2", entityBasvuruForm.BasDersId);
            if (cmd3.Connection.State != ConnectionState.Open)
            {
                cmd3.Connection.Open();
            }
            return cmd3.ExecuteNonQuery();
        }

    }
}
