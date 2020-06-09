// 文字系統 変数宣言
char c;               // 1バイト

// 整数系統 変数宣言
short s;              // 2バイト
int i;                // 4バイト
long l;               // 4バイト
long long ll;         // 8バイト

// 実数系統 変数宣言
float f;              // 4バイト
double d;             // 8バイト
long double ld;       // 16バイト

// ブーリアン型
bool b;               // 1バイト（[true]もしくは[false]のみ）

// 符号有無keywordは「signed」と「unsigned」の2つしかない
// 省略した場合には「singed」が自動挿入されるが
// 変数型のkeywordやコンパイラによっては「unsigned」が自動挿入される場合がある
int si1;              // 符号ありint型
signed float sf;      // 符号ありfloat型
unsigned int ui;      // 符号なしint型
unsigned float uf;    // 符号ありfloat型

// 特殊な変数型のkeywordとして
// 「const」「constexpr」「static」「extern」などがよく使われる（他にもある）
const int ci=0;       // int型時定数
constexpr float cf=2; // float型コンパイル時定数

// 変数名の前に*を付けるとポインタ変数になる
int *pi;              // int型ポインタ変数
float *pf;            // float型ポインタ変数
