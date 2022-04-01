#include "DHT.h"
#define DHTTYPE DHT11
#define pinDHT11 0

DHT dht(pinDHT11, DHTTYPE);

void setup() {
  dht.begin();
  Serial.begin(9600);
  delay(500);
}

void loop() {
  float h = dht.readHumidity();
  float t = dht.readTemperature();

  Serial.print("Humedad: ");
  Serial.println(h);
  Serial.print("Temperatura: ");
  Serial.println(t);
  delay(500);
}
