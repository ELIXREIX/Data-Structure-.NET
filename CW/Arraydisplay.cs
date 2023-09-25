﻿using Collections;
using System;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CW
{
    public partial class Arraydisplay : Form
    {
        Collection x = new Arraylist(5);
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
            try
            {
                int indexToSearch = int.Parse(textBox2.Text); // Parse the index from textBox4
                if (indexToSearch >= 0 && indexToSearch < x.size())
                {
                    object message = x.get(indexToSearch); // Get the message at the specified index
                    textBox3.Text = message.ToString(); // Display the message in textBox5
                }
                else
                {
                    textBox3.Text = "Index is out of range.";
                }
            }
            catch (FormatException)
            {
                textBox3.Text = "Invalid index. Please enter a valid number.";
            }
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(textBox2.Text); 
                if (index >= 0 && index < x.size())
                {
                    object ea = x.get(index);
                    string newText = textBox3.Text;
                    ea = newText;
                    x.set(index, ea); // Set the new text at the specified index
                    UpdateCountLabel(); // Update the count label
                    MessageBox.Show("The text at index " + index + " has been updated.");
                }
                else
                {
                    MessageBox.Show("Index is out of range.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid index or new text. Please enter valid values.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StringBuilder allObjects = new StringBuilder();

            // Iterate through the collection and add all objects to the result
            for (int i = 0; i < x.size(); i++)
            {
                object obj = x.get(i);
                allObjects.AppendLine(obj.ToString()); // Add object to the result
            }

            textBox4.Text = allObjects.ToString(); // Display all objects in textBox8
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
