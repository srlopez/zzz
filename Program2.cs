using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using static System.Console;


var datafile = "notas.csv";

var notas = new List<Calificacion>{
        new Calificacion{ Nombre = "santi",Nota = 10, Sexo = "H"},
        new Calificacion{ Nombre = "pedro",Nota = 6, Sexo = "M"},
        new Calificacion{ Nombre = "marta",Nota = 5, Sexo = "H"},
        new Calificacion{ Nombre = "ana",Nota = 4, Sexo = "M"},

 };
notas.ForEach(WriteLine);
GuardarCalificacionesCSV(notas);

var notas3 = File.ReadAllLines(datafile)
        .Skip(1)
        .Where(row => row.Length > 0)
        .Select(row =>
        {
            var columns = row.Split(',');
            return new Calificacion
            {
                Sexo = columns[0],
                Nombre = columns[1],
                Nota = decimal.Parse(columns[2])
            };
        }).ToList();
notas3.ForEach(WriteLine);

// var notas2 = CargarCalificacionesCSV();
// notas2.ForEach(WriteLine);


void GuardarCalificacionesCSV(List<Calificacion> data)
{
    var lines = new List<string> { "SX,NOMBRE,NOTA" };
    lines.AddRange(data.Select(ToDTO));
    File.WriteAllLines(datafile, lines);
    // Modelo=>DTO
    string ToDTO(Calificacion item) => $"{item.Sexo},{item.Nombre},{item.Nota}";
}

// List<Calificacion> CargarCalificacionesCSV()
// {
//     return File.ReadAllLines(datafile)
//         .Skip(1)
//         .Where(row => row.Length > 0)
//         .Select(ParseRow).ToList();
//     // DTO=>Modelo
//     Calificacion ParseRow(string row)
//     {
//         NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

//         var columns = row.Split(',');
//         return new Calificacion
//         {
//             Sexo = columns[0],
//             Nombre = columns[1],
//             Nota = decimal.Parse(columns[2])
//         };
//     }
// }

public class Calificacion
{
    public string Nombre { get; set; }
    public string Sexo { get; set; }
    public decimal Nota { get; set; }
    // Muy importante. ToString es nuestro ModelView/DTO para vista
    public override string ToString() => $"({Nombre}, {Nota})";
}