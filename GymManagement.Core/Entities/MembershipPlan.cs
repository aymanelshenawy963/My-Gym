using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class MembershipPlan : BaseEntity
    {
        public string PlanName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
    }
}
