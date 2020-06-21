#include <iostream>

int main()
{
  int n,x;
  
  // n:数値 x:基数
  cin >> n >> x;
  
  // 1桁目から順に表示していく
  while(n>0){
    std::cout << n%x << std::endl;
    n/=x;
  }
}
