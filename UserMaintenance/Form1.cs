using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Text = Resource1.Delete;
            button3.Click += Button3_Click;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Write;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var torlendo = (User)listBox1.SelectedItem;
            users.Remove(torlendo);
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Seperated Values (*.txt)|*.txt";
            sfd.DefaultExt = "txt";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var u in users)
                {
                    sw.Write(u.FullName);
                    sw.Write(";");
                    sw.Write(value: u.ID);
                    sw.WriteLine();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
               FullName = textBox1.Text,
              
            };
            users.Add(u);
        }
    }
}
