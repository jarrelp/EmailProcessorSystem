cd infrastructure
./stop-all.ps1
./start-all.ps1

OracleFetchApi:
cd src/Services/OracleFetchApi
dapr run --app-id oraclefetchapi dotnet run

Webstatus:
cd src/Web/Webstatus
dapr run --app-id webstatus dotnet run

EmailSendApi:
cd src/Services/EmailSendApi/src/Web
dapr run --app-id emailsendapi dotnet run

[text](http://localhost:4000)

RabbitMQ:
http://localhost:15672/
guest
guest
