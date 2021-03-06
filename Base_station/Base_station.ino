#include <nRF24L01.h>
#include <RF24.h>
#include <RF24_config.h>

#include <SPI.h>

#include <RF24Network.h>
#include <RF24Network_config.h>
#include <Sync.h>

int dd1 = 10;
int aa1 = A0;
int aa2 = A1;
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

// Address that we are going to send a message to 
uint16_t txmessage_destination = 00;

// value that we are putting in that message
uint8_t txmessage_value = 0;

// and the message type that we are assigning that message
char txmessage_type;

// String that we read the incoming serial data into 
char serial_rxd[] = "            ";

//buffer used to parse rx serial data
char buffer[6];

// How often to flash
const unsigned long interval = 10000; //ms

// When did we last flash?
unsigned long last_lit;

// Current time
unsigned long now;

// These are the addresses of the nodes that we expect to be on our network. Leading 0 defines numbers as being Octal
uint16_t network_nodes[30] = {
  01, 02, 03, 04, 05, 011, 012, 013, 014, 015, 021, 022, 023, 024, 025};

// This holds the state of the nodes after we scan to see if they are alive
uint16_t node_alive[30] = {
  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

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
  network_scan();
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
    Serial.print("\" from Node 0");
    Serial.println(header.from_node, OCT);
    digitalWrite(green, LOW);
  }

  // If it's time to flash then...
  now = millis();
  if (now - last_lit > interval)
  {
    digitalWrite(green, HIGH);
  }
  if(now - last_lit > interval + 50)
  {
    digitalWrite(green, LOW);
    last_lit = now;
  }

  if(Serial.available()>=12)
  {
    for(int i=0; i<=11; i++) serial_rxd[i] = ' '; // wipe the incoming data array
    while(serial_rxd[0] != 'd') serial_rxd[0] = Serial.read(); // read into the first position of the array until we find the destination prefix
    for(int n=1; n<12; n++) serial_rxd[n] = Serial.read(); //read the rest of the serial buffer into the array
    Serial.println(serial_rxd);
    if(serial_rxd[0] == 'd')
    {
      if(serial_rxd[6] == 'v')
      {
        if(serial_rxd[10] == 't')
        {
          for(int m=0; m<6; m++) buffer[m] = ' '; //reset buffer
          for(int m=0; m<5; m++) buffer[m] = serial_rxd[m+1]; //copy section of serial_rxd into temp buffer
          buffer[5] = '\0'; //null terminate
          txmessage_destination = strtol(buffer, NULL, 8); // extract address and store as octal number

          for(int m=0; m<6; m++) buffer[m] = ' '; //reset buffer
          for(int m=0; m<3; m++) buffer[m] = serial_rxd[m+7]; //copy section of serial_rxd into temp buffer
          buffer[3] = '\n'; //null terminate
          txmessage_value = atoi(buffer); // convert value to int
          buffer[3] = 'z'; //terminate with non numerical character so that we can send
          txmessage_type = serial_rxd[11]; // set the message type based on the rx string
          
          // uncomment for debug
          /* Serial.print("Destination Address: 0");
           Serial.println(txmessage_destination, OCT);
           Serial.print("Message Value: ");
           Serial.println(txmessage_value);
           Serial.print("Message Type: ");
           Serial.println(txmessage_type);*/

          char* txmessage_content = buffer;
          RF24NetworkHeader header(/*to node*/ txmessage_destination, txmessage_type);
          bool ok = network.write(header,txmessage_content,strlen(txmessage_content));
          if(ok) Serial.println("OK");
          if(serial_rxd [11] == 'l')network_scan();
        } 
      }
    }
    while(Serial.available())Serial.read(); // wipe buffer
  }
}











