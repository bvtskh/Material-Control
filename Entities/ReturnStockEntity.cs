using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class ReturnStockEntity
    {
        public string BC_NO { get; set; }
        public string PART_NO { get; set; }
        public int QTY { get; set; }
        public string WH_LOC { get; set; }
    }
}
