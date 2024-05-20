namespace Material_System.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_RULES
    {
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string USER_ID { get; set; }

        public int RULE_ID { get; set; }
        public string MODULE { get; set; }
        public string DESCRIPTION { get; set; }
        public ERP_RULES()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
