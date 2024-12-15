## שלב 1: Build
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /app
#
## העתיקי את קובץ ה-solution והתקיני את התלויות
#COPY userLoginBackend/Project/Project.sln ./
#COPY userLoginBackend/Project/Server/*userLoginBackend.csproj ./userLoginBackend/Project/Server/
#COPY userLoginBackend/Project/Dal/DAL.csproj ./userLoginBackend/Project/Dal/
#COPY userLoginBackend/Project/BL/BLL.csproj ./userLoginBackend/Project/BL/
#RUN dotnet restore Project.sln
#
## העתיקי את שאר קבצי הפרויקט ובני את הפרויקט
#COPY . ./
#WORKDIR /app/userLoginBackend/Project/Server
#RUN dotnet publish -c Release -o out
#
## שלב 2: Run
#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
#WORKDIR /app
#COPY --from=build /app/userLoginBackend/Project/Server/out ./
#ENV ASPNETCORE_URLS=http://+:8080
#EXPOSE 8080
#ENTRYPOINT ["dotnet", "userLoginBackend.dll"]
#

# שלב 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# העתק את קובץ ה-solution והתקן את התלויות
COPY userLoginBackend/Project/Project.sln ./
COPY userLoginBackend/Project/Server/*.csproj ./Server/
COPY userLoginBackend/Project/Dal/*.csproj ./Dal/
COPY userLoginBackend/Project/BL/*.csproj ./BL/

RUN echo "Checking contents of /app:" && ls -la /app && echo "Checking contents of /app/Server:" && ls -la /app/Server

RUN dotnet restore Project.sln

# העתק את שאר קבצי הפרויקט ובנה את הפרויקט
COPY . ./
WORKDIR /app/userLoginBackend/Project/Server
RUN dotnet publish -c Release -o out

# שלב 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/userLoginBackend/Project/Server/out ./
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "userLoginBackend.dll"]
