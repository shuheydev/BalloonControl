# BalloonControl

吹き出し型のコントロールです.
中にテキストを表示します.

<image src='https://user-images.githubusercontent.com/43431002/71541037-40f73f00-2996-11ea-826d-c25582cfed15.png' width=350/>

iOSでは動作,見た目の確認をしていません.
Android,UWPで確認しました.

## プロパティ
### Text
表示する文字列.
### BalloonColor
吹き出しの色.
### CornerRadius
吹き出しの角の丸み.範囲:0~20
### MouthDirection
吹き出しの口の方向(Right,Left)
### TextColor
文字色.
### FontSize
フォントサイズ.
double型での指定のみ

.NamedSize列挙型は使えない.どうやったらいいんだ?

### Padding
吹き出しの中の余白.

