# BookRating

Projeto para avaliação de livros lidos, seguindo os princípios de **DDD** (Domain-Driven Design) e **Clean Architecture**. Permite cadastrar livros, atribuir notas e avaliações, e consultar os dados via API. Os dados são persistidos em um banco SQL Server rodando em container Docker.

---

## Estrutura do Projeto
BookRating/
│
├── BookRating.Domain/         # Entidades, Value Objects, Interfaces de Repositório
│   └── Entities/
│   └── ValueObjects/
│   └── Interfaces/
│
├── BookRating.Application/    # Casos de uso, DTOs, Serviços de aplicação
│   └── UseCases/
│   └── DTOs/
│
├── BookRating.Infrastructure/ # Implementação de repositórios, contexto do banco, migrations
│   └── Data/
│   └── Repositories/
│
├── BookRating.API/            # Controllers, configuração da API
│   └── Controllers/
│
├── BookRating.Tests/          # Testes unitários e de integração
│
└── docker-compose.yml         # Configuração do container do banco de dados


---

## Regra de Negócio

- **Cadastro de Livro:**  
  Cada livro possui:
  - `Id` (Guid)
  - `Name` (Nome do livro)
  - `Author` (Autor)
  - `Genre` (Gênero)
  - `Rating` (Nota de 1 a 5)
  - `Review` (Avaliação textual)

- **Validação:**  
  - A nota (`Rating`) deve ser um inteiro entre 1 e 5.
  - Todos os campos são obrigatórios, exceto o `Id` (gerado automaticamente).
  - A avaliação (`Review`) deve conter ao menos 10 caracteres.

- **Persistência:**  
  - Os dados são salvos em um banco SQL Server, acessado via Entity Framework Core na camada Infrastructure.

- **API:**  
  - Permite cadastrar livros via endpoint POST.
  - Futuramente pode ser expandida para listar, buscar e editar livros.

---

## Endpoints da API

- **POST /api/books**  
  Cadastra um novo livro.

  **Request Body:**
  ```json
  {
	"name": "Nome do Livro",
	"author": "Autor do Livro",
	"genre": "Gênero do Livro",
	"rating": 4,
	"review": "Avaliação detalhada do livro."
  }
  ```

  
**Response:**
- `200 OK` em caso de sucesso.
- `400 Bad Request` se houver erro de validação.

---

## Como Executar

1. **Suba o banco de dados com Docker:**
   ```bash
   docker-compose up -d
   ```

   
2. **Configure a string de conexão no projeto Infrastructure:**

3. **Execute as migrations do Entity Framework Core (se aplicável):**

4. **Execute a aplicação:**


---

## Tecnologias Utilizadas

- .NET 8 / C# 12
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (Docker)
- DDD & Clean Architecture

---

## Expansões Futuras

- Listagem, busca e edição de livros
- Autenticação de usuários
- Testes automatizados
- Documentação Swagger

---

## Observações

- Certifique-se de que o projeto `BookRating.Application` referencia o projeto `BookRating.Domain`.
- O container SQL Server deve estar rodando antes de iniciar a aplicação.
- Para dúvidas ou sugestões, abra uma issue.
