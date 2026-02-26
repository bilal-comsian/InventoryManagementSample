\# InventoryManagement



InventoryManagement is a Server‑side Blazor application (ASP.NET Core) that demonstrates:

\- ASP.NET Core Identity with roles \& claims

\- In-memory EF Core data store for rapid development and demos

\- Basic blog-post CRUD with authorization policies

\- A simple inventory service example

\- AutoMapper for DTO/ViewModel mapping



\## Quick facts

\- Target framework: .NET 6

\- Project type: Server-side Blazor (Blazor Server)

\- Database: EF Core InMemory (configured in Program.cs)

\- Authentication: ASP.NET Core Identity (custom ApplicationUser/ApplicationRole)

\- Default seeded users \& roles are created on startup



\## What’s included (important files / folders)

\- Program.cs — app startup, DI registration, Identity config, AutoMapper, seed invocation.

\- Data/

&nbsp; - ApplicationDbContext.cs — EF Core DbContext.

&nbsp; - SeedData.cs — seeds roles, claims and default users.

&nbsp; - ProjectAccesses.cs — roles, policies and claim definitions (BlogPost policies).

\- Areas/Identity — Identity UI pages for login/register/etc.

\- Pages/

&nbsp; - Index.razor — app landing page.

&nbsp; - BlogPost/\* — pages for listing, creating, editing, viewing blog posts and authorization usage.

&nbsp; - Inventory/Index.razor — inventory sample page.

\- Shared/

&nbsp; - MainLayout.razor, NavMenu.razor, LoginDisplay.razor — shared layout and navigation.

\- Services/

&nbsp; - BlogPostService — CRUD operations for blog posts.

&nbsp; - UserService, RoleService — helpers to query users/roles.

&nbsp; - InventoryService (IInventoryService) — sample inventory logic.

\- ViewModels/ — view models used for UI mapping.

\- wwwroot/ — static assets, bootstrap, open-iconic icons.

\- appsettings.json / appsettings.Development.json — configuration.

\- Properties/launchSettings.json — development launch URLs \& profile.



\## Seeded credentials (development/demo)

SeedData creates:

\- Admin user

&nbsp; - Email: `admin@admin.com`

&nbsp; - Password: `123456`

&nbsp; - Roles: Admin, User

&nbsp; - Role claims: full blog-post claims (Create/Read/Update/Delete)

\- Normal user

&nbsp; - Email: `user@user.com`

&nbsp; - Password: `123456`

&nbsp; - Roles: User

&nbsp; - Claims: BlogPost Read



> These are for development only. Change passwords and remove in-memory DB for production.



\## Routes overview

\- `/` — Home

\- `/BlogPost` — List (requires BlogPostRead claim)

\- `/BlogPost/Create` — Create (requires BlogPostCreate claim)

\- `/BlogPost/Details/{id}` — Details (requires BlogPostRead claim)

\- `/BlogPost/Edit/{id}` — Edit (requires BlogPostUpdate claim)

\- `/BlogPost/Delete/{id}` — Delete (requires BlogPostDelete claim)

\- `/Inventory` — Inventory sample page



\## How to run (Visual Studio 2022)

1\. Open the solution or project in Visual Studio 2022. If you renamed the project folder, open the .sln from its folder.

2\. Make sure the launch profile points to the InventoryManagement project (Project Properties / Debug).

3\. Press F5 or use \_\_Debug > Start Debugging\_\_ to run.

4\. Default development URLs are in Properties/launchSettings.json (https://localhost:5001;http://localhost:5000).



Or from command line:

