using Material_System.ErpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class MachineDocumentLine
    {
        public string PART_ID { get; set; }
        public int UNIT_QUANTITY { get; set; }
        public string COMPONENT_ID { get; set; }
    }
}
