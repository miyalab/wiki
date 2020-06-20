#include <iostream>
template<typename type>
void print(type s)
{
  std::cout << s << std::endl;
}

int main()
{
  int a=10;
  double b=20;
  print(a);       // void print(int a)として呼び出される
  print(b);       // void print(double b)として呼び出される
}
