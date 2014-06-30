#include <SPI.h>
#include<avr/eeprom.h>

#include <RF24Network.h>
#include <RF24Network_config.h>
#include <Sync.h>

#include <nRF24L01.h>
#include <RF24.h>
#include <RF24_config.h>

#include "S_message.h"


// Setup pin numbers
int dd1 = 10;
int aa1 = A0;
int aa2 = A1;
int red = 3; 
int yellow = 4;
int green = 5;
int btn = 6;
int volt = A3;
int temp = A2;

// Setup pin directions. These are then used to define whether the pin is an input or an output pin. 0 = Output, 1 = Input, 3 = Input with pullup resistor

int dd1d = 0;
int aa1d = 0;
int aa2d = 0;


// How often to flash
const unsigned long interval = 10000; //ms

// When did we last flash?
unsigned long last_lit;

// Current time
unsigned long now;

//number of voltage and temp measurements to take
const int num_measurements = 64;

// What voltage is a reading of 1023?
const unsigned voltage_reference = 3.44 * 256; // 5.0V

// What is the temperature calibration value. Change the first number only. 
const int16_t temp_calibration = 0x0*0x10;

//message received from other node
char rxmessage[32]; 

// Setup radio on SPI and pins 8 and 7
RF24 radio(8,7);

// Declare Network
RF24Network network(radio);

// Our node address 
uint16_t this_node;
uint16_t new_address;

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
  //hold button down to enter config
  if(digitalRead(btn) == LOW) config_mode();
}

void setup() {
  // put your setup code here, to run once:

  analogReference(INTERNAL);

  Serial.begin(57600);

  if(dd1d == 0) pinMode(dd1, OUTPUT);
  if(dd1d == 1) pinMode(dd1, INPUT);
  if(dd1d == 2) pinMode(dd1, INPUT_PULLUP);
  if(aa1d == 0) pinMode(aa1, OUTPUT);
  if(aa1d == 1) pinMode(aa1, INPUT);
  if(aa1d == 2) pinMode(aa1, INPUT_PULLUP);
  if(aa2d == 0) pinMode(aa2, OUTPUT);
  if(aa2d == 1) pinMode(aa2, INPUT);
  if(aa2d == 2) pinMode(aa2, INPUT_PULLUP);
  pinMode(red, OUTPUT);
  pinMode(yellow, OUTPUT);
  pinMode(green, OUTPUT);
  pinMode(btn, INPUT_PULLUP);
  pinMode(volt, INPUT);
  pinMode(temp, INPUT);

  //Read node address from eeprom
  this_node = eeprom_read_word((uint16_t*)10);

  // Run the LED routine and if button is depressed at the end of the routine enter config mode
  startup(); 

  SPI.begin();
  radio.begin();
  network.begin(/*channel*/ 90, /*node address*/ this_node);
  Serial.print("Network up - Node address is: 0");
  Serial.println(this_node, OCT);

}

void loop() {
  // put your main code here, to run repeatedly: 
  network.update();


  while ( network.available() )
  {
    digitalWrite(green, HIGH);
    // If so, grab it and print it out
    RF24NetworkHeader header;
    for(int i=0; i<32; i++) rxmessage[i] = ' '; // this doesn't work....
    network.read(header,rxmessage,sizeof(rxmessage));
    digitalWrite(green, LOW);
    if(header.type == 'l') 
    {
      lifecall();
    }
    else if(header.type != 1)
    {
      switch(header.type)
      {
      case 'a':
        digitalWrite(red, HIGH);
        digitalWrite(yellow, HIGH);
        digitalWrite(green, HIGH);
        delay(200);
        digitalWrite(red, LOW);
        digitalWrite(yellow, LOW);
        digitalWrite(green, LOW);
        delay(200);
        digitalWrite(red, HIGH);
        digitalWrite(yellow, HIGH);
        digitalWrite(green, HIGH);
        delay(200);
        digitalWrite(red, LOW);
        digitalWrite(yellow, LOW);
        digitalWrite(green, LOW);
        break;

      case 'b':
        if(dd1d == 0) digitalWrite(dd1, HIGH);
        break;

      case 'c':
        if(dd1d == 0) digitalWrite(dd1, LOW);
        break;

      case 'd':
      Serial.println(rxmessage); // something funny going on here... I suspect that is is some problem with the array in which the incoming messages are stored.
                                  //for some reason the above line prints the correct information and then continues with data conatined in the message section 
                                  // of messages that have previously been received or sent. The documentation indicated that pointers... are used to store the message
                                  // so i'm not exactly sure where the data is being stored. I think that the program is starting to printout the information and then 
                                  // continues until it finds a previously used null character.
        //if(dd1d == 0) analogWrite(dd1, (atoi(message))); // may need to use strtoi here, not sure yet... will also need to add some non numerical character to function as an end character
        break;

      case 'e':
        if(aa1d ==  0) digitalWrite(aa1, HIGH);
        break;

      case 'f':
        if(aa1d == 0) digitalWrite(aa1, LOW);
        break;

      case 'g':
        if(aa2d == 0) digitalWrite(aa2, HIGH);
        break;

      case 'h':
        if(aa2d ==0) digitalWrite(aa2, LOW);
        break;
      }
    }
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
}
















