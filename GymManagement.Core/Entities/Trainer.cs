using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class Trainer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty; //
        public string LastName { get; set; } = string.Empty; //
        public string Specialization { get; set; } = string.Empty; //
        public decimal Salary { get; set; } //
        public string Phone { get; set; } = string.Empty; //
    }
}
