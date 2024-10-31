using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Account.src {
    public class Register {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        private static string connstring = $"server=127.0.0.1;uid=root;pwd={Environment.GetEnvironmentVariable("CONN_PASS")};database=finals";
        MySqlConnection conn = new MySqlConnection(connstring);


        public string login(Register account) {
            string username = null;

            using (conn) {
                try {
                    conn.Open();
                    string query = "SELECT username FROM useraccount WHERE username = @username AND password = @password";
                    using (var cmd = new MySqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@username", Username);
                        cmd.Parameters.AddWithValue("@password", Password);

                        object result = cmd.ExecuteScalar();

                        if (result != null) {
                            username = result.ToString();
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return username;
        }
    }
}
