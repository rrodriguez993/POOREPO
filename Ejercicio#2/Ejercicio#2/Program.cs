using System;
using System.Collections.Generic;

interface IReproducible
{
    void Reproducir();
}

class SmartTV : IReproducible
{
    public string Modelo { get; set; }

    public SmartTV(string modelo)
    {
        Modelo = modelo;
    }

    public void Reproducir()
    {
        Console.WriteLine($"Smart TV {Modelo} reproduciendo video en 4K.");
    }
}

class SistemaSonido : IReproducible
{
    public string Modelo { get; set; }

    public SistemaSonido(string modelo)
    {
        Modelo = modelo;
    }

    public void Reproducir()
    {
        Console.WriteLine($"Sistema de sonido {Modelo} reproduciendo audio envolvente.");
    }
}

class Program
{
    static void Main()
    {
        List<IReproducible> dispositivos = new List<IReproducible>()
        {
            new SmartTV("Samsung"),
            new SistemaSonido("Sony")
        };

        foreach (var d in dispositivos)
        {
            d.Reproducir();
        }
    }
}