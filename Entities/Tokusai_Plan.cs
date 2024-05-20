using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    [Table("Tokusai_Plan")]
    public class Tokusai_Plan
    {
        [ExplicitKey]
        public string ID { get; set; }
        public string ORDER_NO { get; set; }
        public string MODEL_NO { get; set; }
        public string QUANTITY { get; set; }
        public DateTime DUE_DATE { get; set; }
        public DateTime UPD_DATE { get; set; }
        public string ORDER_TYPE { get; set; }
    }
}
