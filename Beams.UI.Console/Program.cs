using Beams.logic;

Console.WriteLine("ingrese la estructura de su viga");
string? Inbeam = Console.ReadLine();
var mybeam = new MyBeams($"{Inbeam}");

Console.WriteLine(mybeam.IsValid());
Console.WriteLine(mybeam.ValidateWeigth());

