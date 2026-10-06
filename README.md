# consumer-advice-api-net-console

Lista de Exercícios — Desenvolvimento Web (**UDWMJ**), Prof. Daniel Henrique Matos de Paiva.

Aplicação console em **C# (.NET 8)** que consome a API de conselhos aleatórios [Advice Slip](https://api.adviceslip.com/) e mostra o conselho no console.

## Endpoint

```
GET https://api.adviceslip.com/advice
```

Resposta (exemplo):

```json
{
  "slip": {
    "id": 22,
    "advice": "Things are just things. Don't get too attached to them."
  }
}
```

O campo `advice` contém o conselho aleatório.

## Como funciona

1. Um `HttpClient` faz uma requisição `GET` ao endpoint.
2. O JSON retornado é convertido (`System.Text.Json`) para as classes `AdviceResponse` e `Slip`.
3. O programa imprime `Conselho de Hoje:` e, na linha seguinte, o valor de `advice`.
4. Se a API estiver fora do ar ou retornar dados inválidos, uma mensagem de erro é exibida.

## Como executar

Pré-requisito: [.NET SDK 8](https://dotnet.microsoft.com/download) ou superior.

```bash
cd ConsumerAdviceApi
dotnet run
```

Saída:

```
Conselho de Hoje:
Things are just things. Don't get too attached to them.
```

## Como o projeto foi criado

```bash
dotnet new console -n ConsumerAdviceApi
```
