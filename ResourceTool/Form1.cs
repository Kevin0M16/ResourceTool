using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ResourceTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string RPath { get; private set; }

        public static void AppendLine(TextBox source, string value)
        {
            //My neat little textbox handler
            if (source.Text.Length == 0)
                source.Text = value;
            else
                source.AppendText("\r\n" + value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            MessageBox.Show("Copied to Clipboard!", "Clipboard", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();


            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                RPath = textBox2.Text;
            }
            //If nmsPath is not found, show message and return
            if (!Directory.Exists(RPath))
            {
                MessageBox.Show("Path not Found!", "Alert", MessageBoxButtons.OK);
                return;
            }

            //Search for hg files in the current dir
            DirectoryInfo dinfo = new DirectoryInfo(RPath);
            FileInfo[] Files = dinfo.GetFiles("*.ytd", SearchOption.AllDirectories);

            List<string> list = new List<string>();
            // Set to false for no duplicates
            textBox4.Text = "FALSE";

            //if hg files are found, start adding them to dictionaries
            if (Files.Length != 0)
            {
                foreach (FileInfo file in Files.OrderByDescending(f => f.LastWriteTime))
                {
                    if (!file.Name.Contains("+") && !file.Name.Contains("vehicles") && !file.Name.Contains("share"))
                    {
                        string name = Path.GetFileNameWithoutExtension(file.FullName);
                        
                        if (!list.Contains(name))
                        {
                            list.Add("\"" + name + "\",");                        
                        }
                        else
                        {
                            // Show true if duplicates are found
                            textBox4.Text = "TRUE";
                        }
                    }                    
                }

                // Show how many files
                textBox3.Text = list.Count.ToString();

                foreach (string item in list)
                {
                    AppendLine(textBox1, item);
                }
            }
        }        

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();


            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                RPath = textBox2.Text;
            }
            //If nmsPath is not found, show message and return
            if (!Directory.Exists(RPath))
            {
                MessageBox.Show("Path not Found!", "Alert", MessageBoxButtons.OK);
                return;
            }

            //Search for hg files in the current dir
            DirectoryInfo dinfo = new DirectoryInfo(RPath);
            //FileInfo[] Files = dinfo.GetFiles("*.ytd", SearchOption.AllDirectories);
            FileInfo[] Files = dinfo.GetFiles("*.*", SearchOption.AllDirectories);

            List<string> list = new List<string>();

            // Set to false for no duplicates
            textBox4.Text = "FALSE";

            //if hg files are found, start adding them to dictionaries
            if (Files.Length != 0)
            {
                foreach (FileInfo file in Files.OrderByDescending(f => f.LastWriteTime))
                {
                    //if (!file.Name.Contains("+") && !file.Name.Contains("vehicles") && !file.Name.Contains("share"))
                    //{
                    string name = Path.GetFileNameWithoutExtension(file.FullName);

                    if (!list.Contains(file.Name))
                    {
                        list.Add("\"" + file.Name + "\",");
                    }
                    else
                    {
                        // Show true if duplicates are found
                        textBox4.Text = "TRUE";
                    }
                    //}                    
                }

                // Show how many files
                textBox3.Text = list.Count.ToString();

                foreach (string item in list)
                {
                    AppendLine(textBox1, item);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();


            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                RPath = textBox2.Text;
            }
            //If nmsPath is not found, show message and return
            if (!Directory.Exists(RPath))
            {
                MessageBox.Show("Path not Found!", "Alert", MessageBoxButtons.OK);
                return;
            }

            //Search for hg files in the current dir
            DirectoryInfo dinfo = new DirectoryInfo(RPath);
            //FileInfo[] Files = dinfo.GetFiles("*.ytd", SearchOption.AllDirectories);
            FileInfo[] Files = dinfo.GetFiles("*.*", SearchOption.AllDirectories);

            List<string> list = new List<string>();

            // Set to false for no duplicates
            textBox4.Text = "FALSE";

            //if hg files are found, start adding them to dictionaries
            if (Files.Length != 0)
            {
                foreach (FileInfo file in Files.OrderByDescending(f => f.LastWriteTime))
                {
                    //if (!file.Name.Contains("+") && !file.Name.Contains("vehicles") && !file.Name.Contains("share"))
                    //{
                    string name = Path.GetFileNameWithoutExtension(file.FullName);

                    if (!list.Contains(file.Name))
                    {
                        list.Add("\"" + file.Name + "\",");
                    }
                    else
                    {
                        // Show true if duplicates are found
                        textBox4.Text = "TRUE";
                    }
                    //}                    
                }

                // Show how many files
                textBox3.Text = list.Count.ToString();

                foreach (string item in list)
                {
                    AppendLine(textBox1, item);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();


            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                RPath = textBox2.Text;
            }
            //If nmsPath is not found, show message and return
            if (!Directory.Exists(RPath))
            {
                MessageBox.Show("Path not Found!", "Alert", MessageBoxButtons.OK);
                return;
            }

            //Search for hg files in the current dir
            DirectoryInfo dinfo = new DirectoryInfo(RPath);
            //FileInfo[] Files = dinfo.GetFiles("*.ytd", SearchOption.AllDirectories);
            DirectoryInfo[] dirs = dinfo.GetDirectories("*.*", SearchOption.AllDirectories);

            List<string> list = new List<string>();

            // Set to false for no duplicates
            textBox4.Text = "FALSE";

            //if hg files are found, start adding them to dictionaries
            if (dirs.Length != 0)
            {
                foreach (DirectoryInfo dir in dirs.OrderByDescending(f => f.LastWriteTime))
                {
                    if (!dir.Name.Contains("stream") && !dir.Name.Contains("["))
                    {
                    string name = Path.GetFileNameWithoutExtension(dir.FullName);

                    if (!list.Contains(dir.Name))
                    {
                        list.Add("\"" + dir.Name + "\",");
                    }
                    else
                    {
                        // Show true if duplicates are found
                        textBox4.Text = "TRUE";
                    }
                    }                    
                }

                // Show how many files
                textBox3.Text = list.Count.ToString();

                foreach (string item in list)
                {
                    AppendLine(textBox1, item);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();


            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                RPath = textBox2.Text;
            }
            //If nmsPath is not found, show message and return
            if (!Directory.Exists(RPath))
            {
                MessageBox.Show("Path not Found!", "Alert", MessageBoxButtons.OK);
                return;
            }

            //Search for hg files in the current dir
            DirectoryInfo dinfo = new DirectoryInfo(RPath);
            //FileInfo[] Files = dinfo.GetFiles("*.ytd", SearchOption.AllDirectories);
            FileInfo[] Files = dinfo.GetFiles("*.ymap", SearchOption.AllDirectories);

            List<string> list = new List<string>();

            // Set to false for no duplicates
            textBox4.Text = "FALSE";

            //if hg files are found, start adding them to dictionaries
            if (Files.Length != 0)
            {
                foreach (FileInfo file in Files.OrderByDescending(f => f.LastWriteTime))
                {
                    //if (!file.Name.Contains("+") && !file.Name.Contains("vehicles") && !file.Name.Contains("share"))
                    //{
                    string name = Path.GetFileNameWithoutExtension(file.FullName);

                    if (!list.Contains(file.Name))
                    {
                        list.Add("\"" + file.Name + "\",");
                    }
                    else
                    {
                        // Show true if duplicates are found
                        textBox4.Text = "TRUE";
                    }
                    //}                    
                }

                // Show how many files
                textBox3.Text = list.Count.ToString();

                foreach (string item in list)
                {
                    AppendLine(textBox1, item);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();


            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                RPath = textBox2.Text;
            }
            //If nmsPath is not found, show message and return
            if (!Directory.Exists(RPath))
            {
                MessageBox.Show("Path not Found!", "Alert", MessageBoxButtons.OK);
                return;
            }

            //Search for hg files in the current dir
            DirectoryInfo dinfo = new DirectoryInfo(RPath);
            FileInfo[] Files = dinfo.GetFiles("*.ytd", SearchOption.AllDirectories);

            List<string> list = new List<string>();
            // Set to false for no duplicates
            textBox4.Text = "FALSE";

            //if hg files are found, start adding them to dictionaries
            if (Files.Length != 0)
            {
                foreach (FileInfo file in Files.OrderByDescending(f => f.LastWriteTime))
                {
                    if (!file.Name.Contains("+") && !file.Name.Contains("vehicles") && !file.Name.Contains("share"))
                    {
                        string name = Path.GetFileNameWithoutExtension(file.FullName);

                        if (!list.Contains(name))
                        {
                            list.Add(@"<Item><Name>" + name + @"</Name><Variations type=""NULL""/></Item>");
                        }
                        else
                        {
                            // Show true if duplicates are found
                            textBox4.Text = "TRUE";
                        }
                    }
                }

                // Show how many files
                textBox3.Text = list.Count.ToString();

                foreach (string item in list)
                {
                    AppendLine(textBox1, item);
                }
            }
        }
    }
}
