# mvp24hours-netcore-simpleapi
This project is an example of using the libraries of the Mvp24Hours series developed to accelerate the development of API with .NET Core.

# Database Test
If you don't have a server database SQL Server, you can to use command docker:
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1433:1433 -d --name=sql microsoft/mssql-server-linux:latest