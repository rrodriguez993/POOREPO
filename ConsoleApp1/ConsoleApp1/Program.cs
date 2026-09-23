using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Por favor, introduce el ID del empleado:");
        string empleadoId = Console.ReadLine();

        // Crear cuatro hilos para buscar información de diferentes conceptos
        //debido a mis limitaciones de equipo no logre crear una base de datos funcional
        //asi que realice un simulacion en donde buscaremos el concepto empleado por su id
        Thread[] threads = new Thread[4];

        for (int i = 0; i < threads.Length; i++)
        {
            int concepto = i + 1;
            threads[i] = new Thread(() =>
            {
                BuscarInformacion(empleadoId, concepto);
            });
            threads[i].Start();
        }

        // Esperar a que todos los hilos terminen
        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Todos los hilos han concluido. Resultados:");
        Console.WriteLine("Resultado del concepto 1:");
        Console.WriteLine(ResultadoConcepto(1));
        Console.WriteLine("Resultado del concepto 2:");
        Console.WriteLine(ResultadoConcepto(2));
        Console.WriteLine("Resultado del concepto 3:");
        Console.WriteLine(ResultadoConcepto(3));
        Console.WriteLine("Resultado del concepto 4:");
        Console.WriteLine(ResultadoConcepto(4));
    }

    // Simular búsqueda de información para un concepto específico
    static void BuscarInformacion(string empleadoId, int concepto)
    {
        // Simulando una búsqueda de información, por ejemplo:
       
        Thread.Sleep(2000); // Simular una búsqueda demorada de 2 segundos

        // Almacenar el resultado en una estructura de datos compartida
        AlmacenarResultado(concepto, $"Resultado del concepto {concepto} para el empleado {empleadoId}");
    }
    static readonly object lockObj = new object();
    static readonly Dictionary<int, string> resultados = new Dictionary<int, string>();

    static void AlmacenarResultado(int concepto, string resultado)
    {
        lock (lockObj)
        {
            resultados[concepto] = resultado;
        }
    }

    // Método para obtener el resultado de un concepto específico
    static string ResultadoConcepto(int concepto)
    {
        lock (lockObj)
        {
            return resultados.ContainsKey(concepto) ? resultados[concepto] : "Resultado no encontrado";
        }
    }
}
