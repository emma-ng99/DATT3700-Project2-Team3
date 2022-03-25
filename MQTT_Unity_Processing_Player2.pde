import mqtt.*;
MQTTClient client;

static final String server = "mqtt://datt3700:datt3700experiments@datt3700.cloud.shiftr.io";

void messageReceived(String topic, byte[] payload) {
   //println(topic, int(new String(payload)));  // this is a general print of all topics subscribed to.
 
  if (topic.equals("Processing/player2/I")){
  println("M2MQTT_Unity/player2/I",  int(new String(payload)));
  }
  
  if (topic.equals("Processing/player2/K")){
  println("M2MQTT_Unity/player2/K", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player2/J")){
  println("M2MQTT_Unity/player2/J", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player2/L")){
  println("M2MQTT_Unity/player2/L", int(new String(payload)));
  }
  
}

void settings() {
  size(400, 400);
}

//Change name "Processing_Player2" to another unique name

void setup() {
  client = new MQTTClient(this);
  client.connect(server, "Processing_Player2");
  client.subscribe("M2MQTT_Unity/connect2");
}

void draw() {
    background(0);
}


void keyPressed(){
  if (keyPressed) {
    if (key == 'i' || key == 'I') {
      client.publish("M2MQTT_Unity/player2/I", str('1'));
      
    }
    
    if (key == 'k' || key == 'K') {
      client.publish("M2MQTT_Unity/player2/K", str('1'));
    }
    
    if (key == 'j' || key == 'J') {
      client.publish("M2MQTT_Unity/player2/J", str('1'));

    }
    
    if (key == 'l' || key == 'L') {
      client.publish("M2MQTT_Unity/player2/L", str('1'));
    }
  }

}

void keyReleased(){
  if (keyPressed == false) {
    if (key == 'i' || key == 'I') {
      client.publish("M2MQTT_Unity/player2/I", str('0'));
    }
    
    if (key == 'k' || key == 'K') {
      client.publish("M2MQTT_Unity/player2/K", str('0'));
    }
    
    if (key == 'j' || key == 'J') {
      client.publish("M2MQTT_Unity/player2/J", str('0'));
    }
    
    if (key == 'l' || key == 'L') {
      client.publish("M2MQTT_Unity/player2/L", str('0'));
    }
  }

}
