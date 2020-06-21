#include <iostream>
#include <vector>
int main()
{
  int n,x;
  std::vector<int> N;
  
  // n:数値 x:基数
  cin >> n >> x;
  
  // 基数変換メイン
  while(n>0){
    N.push_back(n%x);
    n/=x;
  }
  
  // 上位桁から出力
  for(int i=N.length()-1;i>=0;i--){
    std::cout << N[i];
  }
  std::cout << std::endl;
}
