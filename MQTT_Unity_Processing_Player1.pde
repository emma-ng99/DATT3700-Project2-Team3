import mqtt.*;
MQTTClient client;

static final String server = "mqtt://datt3700:datt3700experiments@datt3700.cloud.shiftr.io";

void messageReceived(String topic, byte[] payload) {
   //println(topic, int(new String(payload)));  // this is a general print of all topics subscribed to.
 
  if (topic.equals("Processing/player1/W")){
  println("M2MQTT_Unity/player1/W",  int(new String(payload)));
  }
  
  if (topic.equals("Processing/player1/S")){
  println("M2MQTT_Unity/player1/S", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player1/A")){
  println("M2MQTT_Unity/player1/A", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player1/D")){
  println("M2MQTT_Unity/player1/D", int(new String(payload)));
  }
  
}

void settings() {
  size(400, 400);
}

//Change name "Processing_Player1" to another unique name

void setup() {
  client = new MQTTClient(this);
  client.connect(server, "Processing_Player1");
  client.subscribe("M2MQTT_Unity/connect1");
}

void draw() {
    background(0);
}


void keyPressed(){
  if (keyPressed) {
    if (key == 'w' || key == 'W') {
      client.publish("M2MQTT_Unity/player1/W", str('1')); 
    }
    
    if (key == 's' || key == 'S') {
      client.publish("M2MQTT_Unity/player1/S", str('1'));
    }
    
    if (key == 'a' || key == 'A') {
      client.publish("M2MQTT_Unity/player1/A", str('1'));
    }
    
    if (key == 'd' || key == 'D') {
      client.publish("M2MQTT_Unity/player1/D", str('1'));
    }
  }

}

void keyReleased(){
  if (keyPressed == false) {
    if (key == 'w' || key == 'W') {
      client.publish("M2MQTT_Unity/player1/W", str('0'));
    }
    
    if (key == 's' || key == 'S') {
      client.publish("M2MQTT_Unity/player1/S", str('0'));
    }
    
    if (key == 'a' || key == 'A') {
      client.publish("M2MQTT_Unity/player1/A", str('0'));
    }
    
    if (key == 'd' || key == 'D') {
      client.publish("M2MQTT_Unity/player1/D", str('0'));
    }
  }

}
