
void ping_message ()
{
  digitalWrite(yellow, HIGH);
  Serial.println("Pinging Base");
  char* tx_message = "Ping";
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

