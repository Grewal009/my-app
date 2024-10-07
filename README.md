### Docker MS SQL Image commands:

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password1." -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest

### "ConnectionStrings:PizzaContext" (connection string)User-Secrets Manager

dotnet user-secrets set "ConnectionStrings:PizzaContext" "Server=localhost; Database=PizzaDB; User Id=sa; Password=Password1.;TrustServerCertificate=True;"
