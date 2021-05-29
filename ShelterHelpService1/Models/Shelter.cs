using System;

namespace ShelterHelpService1.Models
{
    public class Shelter : User
    {
        public string FullName { get; set; }
        public DateTime LastPaymentDate { get; set; }
    }
}
