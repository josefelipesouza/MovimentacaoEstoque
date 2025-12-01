# 📦 API de Movimentação de Estoque

API desenvolvida em **.NET 8** utilizando arquitetura em camadas (**API**, **Application**, **Domain**, **Infrastructure**).  
Permite registrar **entradas** e **saídas** de produtos no estoque, consultar movimentações e integrar com sistemas externos.

---

## 🚀 Executando o Projeto

Abra o terminal na pasta da API:

\MovimentacaoEstoque\MovimentacaoEstoque.API>


E execute o comando:

dotnet run


Se tudo estiver correto, você verá algo como:

Now listening on: http://localhost:5000
Application started.
Hosting environment: Development



A API estará disponível em:

http://localhost:5000


---

## 📘 Acessando o Swagger

O Swagger é a interface de documentação interativa da API.

Acesse no navegador:

http://localhost:5000/index.html

No Swagger você encontrará:

- Todas as rotas disponíveis
- Exemplos de envio
- Modelos de Request e Response
- Botões para testar cada endpoint diretamente no navegador

---

## 📥 Cadastrando uma Movimentação

A API permite registrar dois tipos de movimentação:

| Tipo | Significado |
|------|-------------|
| **1** | Entrada de produto |
| **-1** | Saída de produto |

### 📡 Exemplo de requisição cURL

Você pode testar a rota usando o terminal:

```bash
curl -X 'POST' \
  'http://localhost:5000/api/Movimentacao/cadastrar' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
        "codigoProduto": 103,
        "tipoMovimentacao": -1,
        "quantidade": 15,
        "descricao": "Venda de Produto"
      }'
🔍 Descrição dos campos
Campo	Tipo	Descrição
identificador	GUID	Identificador único da movimentação
codigoProduto	int	Código do produto
tipoMovimentacao	int	1 para entrada, -1 para saída
quantidade	int	Quantidade a ser movimentada
descricao	string	Observação ou justificativa

✔️ Regras de Negócio
Para entrada, o estoque é somado

Para saída, o estoque é subtraído

O sistema valida valores negativos e inconsistências de saldo

Toda movimentação é registrada com data/hora

🛠 Tecnologias Utilizadas
.NET 8

C#

Swagger / Swashbuckle

Arquitetura em camadas (Domain, Application, Infrastructure, API)

Injeção de Dependência (DI)

## 🗄️ Banco de Dados – SQLite

Este projeto utiliza **SQLite** como banco de dados local.  
O SQLite é simples, leve e não requer instalação de servidor.

---

### 📌 O arquivo do banco:

MovimentacaoEstoque.API/Database


