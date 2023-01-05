# hexapod_velocity_C_sharp_console
This C# console program sets velocity of the hexapod. 

The C# program asks for previous velocity of the hexapod. It asks you if you want to change the velocity of the hexapod, if yes, then it sets new velocity of the hexapod and prints it into the console application. 

The C# program asks for IP address of hexapod, for example 147.213.112.19, and port of hexapod, for example 50000. It creates session with hexapod using TCPClient in the line 25. In the line 26, the NetworkStream is established. It asks for previous or last velocity of the hexapod by sending VLS? command to the hexapod. It prints the last velocity of the hexapod. Then, it asks if you want to set the new velocity of the hexapod. If yes (Y or y), it asks you for new velocity value. It sets new velocity value and again asks for current or new velocity value by sending VLS? command to the hexapod. The new velocity value is printed into the console application. Finally, the network stream is flushed and closed. The TCP session with hexapod is also closed. 
