using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            genericListe<int> g = new genericListe<int>();
            g.Add(12345);
            g.Insert(0, 321);
            g.Add(222);
            g.RemoveAt(1);
            MessageBox.Show(g[1].ToString());
        }
    }
}
