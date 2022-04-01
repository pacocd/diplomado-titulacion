void setup() {
  pinMode(A0, INPUT);
  pinMode(D1, OUTPUT);

  Serial.begin(9600);
  Serial.println("Fotorresistencia");
}

void loop() {
  int photoceldaValue = analogRead(A0);

  Serial.println(photoceldaValue);
  if (photoceldaValue <= 120) {
    digitalWrite(D1, HIGH);
  } else {
    digitalWrite(D1, LOW);
  }

  delay(500);
}
