using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class MemberSubscription : BaseEntity
    {
       
        public int MemberId { get; set; } //
        public int PlanId { get; set; } //

        public DateTime StartDate { get; set; } //
        public DateTime EndDate { get; set; } //
        public string PaymentStatus { get; set; } = string.Empty; //

      
        public Member Member { get; set; } = null!;
        public MembershipPlan MembershipPlan { get; set; } = null!;
    }
}
