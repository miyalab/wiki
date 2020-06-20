#include <iostream>
template<typename type>
void sum_print(type a, type b)
{
  std::cout << a+b << std::endl;
}

template<typename type1, typename type2>
void time_print(type1 a, type2 b)
{
  std::cout << (type1)type1*type2 << std::endl;
}

int main()
{
  int a=10;
  double b=21.5;
  sum_print(a,b);   // ワーニングがでる（sum_printは1つの型した扱えない）
  time_print(a,b);  // void time_print(int a, double b)として呼び出される
}
