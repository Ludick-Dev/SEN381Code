using CallCenter.DataAccess;

namespace CallCenter.Services
{
    public class LoginServices
    {
        LoginDataAccess loginDA = new LoginDataAccess();
        public string AuthenticateUser(string inputUsername, string inputPassword)
        {
            var credentials = loginDA.GetUserCredentials(inputUsername);
            int id = credentials.ID;
            string username = credentials.Username;
            string password = credentials.Password;

            if (inputUsername == username && inputPassword == password)
            {
                return "Logged in successfully.";
            }

            else if (inputPassword != password || inputUsername != username)
            {
                return "Incorrect username or password. Try again.";
            }

            return "Unexpected error occurred.";
        }
    }
}
