using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class TokusaiHis
    {
        [DisplayName("Type")]
        public string ERR_TYPE { get; set; }

        [DisplayName("Barcode")]
        public string UPN_ID { get; set; }

        [DisplayName("Parts")]
        public string PART_ID { get; set; }

        [DisplayName("Slot")]
        public int MACHINE_SLOT { get; set; }

        [DisplayName("Machine")]
        public string MACHINE_ID { get; set; }

        [DisplayName("Product")]
        public string PRODUCT_ID { get; set; }

        [DisplayName("Material Order")]
        public string MATERIAL_ORDER_ID { get; set; }

        [DisplayName("Line")]
        public string LINE_ID { get; set; }

        [DisplayName("Production Order")]
        public string PRODUCTION_ORDER_ID { get; set; }

        [DisplayName("Quantity")]
        public double QUANTITY { get; set; }

        [DisplayName("Error Time")]
        public DateTime ERROR_TIME { get; set; }
    }
}
