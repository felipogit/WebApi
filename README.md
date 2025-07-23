
# 📚 API de Livros com Autores (.NET 8 Web API)

Este projeto é uma API RESTful desenvolvida em .NET 8 para gerenciar livros e seus respectivos autores.  
Ela permite **criar**, **editar**, **listar** e **deletar** registros de livros e autores.

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Entity Framework Core
- SQL Server
- Swagger (para documentação da API)
- Visual Studio / Visual Studio Code

---

## 🛠️ Como iniciar o projeto

### ✅ Pré-requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server instalado e em execução
- Visual Studio 2022 ou Visual Studio Code
- Git (opcional, para clonar o projeto)

### 🧰 Passo a passo

#### 1. Clone o repositório

```bash
git clone https://github.com/felipogit/WebApi.git
cd nomedoprojeto
```

> Ou baixe o `.zip` do projeto e extraia.

#### 2. Configure a string de conexão

Abra o arquivo `appsettings.json` e edite a `DefaultConnection` com os dados do seu banco:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=NomeDoSeuBanco;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

#### 3. Restaure os pacotes NuGet

```bash
dotnet restore
```

#### 4. (Opcional) Aplique as Migrations no banco

```bash
dotnet ef database update
```

#### 5. Execute a aplicação

```bash
dotnet run
```

A aplicação será iniciada em:  
👉 `https://localhost:7125/swagger` (ou porta configurada no seu `launchSettings.json`)

#### 6. Teste os endpoints via Swagger

Abra no navegador:

```
https://localhost:7125/swagger
```

Você verá a documentação interativa com todos os endpoints para testes.

---

## 📂 Estrutura de Pastas

```
/Controllers       → Controllers da API (Livros, Autores)
/Data              → Contexto do banco de dados (DbContext)
/Dtos              → Data Transfer Objects para comunicação
/Models            → Entidades (Livro, Autor)
/Migrations        → Histórico de Migrations do EF Core
Program.cs         → Configuração da aplicação
appsettings.json   → Configurações da aplicação
```

---

## 🧑‍💻 Autor

**Felipe Costa**  
Desenvolvedor .NET apaixonado por backend, APIs e boas práticas.

---

