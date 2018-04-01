using Tangent.Core.Domain.Users;

namespace Tangent.Core.Domain.Employees
{
    public class Employee
    {
        public User User { get; set; }
        public Position Position { get; set; }

        public string phone_number { get; set; }
        public string email { get; set; }
        public string github_user { get; set; }
        public string birth_date { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public string years_worked { get; set; }
        public string age { get; set; }
        public string days_to_birthday { get; set; }

    }
}
