cd infrastructure
./stop-all.ps1
./start-all.ps1

FakeOracleFetchApi:
cd src/Services/FakeOracleFetchApi
dapr run --app-id fakeoraclefetchapi dotnet run

Webstatus:
cd src/Web/Webstatus
dapr run --app-id webstatus dotnet run

EmailApi:
cd src/Services/EmailApi/src/Web
dapr run --app-id emailapi dotnet run

[text](http://localhost:4000)

RabbitMQ:
http://localhost:15672/
guest
guest

- vorige keer:
  - DatabaseConnectie
- nu af:
  - Zelf een fake oracle database met sqlite
  - Swagger
  - Sqlite
  - HealthChecks
- ben mee bezig:
  - Email data omzetten naar een email die verzonden kan worden
  - Verzenden van de emails
- Vragen:
  - Zit er al een email in de database met emailbijlage?

MJML bestanden (mjml is syntax)

zet om in

Razor Pages:

toegang tot razor engine

@html.displayfor (output encoding)

output is veilig
