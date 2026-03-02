using System;
using System.Collections.Generic;

namespace RegistroPersonas
{
    class RegistroPersonasRefac
    {
        static void Main(string[] args)
        {
            int cantidad = LeerEntero("Ingreser la cantidad de personas a registrar: ", 1);

            List<string> nombresG = new List<string>(), nombresMay = new List<string>(), nombresMen = new List<string>();
            List<int> edadesG = new List<int>(), edadesMay = new List<int>(), edadesMen = new List<int>();

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nRegistro #{i + 1}");
                Console.Write("Nombre: ");
                string n = Console.ReadLine();
                int e = LeerEntero("Edad: ", 0);

                nombresG.Add(n);
                edadesG.Add(e);

                if (e >= 18) { nombresMay.Add(n); edadesMay.Add(e); }
                else { nombresMen.Add(n); edadesMen.Add(e); }
            }


            MostrarListado("LISTADO GENERAL", nombresG, edadesG);
            MostrarListado("MAYORES DE EDAD", nombresMay, edadesMay);
            MostrarListado("MENORES DE EDAD", nombresMen, edadesMen);

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static int LeerEntero(string msj, int min)
        {
            int num;
            while (true)
            {
                Console.Write(msj);
                if (int.TryParse(Console.ReadLine(), out num) && num >= min) return num;
                Console.WriteLine("Error: Ingrese un número válido.");
            }
        }

        static string ObtenerTag(int edad) => (edad >= 18) ? "[Adulto]" : "[Menor]";

        static void MostrarListado(string titulo, List<string> n, List<int> e)
        {
            if (n.Count == 0) return;
            Console.WriteLine($"\n--- {titulo} ---");
            for (int i = 0; i < n.Count; i++)
                Console.WriteLine($"- {n[i]} ({e[i]} años) {ObtenerTag(e[i])}");
        }
    }
}