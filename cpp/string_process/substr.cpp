#include<iostream>
#include<string>
int main()
{
  std::string str="abcdefghijklmn";
  
  // 変数.substr(i,j);               // 変数のi+1文字目からj文字抽出
  std::string str2=str.substr(1,3); // 「bcd」が抽出される
  
  // 変数.substr(i);                // 変数のi+1文字目以降を抽出
  std::string str3=str.substr(5);   // 「fghijklmn」が抽出される
  
  std::cout << str2 << std::endl;
  std::cout << str3 << std::endl;
}
