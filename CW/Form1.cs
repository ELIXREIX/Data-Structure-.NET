using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Collections;

namespace CW
{
    public partial class Form1 : Form
    {
        Collection x = new Arrayset(5);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchText = textBox2.Text;
            bool textExists = x.Contains(searchText);
            textBox2.Clear();
            if (textExists)
            {
                MessageBox.Show("The text exists in the collection.");
            }
            else
            {
                MessageBox.Show("The text does not exist in the collection.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            x.Add(textBox1.Text);
            UpdateCountLabel();
            textBox1.Clear();
            MessageBox.Show("The text was add in the collection.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string textToDelete = textBox3.Text; 
            bool textExists = x.Contains(textToDelete);
            textBox3.Clear();
            if (textExists)
            {
                x.remove(textToDelete);
                UpdateCountLabel();
                MessageBox.Show("The text has been removed from the collection.");
            }
            else
            {
                MessageBox.Show("The text was not found in the collection.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateCountLabel()
        {
            label1.Text = "Contains: " + x.size(); 
        }
    }
}
