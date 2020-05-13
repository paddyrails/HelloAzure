# HelloAzure
## create new folder
cd ~/code/HelloAzure/
## new solution
dotnet new solution -n HelloAzure -o
## new Azure Function project
func init HelloAzure.Functions

##Add to solution
dotnet sln add HelloAzure.Functions/HelloAzure_Functions.csproj

##Add new class lib
dotnet new classlib -n HelloAzure.BusinessLogic
dotnet sln add HelloAzure.BusinessLogic/HelloAzure.BusinessLogic.csproj

##Add reference to classlib
cd ~/code/HelloAzure/HelloAzure.Functions/
func new
dotnet add reference ../HelloAzure.BusinessLogic/HelloAzure.BusinessLogic.csproj

##Run function locally
func start --build

##Login to azure and publish
az login
func azure functionapp publish <FunctionAppName>
  

Great post - https://dev.to/jsmithdenverdev/introduction-to-azure-functions-series-2k8j
