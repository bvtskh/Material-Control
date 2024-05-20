using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    [Table("MainSub_Model")]
    public class MainSubModel
    {
        [ExplicitKey]
        public string ID { get; set; }
        public string PART_TO { get; set; }
        public string PART_FROM { get; set; }
        public DateTime UPD_TIME { get; set; }
        public string UPDATOR { get; set; }
        public bool IS_SPECIAL { get; set; }
    }
}
