# ## Aplicação de Banco Simulada em C#

**Introdução**

Este repositório GitHub contém a implementação de uma aplicação de banco simulada em C#. A aplicação possui três entidades: usuário, operação bancária e saldo, e duas operações principais: depósito e transferência.

**Entidades**

* **Usuário:** Representa um cliente do banco e armazena informações como nome, CPF e conta corrente.
* **Operação Bancária:** Representa uma transação bancária e armazena informações como tipo da operação (depósito ou transferência), data, valor e conta envolvida.
* **Saldo:** Representa o saldo disponível em uma conta corrente específica.

**Operações**

* **Depósito:** Permite que um cliente deposite um valor em sua conta corrente. O valor do depósito é adicionado ao saldo da conta.
* **Transferência:** Permite que um cliente transfira um valor de sua conta corrente para a conta de outro cliente. O valor da transferência é deduzido da conta do originador e adicionado à conta do destinatário.

**Regras de Negócio**

* Um usuário só pode ter uma conta corrente.
* O valor do depósito deve ser positivo.
* O valor da transferência deve ser positivo e menor ou igual ao saldo disponível na conta do originador.
* As contas envolvidas na transferência devem existir no sistema.

**Implementação**

A aplicação é implementada em C# utilizando as seguintes tecnologias:

* **.NET Framework:** A estrutura base para desenvolvimento em C#.
* **Entity Framework:** Um ORM (Object-Relational Mapping) que facilita o acesso a bancos de dados relacionais.

**Requisitos de Execução**

Para executar a aplicação, você precisará ter os seguintes softwares instalados em seu computador:

* **.NET Framework:** Versão 4.6 ou superior.
* **Visual Studio:** Versão 2017 ou superior.

**Instruções de Uso**

1. Clone o repositório GitHub para o seu computador.
2. Abra o projeto no Visual Studio.
3. Configure a string de conexão com o banco de dados no arquivo `app.config`.
4. Execute o projeto.

**Documentação**

A documentação da API da aplicação está disponível no arquivo `ApiDocumentation.html`.

**Contribuições**

Sua contribuição para este projeto é bem-vinda! Você pode contribuir abrindo issues, enviando pull requests ou simplesmente usando a aplicação e fornecendo feedback.

**Licença**

Este projeto está licenciado sob a licença MIT.

**Agradecimentos**

Agradecemos a todos que contribuíram para este projeto.
