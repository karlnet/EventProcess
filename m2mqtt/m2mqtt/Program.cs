using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace m2mqtt
{
    class Program
    {
        private const string IotEndpoint = "hhnext.azure-devices.net";

        private const int BrokerPort = 8883;
        private const string toKen =
            "SharedAccessSignature sr=hhnext.azure-devices.net%2fdevices%2ftest&sig=xUvRM16R29Ss%2bFBPfvnScLkNmzAEVb2%2fASyb0eHsMwk%3d&se=1474721929";

        static void Main(string[] args)
        {
            // create client instance 
            MqttClient client = new MqttClient(IotEndpoint, BrokerPort, true, null, null, MqttSslProtocols.TLSv1_1);

            //string clientId = Guid.NewGuid().ToString();
            client.Connect("test", "hhnext.azure-devices.net/test", toKen);
            string strValue = Convert.ToString("hello");
            Console.WriteLine(strValue);
            // publish a message on "/home/temperature" topic with QoS 2 
            client.Publish("devices/test/messages/events/", Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Console.WriteLine("SUCCESS!");


        }
    }

}
