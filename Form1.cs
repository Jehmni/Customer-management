using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Task_b
{
    public partial class Form1 : Form
    {
        private CustomerQueue customerQueue = new CustomerQueue();  // Creates an instance of the CustomerQueue

        public Form1()
        {
            InitializeComponent();
            UpdateListBox();  // Calls the method to update the listbox
        }

        // Event handler for the button that adds to the queue
        private void btn_add_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();  // Reads what the user enters in the textbox
            if (name.Length > 0)  // Checks that a valid name was entered
            {
                try
                {
                    customerQueue.Enqueue(name);  // Calls the enqueue method of the CustomerQueue class
                    UpdateListBox();  // Calls this method to update the listbox
                    MessageBox.Show($"Added customer {name} to the database");
                    txtName.Clear();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Customer add: operation failed");
                }
            }
            else
            {
                MessageBox.Show("Please enter a customer's name");
            }
            txtName.Clear();
        }

        // Event handler for the remove button
        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                string name = customerQueue.Dequeue();  // Calls the dequeue method of the CustomerQueue class
                UpdateListBox();
                MessageBox.Show($"Deleted customer {name} from the database");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("No customer in the database");
            }
        }

        private void UpdateListBox()  // Method to update the listbox
        {
            listBox1.DataSource = null;
            listBox1.DataSource = customerQueue.GetQueue();  // Calls the getqueue method of CustomerQueue to populate the listbox
            count.Text = "Number of customers: " + customerQueue.Count().ToString();  // Updates the count label
        }

    }
}