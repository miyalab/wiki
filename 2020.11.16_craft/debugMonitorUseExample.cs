using System;
using System.Windows.Forms;

using MiYALAB.CSharp;

namespace TestApp
{
    public partial class Form1 : Form
    {
        // インスタンス生成例
        DebugMonitor debugMonitor = new DebugMonitor();                     // モニタ作成
        DebugMonitor debugMonitor1 = new DebugMonitor(100, 200);            // モニタサイズ指定して作成
        DebugMonitor debugMonitor2 = new DebugMonitor(500, 500, 300, 300);  // モニタサイズ、場所を指定して作成
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // モニタを隠す
            debugMonitor.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // モニタサイズを変更する
            debugMonitor.ChangeWindowSize(200, 200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // テキストを挿入
            debugMonitor.Write("button2 push!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // テキストを挿入し、改行
            debugMonitor.WriteLine("button3 push!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ウインドウ表示場所を変更する
            debugMonitor.MoveWindow(600, 0);
        }
    }
}
