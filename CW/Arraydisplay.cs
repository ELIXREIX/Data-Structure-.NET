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
    public partial class Arraydisplay : Form
    {
        Collection x = new ArrayList(5);
        public Arraydisplay()
        {
            InitializeComponent();
        }

        private void Arraydisplay_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x.Add(textBox1.Text);
            UpdateCountLabel();
            textBox1.Clear();
            MessageBox.Show("The text was add in the collection.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            bool textExists = x.Contains(searchText);
            textBox1.Clear();
            if (textExists)
            {
                MessageBox.Show("The text exists in the collection.");
            }
            else
            {
                MessageBox.Show("The text does not exist in the collection.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string textToDelete = textBox1.Text;
            bool textExists = x.Contains(textToDelete);
            textBox1.Clear();
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
        private void UpdateCountLabel()
        {
            label1.Text = "Contains: " + x.size();
        }
    
}
}
