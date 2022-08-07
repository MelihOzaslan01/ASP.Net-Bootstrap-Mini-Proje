using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class BLLDers
    {
        public static List<EntityDers> BLLListele()
        {
            return DALDers.DersListele();
        }

        public static int TalepEkle(EntityBasvuruForm entityBasvuruForm)
        {
            if (entityBasvuruForm.BasDersId >= 0 && entityBasvuruForm.BasOgrId >= 0)
            {
                return DALDers.TalepEkle(entityBasvuruForm);
            }
            return -1;
        }



    }
}
