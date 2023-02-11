using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab11
{
    public partial class Form1 : Form
    {

        //Drives appearance

        DriveInfo[] my_Drives = DriveInfo.GetDrives();

        DirectoryInfo Directory_Item;
        string selected;
        string selected1;
        bool flag1 = false;
        bool flag2 = false;
        string last_change;
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.AddRange(my_Drives);
            listBox2.Items.AddRange(my_Drives);
        }

        //selection for listbox 1
        private void listBox1_Click(object sender, EventArgs e)
        {
            selected= listBox1.SelectedItem.ToString();
            flag1 = true;
            flag2 = false;
        }


        //open selection components
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (selected == ".")
                {
                    listBox1.Items.Clear();

                    if (textBox1.Text.Length < 4)
                    {
                        listBox1.Items.AddRange(my_Drives);
                    }

                    else
                    {
                        string parent = Directory.GetParent(textBox1.Text).ToString();

                        foreach (string entry in Directory.GetDirectories(parent))
                        {
                            listBox1.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(parent))
                        {
                            listBox1.Items.Add(entry);
                        }

                        listBox1.Items.Add(".");
                        listBox1.Items.Add("..");

                        flag1 = true;
                        flag2 = false;

                        textBox1.Text = parent;
                    }
                }

                else if (selected == "..") 
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(my_Drives);

                }
                else

                {

                    listBox1.Items.Clear();


                    foreach (string entry in Directory.GetDirectories(selected))
                    {
                        listBox1.Items.Add(entry);

                    }

                    foreach (string entry in Directory.GetFiles(selected))
                    {
                        listBox1.Items.Add(entry);
                    }
                    listBox1.Items.Add(".");
                    listBox1.Items.Add("..");
                    last_change = textBox1.Text;
                    flag1 = true;
                    flag2 = false;
                    textBox1.Text = selected;

                }

                
            }

            catch
            {

         
                MessageBox.Show("Can't open file");

                foreach (string entry in Directory.GetDirectories(textBox1.Text))
                {
                    listBox1.Items.Add(entry);

                }

                foreach (string entry in Directory.GetFiles(textBox1.Text))
                {
                    listBox1.Items.Add(entry);
                }

                listBox1.Items.Add(".");
                listBox1.Items.Add("..");
            }
  
        }

        //selection for listbox 2
        private void listBox2_Click(object sender, EventArgs e)
        {
            selected1 = listBox2.SelectedItem.ToString();
            flag1 = false;
            flag2 = true;
        }

        //open selection component
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ( selected1 == ".")
                {
                    listBox2.Items.Clear();

                    if (textBox2.Text.Length < 4)
                    {
                        listBox2.Items.AddRange(my_Drives);
                    }

                    else
                    {
                        string parent2 = Directory.GetParent(textBox2.Text).ToString();

                        foreach (string entry in Directory.GetDirectories(parent2))
                        {
                            listBox2.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(parent2))
                        {
                            listBox2.Items.Add(entry);
                        }

                        listBox2.Items.Add(".");
                        listBox2.Items.Add("..");

                        flag1 = false;
                        flag2 = true;

                        textBox2.Text = parent2;
                    }
                }

                else if (selected1 == "..") 
                {

                    listBox2.Items.Clear();
                    listBox2.Items.AddRange(my_Drives);
                }

                else
                {

                    listBox2.Items.Clear();
                    foreach (string entry in Directory.GetDirectories(selected1))
                    {
                        listBox2.Items.Add(entry);

                    }

                    foreach (string entry in Directory.GetFiles(selected1))
                    {
                        listBox2.Items.Add(entry);
                    }
                    listBox2.Items.Add(".");
                    listBox2.Items.Add("..");
                    last_change = textBox2.Text;
                    flag1 = false;
                    flag2 = true;

                    textBox2.Text = selected1;
                }
            }
                
            catch
            {


                MessageBox.Show("Can't open file");


                foreach (string entry in Directory.GetDirectories(textBox2.Text))
                {
                    listBox2.Items.Add(entry);

                }

                foreach (string entry in Directory.GetFiles(textBox2.Text))
                {
                    listBox2.Items.Add(entry);
                }

                listBox2.Items.Add(".");
                listBox2.Items.Add("..");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag1 == true)
            {
                listBox1.Items.Clear();

                if (textBox1.Text.Length < 4)
                {
                    listBox1.Items.AddRange(my_Drives);
                }

                else
                {
                    string parent = Directory.GetParent(textBox1.Text).ToString();

                    foreach (string entry in Directory.GetDirectories(parent))
                    {
                        listBox1.Items.Add(entry);

                    }

                    foreach (string entry in Directory.GetFiles(parent))
                    {
                        listBox1.Items.Add(entry);
                    }

                    listBox1.Items.Add(".");
                    listBox1.Items.Add("..");

                    flag1 = true;
                    flag2 = false;

                    textBox1.Text = parent;
                }
            }

                if (flag2 == true) 
                {
                    listBox2.Items.Clear();

                    if (textBox2.Text.Length < 4)
                    {
                        listBox2.Items.AddRange(my_Drives);
                        textBox2.Text = "";
                    }

                    else
                    {
                        string parent2 = Directory.GetParent(textBox2.Text).ToString();

                        foreach (string entry in Directory.GetDirectories(parent2))
                        {
                            listBox2.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(parent2))
                        {
                            listBox2.Items.Add(entry);
                        }

                    listBox2.Items.Add(".");
                    listBox2.Items.Add("..");
                    flag1 = false;
                        flag2 = true;

                        textBox2.Text = parent2;
                    
                }
                
            }
        }

        //Moving from listbox 1 to listbox 2
        private void button4_Click(object sender, EventArgs e)
        {
            Directory_Item = new DirectoryInfo(selected);
            File.Move(selected, selected1 + "/" + Directory_Item.Name);
            listBox1.Items.Clear();

            foreach (string entry in Directory.GetDirectories(textBox1.Text))
            {
                listBox1.Items.Add(entry);

            }

            foreach (string entry in Directory.GetFiles(textBox1.Text))
            {
                listBox1.Items.Add(entry);
            }

            listBox1.Items.Add(".");
            listBox1.Items.Add("..");
        }


        //moving from listbox 2 to listbox 1
        private void button5_Click(object sender, EventArgs e)
        {
            Directory_Item = new DirectoryInfo(selected);
            File.Move(selected1, selected + "/" + Directory_Item.Name);
            listBox2.Items.Clear();

            foreach (string entry in Directory.GetDirectories(textBox2.Text))
            {
                listBox2.Items.Add(entry);

            }

            foreach (string entry in Directory.GetFiles(textBox2.Text))
            {
                listBox2.Items.Add(entry);
            }

            listBox2.Items.Add(".");
            listBox2.Items.Add("..");
        }

        //Copying files
        private void button1_Click(object sender, EventArgs e)
        {
          
                if (listBox1.SelectedItem != null && listBox2.SelectedItem != null)
                {
                    if ( flag1 == true )
                    {
                         string destinationFile = Path.Combine(selected1, Path.GetFileName(selected));
                        
                        try
                        {
                            File.Copy(selected, destinationFile, true);

                            listBox2.Items.Clear();


                        foreach (string entry in Directory.GetDirectories(textBox2.Text))
                        {
                            listBox2.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(textBox2.Text))
                        {
                            listBox2.Items.Add(entry);
                        }

                        listBox2.Items.Add(".");
                        listBox2.Items.Add("..");

                        MessageBox.Show("File copied successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error copying file: " + ex.Message);
                        }
                    }
     

                    if (flag2 == true)
                    {
                        string destinationFile = Path.Combine(selected, Path.GetFileName(selected1));

                        try
                        {
                            File.Copy(selected1, destinationFile, true);
                            listBox2.Items.Clear();


                        foreach (string entry in Directory.GetDirectories(textBox1.Text))
                        {
                            listBox1.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(textBox1.Text))
                        {
                            listBox1.Items.Add(entry);
                        }

                        listBox2.Items.Add(".");
                        listBox2.Items.Add("..");
                        MessageBox.Show("File copied successfully");
                        }
                        catch (Exception ex)
                        {
                             MessageBox.Show("Error copying file: " + ex.Message);
                        }
                    }
    
                }

        }


        //Deleting files
        private void button2_Click(object sender, EventArgs e)
        {
            if ( flag1  == true)
            {
                if (File.Exists(selected))
                {
                    try
                    {
                        File.Delete(selected);

                        listBox1.Items.Clear();


                        foreach (string entry in Directory.GetDirectories(textBox1.Text))
                        {
                            listBox1.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(textBox1.Text))
                        {
                            listBox1.Items.Add(entry);
                        }

                        listBox1.Items.Add(".");
                        listBox1.Items.Add("..");
                    }

                    catch (IOException o)
                    {
                        MessageBox.Show(o.Message);
                    }


                }
                else if (Directory.Exists(selected))

                {
                    try
                    {
                        Directory.Delete(selected);

                        listBox1.Items.Clear();


                        foreach (string entry in Directory.GetDirectories(textBox1.Text))
                        {
                            listBox1.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(textBox1.Text))
                        {
                            listBox1.Items.Add(entry);
                        }

                        listBox1.Items.Add(".");
                        listBox1.Items.Add("..");
                    }

                    catch (IOException o)
                    {
                        MessageBox.Show(o.Message);
                    }

                } 

            }

            if (flag2 == true)
            {
              if (File.Exists(selected1))
                {
                    try
                    {
                        File.Delete(selected1);

                        listBox2.Items.Clear();


                        foreach (string entry in Directory.GetDirectories(textBox2.Text))
                        {
                            listBox2.Items.Add(entry);

                        }

                        foreach (string entry in Directory.GetFiles(textBox2.Text))
                        {
                            listBox2.Items.Add(entry);
                        }

                        listBox2.Items.Add(".");
                        listBox2.Items.Add("..");
                    }

                    catch (IOException o)
                    {
                        MessageBox.Show(o.Message);
                    }
                 }

                  else if (Directory.Exists(selected1))

                     {
                        try
                        {
                            Directory.Delete(selected1);

                            listBox2.Items.Clear();


                            foreach (string entry in Directory.GetDirectories(textBox2.Text))
                            {
                                listBox2.Items.Add(entry);

                            }

                            foreach (string entry in Directory.GetFiles(textBox2.Text))
                            {
                                listBox2.Items.Add(entry);
                            }

                        listBox2.Items.Add(".");
                        listBox2.Items.Add("..");
                    }

                        catch (IOException o)
                        {
                            MessageBox.Show(o.Message);
                        }

                }
            }
        }
    }
 }

