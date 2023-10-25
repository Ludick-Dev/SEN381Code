namespace CallCenter.Models
{
    public class Login
	{
        private int EmployeeID;
        private string username;
        private string password;

        public Login()
        {

        }

        public int EmployeeID1 { get => EmployeeID; set => EmployeeID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

    }
}

