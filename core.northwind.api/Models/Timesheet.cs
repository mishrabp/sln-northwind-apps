using System;
using System.Collections.Generic;

namespace corenorthwindapi.Models
{
    public partial class Timesheet
    {
        public int Id { get; set; }
        public string? PortalId { get; set; }
        public int? EmpNumber { get; set; }
        public string? EmployeeName { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? TotalTargHrs { get; set; }
        public string? TotalRecHrs { get; set; }
        public string? TimeOff { get; set; }
        public string? TimeOffType { get; set; }
        public string? AttAbsType { get; set; }
        public string? PublicHoliday { get; set; }
        public int? WbsPersResponsible { get; set; }
        public string? WbsPersName { get; set; }
        public int? WbsPersPortalid { get; set; }
        public int? AssgnStart { get; set; }
        public int? AssgnmtEnd { get; set; }
        public int? CostCenter { get; set; }
        public string? CostcenterName { get; set; }
        public string? CostcenterOwner { get; set; }
        public string? RecWbsElem { get; set; }
        public string? WbsDescription { get; set; }
        public string? PreviousWbs { get; set; }
        public string? ProcessStatus { get; set; }
        public string? ProcessStatus1 { get; set; }
        public string? TimeSheetApprPid { get; set; }
        public string? TimeSheetApprEmpId { get; set; }
        public string? DateApproved { get; set; }
        public string? TimeSheetApprName { get; set; }
        public string? PremiumNumber { get; set; }
        public string? PremiumId { get; set; }
        public string? LongText { get; set; }
        public string? BillableNon { get; set; }
        public string? NbType { get; set; }
        public string? OnOffShore { get; set; }
        public int? ContractNo { get; set; }
        public string? Name { get; set; }
        public int? ShipToParty { get; set; }
        public string? ShipToPartyName { get; set; }
        public string? ResourceCountry { get; set; }
        public string? EeGroup { get; set; }
        public string? EeSubgroup { get; set; }
        public int? ReportingManagerId { get; set; }
        public string? ReportingManagerName { get; set; }
        public string? TransferredToCo { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? BasePlus { get; set; }
        public string? IsParsed { get; set; }
    }
}
