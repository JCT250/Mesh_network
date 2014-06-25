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

// How often to send ping message to base station
const unsigned long interval = 2000; //ms

// When did we last send ping message?
unsigned long last_sent;

// Current time
unsigned long now;

//number of voltage and temp measurements to take
const int num_measurements = 64;

// What voltage is a reading of 1023?
const unsigned voltage_reference = 3.44 * 256; // 5.0V

// What is the temperature calibration value. Change the first number only. 
const int16_t temp_calibration = 0x0*0x10;

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

  // If it's time to ping then...
  now = millis();
  if (now - last_sent > interval)
  {
    ping_message();
    last_sent = now;
  }

}

