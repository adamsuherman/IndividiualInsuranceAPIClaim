using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.BindingModel
{
    public class BReqDiagnosa
    {
        public string DiagonosaCode { get; set; } = null!;

        public string? DiagonsaName { get; set; }
    }
}
