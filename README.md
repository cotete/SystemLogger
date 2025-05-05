# Desafio estágio Lummen AI

## Sistema para observação do sistema
- Sistema desenvolvido com intuito de monitorar ações que o usuário realiza no sistema.
- Realizado em forma de um aplicativo de console.

### Pré-requisitos
   - Certifique-se de que o runtime do .NET 9 está instalado na máquina.
   - Caso não esteja, você pode baixá-lo aqui: [Download .NET Runtime](https://dotnet.microsoft.com/download/dotnet/9.0).
   
## Instruções para rodar o projeto
### 1 - Clonar repositório
- `https://github.com/cotete/SystemLogger`
### 2 - Acessar pastas
- `bin\release\net9.0-windows`
- Dentro desta pasta executar o: `SystemLogger.exe`
### 3 - Testar o projeto
- Nesta etapa só resta testar o projeto.
- É necessário executar como Administrador!
- Eventos Monitorados:
	- Pressionar `Ctrl+c`.
	- Clique do mouse.
	- Abertura de arquivos `.pdf`, `.docx` ou `.xlsx`


## Descrição das Pastas e Arquivos

### **Watchers\\**: Contém classes que monitoram eventos do sistema, como teclado, mouse e processos.
  - **KeyboardAndMouse.cs**: Classe que monitora eventos de teclado e mouse, capturando combinações de teclas como `Ctrl+c` e Cliques no mouse.
  - **SystemWatcher.cs**: Classe que monitora processos do sistema e captura a abertura de arquivos específicos.

### **Sender\\**: Contém classe para enviar dados à API.
  - **Sender.cs**: Classe que utiliza `HttpClient` para realizar requisição POST com os dados monitorados.

### **Util\\**: Contém classes que de utilidade do projeto.
  - **ImageConv.cs**: Classe para conversão de imagens capturadas em strings Base64.
  - **ScreenshotEvent.cs**: Classe para realizar a captura de tela quando chamada a função CaptureScreen.


  ### Explicação
  - Escolhi deixar a estrutura assim, pois acredito que desta maneira o projeto está organizado, deixando cada parte com uma função,
	fazendo o projeto seja modular oque ajuda na escalabilidade dele.

## Pacotes
### MouseKeyHook : Utilizado para capturar eventos de mouse e de teclado
- Utilizei esse pacote, pois com ele tenho fácil acesso aos eventos de teclado e mouse, assim deixando o projeto menos verboso, e com melhor entendimento, facilitando os ajustes futuros.

### TraceEvent : Utilizado para capturar os eventos de sistema em tempo real
- Utilizei esse pacote, pois foi o que mais atendia para o desafio, pois com ele consigo observar os eventos do sistema, como abertura de arquivos em tempo real. 



