namespace Material_System.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Tokusai_Item
    {
        [Key]
        [StringLength(64)]
        public string UPN_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string EM_NO { get; set; }

        [Required]
        [StringLength(64)]
        public string MATERIAL_ORDER_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string PART_ID { get; set; }

        public int MACHINE_SLOT { get; set; }

        [Required]
        [StringLength(64)]
        public string MACHINE_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string PRODUCT_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string LINE_ID { get; set; }

        public DateTime UPD_TIME { get; set; }

        public bool IS_FAILED { get; set; }

        public int ERR_TYPE { get; set; }
    }
}
