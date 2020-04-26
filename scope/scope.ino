void setup() {
  Serial.begin(57600);
  Serial.setTimeout(1000);
}

// split string [cmd] based on delimiter [delimiter] and put results in [parts] which is a String* buffer of lenth [len]
// returns the number of parts
int splitString(String cmd, char delimiter, String *parts, int partsLength)
{
  int pStart = 0;
  int pEnd = -1;
  int len = cmd.length();
  
  //String *tParts = new String[len];
  int c = 0;
  bool extract = false;
  for (int i=0; i<len; i++)
  {
    extract = false;
    if (cmd[i] == delimiter)
    {
      pEnd = i;
      extract = true;
    } else if (i == (len - 1))
    {
      // there is one string left
      pEnd = len;
      extract = true;
    }

    if (extract)
    {
      //tParts[c] = cmd.substring(pStart,pEnd);
      parts[c] = cmd.substring(pStart,pEnd);
      pStart = pEnd + 1;
      c++;
      if (c == partsLength) break;  // no more space so break
    }
  }
  //*parts = new String[c];
  //for (int i=0; i<c; i++)
  //{
  //  (*parts)[i] = tParts[i];
  //}
  //delete [] tParts;
  return c;
}

void printTerm()
{
  Serial.print('\n');
}

int pinNumToPin(int pin)
{
  switch (pin)
  {
    case 0:
      return A0;
    case 1:
      return A1;
    case 2:
      return A2;
    case 3:
      return A3;
    case 4:
      return A4;
  }
}

int freeRam () {
  extern int __heap_start, *__brkval; 
  int v; 
  return (int) &v - (__brkval == 0 ? (int) &__heap_start : (int) __brkval); 
}

// variables
unsigned long wait = 0;
unsigned long numPoints = 0;
uint16_t *vals = 0;
unsigned long *times = 0;

void loop() {
  // do what?
  String cmd = Serial.readStringUntil('\n');

  if (cmd == "")
  {
    return;
  }
  
  String parts[10];  // suppoer for 10 arguments
  int r = splitString(cmd, ' ', parts, 10);


  //for (int i=0; i<r; i++)
  //{
  //  Serial.println(parts[i]);
  //}
  //return;
  
  if (r > 0)
  {
    if (parts[0] == F("ping"))
    {
      Serial.print(F("pong"));
      printTerm();


    } else if (parts[0] == F("freeram?"))
    {
      Serial.print(freeRam());
      printTerm();

    } else if (parts[0] == F("wait?"))
    {
      Serial.print(wait);
      printTerm();
      
    } else if (parts[0] == F("wait"))
    {
      double val;
      unsigned long tWait = -1;
      if (r >= 2)
      {
        const char sWait[5];
        char *cEnd;
        parts[1].toCharArray(sWait, 5);
        tWait = strtol(sWait, &cEnd, 10);
        if (cEnd > sWait && tWait >= 0)
        {
          wait = tWait;
          val = analogRead(wait);
        } else {
          Serial.print(tWait);
          Serial.print(" is not a correct time (us)");
          printTerm();
        }
      } else {
        Serial.print("set:wait <time_us:i>");
        printTerm();
      }


    } else if (parts[0] == F("read"))
    {
      double val;
      
      byte pin = -1;
      if (r >= 2)
      {
        const char sPin[5];
        char *cEnd;
        parts[1].toCharArray(sPin, 5);
        pin = strtol(sPin, &cEnd, 10);
        if (cEnd > sPin && pin >= 0)
        {
          val = analogRead(pinNumToPin(pin));
          Serial.print(val);
          printTerm();
        } else {
          Serial.print(pin);
          Serial.print(" is not a correct pin");
          printTerm();
        }
      } else {
        Serial.print("read <pin:i>");
        printTerm();
      }
      
      //Serial.print(analogRead(0));
      //printTerm();



      
    } else if (parts[0] == "rec")
    {
      bool ok = false;
      unsigned long num = 1000;
      byte pin = -1;

      // given a pin number?
      if (r >= 2)
      {
        const char sPin[5];
        char *cEnd;
        parts[1].toCharArray(sPin, 5);
        unsigned long tPin = strtol(sPin, &cEnd, 10);
        if (cEnd > sPin && tPin >= 0)
        {
          pin = tPin;
          ok = true;
        }
      }

      if (ok)
      {
        // given a number of points?
        if (r >= 3)
        {
          const char sPoints[5];
          char *cEnd;
          parts[2].toCharArray(sPoints, 5);
          unsigned long tNum = strtol(sPoints, &cEnd, 10);
          if (cEnd > sPoints && tNum > 0)
          {
            num = tNum;
          }
        }
        
        // assign new storage if: new previous storage, last storage amount was different to the one requested this time
        if (numPoints == 0 || vals == 0 || times == 0 || (numPoints != num))
        {
          if (vals != 0) delete vals;
          if (times != 0) delete times;
          
          vals = new uint16_t[num];
          times = new unsigned long[num];
          numPoints = num;
        }

        // start measuring
        if (wait == 0)
        {
          for (unsigned long si = 0; si < num; si++)
          {
            vals[si] = analogRead(pinNumToPin(pin));
            times[si] = micros();
          }
        } else {
          for (unsigned long si = 0; si < num; si++)
          {
            vals[si] = analogRead(pinNumToPin(pin));
            times[si] = micros();
            delayMicroseconds(wait);
          }
        }

        // send back
        for (unsigned long si = 0; si < num; si++)
        {
          Serial.print(vals[si]);
          Serial.print(",");
          Serial.print(times[si] - times[0]);
          printTerm();
        }
      }
    }
  }
  
}
