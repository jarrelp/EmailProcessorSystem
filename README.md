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

MJML bestanden (mjml is syntax)

zet om in

Razor Pages:

toegang tot razor engine

@html.displayfor (output encoding)

output is veilig

- context:
  - Ik kwam deze week tot de conclussie dat de clean architecture niet handig is om te gebruiken voor het project
  - Dus ik ga het clean architecture schappen en vanaf nu alleen maar n-layer architecture gebruiken
  - En me voornamelijk focussen op het belangrijke, om de applicatie af te krijgen
- ben bezig geweest met:
  - Ik ben bezig geweest om ervoor te zorgen dat alle attributen van de emailqueue geupdated kunnen worden met de api
- Wat ga ik doen:

  - Dennis gaat me vanmiddag helpen met de trigger
  - Leon heeft een demo projectje gemaakt waarin een email met mjml encoderen wordt verstuurd

- Clean Architecture:

  - Ik wilde clean architecture gebruiken omdat je hiermee makkelijker unit tests kan schrijven
  - Ook maakt clean architecture gebruik van events en eventhandlers
  - Maar Clean architecture is vooral gericht op domainmodels

  10.0.4.49
