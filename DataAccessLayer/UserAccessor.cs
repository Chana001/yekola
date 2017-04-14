using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserAccessor
    {
        public static int VerifyUsernameAndPassword(string username, string passwordHash)
        {
            var result = 0;

            // get a connection
            var conn = DBConnection.GetConnection();

            // get command text ***replace with stored procedure
            var cmdText = @"sp_authenticate_user";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 100);

            // set parameter values
            cmd.Parameters["@Username"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            // try-catch-finally
            try
            {
                // open a connection
                conn.Open();

                // execute and capture the result
                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public static List<UserRoles> RetrieveUsersRoles(int usersID)
        {
            var roles = new List<UserRoles>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_user_roles";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UsersID", SqlDbType.Int);
            cmd.Parameters["@UsersID"].Value = usersID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(new UserRoles()
                        {
                            Id = reader.GetString(0),
                            Desription = reader.GetString(1)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public static User RetrieveUserByUsername(string username)
        {
            User user = null;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_users_by_username";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters["@Username"].Value = username;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                { // EmployeeID, FirstName, LastName, PhoneNumber, Email, UserName, Active
                    reader.Read();
                    user = new User()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        PhoneNumber = reader.GetString(3),
                        Email = reader.GetString(4),
                        UserName = reader.GetString(5),
                        Active = reader.GetBoolean(6)
                    };
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return user;
        }

        public static int UpdatePasswordHash(int employeeID, string oldPasswordHash, string newPasswordHash)
        {
            var count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_update_passwordHash";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.VarChar, 100);

            cmd.Parameters["@EmployeeID"].Value = employeeID;
            cmd.Parameters["@OldPasswordHash"].Value = oldPasswordHash;
            cmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public static bool CreateNewUser(User user)
        {
            //stored procedure to add new user

            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_create_new_user";
            var cmd = new SqlCommand(cmdText, conn);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@UserRolesId", user.UserRolesID);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@Active", user.Active);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            //Returns the User ID
            bool result = count == 1 ? true : false;

            return result;
        }

        public static bool addSecurityQuestions(Security securityQuestions) //add matching in
        {
            //store procedure to add new question to database

            return true;
        }

        public static List<Security> retrieveSecurityQuestions(int usersId)
        {
            //stored procedure to retrieve security questions based on userId.

            return new List<Security>();
        }

    }
}
