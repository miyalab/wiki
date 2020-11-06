/ *
 *シリアル通信端末システム（SCTS）
 * 
 * Copyright（c）2020 K.Miyauchi
 *このソフトウェアはMITLICENSEの下でリリースされています
 * http://opensource.org/licenses/mit-license.php
 * 
 *ファイル：MainForm.cs
 *著者：K.Miyauchi
 * 
 *バージョン：1.00
 * /

// --------------------------------------
//パナ
// --------------------------------------
 システムを使用する;
 システムを使用します。コレクション。ジェネリック;
 システムを使用します。データ;
 システムを使用します。IO。ポート;
 システムを使用します。Linq ;
 システムを使用します。管理;
 システムを使用します。テキスト。正規表現;
 システムを使用します。Windows。フォーム;

// ------------------------------------------------ ------------------------------------------
//シリアル通信端末システム
// ------------------------------------------------ ------------------------------------------
名前空間 SerialCommunicationTerminalSystem
{{
    // ------------------------------------------------ --------------------------------------
    //メインフォーム
    // ------------------------------------------------ --------------------------------------
    パブリック 部分 クラス MainForm：フォーム
    {{
        //変数
        プライベート 文字列 lineFeedCode  =  " \ r \ n " ;       //改行コード（送信）

        // ------------------------------------------------ ----------------------------------
        // MainFormコンストラクタ
        // ------------------------------------------------ ----------------------------------
        public  MainForm（）
        {{
            InitializeComponent（）;
        }

        // ------------------------------------------------ ----------------------------------
        // MainForm押し時の処理
        // ------------------------------------------------ ----------------------------------
        private  void  MainForm_Load（オブジェクト 送信者、EventArgs  e）
        {{
            //シリアルポートチップ設定
            comboBoxStopbit。SelectedIndex  =  0 ;
            comboBoxDatabit。SelectedIndex  =  1 ;
            comboBoxParity。SelectedIndex  =  0 ;
            comboBoxLineFeedCode。SelectedIndex  =  2 ;

            //オプションリスト更新
            deviceList_Update（）;
        }

        // ------------------------------------------------ ----------------------------------
        // MainFormウィジェット時の処理
        // ------------------------------------------------ ----------------------------------
        private  void  MainForm_FormClosed（オブジェクト 送信者、FormClosedEventArgs  e）
        {{
            //ステレオポートオープンされた
            もし（SERIALPORT。のIsOpen  == 真）
            {{
                //クローズポートの
                serialPort。閉じる（）;
            }
        }

        // ------------------------------------------------ ----------------------------------
        //メニューバー「著作権」クリック時
        // ------------------------------------------------ ----------------------------------
        private  void  CopyrightToolStripMenuItem_Click（オブジェクト 送信者、EventArgs  e）
        {{
            // CopyrightForm N
            CopyrigthForm  copyrigthForm  =  new  CopyrigthForm（）;
            copyrigthForm。表示（）;
        }

        // ------------------------------------------------ ----------------------------------
        //「オプションでき」ボタン回時処理
        // ------------------------------------------------ ----------------------------------
        private  void  buttonGetDevicesList_Click（オブジェクト 送信者、EventArgs  e）
        {{
            //オプションリスト更新
            deviceList_Update（）;
        }

        // ------------------------------------------------ ----------------------------------
        //「切断」または「切断」ボタン時の切断
        // ------------------------------------------------ ----------------------------------
        private  void  buttonConnect_Click（オブジェクト 送信者、EventArgs  e）
        {{
            もし（buttonConnect。テキスト ==  "接続"）
            {{
                試してみてください
                {{
                    //コンボボックスからCOM番号取得
                    string  buff  =  comboBoxDevices。テキスト;
                    int  deviceComBegin  =  buff。IndexOf（'（'）;
                    int  deviceComEnd  =  buff。IndexOf（'）'）;
                    文字列 deviceCom  =  buff。部分文字 列（deviceComBegin +  1、deviceComEnd  -  deviceComBegin  -  1）;

                    //シリアル通信設定
                    serialPort。PortName  =  deviceCom ;
                    serialPort。BaudRate  =  int。パース（textBoxBaudrate。テキスト）;
                    serialPort。DataBits  =  int。パース（comboBoxDatabit。テキスト）;
                    もし（comboBoxStopbit。テキスト ==  " 1 "）SERIALPORT。StopBits  =  StopBits。1つ;
                    それ以外の 場合（comboBoxStopbit。テキスト ==  " 2 "）SERIALPORT。StopBits  =  StopBits。2 ;
                    それ以外の場合は serialPort。StopBits  =  StopBits。OnePointFive ;
                    もし（comboBoxParity。テキスト ==  "なし"）SERIALPORT。パリティ = パリティ。なし;
                    それ以外の 場合（comboBoxParity。テキスト ==  "奇数パリティ"）SERIALPORT。パリティ = パリティ。奇数;
                    それ以外の場合は serialPort。パリティ = パリティ。でも;

                    //シリアルポートの
                    serialPort。開く（）;
                    

                    //「切断」ボタンに
                    buttonConnect。テキスト =  "切断" ;

                    //シリアル通信設定
                    serialSetting_Disable（）;
                }
                キャッチ
                {{
                    MessageBox。ショー（"シリアルポートをオープンできませんでした。"、"エラー"、MessageBoxButtons。OK、MessageBoxIcon。エラー）。
                }
            }
            そうしないと
            {{
                serialPort。閉じる（）;

                //「接続」ボタンに
                buttonConnect。テキスト =  "連結" ;

                //シリアル通信設定
                serialSetting_Enable（）;
            }
        }

        // ------------------------------------------------ ----------------------------------
        //「送信」ボタン時時処理
        // ------------------------------------------------ ----------------------------------
        private  void  buttonTrans_Click（オブジェクト 送信者、EventArgs  e）
        {{
            serialPort。書き込み（textBoxTrans。テキスト +  lineFeedCode）。
        }

        // ------------------------------------------------ ----------------------------------
        //ボーレート設定用INTボックスキー入力時処理
        // ------------------------------------------------ ----------------------------------
        private  void  textBoxBaudrate_KeyPress（オブジェクト 送信者、KeyPressEventArgs  e）
        {{
            //数字とBSIncludeの押し説明処理
            もし（（E。は、keyChar  <  '0'  ||  '9'  <  E。は、keyChar）&&  E。は、keyChar  ！=  ' \ B '）
            {{
                e。処理済み =  true ;
            }
        }

        // ------------------------------------------------ ----------------------------------
        //データデータ用INTボックスキー入力時処理
        // ------------------------------------------------ ----------------------------------
        private  void  textBoxTrans_KeyPress（オブジェクト 送信者、KeyPressEventArgs  e）
        {{
            //キーを入力します
            もし（E。は、keyChar  ==（文字）キー。入力してください）
            {{
                //データを
                serialPort。書き込み（textBoxTrans。テキスト +  lineFeedCode）。

                //ページボックス
                textBoxTrans。クリア（）;
                e。処理済み =  true ;
            }
        }

        // ------------------------------------------------ ----------------------------------
        //改行コード（送信）設定用コンボボックス変更時処理
        // ------------------------------------------------ ----------------------------------
        private  void  comboBoxLineFeedCode_SelectedIndexChanged（オブジェクト 送信者、EventArgs  e）
        {{
            もし（comboBoxLineFeedCode。テキスト ==  " CR（マック系）"）             lineFeedCode  =  " \ rを" ;
            それ以外の 場合（comboBoxLineFeedCode。テキスト ==  " LF（Unixの系）"）       lineFeedCode  =  " \ n個" ;
            それ以外の 場合（comboBoxLineFeedCode。テキスト ==  " CRLF（Windowsの系）"）lineFeedCode  =  " \ rを\ n個" ;
            それ以外の 場合（comboBoxLineFeedCode。テキスト ==  "なし"）               lineFeedCode  =  " " ;
        }

        // ------------------------------------------------ ----------------------------------
        //ピボットポートデータ時処理
        // ------------------------------------------------ ----------------------------------
        プライベート 無効 serialPort_DataReceived（オブジェクト 送信者、System.IO.Ports。SerialDataReceivedEventArgs  E）
        {{
            textBoxRead。appendText（SERIALPORT。ReadExisting（））。
        }

        // ************************************************ **********************************
        //あり、自作関数（関数処理なし）
        // ************************************************ **********************************
        // ------------------------------------------------ ----------------------------------
        //シリアル通信チップ
        // ------------------------------------------------ ----------------------------------
        プライベート 静的 IEnumerable <文字列> GetSerialDeviceNames（）
        {{
            var  pnpEntity  =  new  ManagementClass（" Win32_PnPEntity "）;
            var  comRegex  =  new  Regex（@ " \（COM [1-9] [0-9]？[0-9]？\）"）;                  //オプション名に "（COM3）"特がててゆんを購入

             pnpEntityを返します
                。GetInstances（）                                                      //コレクションを取得
                。キャスト< ManagementObject >（）
                。選択（managementObj  =>  managementObj。GetPropertyValue（"名前"））     //名前拾ってくる
                。Where（nameObj  =>  nameObj  ！=  null）                                   //帯Bが逸えないものはnullにしたら見るので弾く
                。選択（nameObj  =>  nameObj。ToStringメソッド（））                               //文字列に直し、
                。ここで、（名前 =>  comRegex。IsMatch（名））;                             //正規表現で完了の
        }

        // ------------------------------------------------ ----------------------------------
        //シリアル通信チップリスト更新
        // ------------------------------------------------ ----------------------------------
        private  void  deviceList_Update（）
        {{
            //オプションリスト更新
            comboBoxDevices。アイテム。クリア（）;
            foreachの（文字列 ポート で GetSerialDeviceNames（））
            {{
                comboBoxDevices。アイテム。追加（ポート）;
            }

            //デバイスあり
            もし（comboBoxDevices。アイテム。カウント ！=  0）
            {{
                //でしょう
                buttonConnect。有効 =  true ;
                comboBoxDevices。SelectedIndex  =  0 ;
            }
            //デバイスなし
            そうしないと
            {{
                //でしょう
                buttonConnect。有効 =  false ;
            }
        }

        // ------------------------------------------------ ----------------------------------
        //シリアル通信設定
        // ------------------------------------------------ ----------------------------------
        private  void  serialSetting_Disable（）
        {{
            buttonGetDevicesList。有効 =  false ;
            comboBoxDevices。有効 =  false ;
            textBoxBaudrate。有効 =  false ;
            comboBoxStopbit。有効 =  false ;
            comboBoxDatabit。有効 =  false ;
            comboBoxParity。有効 =  false ;

            //シリアルポート販売
            textBoxTrans。有効 =  true ;
            buttonTrans。有効 =  true ;
        }

        // ------------------------------------------------ ----------------------------------
        //シリアル通信設定
        // ------------------------------------------------ ----------------------------------
        private  void  serialSetting_Enable（）
        {{
            buttonGetDevicesList。有効 =  true ;
            comboBoxDevices。有効 =  true ;
            textBoxBaudrate。有効 =  true ;
            comboBoxStopbit。有効 =  true ;
            comboBoxDatabit。有効 =  true ;

            //シリアルポート販売
            textBoxTrans。有効 =  false ;
            buttonTrans。有効 =  false ;
        }
    }
}

// ------------------------------------------------ ------------------------------------------
//ファイルの終わり
// ------------------------------------------------ ------------------------------------------
