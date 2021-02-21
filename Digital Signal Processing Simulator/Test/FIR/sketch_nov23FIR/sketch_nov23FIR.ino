
int data[900];
float fil;
int i,a;

void setup() {
  // put your setup code here, to run once:
Serial.begin(115200);
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly: 

//if (i>2)
//{
//i=2;
//data[i-2]=data[i-1];
//data[i-1]=data[i];
//
//
//}
for (i=0;i<901;i++){
data[i] = analogRead(A0)/4;
fil = (0.5*data[i])+(0.5*data[i-1])+(0.5*data[i-2]);
fil = fil;
PORTD=int(fil);
}
//for (i=0;i<901;i++){
//
//fil = (0.3*data[i]);//-(0.3*data[a-1])+(0.3*data[a-2]);
//
//}

//fil=analogRead(A0)/4;


//delay(5);

}
