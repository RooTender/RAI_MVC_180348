namespace RAI_MVC_180348.Models
{
    public enum Roles
    {
        Default = 0,
        Admin
    }

    public class UserViewModel
    {
        public string UserName { get; }
        public DateTime MemberFrom { get; }
        public List<string> Friends { get; }

        public UserViewModel(string userName, List<string> friends)
        {
            UserName = userName;
            MemberFrom = DateTime.Now;
            Friends = friends;
        }
    }
}
