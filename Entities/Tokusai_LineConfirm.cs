using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    [Table("Tokusai_LineConfirm")]
    public class Tokusai_LineConfirm
    {
        public int ID { get; set; }
        public string ID_HISTORY { get; set; }
        public string DEPT { get; set; }
        public DateTime UPD_TIME { get; set; }
        public string USER_CONFIRM { get; set; }
        public bool RESULT_CONFIRM { get; set; }
    }
}
