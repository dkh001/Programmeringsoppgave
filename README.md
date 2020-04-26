# Programmeringsoppgave

1) Install Visual Studio 2019
2) Åpne proskektet i Visual Studio 2019 (Programmeringsoppgave.csproj)
3) Tools -> NuGet Package Manager -> Package Manager Console -> update-database
4) Debug -> Start Without Debugging 
5) Swagger startes for å sjekke forespørsler til database. 
6) Trykk POST -> Try it out -> legg til data i JSON -> Execute 
7) Trykk GET /api/DailyMeasures/GetTotalSumAllMeters/{customer_id}  -> Try it out -> legg inn "customer_id" -> Execute 
8) Trykk GET /api/DailyMeasures/GetTotalSumEachMeters/{customer_id}  -> Try it out -> legg inn "customer_id" -> Execute 
9) Trykk GET /api/DailyMeasures/GetAllTimeSeriesByDay/{date}  -> Try it out -> legg inn "date" -> Execute 
