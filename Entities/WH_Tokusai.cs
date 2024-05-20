namespace Material_System.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WH_Tokusai
    {
        [Key]
        [StringLength(64)]
        [DisplayName("id")]
        public string ID { get; set; }

        [Required]
        [StringLength(64)]
        [DisplayName("E/M No")]
        public string EM_NO { get; set; }

        [Required]
        [StringLength(64)]
        [DisplayName("Parts From")]
        public string PART_FM { get; set; }

        [Required]
        [StringLength(64)]
        [DisplayName("Parts To")]
        public string PART_TO { get; set; }

        [StringLength(64)]
        [DisplayName("Model")]
        public string PRODUCT_ID { get; set; }

        [DisplayName("Os Qty")]
        public int OS_QTY { get; set; }

        [DisplayName("Time")]
        public DateTime UPD_DATE { get; set; }

        [StringLength(64)]
        [DisplayName("Updater Name")]
        public string UPD_NAME { get; set; }


        [DisplayName("Issua Date")]
        public DateTime ISSUA_DATE { get; set; }

        public WH_Tokusai()
        {
            ID = Guid.NewGuid().ToString();
            UPD_DATE = DateTime.Now;
            UPD_NAME = Program.userEntity != null ? Program.userEntity.User.ID : Environment.MachineName;
        }
    }
}
