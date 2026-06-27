using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class Trainer : BaseEntity
    {
        public string Specialization { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public ICollection<GymClass> GymClasses { get; set; } = new List<GymClass>();
    }
}
