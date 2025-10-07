using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Access
{
    public partial class SignUpUserData
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool SubscribeToNewsletter { get; set; }
        public bool ReceiveSpecialOffers { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Company {  get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }   
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string MobileNumber { get; set; }

    }
}
