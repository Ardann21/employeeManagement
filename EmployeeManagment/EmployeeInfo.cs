using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagment
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        static string conString = @"Data Source=DESKTOP-9O1N3H5;Initial Catalog=EmployeeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);




        // Button click event to refresh the employee data in the DataGridView
        private void showEmployeeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to the database and retrieve all employee records

                SqlCommand cmd = new SqlCommand("select * from Employee", con);
                    
                        // Use SqlDataAdapter to fill a DataTable with employee data
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView to display the data
                        dataGridView1.DataSource = dataTable; 
                    
                
            }
            catch (Exception ex)
            {
                // Display an error message if data load fails
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            
                try
                {
                    con.Open();

                    // SQL query with parameter
                    
                    using (SqlCommand search = new SqlCommand("SELECT * FROM Employee WHERE employeeid = @employeeid", con))
                    {
                        // Set the parameter value
                        search.Parameters.AddWithValue("@employeeid", searchText.Text);

                        // Fill the DataTable with search results
                        DataTable searchDataTable = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(search))
                        {
                            adapter.Fill(searchDataTable);
                        }

                        // Bind the search results to the DataGridView
                        dataGridView1.DataSource = searchDataTable;

                        if (searchDataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No records found for the given Employee ID. ");
                        }
                    }
                con.Close();
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        
        

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 back = new Form1();
            back.Show();
        }

       
    }
    }

