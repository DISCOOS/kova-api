﻿using System;
using System.Collections.Generic;

namespace kova.api.Models
{
    public partial class TOrganizationComNumber
    {
        public string ComNumber { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Symbol { get; set; }
        public Guid PrimKey { get; set; }
        public byte[] TimeStamp { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
