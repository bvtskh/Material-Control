using Material_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public class Validator
    {
        public IEnumerable<string> TokusaiErr(List<WH_Tokusai> lst)
        {
            foreach (var EmNos in lst.GroupBy(r=>r.EM_NO))
            {

            }
            yield break;
        }
    }
}
