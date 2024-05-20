using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public class MaterialHelper
    {
        private static SMTService.MaterialWebServiceSoapClient _service = new SMTService.MaterialWebServiceSoapClient();
        public static string GetWORuntime(string lineId)
        {
            var res = _service.GetLineStartByLineId(lineId);
            if(res == null) return null;
            return res.PRODUCTION_ORDER_ID;
        }
    }
}
