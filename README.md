# Ozzilloscope

Just send numeric values to your serial PC port and it will draw all for you!

![Oscilloscope](https://github.com/hlavrencic/ozzilloscope/raw/master/Ozzilloscope.gif)

## Arduino Example


    #include  "Arduino.h"
	void  setup(){
		pinMode(5, INPUT);
		Serial.begin(230400);
	}
	void  loop(){
		Serial.println(analogRead(5));
	}
    

## Downloads

- Just for Windows systems: [Ozzilloscope.exe 1.0.1v](https://github.com/hlavrencic/ozzilloscope/raw/master/Ozzilloscope.exe)
 
