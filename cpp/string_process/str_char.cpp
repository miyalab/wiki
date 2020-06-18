#include <iostream>
#include <string>
int main()
{
  std::string str="0123456789";
  
  string str1 = str[0];   // str1に「0」が格納される。
  str1[5]='A';            // 「01234A6789」になる。
  
  std::cout << str << std::endl;
  std::cout << str1 << std::endl;
}
