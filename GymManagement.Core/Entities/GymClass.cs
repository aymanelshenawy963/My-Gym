using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class GymClass : BaseEntity
    {
        public string ClassName { get; set; } = string.Empty; 

      
        public int TrainerId { get; set; } 

        public DateTime ScheduleTime { get; set; } 
        public int MaxCapacity { get; set; } 
       
        public Trainer Trainer { get; set; } = null!;
    }
}
