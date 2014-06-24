#include <nRF24L01.h>
#include <RF24.h>
#include <RF24_config.h>

#include <SPI.h>

#include <RF24Network.h>
#include <RF24Network_config.h>
#include <Sync.h>

int dd1 = 0;
int dd2 = 0;
int aa1 = 0;
int aa2 = 0;
int red = 3; 
int yellow = 4;
int green = 5;
int btn = 6;

// Setup radio on SPI and pins 8 and 7
RF24 radio(8,7);

// Declare Network
RF24Network network(radio);

// Our node address 
uint16_t this_node = 00;

void startup()
{
  digitalWrite(red, HIGH);
  delay(500);
  digitalWrite(yellow, HIGH);
  delay(500);
  digitalWrite(green, HIGH);
  delay(500);
  digitalWrite(red, LOW);
  digitalWrite(yellow, LOW);
  digitalWrite(green, LOW);

  for(int i=0; i<=2; i++)
  {
    digitalWrite(red, HIGH);
    digitalWrite(yellow, HIGH);
    digitalWrite(green, HIGH);
    delay(250);
    digitalWrite(red, LOW);
    digitalWrite(yellow, LOW);
    digitalWrite(green, LOW);
    delay(250);    
  }
}

void setup() {
  // put your setup code here, to run once:

  Serial.begin(57600);

  pinMode(dd1, OUTPUT);
  pinMode(dd2, OUTPUT);
  pinMode(aa1, OUTPUT);
  pinMode(aa2, OUTPUT);
  pinMode(red, OUTPUT);
  pinMode(yellow, OUTPUT);
  pinMode(green, OUTPUT);
  pinMode(btn, INPUT_PULLUP);

  startup();

  SPI.begin();
  radio.begin();
  network.begin(/*channel*/ 90, /*node address*/ this_node);

  Serial.println("Network up - Base Station");
}

void loop() {
  // put your main code here, to run repeatedly: 
  network.update();

  // Is there anything ready for us?
  while ( network.available() )
  {
    digitalWrite(green, HIGH);
    // If so, grab it and print it out
    RF24NetworkHeader header;
    static char message[32];
    network.read(header,message,sizeof(message));
    Serial.print("Received: \"");
    Serial.print(message);
    Serial.print("\" from node 0");
    Serial.println(header.from_node);
    digitalWrite(green, LOW);
  }
}




