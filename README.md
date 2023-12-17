## Tasks System

``.NET Core API Application with a Postgresql Database that allows users of the application to create tasks and set tasks``

### Stack and Technologies :
- .NET 6 or 7 (Your Prefereable Choice)
- Use PostgreSQL as Database
- EntityFramework Core as ORM
- JWT Authentication Scheme
- Swagger / OpenAPI

### Project Checklist :
- Database Must be Generated using EFCore Migrations System
- Users Can register and login using JWT Authentication
- Registeration Process implement this fields : **Name, Email, Phone, Password and Profile Picture**
- Each User can Add Tasks : **Title, Description, Due Date, Assinged Users**
- Each Task can be additionally assigned to multiple users (Hint : Many to Many Relationship)
- Users can see their own Tasks only either Creator or Assigned
- Create an Admin Account that can view all tasks on the System for all users
- Users can Set their Tasks as Finished or Unfinished (Default is Unfinished)
- Users can Delete their own Tasks (as owners, not assigned)
- Admin Account can Delete or Change Status of any Task on the System
- Use Repository Pattern with Dependency Injection
- Retriving Tasks should be ordered by Due Date (Ascending)
- Users Can Search thier own tasks (as Owners or Assigned) by Due Date
