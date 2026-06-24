using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class ClassEnrollment : BaseEntity
    {
        
        public int MemberId { get; set; } //
        public int ClassId { get; set; } //

        public DateTime EnrollmentDate { get; set; } //

       
        public Member Member { get; set; } = null!;
        public GymClass GymClass { get; set; } = null!;
    }
}
