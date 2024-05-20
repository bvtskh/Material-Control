using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class BomListEntity
    {
        public string MATERIAL_NUMBER { get; set; }
        public string ASSEMBLE_MATERIAL_NUMBER { get; set; }
        public string BOM_LEVEL { get; set; }
        public string BOM_COMPONENT { get; set; }
        public double QTY { get; set; }
    }
}
