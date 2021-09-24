using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerFitness.Models
{
    public class ClientValues
    {
        public int v_cid { get; set; }
        public int v_calories { get; set; }
        public DateTime v_date { get; set; }
        public decimal v_arm { get; set; }
        public decimal v_chest { get; set; }
        public decimal v_leg { get; set; }
        public decimal v_calves { get; set; }
        public decimal v_stomach { get; set; }
        public decimal v_hips { get; set; }
        public decimal v_muscle { get; set; }
        public decimal v_fat { get; set; }
        public decimal v_vfat { get; set; }
        public decimal v_weight { get; set; }

        public ClientValues(int v_cid) => this.v_cid = v_cid;
        public ClientValues(int v_cid,
            int v_calories, 
            DateTime v_date, 
            decimal v_arm, 
            decimal v_chest, 
            decimal v_leg, 
            decimal v_calves, 
            decimal v_stomach, 
            decimal v_hips,
            decimal v_muscle,
            decimal v_fat,
            decimal v_vfat,
            decimal v_weight)
        {
            this.v_date = v_date;
            this.v_arm = v_arm;
            this.v_chest =  v_chest;
            this.v_leg = v_leg;
            this.v_calves = v_calves;
            this.v_stomach = v_stomach;
            this.v_hips = v_hips;
            this.v_muscle = v_muscle;
            this.v_fat = v_fat;
            this.v_vfat = v_vfat;
            this.v_weight = v_weight;
        }
        
        //TODO: 
        // - Create a class in C# for each logical object in the database class. 
        // - Migrate the fetching of the data from the database to the respective classes via static access
        // - Create a core class as an interface
        // - Always access the database object via the core class
        
        /* ----------------
           -- EXAMPLE    --
           ----------------
           
        public static ClientValue GetLatestClientValue(int v_cid) {
            if (Core.GetDatabase().OpenConnection()) {
                string query = (
                    "SELECT v_cid"
                +   "     , v_calories"
                +   "     , v_date" 
                +   "     , v_arm" 
                +   "     , v_chest" 
                +   "     , v_leg" 
                +   "     , v_calves" 
                +   "     , v_stomach" 
                +   "     , v_hips" 
                +   "     , v_muscle" 
                +   "     , v_fat" 
                +   "     , v_vfat"
                +   "     , v_weight"
                +   "  FROM t_cvalues" 
                +   " WHERE v_cid = " + clientNr
                +   "   AND vid = ("
                +   "        SELECT MAX(vid)"
                +   "          FROM t_cvalues" 
                +   "         WHERE v_cid = " + clientNr
                +   "             )"
                +   ";"
                );

                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                
                ClientValues clientValues new ClientValues(
                    rdr.GetInt32(0),      //ClientNr
                    rdr.GetInt32(1),      //Kalorien
                    rdr.GetDateTime(2),   //Datum
                    rdr.GetDecimal(3),    //Arm
                    rdr.GetDecimal(4),    //Brust
                    rdr.GetDecimal(5),    //Beine
                    rdr.GetDecimal(6),    //Unterschenkel
                    rdr.GetDecimal(7),    //Bauch
                    rdr.GetDecimal(8),    //Hüfte
                    rdr.GetDecimal(9),    //Muskeln
                    rdr.GetDecimal(10),   //Fett
                    rdr.GetDecimal(11),   //Fett
                    rdr.GetDecimal(12)    //Gewicht
                );

                Core.GetDatabase().CloseConnection();
                return clientValues;
            }
        }
        */
    }
}
