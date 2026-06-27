using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class Member : BaseEntity
    {
        public string Gender { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public string Status { get; set; } = string.Empty;

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public ICollection<MemberSubscription> MemberSubscriptions { get; set; } = [];
        public ICollection<Attendance> Attendances { get; set; } = [];
        public ICollection<ClassEnrollment> ClassEnrollments { get; set; } = [];
    }
}


