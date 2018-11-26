using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace SNCompareWithExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBoxSN.KeyDown += new KeyEventHandler(textBoxSN_KeyDown);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
 
            openFileDialog.Title = "选择文件";
            openFileDialog.Filter = "CSV (逗号分隔)(*.csv)|*.csv";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = openFileDialog.FileName;
                textBoxSN.Enabled = true;
                textBoxSN.Text = "";
            }

            openFileDialog.Dispose();
        }

        private void textBoxSN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (textBoxFile.Text.Length > 0) && (textBoxSN.Text.Length > 0))
            {
                bool flagFailed = false;
                using (TextFieldParser parser = new TextFieldParser(textBoxFile.Text))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            if (field == textBoxSN.Text)
                            {
                                labelResult.BackColor = Color.Red;
                                labelResult.Text = "FAIL";
                                flagFailed = true;
                                break;
                            }
                        }

                        if (flagFailed == true)
                        {
                            break;
                        }
                    }

                    if (flagFailed != true)
                    {
                        labelResult.BackColor = Color.Green;
                        labelResult.Text = "PASS";
                    }
                }

                textBoxSN.Text = "";
            }
        }
    }
}
