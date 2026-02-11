using System;
using System.Collections.Generic;

namespace RegistroPersonas
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int cantidadPersonas = 0;
            bool esCantidadValida = false;

         
            List<string> listaNombres = new List<string>();
            List<int> listaEdades = new List<int>();

           
            do
            {
                Console.Write("Ingrese la cantidad de personas que desea registrar: ");
                string entrada = Console.ReadLine();

              
                if (int.TryParse(entrada, out cantidadPersonas) && cantidadPersonas >= 1)
                {
                    esCantidadValida = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(">> Error: Debe ingresar un número entero mayor o igual a 1.\n");
                    Console.ResetColor();
                }

            } while (!esCantidadValida);

            Console.WriteLine("\n--------------------------------------------------");

            
            for (int i = 0; i < cantidadPersonas; i++)
            {
                Console.WriteLine($"\nRegistro de Persona #{i + 1}");

              
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

           
                int edad = 0;
                bool esEdadValida = false;

                while (!esEdadValida)
                {
                    Console.Write("Edad: ");
                    string entradaEdad = Console.ReadLine();

                   
                    if (int.TryParse(entradaEdad, out edad) && edad >= 0)
                    {
                        esEdadValida = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(">> Error: Ingrese una edad numérica válida (ej. 25).");
                        Console.ResetColor();
                    }
                }

                // C. Guardar en las Listas
                listaNombres.Add(nombre);
                listaEdades.Add(edad);
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("                RESULTADOS DEl REGISTRO             ");
            Console.WriteLine("==================================================");

            
            if (cantidadPersonas == 1)
            {
                string nombre = listaNombres[0];
                int edad = listaEdades[0];
                string estado = (edad >= 18) ? "MAYOR de edad" : "MENOR de edad";

                Console.WriteLine($"\nNombre: {nombre}");
                Console.WriteLine($"Edad: {edad} años");
                Console.WriteLine($"Estado: Es {estado}.");
            }
          
            else
            {
                
                Console.WriteLine("\n--- LISTADO GENERAL COMPLETO ---");
                for (int i = 0; i < cantidadPersonas; i++)
                {
                    Console.WriteLine($"- {listaNombres[i]} ({listaEdades[i]} años)");
                }

              
                List<string> nombresMayores = new List<string>();
                List<int> edadesMayores = new List<int>();

                List<string> nombresMenores = new List<string>();
                List<int> edadesMenores = new List<int>();

                for (int i = 0; i < cantidadPersonas; i++)
                {
                    if (listaEdades[i] >= 18)
                    {
                        nombresMayores.Add(listaNombres[i]);
                        edadesMayores.Add(listaEdades[i]);
                    }
                    else
                    {
                        nombresMenores.Add(listaNombres[i]);
                        edadesMenores.Add(listaEdades[i]);
                    }
                }

               
                if (nombresMayores.Count > 0)
                {
                    Console.WriteLine("\n--- PERSONAS MAYORES DE EDAD (18+) ---");
                    for (int i = 0; i < nombresMayores.Count; i++)
                    {
                        Console.WriteLine($"• {nombresMayores[i]} - {edadesMayores[i]} años");
                    }
                }

                if (nombresMenores.Count > 0)
                {
                    Console.WriteLine("\n--- PERSONAS MENORES DE EDAD (<18) ---");
                    for (int i = 0; i < nombresMenores.Count; i++)
                    {
                        Console.WriteLine($"• {nombresMenores[i]} - {edadesMenores[i]} años");
                    }
                }
            }

            
            Console.WriteLine("\n\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}