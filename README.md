# Projeto Hospedagem

Este projeto simula o funcionamento de um sistema de reserva de hospedagem, onde é possível registrar hóspedes, criar reservas e gerar recibos em formato PDF.

## Estrutura do Projeto

O projeto está dividido em várias classes e funcionalidades:

1. **Pessoa**: Representa um hóspede, com informações de nome e sobrenome.
2. **Suite**: Representa uma suíte de hospedagem, com tipo, capacidade e valor da diária.
3. **Reserva**: Representa uma reserva feita por um hóspede, com informações sobre os dias reservados e a suíte escolhida.
4. **ReciboReserva**: Gera um recibo da reserva em formato PDF.

## Funcionalidades

- **Cadastro de hóspedes**: É possível cadastrar múltiplos hóspedes para uma reserva.
- **Cadastro de suíte**: Uma suíte é associada à reserva, com capacidade e valor diário definidos.
- **Cálculo de valor da diária**: O valor total da diária é calculado com base na quantidade de dias reservados, com descontos aplicados para reservas acima de 10 dias.
- **Geração de recibo em PDF**: Um recibo é gerado em formato PDF, contendo o nome do hóspede, dias reservados e valor total.

## Como usar

1. **Criar Hóspedes**:
   - Utilize a classe `Pessoa` para criar os hóspedes.
   - Exemplo: `new Pessoa(nome: "Nome do Hóspede")`.

2. **Criar Suíte**:
   - Utilize a classe `Suite` para criar as suítes.
   - Exemplo: `new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 250)`.

3. **Criar Reserva**:
   - Utilize a classe `Reserva` para criar uma reserva.
   - Exemplo:
     ```csharp
     Reserva reserva = new Reserva(diasReservados: 8);
     reserva.CadastrarSuite(suite);
     reserva.CadastrarHospedes(hospedes);
     ```

4. **Gerar Recibo**:
   - A classe `ReciboReserva` é responsável por gerar o recibo da reserva em PDF.

## Exemplo de Execução

```csharp
// Criação de hóspedes
List<Pessoa> hospedes = new List<Pessoa>
{
    new Pessoa(nome: "Hospede 1"),
    new Pessoa(nome: "Hospede 2")
};

// Criação de suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 250);

// Criação de reserva
Reserva reserva = new Reserva(diasReservados: 8);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibição de detalhes da reserva
Console.WriteLine($"Suíte: {suite.TipoSuite}");
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor Total: R$ {reserva.CalcularValorDiaria():F2}");

// Geração do recibo
GerarRecibo(reserva);
```

## Geração de Recibo

Após a execução, o recibo será gerado em um arquivo PDF com os seguintes detalhes:

- Nome do hóspede
- Dias reservados
- Valor total

O arquivo será salvo com o nome Recibo_Reserva.pdf.

## Tecnologias Utilizadas

- C#: Linguagem de programação principal.
- iTextSharp: Biblioteca utilizada para gerar o recibo em PDF.



