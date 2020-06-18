#include <iostream>
#include <string>
int main()
{
  std::string str="hello world";
  
  // 文字列長を取得
  int length=str.length();  // lengthに11が格納される。
  int size=str.size();      // sizeに11が格納される。
  
  std::cout << length << std::endl;
  std::cout << size << std::endl
}
