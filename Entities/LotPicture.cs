namespace Material_System.Entities
{
    using Material_System.Business;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WH_LotNo_Picture")]
    public partial class LotPicture
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Part No")]
        public string PART_NO { get; set; }

        [StringLength(50)]
        [Display(Name = "Path Image")]
        public string PATH_IMG { get; set; }
        public string FullPath
        {
            get
            {
                return $@"\PART_PICTURE\{PATH_IMG}";
            }
        }

        [Display(Name = "Create Time")]
        public DateTime UPD_TIME { get; set; }

        public static LotPicture CreateInstance(string partNo)
        {
            LotPicture entity = new LotPicture()
            {
                PART_NO = partNo,
                PATH_IMG = string.Format("{0}.jpg", partNo.RemoveInvalidChars()),
                UPD_TIME = DateTime.Now
            };
            return entity;
        }
    }
}
