using System.ComponentModel;

namespace Material_System.Entities
{
    public class TokusaiStock
    {
        [DisplayName("E/M No")]
        public string EM_NO { get; set; }
        [DisplayName("Req Qty")]
        public decimal REQ_QTY { get; set; }
        [DisplayName("New Barcode")]
        public string BC_TO { get; set; }
        [DisplayName("Part From")]
        public string PART_FM { get; set; }
        [DisplayName("Part To")]
        public string PART_TO { get; set; }
        [DisplayName("State")]
        public string BC_SITE { get; set; }
    }
}
