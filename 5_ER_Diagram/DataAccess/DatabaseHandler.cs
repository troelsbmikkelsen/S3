using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class DatabaseHandler : DatabaseAccess {
        User errorUser = new User() { id = -1, username = "error", password = "error" };

        public DatabaseHandler() {
            connectionString = @"Data Source = CV-PC-T-04\SQLEXPRESS; Initial Catalog = ER_Diagram_Intro; Integrated Security = True";
        }

        public User GetUserBy(int id) {
            DataTable userData = new DataTable();

            if (Select(userData, "SELECT * FROM Users WHERE id = @id", new SqlParameter("id", id))) {
                if (userData.Rows.Count > 0) {
                    User u = new User() {
                        id = (int)userData.Rows[0]["id"],
                        username = (string)userData.Rows[0]["username"],
                        password = (string)userData.Rows[0]["password"]
                    };
                    return u;
                }
                return errorUser;
            } else {
                return errorUser;
            }
        }

        public User GetUserBy(string name) {
            DataTable userData = new DataTable();

            if (Select(userData, "SELECT * FROM Users WHERE username = @username", new SqlParameter("username", name))) {
                if (userData.Rows.Count > 0) {
                    User u = new User() {
                        id = (int)userData.Rows[0]["id"],
                        username = (string)userData.Rows[0]["username"],
                        password = (string)userData.Rows[0]["password"]
                    };
                    return u;
                }
                return errorUser;
            } else {
                return errorUser;
            }




        }

        public void SaveUser(User user) {
            if (GetUserBy(user.id).username == "error") {
                NonQuery("INSERT INTO Users VALUES(@username, @password)", new SqlParameter("username", user.username), new SqlParameter("password", user.password));
            } else {
                NonQuery("UPDATE Users SET username=@username, password=@password WHERE id=@id", new SqlParameter("username", user.username), new SqlParameter("password", user.password), new SqlParameter("id", user.id));
            }
        }
    }
}
