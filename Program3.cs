using System.Collections.Generic;
using System;
using System.Linq;

var misEnteros = new List<int> { 2, 14, 7, 19 };
 
// Declaración de una variable de tipo Func, y su asignación
// Declaramos la signatura/firma de la función
Func<string, string> ConcatenarLargo;
ConcatenarLargo = (string s) => $"{s}:{s.Length}";
 
// Declaración e inicialización, con inferencia de tipo (var C#10)
Func<string, string>  ConcatenarLargo2 = (string s) => $"{s}:{s.Length}";
 
// Func, Action, Predicate
// Action -> sin retorno
// Predicate -> retorno bool
Action<int> MiActionDeSaludar = (int i) => System.Console.WriteLine($"Hola Mundo {i}");
Predicate<int> MiPredicadoSuper10 = (int i) => i > 10;
 
// Como parametros
misEnteros.ForEach(MiActionDeSaludar);
// Lambda pura, como parámetro
misEnteros.Where(i => MiPredicadoSuper10(i)).ToList().ForEach(MiActionDeSaludar);
misEnteros.Where(i => i % 2 == 1).ToList().ForEach(MiActionDeSaludar);
 
var f = CrearFuncion("uno", "dos");
Console.WriteLine(f("tres"));
 
// Como retorno
ConcatenarLargoD CrearFuncion(string a, string b)
{
    var ab = $"{a}|{b}";
    return ((string p) =>$"{ab}|{p}:{p.Length}");
}
 
 
// Declaración de una variable de tipo ConcatenarLargoD
ConcatenarLargoD funcionCLD = (string s) => $"{s}:{s.Length}";
// Definición de un tipo de dato delegate
public delegate string ConcatenarLargoD(string value);