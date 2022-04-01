// Francisco Javier Chacón de Dios
// Diplomado de titulación 2021 (Febrero-Abril)
// contador_binario.ino
// Práctica de contador binario usando 3 bits de 0 a 7.


void setup() {
  pinMode(D1, OUTPUT);
  pinMode(D2, OUTPUT);
  pinMode(D5, OUTPUT);
}

void loop() {
  for (int counter = 0; counter < 8; counter++) {
    digitalWrite(D1, byteValue(counter, 0));
    digitalWrite(D2, byteValue(counter, 1));
    digitalWrite(D5, byteValue(counter, 2));
    delay(500);
  }
}

int byteValue(int number, int bytePosition) {
  return (number >> bytePosition) & 1;
}
