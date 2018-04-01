namespace Tangent.Core.Domain.Users
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string is_active { get; set; }
        public string is_staff { get; set; }


    }
}
