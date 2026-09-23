using System;
using System.Collections.Generic;

abstract class Vehiculo
{
    public double Combustible { get; set; }

    public Vehiculo(double combustible)
    {
        Combustible = combustible;
    }

    public abstract double CalcularAutonomia();
}

class Automovil : Vehiculo
{
    public Automovil(double combustible) : base(combustible) { }

    public override double CalcularAutonomia()
    {
        return Combustible * 15;
    }
}

class Camion : Vehiculo
{
    public Camion(double combustible) : base(combustible) { }

    public override double CalcularAutonomia()
    {
        return Combustible * 5;
    }
}

class Program
{
    static void Main()
    {
        List<Vehiculo> flota = new List<Vehiculo>()
        {
            new Automovil(40),
            new Camion(40)
        };

        foreach (Vehiculo v in flota)
        {
            Console.WriteLine($"Autonomía: {v.CalcularAutonomia()} km");
        }
    }
}