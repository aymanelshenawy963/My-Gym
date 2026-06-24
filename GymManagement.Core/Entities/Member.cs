using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Core.Entities
{
    public class Member : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty; // [cite: 10, 85]
        public string LastName { get; set; } = string.Empty; // [cite: 16, 87]
        public string Email { get; set; } = string.Empty; // [cite: 22, 89]
        public string Phone { get; set; } = string.Empty; // [cite: 26, 91]
        public string Gender { get; set; } = string.Empty; // [cite: 28, 93]
        public DateTime JoinDate { get; set; } // [cite: 33, 95]
        public string Status { get; set; } = string.Empty; // [cite: 37, 97]
    }
}
