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

        public UserViewModel(string userName, string password, Roles role, List<string> friends)
        {
            UserName = userName;
            _password = password;
            Role = role;
            Friends = friends;
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
