void config_mode()
{
  digitalWrite(red, HIGH);
  Serial.print("Node Config - Current address: 0");
  Serial.println(this_node, OCT);
  Serial.println("Please send new address, end with 'n' ");
  
  //get new address from the serial port
  configmode_listen(); //get new address from the serial port
  
  //write to the eeprom the new address in position 10
  eeprom_write_word((uint16_t*)10, new_address); 
  Serial.print("New address: 0");
  
  //then read it back again and echo to confirm
  this_node = eeprom_read_word((uint16_t*)10); 
  Serial.println(this_node, OCT);
  digitalWrite(red, LOW);
}

void configmode_listen(void) //there be dragons here...
{
  char serialdata[10];
  char* nextserialat = serialdata;
  const char* maxserial = serialdata + sizeof(serialdata) - 1;
  bool done = false;
  //
  // Listen for serial input, which is how we set the address
  //
  while(done == false)
  {
    if (Serial.available())
    {
      // If the character on serial input is in a valid range...
      char c = tolower(Serial.read());
      if ( (c >= '0' && c <= '9' ) || (c >= 'a' && c <= 'f' ) ) 
      {
        *nextserialat++ = c;
        if ( nextserialat == maxserial )
        {
          *nextserialat = 0;
          Serial.println("*** Unknown serial command: ");
          nextserialat = serialdata;
        }
      }
      if ( c == 'n' )
      {
        // Convert to octal
        char *pc = serialdata;
        new_address = 0;
        while ( pc < nextserialat )
        {
          new_address <<= 3;
          new_address |= (*pc++ - '0');
        }
        if(new_address > 0)
        {
          done = true;
          Serial.print("Received address: 0");
          Serial.println(new_address, OCT);
        }
        else if(new_address < 0) Serial.println("Unable to configure as base node");
      }
    }
  }
}
