#include <vector>
int main()
{
  // vector<変数型> 変数名;
  std::vector<int> vec1;        // int型の動的配列を宣言
  std::vector<int> vec2(5);     // int型の動的配列を5つの要素を用意して宣言
  std::vector<int> vec3(5,3);   // int型の動的配列を5つの要素を用意して、すべて3で初期化
  
  std::vector<std::vector<int>> vec4;                         // int型の2次元動的配列を宣言
  std::vector<std::vector<int>> vec5(5,vector<int>(5));       // int型の2次元動的配列を5x5の要素を用意して宣言
  std::vector<std::vector<int>> vec6(5,vector<int>(5,3));     // int型の2次元動的配列を5x5の要素を用意して、すべて3で初期化
}
