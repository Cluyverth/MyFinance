# MyFinance

MyFinance é um software de gestão financeira simples, desenvolvido para treinar as operações de CRUD com C# e ASP.NET MVC. Este projeto pessoal foi criado como parte da especialização em Engenharia de Software da PUC-MG e demonstra, de forma direta e prática, os conceitos fundamentais de desenvolvimento moderno.

---

- Transações

    - Tela de Transação

    ![Tela de Transação](/src/images/Screenshot%202025-02-08%20001433.png)

    - Cadastrar Transação

    ![Tela de Transação](/src/images/Screenshot%202025-02-08%20001433.png)

- Plano de Contas

    - Tela de Plano de Contas

    ![Tela de Plano de Contas](/src/images/Screenshot%202025-02-08%20001410.png)

    - Cadastrar Plano de Contas

    ![Tela de Plano de Contas](/src/images/Screenshot%202025-02-08%20001453.png)

- Banco de Dados

    - Tabelas

    ![Tabelas](/src/images/Screenshot%202025-02-08%20001941.png)

    - SELECT

    ![Tela de Transação](/src/images/Screenshot%202025-02-08%20002014.png)

---

## Tecnologias Utilizadas

- **C# & .NET 8** – Desenvolvimento backend robusto e moderno  
- **ASP.NET MVC** – Estrutura para a criação da interface web  
- **Docker & Docker Compose** – Containerização e orquestração dos serviços  
- **SQL Server** – Banco de dados relacional para armazenamento dos dados

---

## O Que Foi Aprendido

- Implementação de operações CRUD em C#  
- Aplicação do padrão MVC para desenvolvimento web  
- Configuração e gerenciamento de containers com Docker  
- Integração entre a aplicação e o SQL Server  
- Noções práticas de redes e orquestração de ambientes isolados

---

## Como Rodar o Projeto

### Pré-requisitos

- **Visual Studio** com suporte para Docker  
- **Docker & Docker Compose** instalados na máquina

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone <URL-do-repositório>
   cd MyFinance
   ```

2. **Abra o projeto no Visual Studio.**

3. **Selecione docker-compose como startup.**

4. **Execute o projeto (F5 ou Ctrl+F5):**

    - O Docker Compose iniciará uma stack chamada myfinance
    - Será criada uma rede isolada para o ambiente
    - Dois containers serão iniciados:
        - Web-dotnet: Hospeda o website da aplicação
        - SQL Server: Gerencia o banco de dados

5. **Crie o banco de dados manualmente:**

    - Banco: `myfinance`
    - Tabela `PlanoConta`:
        - `id` (Primary Key)
        - `Descricao` (NVARCHAR(50))
        - `tipo` (CHAR) – Valores: R (Receita) ou D (Despesa)
    - Tabela `Transacao`:
        `id` (Primary Key)
        `historico` (text)
        `data` (DATETIMEOFFSET)
        `valor` (DECIMAL(9,2))
        `planocontaid` (Foreign Key referenciando PlanoConta)

    > **Observação**: *As migrations ainda estão de férias, então a criação manual do banco é necessária.*

6. **Acesse a aplicação via browser e interaja com o sistema para conferir os resultados.**