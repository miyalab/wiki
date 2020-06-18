#include <iostream>
#include <string>
int main()
{
  std::string str1="abc";
  std::string str2="def";
  std::string str3=str1+str2;       // 「abcdef」がstr3に格納される。
  std::cout << str3 << std::endl;
}
