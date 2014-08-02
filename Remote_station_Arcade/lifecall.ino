
void lifecall ()
{
  Serial.println("Lifecall");
  S_message message;
  message.temp_reading = measure_temp(); 
  message.voltage_reading = measure_voltage();
  message.node_add = this_node;
  int success = 0;
  while(success == 0)
  { 
    digitalWrite(yellow, HIGH);
    Serial.print("Sending: ");
    Serial.println(message.toString());
    char* tx_message = message.toString();
    RF24NetworkHeader header(/*to node*/ 00, 'l');
    bool ok = network.write(header,tx_message,strlen(tx_message));
    if (ok)
    {
      Serial.println("OK");
      digitalWrite(red, LOW);
      success = 1;
    }
    else
    {
      Serial.println("TX Fail");
      delay(250); // extra delay on fail to keep light on longer
      digitalWrite(red, HIGH);
    }
    digitalWrite(yellow, LOW);
  }
}






