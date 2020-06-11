#include <iostream>
#include <iomanip>
int main()
{
  // std::cout << 出力したい変数 or 文字列;
  // std::endl は改行する処理
  // 「<<」 を付けると複数の変数or文字列を出力することができる。
  std::cout << "Hello World" << std::endl;
  // 「Hello World」と出力される
  
  int a=0,b=1;
  std::cout << a << " " << b << std::endl;
  // 「0 1」と出力される
  
  double pi=3.1415926535897932384626433832795028841971;
  std::cout << pi << std::endl;
  // 「3.14159」と出力される
  
  // 表示される桁数を変更する
  std::cout << std::fixed;              // 指数表記から固定小数点表記に変更
  std::cout << std::setprecision(15);   // 表示範囲を小数点以下15桁に変更（iomanipのincludeが必要）
  std::cout << pi << std::endl;
}
