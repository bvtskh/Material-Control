using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class Tokusai_GetCurrentLineConfirm
    {
        public string ID { get; set; }
        public string LINE_ID { get; set; }
        public string PART_ID { get; set; }
        public string PRODUCT_ID { get; set; }
        public DateTime TIME_STOP { get; set; }
        //public int CHANGE_ID { get; set; }
        public string CHANGE_NAME { get; set; }
        public string WO { get; set; }
        public string DEPT { get; set; }
        public DateTime TIME_CONFIRM { get; set; }
        public string USER_CONFIRM { get; set; }
        public string RESULT { get; set; }
        public bool IS_DM_ACCEPT { get; set; }
        public string MACHINE_SLOT { get; set; }
    }

    public class Tokusai_LineDisplay
    {
        public string ID { get; set; }
        public string NO { get; set; }
        public string LINE_ID { get; set; }
        public string PART_ID { get; set; }
        public string PRODUCT_ID { get; set; }
        public DateTime TIME_STOP { get; set; }
        public string WO { get; set; }
        public string DM { get; set; }
        public string PD { get; set; }
        public string TE { get; set; }
        public string QA { get; set; }
        public string REASON { get; set; }
    }
    
}
