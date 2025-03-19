# Inventory Management - Backend Api

## Task List

- [x] Create Asp.Net 8 WebApi skeleton using Clean Architecture.
- [x] Install required dependencies
- [ ] Create category and product models - Domain
- [ ] Create DbContext - Persistence
- [ ] Create qeneric repository - Persistence
- [ ] Create category and product repositories - Application & Domain
- [ ] Create base service configurations
- [ ] Implement exception handling
- [ ] Create CRUD for category - Application
- [ ] Create CRUD for product - Application
- [ ] Create CRUD for category - Api Controller
- [ ] Create CRUD for product - Api Controller

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


```
