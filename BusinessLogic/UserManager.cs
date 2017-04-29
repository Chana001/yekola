using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserManager
    {
        private List<User> _users = null;

        internal string HashSHA256(string source)
        {
            var result = "";

            // this logic is always the same for our purposes
            // create a byte array (8 bit unsigned int)
            byte[] data;

            // Hash providers are all created with factory methods.
            using (SHA256 sha256hash = SHA256.Create())
            {
                // hash the input
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // use a stringbuilder to conserve memory
            var s = new StringBuilder();

            // loop through the bytes creating characts
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString();
            return result;
        }

        public bool UpdatePassword(int employeeID, string oldPassword, string newPassword)
        {
            var result = false;
            try
            {
                if (1 == UserAccessor.UpdatePasswordHash(employeeID,
                    HashSHA256(oldPassword), HashSHA256(newPassword)))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public User AuthenticateUser(string username, string password)
        {
            User user = null;

            if (username.Length < 3 || username.Length > 20)
            {
                throw new ApplicationException("Invalid Username");
            }
            if (password.Length < 3) // we really need a better method
            {                        // possibly a regex for complexity
                throw new ApplicationException("Invalid Password");
            }

            try
            {
                if (1 == UserAccessor.VerifyUsernameAndPassword(username, HashSHA256(password)))
                {
                    password = null;
                    // need to create a user object to use as an access token

                    // get a user object
                    user = UserAccessor.RetrieveUserByUsername(username);
                    // get some roles
                    var roles = UserAccessor.RetrieveUsersRoles(user.Id);
                    // add the List<Role> to the user object
                    user.UserRoles = roles;
                }
                else
                {
                    throw new ApplicationException("Authentication Failed!");
                }

            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public List<UserRoles> GetUserRoles(int userId)
        {
            return UserAccessor.RetrieveUsersRoles(userId); 
        }


        public User RetrieveUserByUsername ( string username )
        {
            var user = new User();

            user = UserAccessor.RetrieveUserByUsername(username);

            return user;
        }

        public bool CreateUser(User user)
        {
            bool result1 = false;

            //Encrypt Password
            string a = user.PasswordHash;
            user.PasswordHash = HashSHA256(a);

            //Set Active
            user.Active = true;
            
            //Handle PHone issue
            user.PhoneNumber = String.Empty;

            try
            {
                if (UserAccessor.CreateNewUser(user))
                {
                    result1 = true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           

            //Setup Player
            var quizManager = new QuizManager();
            bool result2 = quizManager.SetupPlayer(user.UserName);

            return result1 && result2;
        }


        public List<UserRoles> retrieveRoles ( int userID )
        {
            List<UserRoles> roles = new List<UserRoles>();

            roles = UserAccessor.RetrieveUsersRoles(userID);

            return roles;
        }


    }
}

