
* Serial Communication Terminal System(SCTS)
* 
* Copyright (c) 2020 K.Miyauchi
* This software is released under the MIT LICENSE
* http://opensource.org/licenses/mit-license.php
* 
* File    : MainForm.cs
* Author  : K.Miyauchi
* 
* version : 1.00
*/

//--------------------------------------
// パッケージ
//--------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//------------------------------------------------------------------------------------------
// Serial Communication Terminal System
//------------------------------------------------------------------------------------------
namespace SerialCommunicationTerminalSystem
{
//--------------------------------------------------------------------------------------
// Main Form
//--------------------------------------------------------------------------------------
public partial class MainForm : Form
{
// メンバ変数
private string lineFeedCode = "\r\n";       // 改行コード（送信）

//----------------------------------------------------------------------------------
// MainForm コンストラクタ
//----------------------------------------------------------------------------------
public MainForm()
{
InitializeComponent();
}

//----------------------------------------------------------------------------------
// MainForm 起動時の処理
//----------------------------------------------------------------------------------
private void MainForm_Load(object sender, EventArgs e)
{
// シリアルポート初期設定
comboBoxStopbit.SelectedIndex = 0;
comboBoxDatabit.SelectedIndex = 1;
comboBoxParity.SelectedIndex = 0;
comboBoxLineFeedCode.SelectedIndex = 2;

// デバイスリスト更新
deviceList_Update();
}

//----------------------------------------------------------------------------------
// MainForm 閉じた時の処理
//----------------------------------------------------------------------------------
private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
{
// シリアルポートオープンされている
if(serialPort.IsOpen == true)
{
// シリアルポートのクローズ
serialPort.Close();
}
}

//----------------------------------------------------------------------------------
// メニューバー「著作権」クリック時処理
//----------------------------------------------------------------------------------
private void CopyrightToolStripMenuItem_Click(object sender, EventArgs e)
{
// CopyrightFormオープン
CopyrigthForm copyrigthForm = new CopyrigthForm();
copyrigthForm.Show();
}

//----------------------------------------------------------------------------------
// 「デバイス取得」ボタンクリック時処理
//----------------------------------------------------------------------------------
private void buttonGetDevicesList_Click(object sender, EventArgs e)
{
// デバイスリスト更新
deviceList_Update();
}

//----------------------------------------------------------------------------------
// 「接続」or「切断」ボタンクリック時の処理
//----------------------------------------------------------------------------------
private void buttonConnect_Click(object sender, EventArgs e)
{
if(buttonConnect.Text == "接続")
{
try
{
// コンボボックスからCOM番号取得
string buff = comboBoxDevices.Text;
int deviceComBegin = buff.IndexOf('(');
int deviceComEnd = buff.IndexOf(')');
string deviceCom = buff.Substring(deviceComBegin + 1, deviceComEnd - deviceComBegin - 1);

// シリアル通信設定
serialPort.PortName = deviceCom;
serialPort.BaudRate = int.Parse(textBoxBaudrate.Text);
serialPort.DataBits = int.Parse(comboBoxDatabit.Text);
if (comboBoxStopbit.Text == "1") serialPort.StopBits = StopBits.One;
else if (comboBoxStopbit.Text == "2") serialPort.StopBits = StopBits.Two;
else serialPort.StopBits = StopBits.OnePointFive;
if (comboBoxParity.Text == "なし") serialPort.Parity = Parity.None;
else if (comboBoxParity.Text == "奇数パリティ") serialPort.Parity = Parity.Odd;
else serialPort.Parity = Parity.Even;

// シリアルポートのオープン
serialPort.Open();


// 「切断」ボタンに切替
buttonConnect.Text = "切断";

// シリアル通信設定 操作禁止
serialSetting_Disable();
}
catch
{
MessageBox.Show("シリアルポートをオープンできませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}
else
{
serialPort.Close();

// 「接続」ボタンに切替
buttonConnect.Text = "接続";

// シリアル通信設定 操作許可
serialSetting_Enable();
}
}

//----------------------------------------------------------------------------------
// 「送信」ボタンクリック時処理
//----------------------------------------------------------------------------------
private void buttonTrans_Click(object sender, EventArgs e)
{
    serialPort.Write(textBoxTrans.Text + lineFeedCode);
    textBoxTrans.Clear();
}

//----------------------------------------------------------------------------------
// ボーレート設定用テキストボックス キー入力時処理
//----------------------------------------------------------------------------------
private void textBoxBaudrate_KeyPress(object sender, KeyPressEventArgs e)
{
    // 数字とBS以外の入力無視処理
    if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
    {
        e.Handled = true;
    }
}

//----------------------------------------------------------------------------------
// 送信データ用テキストボックス キー入力時処理
//----------------------------------------------------------------------------------
private void textBoxTrans_KeyPress(object sender, KeyPressEventArgs e)
{
    // Enterキーを押したときの処理
    if (e.KeyChar == (char)Keys.Enter)
    {
        // データを送信
        serialPort.Write(textBoxTrans.Text + lineFeedCode);

        // テキストボックス初期化
        textBoxTrans.Clear();
        e.Handled = true;
    }
}

//----------------------------------------------------------------------------------
// 改行コード（送信）設定用コンボボックス 変更時処理
//----------------------------------------------------------------------------------
private void comboBoxLineFeedCode_SelectedIndexChanged(object sender, EventArgs e)
{
    if (comboBoxLineFeedCode.Text == "CR（Mac系）")            lineFeedCode = "\r";
    else if (comboBoxLineFeedCode.Text == "LF（Unix系）")      lineFeedCode = "\n";
    else if (comboBoxLineFeedCode.Text == "CRLF（Windows系）") lineFeedCode = "\r\n";
    else if (comboBoxLineFeedCode.Text == "なし")              lineFeedCode = "";
}

//----------------------------------------------------------------------------------
// シリアルポート データ受信時処理
//----------------------------------------------------------------------------------
private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
{
    textBoxRead.AppendText(serialPort.ReadExisting());
}

//**********************************************************************************
// 以下、自作関数（イベント処理ではない）
//**********************************************************************************
//----------------------------------------------------------------------------------
// シリアル通信デバイス探索
//----------------------------------------------------------------------------------
private static IEnumerable<string> GetSerialDeviceNames()
{
    var pnpEntity = new ManagementClass("Win32_PnPEntity");
    var comRegex = new Regex(@"\(COM[1-9][0-9]?[0-9]?\)");                  // デバイス名に"(COM3)"などが入ってるものを探す

    return pnpEntity
        .GetInstances()                                                     // 一覧を取得
        .Cast<ManagementObject>()
        .Select(managementObj => managementObj.GetPropertyValue("Name"))    // 名前拾ってくる
        .Where(nameObj => nameObj != null)                                  // プロパティ値が拾えないものはnullになっているので弾く
        .Select(nameObj => nameObj.ToString())                              // 文字列に直し、
        .Where(name => comRegex.IsMatch(name));                             // 正規表現で最後のフィルタリング
}

//----------------------------------------------------------------------------------
// シリアル通信デバイスリスト更新
//----------------------------------------------------------------------------------
private void deviceList_Update()
{
    // デバイスリスト更新
    comboBoxDevices.Items.Clear();
    foreach (string Ports in GetSerialDeviceNames())
    {
        comboBoxDevices.Items.Add(Ports);
    }

    // デバイスあり
    if (comboBoxDevices.Items.Count != 0)
    {
        // 接続ボタン許可
        buttonConnect.Enabled = true;
        comboBoxDevices.SelectedIndex = 0;
    }
    // デバイスなし
    else
    {
        // 接続ボタン入力禁止
        buttonConnect.Enabled = false;
    }
}

//----------------------------------------------------------------------------------
// シリアル通信設定 操作禁止
//----------------------------------------------------------------------------------
private void serialSetting_Disable()
{
buttonGetDevicesList.Enabled = false;
comboBoxDevices.Enabled = false;
textBoxBaudrate.Enabled = false;
comboBoxStopbit.Enabled = false;
comboBoxDatabit.Enabled = false;
comboBoxParity.Enabled = false;

// シリアルポート送信関係
textBoxTrans.Enabled = true;
buttonTrans.Enabled = true;
}

//----------------------------------------------------------------------------------
// シリアル通信設定 操作許可
//----------------------------------------------------------------------------------
private void serialSetting_Enable()
{
buttonGetDevicesList.Enabled = true;
comboBoxDevices.Enabled = true;
textBoxBaudrate.Enabled = true;
comboBoxStopbit.Enabled = true;
comboBoxDatabit.Enabled = true;

// シリアルポート送信関係
textBoxTrans.Enabled = false;
buttonTrans.Enabled = false;
}
}
}

//------------------------------------------------------------------------------------------
// end of file
//------------------------------------------------------------------------------------------
