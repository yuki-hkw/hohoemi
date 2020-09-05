﻿using HohoemiCommunicationLib.CommunicatorImp;
using HohoemiCommunicationLib.CommunicatorImpl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HohoemiCommunicationLib
{
    public class CommunicatorFactory
    {
        private const string KEY_TYPE = "Type";
        private const string VALUE_TYEP_MQTT = "Mqtt";
        private const string VALUE_TYEP_MOCK = "Mock";

        public static ICommunicator Create()
        {
            string configPath = Path.Combine(Environment.CurrentDirectory, "hohoemi.conf");
            string data = File.ReadAllText(configPath);
            var properties = JsonSerializer.Deserialize<Dictionary<string, string>>(data);

            ICommunicator comm;

            switch (properties[KEY_TYPE])
            {
                case VALUE_TYEP_MQTT:
                    comm = new MqttCommunicator();
                    break;
                case VALUE_TYEP_MOCK:
                    comm = new MockCommunicator();
                    break;
                default:
                    throw new InvalidDataException("Unkown type " + properties[KEY_TYPE]);
            }

            comm.Init(properties);
            return comm;
        }
    }
}
