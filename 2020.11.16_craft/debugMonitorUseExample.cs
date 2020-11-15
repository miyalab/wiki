using System;
using System.Windows.Forms;

using MiYALAB.CSharp;

namespace TestApp
{
    public partial class Form1 : Form
    {
        // インスタンス生成例
        DebugMonitor debugMonitor = new DebugMonitor();
        DebugMonitor debugMonitor1 = new DebugMonitor(100, 200);
        DebugMonitor debugMonitor2 = new DebugMonitor(500, 500, 300, 300);
        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            debugMonitor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            debugMonitor.ChangeWindowSize(200, 200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            debugMonitor.Write("button2 push!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            debugMonitor.WriteLine("button3 push!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            debugMonitor.MoveWindow(600, 0);
        }
    }
}
