# Gestão Finanças

Um sistema de gerenciamento financeiro desenvolvido em ASP.NET Core 9.0 para controle de despesas pessoais e categorização de gastos.

## 🚀 Funcionalidades

- Gerenciamento de despesas
- Categorização de gastos
- Dashboard financeiro
- Controle de despesas recorrentes
- Visualização de despesas em atraso
- API com documentação Swagger
- Interface web responsiva

## 💻 Tecnologias

- ASP.NET Core 9.0
- Entity Framework Core
- SQLite
- AutoMapper
- Swagger/OpenAPI
- Bootstrap
- jQuery

## 🛠️ Pré-requisitos

- .NET 9.0 SDK
- Visual Studio 2022 ou VS Code

## 📦 Instalação

1. Clone o repositório:
```bash
git clone https://github.com/Murthgar/gestao-financas.git
```

2. Navegue até a pasta do projeto:
```bash
cd gestao-financas
```

3. Restaure as dependências:
```bash
dotnet restore
```

4. Execute as migrações do banco de dados:
```bash
dotnet ef database update
```

5. Execute o projeto:
```bash
dotnet run
```

## 🗄️ Estrutura do Projeto

- `Controllers/`: Controladores da aplicação (Despesas, Categorias, Dashboard)
- `Models/`: Modelos de dados
- `Dtos/`: Objetos de transferência de dados
- `Services/`: Lógica de negócios
- `Data/`: Contexto do banco de dados e configurações
- `Mappings/`: Perfis do AutoMapper
- `Views/`: Views MVC
- `wwwroot/`: Arquivos estáticos (CSS, JavaScript, etc.)

## 📝 Funcionalidades em Desenvolvimento

- Sistema de login de usuários
- Relatórios personalizados
- Exportação de dados
- Metas financeiras
- Gráficos e análises avançadas

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).
