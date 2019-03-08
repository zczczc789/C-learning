using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openNew = new OpenFileDialog();
            openNew = openFileDialog1;
            openNew.ValidateNames = true;
            openNew.CheckPathExists = true;
            openNew.CheckFileExists = true;
             if (openNew.ShowDialog()==DialogResult.OK)
             {
                openNew.Title = "打开文件";
                openNew.Filter = "所有文件|*.*|文本文件|*.txt|图片文件|*.png|文本文档|*.doc";
                string path = openNew.FileName;
                textBox1.Text = path;
             }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder= folderBrowserDialog1;
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {

                string sPath = folder.SelectedPath;
                textBox2.Text = sPath;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string path1=textBox1.Text;
            string path2=textBox2.Text;
          
            if (!(string.IsNullOrEmpty(path1) || string.IsNullOrEmpty(path2)))
            {
                if (File.Exists(path1))
                {
                    if(path2.Contains("."))
                    {
                         File.Move(path1, path2);
                    }
                    else
                    { 
                        string extension=Path.GetExtension("path1");
                          File.Move(path1,path2+extension);
                    }
                      
                }
                else
                    MessageBox.Show("文件不存在","提示：",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
