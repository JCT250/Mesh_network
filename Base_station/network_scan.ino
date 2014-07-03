void network_scan()
{
  digitalWrite(yellow, HIGH);
  digitalWrite(green, HIGH);
  Serial.println("Scanning");
  for(int i=0; i<29; i++)
  {
    if(network_nodes[i] > 0)
    {
      Serial.print("Scanning node: 0");
      Serial.println(network_nodes[i], OCT);
      char* tx_message = "lifecall from 00";
      RF24NetworkHeader header(/*to node*/ network_nodes[i], 'l');
      bool ok = network.write(header,tx_message,strlen(tx_message));
      for(int n=0; n<1000; n++)
      {
        network.update();
        delay(1);
        while(network.available())
        {
          // If so, grab it and print it out
          RF24NetworkHeader header;
          static char message[32];
          network.read(header,message,sizeof(message));
          if(header.type = 'l')
          {
            if(header.from_node == network_nodes[i])
            {

              Serial.println(message);
              node_alive[i] = 1;
              n=1500;
              digitalWrite(red, LOW);
            }
          }
          else
          {
            node_alive[i] = 0;
            n=500;
          }
        }
      }
      if(node_alive[i] == 0) digitalWrite(red, HIGH);
    }
    delay(100);
  }
  digitalWrite(yellow, LOW);
  digitalWrite(green, LOW);
  digitalWrite(red, LOW);
/*  for(int i=0; i<29; i++)
  {
    if(network_nodes[i] >0)
    {
      Serial.print("Node 0");
      Serial.print(network_nodes[i], OCT);
      if(node_alive[i] == 0) Serial.println(" dead");
      else if(node_alive[i] == 1) Serial.println(" alive");
    }
  }
  */
  Serial.println("Network Ready");
}












