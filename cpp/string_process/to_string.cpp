#include <iostream>
#include <string>
int main()
{
  int i=123;
  
  string str=std::to_string(i);   // strに文字列の「123」が格納される。
  std::cout << str << std::endl;
}
