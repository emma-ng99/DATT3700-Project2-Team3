import mqtt.*;
MQTTClient client;

static final String server = "mqtt://datt3700:datt3700experiments@datt3700.cloud.shiftr.io";

void messageReceived(String topic, byte[] payload) {
   //println(topic, int(new String(payload)));  // this is a general print of all topics subscribed to.
 
  if (topic.equals("Processing/player3/up")){
  println("M2MQTT_Unity/player3/up",  int(new String(payload)));
  }
  
  if (topic.equals("Processing/player3/down")){
  println("M2MQTT_Unity/player3/down", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player3/left")){
  println("M2MQTT_Unity/player/left", int(new String(payload)));
  }
  
  if (topic.equals("Processing/player3/right")){
  println("M2MQTT_Unity/player3/right", int(new String(payload)));
  }
  
}

void settings() {
  size(400, 400);
}

//Change name "Processing_Player3" to another unique name

void setup() {
  client = new MQTTClient(this);
  client.connect(server, "Processing_Player3");
  client.subscribe("M2MQTT_Unity/connect3");
}

void draw() {
    background(0);
}


void keyPressed(){
  if (key == CODED) {
    if (keyCode == UP) {
      client.publish("M2MQTT_Unity/player3/up", str('1'));
      
    }
    
    else if (keyCode == DOWN) {
      client.publish("M2MQTT_Unity/player3/down", str('1'));
    }
    
    else if (keyCode == LEFT) {
      client.publish("M2MQTT_Unity/player3/left", str('1'));

    }
    
    else if (keyCode == RIGHT) {
      client.publish("M2MQTT_Unity/player3/right", str('1'));
    }
  }

}

void keyReleased(){
  if (key == CODED) {
    if (keyCode == UP) {
      client.publish("M2MQTT_Unity/player3/up", str('0'));
      
    }
    
    if (keyCode == DOWN) {
      client.publish("M2MQTT_Unity/player3/down", str('0'));
    }
    
    if (keyCode == LEFT) {
      client.publish("M2MQTT_Unity/player3/left", str('0'));

    }
    
    if (keyCode == RIGHT) {
      client.publish("M2MQTT_Unity/player3/right", str('0'));
    }
  }

}
