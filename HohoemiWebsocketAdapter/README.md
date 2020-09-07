
# 背景
MQTTを通さない環境だと使えないのでwebsocket/httpに変換したかった。。  
ただ、HohoemiClientViewerが使っているMQTTライブラリがWebsocketに対応していなかったので、MQTT<->websocket変換をするアダプタをかますことで対応。

# 動作原理
```
<------------------ローカルPC--------------------->
__________         __________          ___________                 ____________
| Hohoemi | -----> |  broker | -----> | hohoemi   | ------------>  |  broker  |
| Client  |  MQTT  | (local) |  MQTT  | websocket |  web socket    | (remote) |
| Viewer  | <----- |         | <----- | adapter   | <-----------   |          |
-----------        -----------         ------------                ------------
                                        ^^^^ ここでMQTT/Websocket変換
```
というわけで、ローカル(もしくはMQTTが通じるPC)に別途brokerが要ります。

# how to use
- hohoemi.conf、hohoemi_ws.conf、HohoemiClientViewr、hohoemi_websocket_adapter.pyを同一フォルダに置く
- python3をインストール(開発環境はpython3.8(64bit))
- ライブラリをインストール
  -  ```pip install -r requirements.txt```
- brokerをインストール
  - 開発環境では[mosquitto 1.6.12(64bit)](https://mosquitto.org/files/binary/win64/mosquitto-1.6.12-install-windows-x64.exe])を使用
- hohoemi.confの接続先をローカルのブローカーに変更
- hohoemi_wsa.confのIPとPortをリモートのブローカーに設定
- broker(local) -> hohoemi_websocket_adapeter.py -> HomoemiClientViewrの順で起動

# おまけ
## リモートブローカの設定(Websocket)
リモートのブローカにmosquittoを使う場合、Websocketを有効にするためにはmosquitto.confに以下を追加。
```
listener <MQTT Port(よく使うのは1883)>
listener <Websocket Port(よく使うのは9001)>
protocol websockets
```
mosqitto起動時にコンフィグファイルを明示的に指定すること。
```sh
mosquitto -v -c path/to/mosquitto.conf
```

## hohoemi_wsa.confの例
```json
{
	"IP": "127.0.0.1",
	"Port": "9001"      // websocket接続ポート
}
```