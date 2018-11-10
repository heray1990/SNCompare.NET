using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNCompareWithExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
 
            openFileDialog.Title = "选择文件";
            openFileDialog.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            openFileDialog.Multiselect = false;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = openFileDialog.FileName;
            }

            openFileDialog.Dispose();
        }
    }
}
