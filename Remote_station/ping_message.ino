
void ping_message ()
{
  digitalWrite(yellow, HIGH);
  S_message message;
  message.temp_reading = measure_temp(); 
  message.voltage_reading = measure_voltage();
  message.node_add = this_node; 

  Serial.print("Sending: ");
  Serial.println(message.toString());
  char* tx_message = message.toString();
  RF24NetworkHeader header(/*to node*/ 00);
  bool ok = network.write(header,tx_message,strlen(tx_message));
  if (ok)
  {
    Serial.println("OK");
    digitalWrite(red, LOW);
  }
  else
  {
    Serial.println("TX Fail");
    delay(250); // extra delay on fail to keep light on longer
    digitalWrite(red, HIGH);
  }
  digitalWrite(yellow, LOW);
}


