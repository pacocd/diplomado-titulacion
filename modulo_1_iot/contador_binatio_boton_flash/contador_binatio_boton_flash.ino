// Francisco Javier Chacón de Dios
// Diplomado de titulación 2021 (Febrero-Abril)
// contador_binario_boton_flash.ino
// Práctica de contador binario usando 3 bits de 0 a 7 aumentando cada que presionan el boton flash.

void setup() {
  pinMode(D1, OUTPUT);
  pinMode(D3, INPUT);
}

void loop() {
  byte buttonStatus = digitalRead(D3);
  digitalWrite(D1, buttonStatus == HIGH ? LOW : HIGH);
}
