# OptiPolicy Project Setup

## Prerequisites

* **SQL Server:** You need a running instance of Microsoft SQL Server.

## Installation Instructions

1.  **Clone the repository:**

2.  **Update the database:**
    * Open your Package Manager Console.
    * Run the following command:
        ```bash
        update-database
        ```
        This command will create a database named `OptiPolicy` on your SQL Server instance, based on the Entity Framework Core migrations included in the project.

3.  **Configure the connection string:**
    * Open the `appsettings.json` file.
    * Locate the connection string. It will look similar to this:
        ```json
        "ConnectionStrings": {
          "OptiPolicy": "Server=.;Database=OptiPolicy;Trusted_Connection=True;MultipleActiveResultSets=true;"
        }
        ```

    * **Example with SQL Server Authentication:**
        ```json
        "ConnectionStrings": {
          "OptiPolicy": "Server=localhost;Database=OptiPolicy;User Id=myUsername;Password=myPassword;TrustServerCertificate=True;"
        }
        ```

4.  **Run the application:**
    * Build and run the application using your development environment (e.g., Visual Studio, dotnet CLI).

## First Run

* When the application runs for the first time, it will automatically seed the database with some initial data.
* A default user with the following credentials will be created:
    * **Username:** `Admin`
    * **Password:** `12345`

## Important Notes

* Ensure that your SQL Server is running and accessible before running the application.
* The user used to connect to the database needs to have the necessary permissions to create databases and tables if they don't already exist.  The `update-database` command handles this, but the connection string must be correctly configured.
