void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
Serial.println("ready");
}

void loop() {
  // put your main code here, to run repeatedly:
if(Serial.available()>0){
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
    
    String claw_str = Serial.readStringUntil(',');
    Serial.read();
    
    
    String token = Serial.readStringUntil('\0');

    Serial.println(token);
   
}
}
