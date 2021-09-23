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
    }
}
