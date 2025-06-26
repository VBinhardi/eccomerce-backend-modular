# Ecommerce Backend Modular

Sistema backend completo e modular para gerenciamento de pedidos e controle de estoque, construído com foco em **Clean Architecture**, **DDD (Domain-Driven Design)** e **arquitetura orientada a eventos** com **RabbitMQ**.

---

## Status do Projeto

**Em desenvolvimento ativo** – o sistema está sendo construído em fases e receberá melhorias contínuas com foco em escalabilidade, boas práticas de engenharia de software e integração entre serviços.

### Funcionalidades já implementadas

- Estrutura baseada em **Clean Architecture + DDD**
- Criação e consulta de pedidos via API RESTful
- Integração com banco de dados **PostgreSQL**
- Comunicação assíncrona via **RabbitMQ**
- Separação clara em camadas: API, Application, Domain, Infrastructure
- Docker e Docker Compose para fácil provisionamento local

### Funcionalidades futuras previstas

Em breve, serão integradas as seguintes tecnologias e práticas:

- Microsserviço de estoque separado (Stock API)
- Comunicação assíncrona com **RabbitMQ**
- Substituição gradual para **MassTransit** como abstraction layer da mensageria
- Testes unitários com **xUnit** e **Moq**
- Autenticação e autorização via **JWT Bearer Token**
- Logs estruturados com **Serilog**
- Pipeline de **CI/CD com Azure DevOps**
- Orquestração de containers com **AWS ECS** ou **Kubernetes**
- Interface frontend (futuramente) para gerenciamento visual

---

## Objetivo do Projeto

O projeto tem como finalidade servir como base para um **sistema de ecommerce completo**, com integração entre o fluxo de **pedidos e controle de estoque**, além de demonstrar **conhecimento prático e aprofundado** nas principais tecnologias modernas de backend.  

Foi desenvolvido com foco em:

- Organização arquitetural escalável e testável
- Separação de responsabilidades por camadas e contextos
- Comunicação assíncrona entre microsserviços
- Deploy e orquestração com Docker e Docker Compose

---

## Arquitetura Utilizada

### Clean Architecture
- Separação clara entre camadas:
  - `Domain`: regras de negócio puras
  - `Application`: lógica de aplicação
  - `Infrastructure`: serviços externos (RabbitMQ, banco, etc.)
  - `API`: camada de apresentação (controllers, endpoints)

### DDD (Domain-Driven Design)
- Entidades ricas (`Order`, `OrderItem`)
- Repositórios como abstração da persistência
- Serviços de aplicação e regras bem segmentadas
- DTOs para transporte de dados entre camadas

### Event-Driven Architecture
- Publicação de eventos de pedidos via RabbitMQ
- Integração futura com o microsserviço de estoque (`Stock`)
- Modelo baseado em troca de mensagens (Publisher → Queue → Consumer)

---

## Tecnologias & Ferramentas

| Categoria         | Ferramenta / Tecnologia                        |
|------------------|------------------------------------------------|
| **Linguagem**     | C# (.NET 8)                                    |
| **Mensageria**    | RabbitMQ (com painel de administração)         |
| **Banco de Dados**| PostgreSQL                                     |
| **Arquitetura**   | Clean Architecture + DDD + Multicamadas        |
| **Containerização**| Docker + Docker Compose                       |
| **Configuração**  | `appsettings.json` + `Environment Variables`   |
| **Injeção de Dependência** | `Microsoft.Extensions.DependencyInjection` |
| **Async**         | `async/await` e versionamento moderno (IChannel 8.x) |

---

## Docker Compose (Serviços)

O projeto possui um `docker-compose.yml` configurado para orquestrar os seguintes containers:

- `postgres`: banco de dados com volume persistente e seed inicial
- `rabbitmq`: serviço de mensageria com painel web (`localhost:15672`)
- `api`: container da API principal

```bash
# Subir tudo com build limpo
docker compose down -v
docker compose up --build
