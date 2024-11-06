using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.BindingModel
{
    public class BResInsertClaim
    {
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public object Data { get; set; }
    }
}
