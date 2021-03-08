FROM mcr.microsoft.com/dotnet/sdk:5.0 

ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:80  
EXPOSE 80

RUN dotnet tool install --global dotnet-ef

ENV PATH="${PATH}:/root/.dotnet/tools"

RUN echo 'alias dotnet-run="dotnet run --urls http://0.0.0.0:80"' >> ~/.bashrc
