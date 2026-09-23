using System;
using System.Collections.Generic;

abstract class CuentaBancaria
{
    public decimal Saldo { get; set; }

    public CuentaBancaria(decimal saldo)
    {
        Saldo = saldo;
    }

    public abstract decimal CalcularInteres();
}

class CuentaAhorro : CuentaBancaria
{
    public CuentaAhorro(decimal saldo) : base(saldo) { }

    public override decimal CalcularInteres()
    {
        return Saldo * 0.03m;
    }
}

class CuentaInversion : CuentaBancaria
{
    public CuentaInversion(decimal saldo) : base(saldo) { }

    public override decimal CalcularInteres()
    {
        return Saldo * 0.08m;
    }
}

class Program
{
    static void Main()
    {
        List<CuentaBancaria> cuentas = new List<CuentaBancaria>()
        {
            new CuentaAhorro(10000),
            new CuentaInversion(10000)
        };

        foreach (var c in cuentas)
        {
            Console.WriteLine($"Interés generado: Q{c.CalcularInteres()}");
        }
    }
}