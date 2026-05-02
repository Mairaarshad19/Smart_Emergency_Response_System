using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;

namespace Emergency_Response_System.DL
{
    public class UserDL
    {
        public static void AddUser(UserBL user)
        {
            string query = "INSERT INTO users (username,password_hash, role) " +
                           "VALUES (@Name, @Password, @Role)";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Name", user.username),
                new MySqlParameter("@Password", user.password_hash),
                new MySqlParameter("@Role", user.role)
            );
        }

        // Update existing user
        public static void UpdateUser(UserBL user)
        {
            string query = "UPDATE users SET username=@Name" +
                           "password_hash=@Password, role=@Role" +
            "WHERE user_id=@UserId";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Name", user.username),
                new MySqlParameter("@Password", user.password_hash),
                new MySqlParameter("@Role", user.role),
                new MySqlParameter("@UserId", user.user_id)
            );
        }

        // Delete user by ID
        public static void DeleteUser(int userId)
        {
            string query = "DELETE FROM users WHERE user_id=@UserId";
            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@UserId", userId)
            );
        }

        // Get all users
        public static List<UserBL> GetAllUsers()
        {
            string query = "SELECT * FROM users";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<UserBL> userList = new List<UserBL>();

            foreach (DataRow row in dt.Rows)
            {
                userList.Add(new UserBL(
                    Convert.ToInt32(row["user_id"]),
                    row["name"].ToString(),
                    row["password_hash"].ToString(),
                    row["role"].ToString()
                ));
            }
            return userList;
        }

        // Get user by ID
        public static UserBL GetUserById(int userId)
        {
            string query = "SELECT * FROM users WHERE user_id=@UserId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@UserId", userId)
            );

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new UserBL(
                    Convert.ToInt32(row["user_id"]),
                    row["name"].ToString(),
                    row["password_hash"].ToString(),
                    row["role"].ToString()
                );
            }
            return null;
        }

        // Authenticate user by email + password + role
        public static UserBL AuthenticateUser(string username, string passwordHash, string role)
        {
            string query = "SELECT * FROM users WHERE username= @Name AND password_hash=@Password AND role=@Role";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@Name", username),
                new MySqlParameter("@Password", passwordHash),
                new MySqlParameter("@Role", role)
            );

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new UserBL(
                    Convert.ToInt32(row["user_id"]),
                    row["username"].ToString(),
                    row["password_hash"].ToString(),
                    row["role"].ToString()
                );
            }
            return null;
        }

    }
}
