using System;
using System.Collections.Generic;

namespace IndividiualInsuranceAPIClaim.DataAccess.Models.Claim;

public partial class trClaim
{
    public Guid ID { get; set; }

    public string? CardNumber { get; set; }

    public string? DiagonosaCode { get; set; }

    public decimal? Cost { get; set; }

    public DateTime? TreatmentDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
