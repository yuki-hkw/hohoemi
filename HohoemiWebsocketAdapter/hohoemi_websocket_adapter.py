import json
import paho.mqtt.client as mqtt
import os
import threading

with open('hohoemi.conf') as lf:
    _local_conf = json.load(lf)


with open('hohoemi_wsa.conf') as rf:
    _remote_conf = json.load(rf)


_client_id = os.path.basename(os.environ['USERPROFILE']) + _local_conf['Channel']

_local_client_sub = mqtt.Client(client_id=_client_id + 'adapter-sub')
_local_client_pub = mqtt.Client(client_id=_client_id + 'adapter-pub')
_remote_client_sub = mqtt.Client(client_id=_client_id + '-sub', transport="websockets")
_remote_client_pub = mqtt.Client(client_id=_client_id + '-pub', transport="websockets")

# 無限メッセージループ防止
# ガード入れないと無限にメッセージが回るので、Xのところでmessage idからフィルタリングする
# clientA -> broker(local) ->  local(subscribe) ->X remote(publish)  -> broker(remote) -> clientB
# clientA <- broker(local) <-  local(publish)  X<-  remote(subscribe) <- broker(remote) <- clientB
_remote_mids = []
_local_mids = []

def on_message_from_remote(mqttc, obj, msg):
    if msg.mid in _remote_mids:
        _remote_mids.remove(msg.mid)
    else:
        info = _local_client_pub.publish(_local_conf['Channel'], msg.payload, 2)
        _local_mids.append(info.mid)


def on_message_from_local(mqttc, obj, msg):
    if msg.mid in _local_mids:
        _local_mids.remove(msg.mid)
    else:
        info = _remote_client_pub.publish(_local_conf['Channel'], msg.payload, 2)
        _remote_mids.append(info.mid)


def start_local():
    _local_client_sub.loop_forever()


def start_remote():
    _remote_client_sub.loop_forever()


_local_client_sub.on_message = on_message_from_local
_local_client_sub.connect(_local_conf['IP'], int(_local_conf['Port']), 60)
_local_client_sub.subscribe(_local_conf['Channel'], 2)
_local_client_pub.connect(_local_conf['IP'], int(_local_conf['Port']), 60)
_local_client_pub.loop_start()

_remote_client_sub.on_message = on_message_from_remote
_remote_client_sub.connect(_remote_conf['IP'], int(_remote_conf['Port']), 60)
_remote_client_sub.subscribe(_local_conf['Channel'], 2)
_remote_client_pub.connect(_remote_conf['IP'], int(_remote_conf['Port']), 60)
_remote_client_pub.loop_start()

threading.Thread(target=start_local).start()
threading.Thread(target=start_remote).start()
