# hohoemi
コメントを表示するやつ

# how to use
## MQTTブローカの準備
MQTTブローカであれば大体うごくはず。。 
開発中で使ったものは以下  
[mosquitto 1.6.12(64bit)](https://mosquitto.org/files/binary/win64/mosquitto-1.6.12-install-windows-x64.exe)  
↑をDL&インストール後実行。ブローカーはmosquitto.exe。

## 設定ファイルの作成
.exeと同じフォルダにあるhohoemi.confを編集。  
```json
{
	"Type": "Mqtt",
	"Channel": "CHANGE_HERE", // コメントを共有したい人たちと合わせる。mqttのトピックになる
	"IP": "127.0.0.1",        // ブローカのIP
	"Port": "1883"            // ブローカのポート
}
```

## 実行
HohoemiClientViewer.exe を実行

# 開発環境
- Visual Studio 2019 community
- Windows10 64bit
