using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>
{
    new Pessoa(nome: "Hospede 1"),
    new Pessoa(nome: "Hospede 2")
};

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 250);

// Cria uma nova reserva
Reserva reserva = new Reserva(diasReservados: 8);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe detalhes da reserva
Console.WriteLine("\n🔹 RESERVA CONFIRMADA 🔹");
Console.WriteLine($"🏨 Suíte: {suite.TipoSuite}");
Console.WriteLine($"👥 Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"💰 Valor total da diária: R$ {reserva.CalcularValorDiaria():F2}\n");

// Gera um recibo em PDF
GerarRecibo(reserva);

// Método para gerar um recibo da reserva em PDF
void GerarRecibo(Reserva reserva)
{
    string nomeArquivo = "Recibo_Reserva.pdf";
    Document doc = new Document();
    PdfWriter.GetInstance(doc, new FileStream(nomeArquivo, FileMode.Create));

    doc.Open();
    doc.Add(new Paragraph("RECIBO DE RESERVA"));
    doc.Add(new Paragraph($"Hóspedes: {reserva.ObterQuantidadeHospedes()}"));
    doc.Add(new Paragraph($"Suíte: {suite.TipoSuite}"));
    doc.Add(new Paragraph($"Dias Reservados: {reserva.DiasReservados}"));
    doc.Add(new Paragraph($"Valor Total: R$ {reserva.CalcularValorDiaria():F2}"));
    doc.Add(new Paragraph("Obrigado por escolher nosso hotel!"));

    doc.Close();
    Console.WriteLine($"Recibo gerado com sucesso: {nomeArquivo}");
}
