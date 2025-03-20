# Inventory Management - Backend Api

## Task List

- [x] Create Asp.Net 8 WebApi skeleton using Clean Architecture.
- [x] Install required dependencies
- [x] Create category and product models - Domain
- [x] Create DbContext - Persistence
- [x] Create qeneric repository - Persistence
- [x] Create category and product repositories - Application & Domain
- [x] Create UnitOfWork
- [x] Create DependecyInjection configurations
- [x] Create CRUD for Brand - Application
- [x] Create CRUD for Brand - Api Controller
- [x] Create CRUD for category - Application
- [x] Create CRUD for category - Api Controller
- [ ] Create CRUD for product - Application
- [ ] Create CRUD for product - Api Controller
- [ ] Implement exception handling

## DotNet / Git CLI Commands

```sh
# GIT CLI

git init
dotnet new gitignore
git init
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/patricklm/InventoryMgrApi.git
git push -u origin main
# DOTNET CLI

# Create InventoryMgr root directory and open it, then run these commands
dotnet new sln -n InventoryMgr
dotnet new webapi -controllers --no-https -n Api
dotnet new classlib -n Domain
dotnet new classlib -n Application
dotnet new classlib -n Persistence
dotnet new classlib -n Infrastructure
dotnet sln add **/**.csproj

/Open Persistence Library Directory in integrated terminal and run the following dotnet cli
dotnet ef migrations add InitDB -s ../Api
dotnet ef database update -s ../Api
```
