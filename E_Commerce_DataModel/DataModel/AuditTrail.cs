using System;
using System.Collections.Generic;

namespace E_Commerce_DataModel.DataModel
{
    public partial class AuditTrail
    {
        public int AuditId { get; set; }
        public string AuditActivity { get; set; }
        public string AuditActor { get; set; }
        public bool AuditStatus { get; set; }
        public DateTime? AudtCreatedDate { get; set; }
    }
}
