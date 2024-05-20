using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class MaterialItem
    {
        public string ORDER_NO { get; set; }
        public string COMPONENT_ID { get; set; }
        public int   QTY { get; set; }
        public string LINE_ID { get; set; }
    }
}
