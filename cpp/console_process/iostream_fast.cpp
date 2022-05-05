#include <iostream>
int main()
{
    // 「iostream」と「stdio」の関係をきる
    std::ios::sync_with_stdio(false);
  
    // 「std::cin」の高速化
    std::cin.tie(nullptr);
}
