namespace Material_System.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WH_BCLBFLM_His
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PART_NO { get; set; }

        [Required]
        [StringLength(50)]
        public string LOT_NO { get; set; }

        public bool IS_LOCK { get; set; }

        public DateTime UPD_TIME { get; set; }

        [Required]
        [StringLength(50)]
        public string UPDATER { get; set; }
    }
}
