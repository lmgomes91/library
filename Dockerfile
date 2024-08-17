# Use a imagem base do Azure SQL Edge
FROM mcr.microsoft.com/azure-sql-edge

# Aceite o contrato de licença
ENV ACCEPT_EULA=1

# Defina a senha do administrador do SQL Server
ENV MSSQL_SA_PASSWORD=MyPass@word

# Defina a edição do SQL Server como Developer
ENV MSSQL_PID=Developer

# Defina o nome de usuário do administrador do SQL Server
ENV MSSQL_USER=SA

# Exponha a porta 1433
EXPOSE 1433

# Comando para iniciar o SQL Server
CMD /opt/mssql/bin/sqlservr


# docker build -t my-sql-image .
# docker run -p 1433:1433 -d --name sql my-sql-image