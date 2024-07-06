docker build -t api_admin:1.0.0 --target api -f Admin.Api/Dockerfile .;
docker build -t api_connection_control:1.0.0 --target api_connection -f ConnectionControl.Api/Dockerfile .;
docker build -t sql_server:1.0.0 --target sql -f Admin.Sql.Test/Dockerfile .;


docker-compose up -d