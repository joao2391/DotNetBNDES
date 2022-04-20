# DotNetBNDES [![Nuget](https://img.shields.io/nuget/v/DotNetBNDES)](https://www.nuget.org/packages/DotNetBNDES/) ![Nuget](https://img.shields.io/nuget/dt/DotNetBNDES)

DotNet.BNDES is a .Net library that helps you to get infos about BNDES card. This is not the official lib from BNDES!

## Notes
Version 1.0.1:

- Upgrade to .NET 6

## Installation

Use the package manager to install.

```bash
Install-Package DotNetBNDES  -Version 1.0.1
```

## Usage

```C#
services.<ChooseYours><IHttpClientWrapper, HttpClientWrapper>();
services.<ChooseYours><IBancos, Bancos>();
services.<ChooseYours><ICartao, Cartao>();

```

### Features - Bancos Credenciados
```C#
var bancosCredenciados = await GetBancosCredenciadosAsync();
// bancosCredenciados[0].Nome -> BANCO SANTANDER (BRASIL) S.A.

```

### Features - Fornecedores e Produtos
```C#
var fornecedores = await GetFornecedoresByNameAsync("Zezinho", 1);
// fornecedores[0].NomeFantasia -> Zezinho
// fornecedores[0].NomePessoa -> Zezinho
// fornecedores[0].TotalRegistros -> 9
// fornecedores[0].UltimaPaginaGrupo -> 1

var fornecedoresByNomeProduto = await GetFornecedoresByNomeProdutoAsync("cimento", 1);
// fornecedoresByNomeProduto[0].NomeFantasia -> Zezinho
// fornecedoresByNomeProduto[0].NomePessoa -> Zezinho
// fornecedoresByNomeProduto[0].TotalRegistros -> 9
// fornecedoresByNomeProduto[0].UltimaPaginaGrupo -> 1

var produtos = await GetProdutosByNameAsync("cimento");
// produtos.PaginaAtual -> 1
// produtos.Produtos[0].NomeFabricante -> TesteFabricante
// produtos.Produtos[0].NomeProduto -> TesteProduto
// produtos.QuantidadePaginas -> 1
// produtos.QuantidadeProdutos -> 1

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)