using System;
using System.Text;
using System.Text.Json;

namespace HohoemiCommunicationLib.Payload
{
    internal class HohoemiPayload
    {
        public string Sender { set; get; }

        public string Message { set; get; }

        internal static HohoemiPayload FromBytes(byte[] payload)
        {
            HohoemiPayload hp;

            try
            {
                hp = JsonSerializer.Deserialize<HohoemiPayload>(Encoding.UTF8.GetString(payload));
                hp.Message = Encoding.UTF8.GetString(Convert.FromBase64String(hp.Message)); // BASE64化されているはずなのでデコード
            }
            catch
            {
                // よく知らないフォーマットのデータが来ている
                // そのまま流す
                hp = new HohoemiPayload()
                {
                    Sender = "unkown",
                    Message = Encoding.UTF8.GetString(payload)
                };
            }

            return hp;
        }

        internal static byte[] ToBytes(string sender, string message)
        {
            var payload = new HohoemiPayload()
            {
                Sender = sender,
                Message = Convert.ToBase64String(Encoding.UTF8.GetBytes(message)) // 何書いてくるかわからないのでBASE64にしておく
            };

            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload));
        }
    }
}
