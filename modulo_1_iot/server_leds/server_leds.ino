//Control de LED's mediante un navegador Web
//El server HTTP estará instalado en la placa

#include <ESP8266WiFi.h> 
 
//Credenciales del WiFi
const char* ssid = "casa 2,4";
const char* password = "06241225";
 
int led0 = D0;    
int led1 = D1;
int led2 = D2;
int led3 = D3;

int value0 = LOW;
int value1 = LOW;
int value2 = LOW;
int value3 = LOW;


//crear Instancia Servidor, puerto=80
WiFiServer serverHTTP(80); 
 
void setup() {
  Serial.begin(9600); 
 
  pinMode(led0, OUTPUT);
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(led3, OUTPUT);
    
  digitalWrite(led0, LOW);
  digitalWrite(led1, LOW);
  digitalWrite(led2, LOW);
  digitalWrite(led3, LOW);
 
  
  Serial.println();
  Serial.println();
  Serial.print("Conectando a ");
  Serial.println(ssid);

 // Conexión con la red WiFi
  WiFi.begin(ssid, password);
 
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  
  Serial.println("");
  Serial.println("WiFi conectado");

 
  //Iniciar el servidor HTTP para que empiece a escuchar peticiones
  serverHTTP.begin();
 
  Serial.println("Servidor iniciado");
 
  //Mostrar IP local asignada (URL del servidor).
  Serial.print("Usa esta URL para conectarte al servidor: ");
  Serial.print("http://");
  Serial.print(WiFi.localIP());
  Serial.println("/");
}

 
void loop() {
  // Comprobar si hay un cliente disponible (una petición)
  WiFiClient client = serverHTTP.available();
  if (!client) {
    return; // En caso de no haber un cliente, regresar a loop()
  }
 
  // Esperando a que el cliente realice una petición
  Serial.println("¡Nuevo cliente!");

  //client.available() -> número de bytes disponibles para lectura
  while (!client.available()){   
    delay(1);
  }
 
  // Se lee la linea de la petición del cliente hasta el retorno de carro
  String request = client.readStringUntil('\r'); 
  Serial.println(request);                       //Imprime la cadena de la petición del cliente
  client.flush();                                //Limpia el buffer
 
  // Interpretando lo que se ha recibido
//Led 1 
  if (request.indexOf("/LED0=ON") != -1)  {
    digitalWrite(led0, HIGH);
    value0 = HIGH;
  }
  if (request.indexOf("/LED0=OFF") != -1)  {
    digitalWrite(led0, LOW);
    value0 = LOW;
  }
  
//Led 2
  if (request.indexOf("/LED1=ON") != -1)  {
    digitalWrite(led1, HIGH);
    value1 = HIGH;
  }  
  if (request.indexOf("/LED1=OFF") != -1)  {
    digitalWrite(led1, LOW);
    value1 = LOW;
  }
  
//Led 3
if (request.indexOf("/LED2=ON") != -1)  {
    digitalWrite(led2, HIGH);
    value2 = HIGH;
  }
  if (request.indexOf("/LED2=OFF") != -1)  {
    digitalWrite(led2, LOW);
    value2 = LOW;
  }

// Led 4
  if (request.indexOf("/LED3=ON") != -1)  {
    digitalWrite(led3, HIGH);
    value3 = HIGH;
  }
  if (request.indexOf("/LED3=OFF") != -1)  {
    digitalWrite(led3, LOW);
    value3 = LOW;
  }
 
  // Se devuelve la respuesta al cliente
  client.println("HTTP/1.1 200 OK");
  client.println("Content-Type: text/html");
  client.println(""); //  do not forget this one
  
  // Creación de la página Web en HTML
  client.println("<!DOCTYPE HTML>"); 
  client.println("<html>  <head> <meta charset='UTF-8'> </head>");
  client.println("<body>");
  
//Led 1
  client.print("La luz está:  ");
  if(value0 == HIGH) {
    client.print("ON");
  } else {
    client.print("OFF");
  }
  client.println("<br>");
  client.println("<a href=\"/LED0=ON\"\"><button>Encender Luz</button></a>"); 
  client.println("<a href=\"/LED0=OFF\"\"><button>Apagar Luz</button></a><br />");
  client.println("<br>");

//Led 2
  client.print("Las Puertas están:  ");
 
  if(value1 == HIGH) {
    client.print("ON");
  } else {
    client.print("OFF");
  }
  client.println("<br>");
  client.println("<a href=\"/LED1=ON\"\"><button>Abrir Puerta</button></a>"); 
  client.println("<a href=\"/LED1=OFF\"\"><button>Cerrar Puerta</button></a><br />");
  client.println("<br>");

//Led 3
  client.print("Las Ventanas están:  "); 
  if(value2 == HIGH) {
    client.print("ON");
  } else {
    client.print("OFF");
  }
  client.println("<br>");
  client.println("<a href=\"/LED2=ON\"\"><button>Abrir Ventana</button></a>");
  client.println("<a href=\"/LED2=OFF\"\"><button>Cerrar Ventana</button></a><br />");
  client.println("<br>");

//Led 4
  client.print("La Cochera está:  "); 
  if(value3 == HIGH) {
    client.print("ON");
  } else {
    client.print("OFF");
  }
  client.println("<br>");
  client.println("<a href=\"/LED3=ON\"\"><button>Abrir Cochera</button></a>");
  client.println("<a href=\"/LED3=OFF\"\"><button>Cerrar Cochera</button></a><br />");
  client.println("</body>");
  client.println("</html>");

  delay(1);
  client.stop();
  Serial.println("Cliente desconectado");
  Serial.println("");
}
