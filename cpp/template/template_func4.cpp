#include <iostream>
#include <string>
template<typename type>
void print(type s)
{
  std::cout << "num:" << s << std::endl;
}

// std::string型だけ別処理
template<>
void print(std::string str)
{
  std::cout << "str:"+str << std::endl;
}

int main()
{
  int a=100;
  double b=150;
  std::string s="200";
  print(a);             // num:100 と出力される
  print(b);             // num:150 と出力される
  print(s);             // str:200 と出力される
}
