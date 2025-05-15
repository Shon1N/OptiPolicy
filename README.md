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
          "DefaultConnection": "Server=.;Database=OptiPolicy;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
        ```
    * Modify the connection string to match your SQL Server configuration.  Here's a breakdown of common settings:
        * `Server`:  The name of your SQL Server instance.  This might be `localhost`, `(localdb)\mssqllocaldb`, a server name, or an IP address.
        * `Database`: The name of the database.  The `update-database` command should create this as `OptiPolicy`, so if you keep the default, it should be fine.
        * `Trusted_Connection`:  If set to `True`, the application will attempt to use your Windows credentials to connect to the database.  If set to `False`, you'll need to provide a `User Id` and `Password` in the connection string.

    * **Example with SQL Server Authentication:**
        ```json
        "ConnectionStrings": {
          "DefaultConnection": "Server=myServerAddress;Database=OptiPolicy;User Id=myUsername;Password=myPassword;MultipleActiveResultSets=true"
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
