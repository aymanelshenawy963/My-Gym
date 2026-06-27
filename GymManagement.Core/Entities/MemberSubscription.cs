using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class MemberSubscription : BaseEntity
    {
       

        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public string PaymentStatus { get; set; } = string.Empty; 

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;


        public int PlanId { get; set; }
        public MembershipPlan Plan { get; set; } = null!;
    }
}
