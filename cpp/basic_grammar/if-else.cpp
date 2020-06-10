// if(条件式){...}
if(a<b){
  // a<bのときに実行される処理;
}
else if(a==b){
  // a=bのときに実行される処理;
}
else{
  // a<b でも a=b でもないときに実行される処理;
}

// {...}の中身が1つの処理しかない場合には、{}を省略できる。
if(a<b) program1;
else if(a==b) program2;
else program3;

// 条件式に使用できる比較演算子は以下のもの
if(a<b);        // aがbより小さい
if(a<=b);       // aがb以下
if(a>b);        // aがbより大きい
if(a>=b);       // aがb以上
if(a==b);       // aとbが等しい
if(a!=b);       // aとbが等しくない

// 複数の条件式を用いる場合
if(-a<b && b<a);  // -a<b かつ b<aのとき
if(a==b || a==0); // a==b もしくは a==0のとき
