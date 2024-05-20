using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class WorkingOrder
    {
        public int ORDER_NO { get; set; }
        public string COMPONENT_ID { get; set; }
        public int QTY { get; set; }
        public string LINE_ID { get; set; }
        public string BOM_VER { get; set; }
        public int SORT { get; set; }
        public string ECO_OLD { get; set; }
        public string ECO_NEW { get; set; }
        public string TOKUSAI_OLD { get; set; }
        public string TOKUSAI_NEW { get; set; }
    }
}
