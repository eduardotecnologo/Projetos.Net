Iniciando o Projeto
$ dotnet new sln -n OverviewIdentity -o OverviewIdentity

// Criando o projeto com autenticação Obs:Para especificar a versão, crie um arquivo global.json
{
    "sdk": {
      "version": "2.2.207"
    }
  }

$ dotnet new mvc -n Id.Overview.Mvc --auth Individual

// Add o projeto a solution
$ dotnet sln add ./Id.Overview.Mvc/Id.Overview.Mvc.csproj
$ dotnet restore //Restaurando pacotes necessários
$ dotnet build

// Strin de Conexão
"Server=(local);Database=IdentityOverview;Trusted_Connection=True"
"UseSqlServer" (Startup)
