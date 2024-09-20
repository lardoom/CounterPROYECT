
using System.ComponentModel;

var refrescos = new List<Sodas>()
{

    new Sodas(){Nombre = "Powerade", Marca = "Cocacola", Azucar = 10.5m},
    new Sodas(){Nombre = "Pepsi", Marca = "Pepsico", Azucar = 20.5m},
    new Sodas(){Nombre = "Fanta", Marca = "Cocacola", Azucar = 15.5m},
    new Sodas(){Nombre = "Squirt", Marca = "Aga", Azucar = 12.4m},
    new Sodas(){Nombre = "Mexicana", Marca = "Indie", Azucar = 9.5m},
    new Sodas(){Nombre = "Caballito", Marca = "RefrescoCo", Azucar = 30.2m},

};

var Countries = new List<Country>()
{
    new Country(){Nombre ="Cocacola", Pais = "EUU"},
    new Country(){Nombre ="Pepsico", Pais = "Colombia"},
    new Country(){Nombre ="Aga", Pais = "Ecuador"},
    new Country(){Nombre ="Mexicana", Pais = "Mexico"},
    new Country(){Nombre ="Caballito", Pais = "Argentina"},


};

//Join Consulta
var Consulta = from b in refrescos
               join refre in Countries on b.Marca equals refre.Nombre
               select new
               {
                   nombre = b.Nombre,
                   marca = b.Marca,
                   pais = refre.Pais,
               };


var Consulta2 = from b in refrescos
               where b.Marca == "Aga" || b.Azucar >20
              select new { b.Nombre, b.Marca, b.Azucar  };
//Trae toda la lista
var Consulta3 = from b in refrescos select new { b.Nombre, b.Marca, b.Azucar};

var Consulta4 = refrescos.Where(b => b.Marca == "Pepsico" || b.Azucar >= 20).Select(b => new
{
    b.Nombre,
    b.Marca,
    b.Azucar
});

var Consulta5 = from b in refrescos
               where b.Marca == "Mexicana"
               select new {b.Nombre, b.Marca};


var Consulta6 = refrescos.Where(b => b.Marca == "Cocacola" || b.Azucar >= 20).ToList();

var Consulta7 = refrescos.Where(b => b.Marca == "Caballito" || b.Azucar >= 15).ToList();

var Consulta8 = refrescos.OrderBy(o => o.Azucar).Where(o => o.Azucar >15).ToList();

var Consulta9 = refrescos.OrderByDescending(o => o.Azucar).Where(o =>o.Azucar <32).ToList();

var Consulta10 = refrescos.OrderByDescending(o => o.Azucar).Where(o =>o.Azucar <11).ToList();
foreach (var nombre in Consulta)
{
    Console.WriteLine(nombre.nombre + " " + nombre.marca + " " + nombre.pais);
}
//Consulta en especifico del Join//

//foreach (var nombre in Consulta2)
//{ 
// Console.WriteLine(nombre.Nombre + " "+ nombre.Azucar);
//}

//PONER CONSULTA CORRESPONIENTE 1/2/3 ETC...

//foreach (var nombre in Consulta10)
//{
//    Console.WriteLine(nombre.Nombre + " " + nombre.Marca +" " + nombre.Azucar);
//}

public class Sodas
{ 
    public string? Nombre {  get; set; }

    public string? Marca { get; set; }

    public decimal? Azucar { get; set; }


}

public class Country
{
    public string? Nombre { get; set; }

    public string? Pais { get; set; }
}