using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            HowToForm f2 = new HowToForm();
            f2.Show();
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();
            employeeInfo.Show();
            this.Hide();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            register  register = new register();
            register.Show();
            this.Hide();
        }
    }
}
