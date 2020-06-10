// プロトタイプ宣言された関数
// プロトタイプ宣言するとすべての関数でアクセス可能
void function1(int a);

// プロトタイプ宣言しないで関数定義
// プロトタイプ宣言していない関数は定義より下にある関数でしかアクセスできない。
void function2()
{
  std::cout << "function2" << std::endl;
}

// メイン関数
int main()
{
  int a=0;
  function1(a);     // OK
  function2();      // OK
  function3(b);     // コンパイルエラー!!
                    // ⇒function3の定義より上にあるため
}

// プロトタイプ宣言した関数定義
void function1(int a)
{
  return a*a;
}

// プロトタイプ宣言してない関数定義
void function3(int b)
{
  return 2*b;
}
