# TakshBE

TakshBE is a backend API built with ASP.NET Core and Entity Framework Core, designed to support educational platforms by managing study materials, assessments, student information, notifications, and more. This API facilitates the creation, retrieval, and management of various educational resources, enabling seamless interaction between students and the educational system.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Database Setup](#database-setup)
- [API Documentation](#api-documentation)
  - [Authentication](#authentication)
  - [Endpoints](#endpoints)
    - [Students](#students)
    - [Assessments](#assessments)
    - [Learning](#learning)
    - [Notices](#notices)
    - [Results](#results)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- **User Management:** Register and authenticate students.
- **Study Materials:** Upload and download PDF study materials categorized by subject and standard.
- **Assessments:** Create and manage assessments, including questions and results tracking.
- **Notifications & Notices:** Send and retrieve notifications and notices for students.
- **Results Tracking:** Record and analyze student results with positional rankings and quarterly summaries.
- **Topics Management:** Manage upcoming topics for different subjects and standards.

## Technologies Used

- **Backend Framework:** ASP.NET Core
- **ORM:** Entity Framework Core
- **Database:** SQL Server (configurable)
- **Language:** C#
- **Others:** Dapper for stored procedures

## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any preferred IDE

### Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/amanjha9716/TakshilaBE.git
   cd takshBE
   ```

2. **Restore Dependencies**

   ```bash
   dotnet restore
   ```

3. **Build the Project**

   ```bash
   dotnet build
   ```

### Configuration

1. **Database Connection**

   Update the `appsettings.json` file with your database connection string:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "your_connection_string"
     },
     // Other configurations
   }
   ```

2. **Configure Services**

   Ensure that the `studentDbcontext` is properly configured in `Startup.cs` or `Program.cs`:

   ```csharp
   services.AddDbContext<studentDbcontext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
   ```

### Database Setup

1. **Apply Migrations**

   ```Nugget Package Manager
   add-migration migration-name
   update database
   ```

   This will create the necessary database schema based on the provided models.

## API Documentation

### Authentication

- **Register:** `POST /api/Students/register`
- **Login:** `GET /api/Students/login?username={username}&password={password}`

### Endpoints

#### Students

- **Register Student**

  ```http
  POST /api/Students/register
  ```

  **Body:**

  ```json
  {
    "Username": "john_doe",
    "Password": "SecurePassword123",
    "Studname": "John Doe",
    "Age": 16,
    "Stand": 10,
    "Image": "base64EncodedImage",
    "Subjects": ["Math", "Science"]
  }
  ```

- **Login**

  ```http
  GET /api/Students/login?username=john_doe&password=SecurePassword123
  ```

- **Get All Students**

  ```http
  GET /api/Students/getAll
  ```

- **Get Notifications**

  ```http
  GET /api/Students/notification?stan=10
  ```

#### Assessments

- **Add Assessment**

  ```http
  POST /api/Assesment/addasses
  ```

  **Body:**

  ```json
  {
    "assessename": "Mid-Term Exam",
    "subject": "Math",
    "expirydate": "2024-12-31",
    "stan": 10,
    "totalstud": 0,
    "questions": []
  }
  ```

- **Get Assessments by Standard**

  ```http
  GET /api/Assesment/getasses?stan=10
  ```

- **Get Questions for Assessment**

  ```http
  GET /api/Assesment/asses{assesid}
  ```

- **Get Recent Three Assessments**

  ```http
  GET /api/Assesment/recent%203?stan=10
  ```

#### Learning

- **Add Topic**

  ```http
  POST /api/Learning/addTopic
  ```

  **Body:**

  ```json
  {
    "topicname": "Algebra Basics",
    "subject": "Math",
    "classdate": "2024-05-01",
    "completion": 0,
    "stand": 10
  }
  ```

- **Get Topics by Standard**

  ```http
  GET /api/Learning/getTopic?stan=10
  ```

- **Upload PDF Study Material**

  ```http
  POST /api/Learning/uploadpdf
  ```

  **Form Data:**

  - `studymaterial`: PDF file
  - `standard`: 10
  - `subjectname`: "Math"

- **Download PDF Study Material**

  ```http
  GET /api/Learning/downloadpdf?standard=10
  ```

#### Notices

- **Add Notice**

  ```http
  POST /api/Notice/addnotice
  ```

  **Body:**

  ```json
  {
    "section": "General",
    "title": "Holiday Announcement",
    "date": "2024-05-15",
    "time": "10:00 AM"
  }
  ```

- **Get All Notices**

  ```http
  GET /api/Notice/getall
  ```

#### Results

- **Add Result**

  ```http
  POST /api/Results/addresult
  ```

  **Body:**

  ```json
  {
    "username": "john_doe",
    "assesid": "GUID",
    "marks": 85
  }
  ```

- **Get Last Four Results**

  ```http
  GET /api/Results/get4result?username=john_doe
  ```

- **Get All Results**

  ```http
  GET /api/Results/getallresult?username=john_doe
  ```

- **Get Position**

  ```http
  GET /api/Results/position?username=john_doe
  ```

- **Get All Data for API**

  ```http
  GET /api/Results/getAlldata?username=john_doe
  ```

- **Get Quarterly Results**

  ```http
  GET /api/Results/getquarterlyresult?username=john_doe
  ```

## Usage

1. **Running the Application**

   Navigate to the project directory and run:

   ```bash
   dotnet run
   ```

   The API will be available at `https://localhost:5001` or `http://localhost:5000` by default.

2. **Testing Endpoints**

   Use tools like [Postman](https://www.postman.com/) or [Swagger](https://swagger.io/) (if integrated) to interact with the API endpoints.

3. **Handling Authentication**

   Currently, authentication is handled via simple username and password verification. For enhanced security,I will consider implementing JWT-based authentication or integrating OAuth providers.

Live Base URL if you want to test it:https://www.takshilabackend.somee.com/
