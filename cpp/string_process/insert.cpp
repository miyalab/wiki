#include <iostream>
#include <string>
int main()
{
  std::string str1="Ho";
  std::string str2="rld";
  
  // 変数.insert(i,str);    // i+1文字目にstrを挿入
  str1.insert(1,"ell");     // str1がHelloになる
  str2.insert(0,"Wo");      // str2がWorldになる
  
  std::cout << str1 << std::endl;
  std::cout << str2 << std::endl;
}
