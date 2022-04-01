#define Trigger D2
#define Echo D5
#define Relay D1

void setup() {
  Serial.begin(9600);
  pinMode(Echo, INPUT);
  pinMode(Trigger, OUTPUT);
  pinMode(Relay, OUTPUT);

  digitalWrite(Trigger, LOW);
}

void loop() {
  digitalWrite(Trigger, HIGH);
  delay(10);
  digitalWrite(Trigger, LOW);
  long analogValue = pulseIn(Echo, HIGH);
  long distance = analogValue / 59;

  Serial.printf("Distancia: %ld\n", distance);
  if (distance < 100) {
    digitalWrite(Relay, HIGH);
    delay(5000);
  } else {
    digitalWrite(Relay, LOW);
    delay(500);
  }
}
