int potPin = A0;  // Define o pino do potenciômetro
int led1Pin = 2;
int led2Pin = 3;
int led3Pin = 4;
String mensagem = "";         // Variável para armazenar a mensagem recebida
String inputString = "";      // Variável para armazenar a string de entrada
String commandString = "";    // Variável para o comando do LED
bool stringComplete = false;  // Flag para indicar se a string está completa
bool potentiometerActive = false; // Flag para ativar/desativar a leitura do potenciômetro

void setup() {
  Serial.begin(9600);            // Configura comunicação serial com 9600 bps
  pinMode(LED_BUILTIN, OUTPUT);  // Configura pino do LED embutido como saída
  pinMode(led1Pin, OUTPUT);      // Configura pino do LED 1 como saída
  pinMode(led2Pin, OUTPUT);      // Configura pino do LED 2 como saída
  pinMode(led3Pin, OUTPUT);      // Configura pino do LED 3 como saída
  pinMode(potPin, INPUT);

  // Iniciar com LEDs desligados
  digitalWrite(led1Pin, LOW);
  digitalWrite(led2Pin, LOW);
  digitalWrite(led3Pin, LOW);
}

void loop() {
  // Somente processa comandos se a string estiver completa
  if (stringComplete) {
    processCommand(mensagem);  // Processa o comando recebido via serial
    stringComplete = false;    // Reseta flag após processar
  }

  // Leitura e envio do valor do potenciômetro se estiver ativo
  if (potentiometerActive) {
    int potValue = analogRead(potPin);      // Lê o valor analógico do potenciômetro
    Serial.println("Potentiometer: " + String(potValue));  // Envia o valor para a serial
    delay(400);
  }
}

void processCommand(String msg) {
  // Verifica comando "A" para ligar/desligar LED embutido
  if (msg.equalsIgnoreCase("A")) {
    toggleBuiltinLED();
  } 
  else if (msg.equalsIgnoreCase("#POTENTIOMETER_ON")) {
    potentiometerActive = true;  // Ativa a leitura do potenciômetro
    Serial.println("Leitura do potenciometro ativada.");
  } 
  else if (msg.equalsIgnoreCase("#POTENTIOMETER_OFF")) {
    potentiometerActive = false; // Desativa a leitura do potenciômetro
    Serial.println("Leitura do potenciometro desativada.");
  }
  else {
    // Processa comandos para LEDs 1, 2 e 3
    getCommand();
    if (commandString.equals("LED1")) {
      setLEDState(led1Pin);
    } else if (commandString.equals("LED2")) {
      setLEDState(led2Pin);
    } else if (commandString.equals("LED3")) {
      setLEDState(led3Pin);
    } else {
      Serial.println("Mensagem: " + msg);
    }
  }
}

void toggleBuiltinLED() {
  if (digitalRead(LED_BUILTIN) == HIGH) {
    digitalWrite(LED_BUILTIN, LOW);
    Serial.println("LED embutido desligado!");
  } else {
    digitalWrite(LED_BUILTIN, HIGH);
    Serial.println("LED embutido ligado!");
  }
}

void setLEDState(int ledPin) {
  // Verifica se a mensagem contém "ON" ou "OFF"
  if (mensagem.indexOf("ON") != -1) {
    digitalWrite(ledPin, HIGH);  // Liga o LED
    Serial.println("LED no pino " + String(ledPin) + " ligado!");
  } else if (mensagem.indexOf("OFF") != -1) {
    digitalWrite(ledPin, LOW);   // Desliga o LED
    Serial.println("LED no pino " + String(ledPin) + " desligado!");
  } else {
    Serial.println("Comando inválido para o LED.");
  }
}

void getCommand() {
  // Extrai comando da string, ex: "#LED1ON"
  if (mensagem.length() > 5) {
    commandString = mensagem.substring(1, 5);  // Ex: "LED1", "LED2", "LED3"
    Serial.println("Comando processado: " + commandString);
  }
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    inputString += inChar;
    
    // Se o caractere for uma nova linha, a string está completa
    if (inChar == '\n') {
      inputString.trim();         // Modifica a string diretamente
      mensagem = inputString;     // Atribui à variável mensagem
      stringComplete = true;      // Marca string como completa
      inputString = "";           // Reseta para próxima leitura
    }
  }
}
