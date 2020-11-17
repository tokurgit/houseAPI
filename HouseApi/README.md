# Overview
In general, I believe I managed to build a basic REST API, with some error checking and functionality and by connecting to SQL Server.
The main issue I haven't resolved is the inability to update list of flats within a particular House and the list of residents within a particular Flat.
There are three entities:
- House
- Flat
- Resident

There are three endpoints in which you can fully utilize four methods via POSTMAN:
- GET() -> gets all entities within the requested table
- GET(int id) -> gets a particular entity by id
- POST(Entity entity) -> creates a new entity
- PUT(int id, Entity entity -> allows to make edits to existing entities
- DELETE(int id) -> deletes an existing entity

https://localhost:44358/{endpoint}
1. api/Houses
2. api/Flats
3. api/Residents