﻿using System;
using System.Collections.Generic;

namespace kova.api.Models
{
    public partial class TOrganizationEventLog
    {
        public Guid? PersonRef { get; set; }
        public string ReportText { get; set; }
        public Guid EventCrewRef { get; set; }
        public bool Public { get; set; }
        public Guid PrimKey { get; set; }
        public byte[] TimeStamp { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TOrganizationEventCrew EventCrewRefNavigation { get; set; }
        public virtual TOrganizationPerson PersonRefNavigation { get; set; }
    }
}
