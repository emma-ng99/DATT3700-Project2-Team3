import mqtt.*;
MQTTClient client;

int count = 1;
int countUp;

static final String server = "mqtt://datt3700:datt3700experiments@datt3700.cloud.shiftr.io";

void messageReceived(String topic, byte[] payload) {
   //println(topic, int(new String(payload)));  // this is a general print of all topics subscribed to.
 
  if (topic.equals("Processing/player/W")){
  countUp = int(new String(payload));
  println("Processing/player/W" + (countUp));
  }
  
  
}

void settings() {
  size(400, 400);
}

void setup() {
  client = new MQTTClient(this);
  client.connect(server, "Processing");
  client.subscribe("Processing/player/W");
  client.subscribe("M2MQTT_Unity/connect");
}

void draw() {
    background(0);
}


void keyPressed(){
  if (keyPressed) {
    if (key == 'w' || key == 'W') {
      client.publish("Processing/player/W", str(count));
      count++;
    }
  }

}
