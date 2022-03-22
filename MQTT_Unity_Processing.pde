import mqtt.*;
MQTTClient client;

static final String server = "mqtt://datt3700:datt3700experiments@datt3700.cloud.shiftr.io";

void messageReceived(String topic, byte[] payload) {
   //println(topic, int(new String(payload)));  // this is a general print of all topics subscribed to.
 
  if (topic.equals("Processing/player/W")){
  println("M2MQTT_Unity/player/W",  int(new String(payload)));
  }
  
  if (topic.equals("Processing/player/S")){
  println("M2MQTT_Unity/player/S", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player/A")){
  println("M2MQTT_Unity/player/A", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player/D")){
  println("M2MQTT_Unity/player/D", int(new String(payload)));
  }
  
}

void settings() {
  size(400, 400);
}

//Change name "Processing" to a different unique name
//Change every "connect" topic to connect1(if player1)/connect2 (if player2)/connect3 (if player3)
//Change every "player" topic to player1/player2/player3
void setup() {
  client = new MQTTClient(this);
  client.connect(server, "Processing");
  client.subscribe("M2MQTT_Unity/connect");
}

void draw() {
    background(0);
}


void keyPressed(){
  if (keyPressed) {
    if (key == 'w' || key == 'W') {
      client.publish("M2MQTT_Unity/player/W", str('1'));
      
    }
    
    if (key == 's' || key == 'S') {
      client.publish("M2MQTT_Unity/player/S", str('1'));
    }
    
    if (key == 'a' || key == 'A') {
      client.publish("M2MQTT_Unity/player/A", str('1'));

    }
    
    if (key == 'd' || key == 'D') {
      client.publish("M2MQTT_Unity/player/D", str('1'));
    }
  }

}

void keyReleased(){
  if (keyPressed == false) {
    if (key == 'w' || key == 'W') {
      client.publish("M2MQTT_Unity/player/W", str('0'));
    }
    
    if (key == 's' || key == 'S') {
      client.publish("M2MQTT_Unity/player/S", str('0'));
    }
    
    if (key == 'a' || key == 'A') {
      client.publish("M2MQTT_Unity/player/A", str('0'));
    }
    
    if (key == 'd' || key == 'D') {
      client.publish("M2MQTT_Unity/player/D", str('0'));
    }
  }

}
