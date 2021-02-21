int data;
void setup() {
  // put your setup code here, to run once:
Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly: 
  data = analogRead(A0);
  data = data/4;
  Serial.write(data);
  delay(2);
}
