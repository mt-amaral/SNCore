
#Imagem para deploy de banco 
#Docker build -t sqlserver:1.0.0 --target SQL .;docker-compose up -d
FROM  mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04 AS  SQL
USER root
RUN mkdir -p /usr/scripts
WORKDIR /usr/
COPY Admin.Sql.Test/Sql /usr/scripts
EXPOSE  1433
USER mssql
ENV PATH="${PATH}:/opt/mssql-tools/bin/"

