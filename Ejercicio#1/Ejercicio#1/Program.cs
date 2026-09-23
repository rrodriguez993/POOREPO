using System;
using System.Collections.Generic;

abstract class Empleado
{
    public string Nombre { get; set; }
    public decimal SalarioBase { get; set; }

    public Empleado(string nombre, decimal salarioBase)
    {
        Nombre = nombre;
        SalarioBase = salarioBase;
    }

    public abstract decimal CalcularSalarioTotal();
}

class Desarrollador : Empleado
{
    public int HorasExtra { get; set; }

    public Desarrollador(string nombre, decimal salarioBase, int horasExtra)
        : base(nombre, salarioBase)
    {
        HorasExtra = horasExtra;
    }

    public override decimal CalcularSalarioTotal()
    {
        return SalarioBase + (HorasExtra * 10);
    }
}

class Gerente : Empleado
{
    public decimal Bono { get; set; }

    public Gerente(string nombre, decimal salarioBase, decimal bono)
        : base(nombre, salarioBase)
    {
        Bono = bono;
    }

    public override decimal CalcularSalarioTotal()
    {
        return SalarioBase + Bono;
    }
}

class Program
{
    static void Main()
    {
        List<Empleado> empleados = new List<Empleado>()
        {
            new Desarrollador("Juan",3000,100),
            new Gerente("Maria",5000,1200)
        };

        foreach (Empleado e in empleados)
        {
            Console.WriteLine($"{e.Nombre}: Q{e.CalcularSalarioTotal()}");
        }
    }
}