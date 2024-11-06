using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividiualInsuranceAPIClaim.BusinessLayer.BindingModel
{
    public class BReqInsertClaim
    {
        public string ID { get; set; }

        public string? CardNumber { get; set; }

        public string? DiagonosaCode { get; set; }

        public decimal? Cost { get; set; }

        public DateTime? TreatmentDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
