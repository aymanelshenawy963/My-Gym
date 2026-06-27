using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class ClassEnrollment : BaseEntity
    {
        

        public DateTime EnrollmentDate { get; set; } 

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public int ClassId { get; set; }
        public GymClass Class { get; set; } = null!;
    }
}
