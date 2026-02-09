# 🐾 Veterinary Clinic System — MVC + REST API

Full-stack Veterinary Clinic System built with **ASP.NET Core**, **Entity Framework Core**, and **RESTful Web APIs**. The project demonstrates backend architecture, relational data modeling, CRUD operations, API design, and testing with Swagger/Postman.

This project was developed as part of a Computing Science program to showcase production-style web and API development skills.

---

# 📌 Features

## Web Application (ASP.NET Core MVC)

* Full CRUD for:

  * Vet Doctors
  * Pets
  * Pet Profiles
* Entity Framework Core relational models
* One-to-many and one-to-one relationships
* Database seeding with sample data
* Razor UI with navigation and layout
* Pet assignment via dropdown doctor selector
* Pet profile notes:

  * Form input
  * Text file upload (content stored in DB)

## REST API (ASP.NET Core Web API)

* Attribute-routed REST endpoints
* JSON responses
* Proper HTTP status codes
* Relational data loading
* Swagger enabled for testing
* Postman-compatible endpoints

---

# 🧱 Data Model

## Entities

**VetDoctor**

* Id (PK)
* Name
* Specialty

**Pet**

* Id (PK)
* MicrochipId
* Name
* Species
* VetDoctorId (FK)

**PetProfile**

* Id (PK)
* PetId (FK)
* VetNotes

## Relationships

* One VetDoctor → Many Pets
* One Pet → One VetDoctor
* One Pet → One PetProfile

---

# 🔌 API Endpoints (Sample)

## Vet Doctors

```
GET     /api/vetdoctors
GET     /api/vetdoctors/{id}
POST    /api/vetdoctors
PUT     /api/vetdoctors/{id}
DELETE  /api/vetdoctors/{id}
```

## Pets

```
GET     /api/pets
GET     /api/pets/{id}
POST    /api/pets
PUT     /api/pets/{id}
DELETE  /api/pets/{id}
```

## Pet Profiles

```
GET     /api/petprofiles/{petId}
POST    /api/petprofiles
PUT     /api/petprofiles/{petId}
DELETE  /api/petprofiles/{petId}
```

---

# 🛠 Tech Stack

* ASP.NET Core MVC
* ASP.NET Core Web API
* Entity Framework Core
* SQL Database
* Razor Views
* Swagger
* Postman
* C#
* REST
* JSON

---

# ▶️ How To Run

## MVC App

```
dotnet restore
dotnet ef database update
dotnet run
```

Open browser:

```
https://localhost:<port>
```

## API App

```
dotnet restore
dotnet run
```

Open Swagger:

```
https://localhost:<port>/swagger
```

---

# 🧪 Testing

* Tested CRUD operations through:

  * Swagger UI
  * Postman
* Verified relational loading (doctor → pets → profiles)
* Validated error handling and not-found responses

---

# 🎯 Skills Demonstrated

* Backend architecture design
* REST API development
* EF Core relational modeling
* CRUD + validation
* API testing workflows
* Database seeding
* MVC pattern
* Structured routing
* Technical documentation


