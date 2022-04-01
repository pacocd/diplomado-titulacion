#define Trigger D2
#define Reader D1
void setup() {
  Serial.begin(9600);
  pinMode(Reader, INPUT);
  pinMode(Trigger, OUTPUT);

  digitalWrite(Trigger, LOW);
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(Trigger, HIGH);
  delay(10);
  digitalWrite(Trigger, LOW);
  long analogValue = pulseIn(Reader, HIGH);
  long distance = analogValue / 59;
  
  Serial.printf("Distancia: %ld\n", distance);
  delay(500);
}
