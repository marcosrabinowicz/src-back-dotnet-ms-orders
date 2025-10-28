# 🧩 Orders Microservice (.NET 8)

**Clean Architecture + DDD - Messaging — Orders Microservice in .NET 8.**

Microserviço desenvolvido em **C#/.NET 8** utilizando **Clean Architecture**, **DDD leve** e **Minimal API**, com estrutura modular para estudos, entrevistas técnicas e portfólio.

Implementa um **CRUD de pedidos** com publicação de eventos (`OrderCreated`) via mensageria simulada (InMemory), pronto para evolução com **RabbitMQ** ou **Azure Service Bus**.  
Inclui **testes unitários e de integração**, **containerização Docker** e base sólida para pipelines CI/CD.

---

## 🧱 Stack Técnica

- **.NET 8 / C#**
- **Minimal API**
- **Clean Architecture**
- **DDD (Domain-Driven Design leve)**
- **Mensageria (InMemory → RabbitMQ/Azure SB)**
- **xUnit + FluentAssertions**
- **Docker / CI/CD Ready**

---

## 🗂️ Estrutura do Projeto

src-back-dotnet-ms-orders/
├── Orders.Domain/ # Entidades e regras de negócio
├── Orders.Application/ # Casos de uso, DTOs e abstrações
├── Orders.Infrastructure/ # Repositórios e mensageria
├── Orders.Api/ # Minimal API (endpoints REST)
└── Orders.Tests/ # Testes unitários e de integração

---

## ⚙️ Getting Started

### 1️⃣ Clonar o repositório

```bash
git clone https://github.com/marcos-rabinowicz/src-back-dotnet-ms-orders.git
cd src-back-dotnet-ms-orders
```

### 2️⃣ Restaurar dependências

```bash
dotnet restore
```

### 3️⃣ Rodar os testes

```bash
dotnet test
```

### 4️⃣ Subir a API localmente

```bash
dotnet run --project Orders.Api
```

### 🐳 Rodar via Docker

```bash
docker build -t orders-api:dev -f Orders.Api/Dockerfile .
docker run -p 8080:8080 orders-api:dev
```

### Acesse: http://localhost:8080/swagger

## 🚀 Roadmap

Implementar RabbitMQ / Azure Service Bus

Adicionar Transactional Outbox Pattern

Configurar Observabilidade (OpenTelemetry + Serilog)

Criar Pipeline CI/CD (GitHub Actions)

## 🧭 Sobre o Projeto

Projeto desenvolvido no contexto de Cultivo Técnico dentro do ecossistema Neshama Tech | Mindset de Crescimento, unindo propósito, clareza e excelência técnica.

“Código limpo é um reflexo de pensamento limpo.” — Neshama Tech 💙🔥

## 📌 Autor

Marcos Rabinowicz

https://github.com/marcosrabinowicz

https://www.linkedin.com/in/marcosrabinowicz
