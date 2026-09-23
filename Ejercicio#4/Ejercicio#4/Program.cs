using System;
using System.Collections.Generic;

abstract class Notificacion
{
    public abstract void Enviar(string mensaje);
}

class CorreoElectronico : Notificacion
{
    public override void Enviar(string mensaje)
    {
        Console.WriteLine($"Correo enviado: {mensaje}");
    }
}

class SMS : Notificacion
{
    public override void Enviar(string mensaje)
    {
        Console.WriteLine($"SMS enviado: {mensaje}");
    }
}

class Program
{
    static void Main()
    {
        List<Notificacion> notificaciones = new List<Notificacion>()
        {
            new CorreoElectronico(),
            new SMS()
        };

        foreach (var n in notificaciones)
        {
            n.Enviar("Alerta crítica del servidor");
        }
    }
}