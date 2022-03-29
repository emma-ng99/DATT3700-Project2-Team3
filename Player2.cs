
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
    public class Player2 : M2MqttUnityClient
    {
        [Tooltip("Set this to true to perform a testing cycle automatically on startup")]
        public bool autoTest = true;

        private List<string> eventMessages = new List<string>();
       
        Vector2 movement;
        public float speed = 5f;
        public Rigidbody2D rb;

        public void TestPublish()
        {
            client.Publish("M2MQTT_Unity/connect2", System.Text.Encoding.UTF8.GetBytes(""), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
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
            client.Subscribe(new string[] { "M2MQTT_Unity/connect2" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player2/I" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player2/K" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player2/J" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "M2MQTT_Unity/player2/L" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
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
            

            if (topic == "M2MQTT_Unity/player2/I")
            {
                Debug.Log("Received: I " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }

                movement.y = (float)number/10;
                Debug.Log("Player 2 Move up: " + movement.y);
     
            }

            
            if (topic == "M2MQTT_Unity/player2/K")
            {
                Debug.Log("Received: K " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }
       
                movement.y = -( (float)number/10);
                Debug.Log("Player 2 Move down: " + movement.y);
              
            }

           
            if (topic == "M2MQTT_Unity/player2/J")
            {
                 Debug.Log("Received: J " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }
           
                movement.x = - ((float)number/10);
                Debug.Log("Player 2 Move left: " + movement.x);
               
            }

            
            if (topic == "M2MQTT_Unity/player2/L")
            {
                Debug.Log("Received: L " + msg);
                bool result;
                double number;
 
                result = double.TryParse(msg, out number);

                if(result){
                }
               
                movement.x = (float)number/10;
                Debug.Log("Player 2 Move right: " + movement.x);
                
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
