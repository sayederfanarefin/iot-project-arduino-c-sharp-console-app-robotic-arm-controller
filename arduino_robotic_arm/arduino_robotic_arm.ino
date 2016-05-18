#include <Servo.h>


Servo base1,base2,arm,shoulder,wrist,claw;

int base1_deg=0;
int base2_deg=180;
int arm_deg=0;
int shoulder_deg=0;
int wrist_deg=0;
int claw_deg = 0;

void setup() {
  base1.attach(8);
  base2.attach(11);
  arm.attach(9);
  shoulder.attach(10);
  wrist.attach(7);
  claw.attach(6);

  Serial.begin(9600);
}

void loop() {
  
  if(Serial.available()>0){
    Serial.println("a");
      String base1_str  = Serial.readStringUntil(',');
    Serial.read(); //next character is comma, so skip it using this
    
    String base2_str = Serial.readStringUntil(',');
    Serial.read(); //next character is comma, so skip it using this

String shoulder_str = Serial.readStringUntil(',');
    Serial.read(); //next character is comma, so skip it using this

    String arm_str = Serial.readStringUntil(',');
    Serial.read(); //next character is comma, so skip it using this

    String wrist_str = Serial.readStringUntil(',');
    Serial.read(); //next character is comma, so skip it using this
    
    String claw_str  = Serial.readStringUntil('\0');

    base1_deg = base1_str.toInt();
    base2_deg = base2_str.toInt();
    arm_deg = arm_str.toInt();
    wrist_deg = wrist_str.toInt();
    shoulder_deg = shoulder_str.toInt();
    claw_deg = claw_str.toInt();

    /*
    //1,45,678,3,09,67
    Serial.println(base1_deg);
    Serial.println(base2_deg);
    Serial.println(shoulder_deg);
    Serial.println(arm_deg);
    Serial.println(wrist_deg);
    Serial.println(claw_deg);
    */
    base1.write(base1_deg);
    base2.write(base2_deg);
    arm.write(arm_deg);
    shoulder.write(shoulder_deg);
    wrist.write(wrist_deg);
    claw.write(claw_deg);
  }
  
    
}
