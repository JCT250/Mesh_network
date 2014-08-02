
uint32_t measure_temp()
{
    int i = num_measurements;
    uint32_t reading = 0;
    while(i--)
      reading += analogRead(temp);
    
    // Convert the reading to celcius*256
    // This is the formula for MCP9700.
    // C = reading * 1.1
    // C = ( V - 1/2 ) * 100
    //
    // Then adjust for the calibation value on this sensor
    return ( ( ( ( reading * 0x120 ) - 0x800000 ) * 0x64 ) >> 16 ) + temp_calibration;
}

uint32_t measure_voltage()
{

//uint32_t reading = analogRead(volt);
//reading = reading 

  // Take the voltage reading 
    int i = num_measurements;
    uint32_t reading = 0;
    while(i--)
      reading += analogRead(volt);

    // Convert the voltage reading to volts*256
    return ( reading * voltage_reference ) >> 16; 
}
