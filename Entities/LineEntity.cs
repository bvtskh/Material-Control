using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Entities
{
    public class LineEntity
    {
        public string LineID { get; set; }
        public string WO { get; set; }
        public string PartNo { get; set; }
        public string DMConfirm { get; set; }
        public string PDConfirm
        {
            get
            {
                if (DMConfirm == "NG")
                {
                    return "NG";
                }
                if (!PD_Confirm_Pitch || !PD_Confirm_Tap_Width || !PD_Confirm_Swive_Angle)
                {
                    return "Confirm";
                }
                return "OK";
            }
        }
        public bool PD_Confirm_Pitch { get; set; }
        public bool PD_Confirm_Tap_Width { get; set; }
        public bool PD_Confirm_Swive_Angle { get; set; }
        public string TEConfirm
        {
            get
            {
                if (DMConfirm == "NG")
                {
                    return "NG";
                }
                if (!TE_Confirm_Pitch || !TE_Confirm_Tap_Width || !TE_Confirm_Swive_Angle)
                {
                    return "Confirm";
                }
                return "OK";
            }
        }
        public bool TE_Confirm_Pitch { get; set; }
        public bool TE_Confirm_Tap_Width { get; set; }
        public bool TE_Confirm_Swive_Angle { get; set; }
        public string QAConfirm
        {
            get
            {
                if (DMConfirm == "NG")
                {
                    return "NG";
                }
                if (!QA_Confirm_Pitch || !QA_Confirm_Tap_Width || !QA_Confirm_Swive_Angle)
                {
                    return "Confirm";
                }
                return "OK";
            }
        }
        public bool QA_Confirm_Pitch { get; set; }
        public bool QA_Confirm_Tap_Width { get; set; }
        public bool QA_Confirm_Swive_Angle { get; set; }
        public string FaultReason { get; set; }
    }
}
