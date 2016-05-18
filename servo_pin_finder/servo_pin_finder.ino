#include <Servo.h>

Servo base1;
void setup() {
  //pins: 6,7,8,9,10,11
  Serial.begin(9600);
  Serial.println("we are ready go!");
}

void loop() {
  
  if(Serial.available()>0){
  int x = Serial.read();
  base1.attach(x);
  Serial.print("servo selected: ");
  Serial.print(x);
  Serial.println();

   int y = Serial.read();
   base1.write(y);
   Serial.print("angle set at: ");
   Serial.print(y);
   Serial.println();
  }else{
    Serial.println("waiting for serial...");
    }
}
