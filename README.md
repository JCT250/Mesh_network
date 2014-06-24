Mesh_network
============
Based on the nRF libraries and low power nodes by manaicbug

Basic sketches for setting up a base station and remote station nodes.

Load the base station sketch onto the base station node and leave connected to computer with serial terminal open
as remote nodes come online they will ping the base station.

Load the remote station sketch onto the remote nodes. Connect to computer, open serial terminal and reset. Push 
and hold the button until all three LEDs have turned on and then turned off again. Node will ask for address 
via serial port. Enter address finishing with a lowercase n character eg 01n, 055n, 02n.

For more information on addressing and network layout see http://maniacbug.wordpress.com/2012/03/30/rf24network/

Still to do:

Add provision for controlling input and output pins on remote nodes.
Write software to easily interface with base station node from computer
