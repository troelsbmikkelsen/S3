using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public abstract class DatabaseAccess {
        /// <summary>
        /// Connectionstring must be set before using any method in this class.
        /// </summary>
        protected string connectionString = "";
        //protected static string connectionString = @"Data Source = CV-PC-T-04\SQLEXPRESS; Initial Catalog = EksamenEksempel; Integrated Security = True";
        //private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Test.mdf;Integrated Security=True;Connect Timeout=30";
        static DatabaseAccess() {
            Trace.Listeners.Add(new TextWriterTraceListener("DatabaseAccess_ErrorLog.txt"));
            Trace.AutoFlush = true;
        }

        /// <summary>
        /// Select with stored procedure
        /// </summary>
        /// <param name="query">Stored procedure</param>
        /// <param name="parameters">Parameters for stored procedure</param>
        /// <returns>DataTable</returns>
        /// <exception cref="SqlException">Thrown when database access somehow fails</exception>
        protected bool SelectSP(DataTable datatable, string query, params SqlParameter[] parameters) {

            try {
                using (SqlConnection myConnection = new SqlConnection(connectionString)) {
                    // Open connection
                    myConnection.Open();

                    // Using a SqlDataAdapter fetch data from database with query and parameters
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection)) {
                        // Make commandtype stored procedure
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        // For each parameter, add it to the command
                        foreach (var param in parameters) {
                            adapter.SelectCommand.Parameters.Add(param);
                        }
                        // Fill datatable with adapter
                        adapter.Fill(datatable);
                    }

                }
            } catch (Exception ex) {
                // For debug, write out exception message
                Debug.WriteLine($"Exception: {ex.Message}");
                // Log Exception message
                Trace.TraceError($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} : {ex.Message}");
                // Return false to let caller know, that method failed.
                return false;
            }

            // Return true, if method succeeds.
            return true;
        }

        /// <summary>
        /// Select with regular query
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="parameters">Parameters for SQL query</param>
        /// <returns></returns>
        protected bool Select(DataTable datatable, string query, params SqlParameter[] parameters) {

            try {
                using (SqlConnection myConnection = new SqlConnection(connectionString)) {
                    // Open connection
                    myConnection.Open();

                    // Using a SqlDataAdapter fetch data from database with query and parameters
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection)) {

                        // For each parameter, add it to the command
                        foreach (var param in parameters) {
                            adapter.SelectCommand.Parameters.Add(param);
                        }
                        // Fill datatable with adapter
                        adapter.Fill(datatable);
                    }

                }
            } catch (Exception ex) {
                // For debug, write out exception message
                Debug.WriteLine($"Exception error: {ex.Message}");
                // Log Exception message
                Trace.TraceError($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} : {ex.Message}");
                // Return false to let caller know, that method failed.
                return false;
            }

            // Return true, if method succeeds.
            return true;
        }

        protected bool NonQuerySP(string query, params SqlParameter[] parameters) {
            try {
                using (SqlConnection myConnection = new SqlConnection(connectionString)) {
                    // Open connection
                    myConnection.Open();

                    // Using a SqlDataAdapter fetch data from database with query and parameters
                    using (SqlCommand command = new SqlCommand(query, myConnection)) {
                        // Make commandtype stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // For each parameter, add it to the command
                        foreach (var param in parameters) {
                            command.Parameters.Add(param);
                        }
                        // Execute non query
                        command.ExecuteNonQuery();
                    }

                }
            } catch (Exception ex) {
                // For debug, write out exception message
                Debug.WriteLine($"Exception error: {ex.Message}");
                // Log Exception message
                Trace.TraceError($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} : {ex.Message}");
                // Return false to let caller know, that method failed.
                return false;
            }

            // Return true, if method succeeds.
            return true;
        }

        protected bool NonQuery(string query, params SqlParameter[] parameters) {
            try {
                using (SqlConnection myConnection = new SqlConnection(connectionString)) {
                    // Open connection
                    myConnection.Open();

                    // Using a SqlDataAdapter fetch data from database with query and parameters
                    using (SqlCommand command = new SqlCommand(query, myConnection)) {

                        // For each parameter, add it to the command
                        foreach (var param in parameters) {
                            command.Parameters.Add(param);
                        }
                        // Execute non query
                        command.ExecuteNonQuery();
                    }

                }
            } catch (Exception ex) {
                // For debug, write out exception message
                Debug.WriteLine($"Exception error: {ex.Message}");
                // Log Exception message
                Trace.TraceError($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} : {ex.Message}");
                // Return false to let caller know, that method failed.
                return false;
            }

            // Return true, if method succeeds.
            return true;
        }
    }
}
