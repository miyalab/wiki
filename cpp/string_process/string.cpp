#include <iostream>
#include <string>
int main()
{
  std::string str1;         // 文字列型の宣言
  std::string str2("abc");  // 文字列型の宣言して、「abc」で定義
  std::string str3(5,'a');  // 文字列型の宣言して、'a'を5個格納したものを定義
  std::string str4="efg";   // 文字列型の宣言して、「efg」で定義
  
  std::cout << str2 << std::endl;
  std::cout << str3 << std::endl;
  std::cout << str4 << std::endl;
}
