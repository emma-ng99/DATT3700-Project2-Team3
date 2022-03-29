
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;

/// <summary>
/// Examples for the M2MQTT library (https://github.com/eclipse/paho.mqtt.m2mqtt),
/// </summary>
namespace ControlsUsingMQTTShiftr
{
    /// <summary>
    /// Script for testing M2MQTT with a Unity UI
    /// </summary>
    public class Player3 : M2MqttUnityClient
    {
        [Tooltip("Set this to true to perform a testing cycle automatically on startup")]
        public bool autoTest = true;

        private List<string> eventMessages = new List<string>();
       
        Vector2 movement;
        public float speed = 5f;
        public Rigidbody2D rb;

        public void TestPublish()
        {
            client.Publish("M2MQTT_Unity/connect3", System.Text.Encoding.UTF8.GetBytes(""), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("Connected");
        }

        protected override void OnConnected()
        {
            base.OnConnected();

            if (autoTest)
            {
                TestPublish();
                
            }
        }

        protected override void SubscribeTopics()
        {
            client.Subscribe(new string[] { "M2MQTT_Unity/connect3" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player3/up" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player3/down" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player3/left" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player3/right" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        protected override void UnsubscribeTopics()
        {
            client.Unsubscribe(new string[] { "M2MQTT_Unity/test" });
        }

     
        protected override void Start()
        {
            base.Start();
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            string msg = System.Text.Encoding.UTF8.GetString(message);
            

            if (topic == "M2MQTT_Unity/player3/up")
            {
                Debug.Log("Received: up " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }

                movement.y = (float)number/10;
                Debug.Log("Player 3 Move up: " + movement.y);
     
            }

            
            if (topic == "M2MQTT_Unity/player3/down")
            {
                Debug.Log("Received: down " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }
       
                movement.y = -( (float)number/10);
                Debug.Log("Player 3 Move down: " + movement.y);
              
            }

           
            if (topic == "M2MQTT_Unity/player3/left")
            {
                 Debug.Log("Received: left " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }
           
                movement.x = - ((float)number/10);
                Debug.Log("Player 3 Move left: " + movement.x);
               
            }

            
            if (topic == "M2MQTT_Unity/player3/right")
            {
                Debug.Log("Received: right " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }
               
                movement.x = (float)number/10;
                Debug.Log("Player 3 Move right: " + movement.x);
                
            }

           
        }

      
        protected override void Update()
        {
            base.Update(); // call ProcessMqttEvents()
           
            
           
        }

        private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //transform.position += movement * Time.deltaTime * speed;
    }

        private void OnDestroy()
        {
            Disconnect();
        }

        private void OnValidate()
        {
            if (autoTest)
            {
                autoConnect = true;
            }
        }
    }
}
