using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;


namespace DesafioProjetoHospedagem.Models;
public class ReciboReserva
{
    // Propriedades do Recibo
    public string NomeHospede { get; set; }
    public int DiasReservados { get; set; }
    public decimal ValorTotal { get; set; }

    // Construtor para inicializar um recibo
    public ReciboReserva(string nomeHospede, int diasReservados, decimal valorTotal)
    {
        NomeHospede = nomeHospede;
        DiasReservados = diasReservados;
        ValorTotal = valorTotal;
    }

    // Método para gerar o PDF do recibo
    public void GerarRecibo()
    {
        // Nome do arquivo com base no nome do hóspede
        string nomeArquivo = $"Recibo_{NomeHospede.Replace(" ", "_")}.pdf";

        // Criar um novo documento PDF
        Document doc = new Document();
        PdfWriter.GetInstance(doc, new FileStream(nomeArquivo, FileMode.Create));

        doc.Open();
        doc.Add(new Paragraph("🏨 RECIBO DE RESERVA"));
        doc.Add(new Paragraph($"Nome: {NomeHospede}"));
        doc.Add(new Paragraph($"Dias Reservados: {DiasReservados}"));
        doc.Add(new Paragraph($"Valor Total: R$ {ValorTotal:F2}"));
        doc.Add(new Paragraph("\nObrigado por escolher nosso hotel!"));

        doc.Close();

        Console.WriteLine($"📄 Recibo gerado com sucesso: {nomeArquivo}");
    }
}
