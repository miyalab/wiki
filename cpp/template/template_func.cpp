template <typename type>
type sum(type a, type b)
{
  return a+b;
}

int main()
{
  int x;
  double y;
  
  x=sum(10,20);       // int sum(int a, int b)として呼び出される
  y=sum(10.9,11.2);   // double sum(double a, double b)として呼び出される
}
