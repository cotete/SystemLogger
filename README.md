# Desafio est�gio Lummen AI

## Sistema para observa��o do sistema
- Sistema desenvolvido com intuito de monitorar a��es que o usu�rio realiza no sistema
- Realizado em forma de um aplicativo de console.


## Instru��es para rodar o projeto
### 1 - Clonar reposit�rio
- `https://github.com/cotete/SystemLogger`
### 2 - Acessar pastas
- ``



## Descri��o das Pastas e Arquivos

### **Watchers\\**: Cont�m classes que monitoram eventos do sistema, como teclado, mouse e processos.
  - **KeyboardAndMouse.cs**: Classe que monitora eventos de teclado e mouse, capturando combina��es de teclas como `Ctrl+c` e Cliques no mouse.
  - **SystemWatcher.cs**: Classe que monitora processos do sistema e captura a abertura de arquivos especificos.

### **Sender\\**: Cont�m classes para enviar dados � API.
  - **Sender.cs**: Classe que utiliza `HttpClient` para realizar requisi��o POST com os dados monitorados.

### **Util\\**: Cont�m classes que de utilidade do projeto.
  - **ImageConv.cs**: Classe para convers�o de imagens capturadas em strings Base64.
  - **ScreenshotEvent.cs**: Classe para realizar a captura de tela quando chamada a fun��o CaptureScreen.


  ### Explica��o
  - Escolhi deixar a estrutura assim, pois acredito que desta maneira o projeto est� organizado, deixando cada parte com uma fun��o,
	fazendo o projeto ser modular oque ajuda na escalabilidade dele.

## Pacotes
### MouseKeyHook : Utilizado para capturar eventos de mouse e de teclado
- Utilizei esse pacote, pois com ela tenho facil acesso aos eventos de teclado e mouse, assim deixando o projeto menos verboso, e de mais facil entendimento, facilitando os ajustes futuros.

### TraceEvent : Utilizado para capturar os eventos de sistema em tempo real
- Utilizei esse pacote, pois foi o que mais atendia para o desafio, pois com ele consigo observar os eventos do sistema, como abertura de arquivos em tempo real. 



