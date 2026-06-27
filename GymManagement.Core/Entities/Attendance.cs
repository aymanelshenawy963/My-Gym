using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class Attendance : BaseEntity
    {     
        public DateTime CheckInTime { get; set; } 

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
    }
}
