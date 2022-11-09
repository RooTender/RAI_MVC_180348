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
        public Roles Role { get; }
        public List<string> Friends { get; }

        private string _password;

        public UserViewModel(string userName, string password, Roles role = Roles.Default)
        {
            UserName = userName;
            _password = password;
            
            Friends = new List<string>();
            Role = role;
        }

        public UserViewModel(string userName, string password, List<string> friends, Roles role = Roles.Default)
        {
            UserName = userName;
            _password = password;
            
            Friends = friends;
            Role = role;
        }

        public void AddFriend(string friendName)
        {
            Friends.Add(friendName);
        }

        public void RemoveFriend(string friendName)
        {
            Friends.Remove(friendName);
        }
    }
}
