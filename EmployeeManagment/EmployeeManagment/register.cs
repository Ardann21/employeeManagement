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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeManagment
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        static string conString = @"Data Source=DESKTOP-9O1N3H5;Initial Catalog=EmployeeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                    con.Open(); // Open database connection

                    // Create SQL command to insert a new employee
                    using (SqlCommand insert = new SqlCommand("insert into Employee values(@employeeid,@employeename,@email,@salary)", con))
                    {
                        // Add parameter values to prevent SQL injection
                        insert.Parameters.AddWithValue("@EmployeeId", int.Parse(textBoxId.Text));
                        insert.Parameters.AddWithValue("@EmployeeName", textBoxName.Text);
                        insert.Parameters.AddWithValue("@Email", textBoxMail.Text);
                        insert.Parameters.AddWithValue("@Salary", int.Parse(textBoxSalary.Text));

                        // Execute the insert command
                        insert.ExecuteNonQuery();
                    }

                    // Display success message to the user
                    MessageBox.Show("Record Saved Successfully");
                
            }
            catch (Exception ex)
            {
                // Catch any errors and display a meaningful message
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                    con.Open(); // Open the database connection

                    // Create a update SQL command with parameter to prevent SQL injection
                    using (SqlCommand update = new SqlCommand("UPDATE Employee SET salary = @Salary WHERE employeeid = @EmployeeId", con))
                    {
                        update.Parameters.AddWithValue("@EmployeeId", int.Parse(textBoxId.Text));
                        update.Parameters.AddWithValue("@Salary", int.Parse(textBoxSalary.Text));

                        // Execute the delete command
                        update.ExecuteNonQuery();
                    }

                    // Display a confirmation message to the user
                    MessageBox.Show("Record Updated Successfully");
                
            }
            catch (Exception ex)
            {
                // Display an error message if the deletion fails
                MessageBox.Show($"An error occurred while updating data: {ex.Message}");
            }
        }

        // Button click event to delete an employee record by ID
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                    con.Open(); // Open the database connection

                    // Create a delete SQL command with parameter to prevent SQL injection
                    using (SqlCommand delete = new SqlCommand("delete Employee where employeeid=@employeeid", con))
                    {
                        delete.Parameters.AddWithValue("@EmployeeId", int.Parse(textBoxId.Text));

                        // Execute the delete command
                        delete.ExecuteNonQuery();
                    }

                    // Display a confirmation message to the user
                    MessageBox.Show("Record Deleted Successfully");
                
            }
            catch (Exception ex)
            {
                // Display an error message if the deletion fails
                MessageBox.Show($"An error occurred while deleting data: {ex.Message}");
            }
        }

        // Button click event to clear input fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all text boxes to reset the input fields
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxMail.Text = "";
            textBoxSalary.Text = "";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 back = new Form1();
            back.Show();
        }

        
    }
}
