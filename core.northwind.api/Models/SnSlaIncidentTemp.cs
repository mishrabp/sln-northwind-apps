using System;
using System.Collections.Generic;

namespace corenorthwindapi.Models
{
    public partial class SnSlaIncidentTemp
    {
        public string? Task { get; set; }
        public string? ShortDescription { get; set; }
        public string? Name { get; set; }
        public string? Name1 { get; set; }
        public string? State { get; set; }
        public string? SlaDefinition { get; set; }
        public string? Stage { get; set; }
        public double? ActualTimeLeft { get; set; }
        public double? ActualElapsedPercentage { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
    }
}
