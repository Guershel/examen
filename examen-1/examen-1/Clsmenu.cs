using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_1
{
    internal class Clsmenu
    { 
        
        public static void mostrarMenu()
        {
            ClsTransacciones manejaclase= new ClsTransacciones();

            byte opcion = 0;
            do
            {
                Console.WriteLine("Menú Principal del Sistema:");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Ingresar Paso Vehicular");
                Console.WriteLine("3. Consulta de vehículos x Número de Placa");
                Console.WriteLine("4. Modificar Datos Vehículos x número de Placa");
                Console.WriteLine("5. Reporte Todos los Datos de los vectores");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Digite una opcion: ");
                opcion = byte.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        manejaclase.inicializarVector();
                        break;

                    case 2:
                        manejaclase.Ingresar();
                        break;
                    case 3:
                        Console.WriteLine("Digite el vehiculo a consultar por medio de la placa");
                        string placa = Console.ReadLine();

                        manejaclase.ConsultarVehiculo(placa);
                        break;
                    case 4:
                        manejaclase.Modificar();
                        break;

                    case 5:
                        manejaclase.ReporteTodosLosDatos();
                            break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;

                }
            } while (opcion !=  6);
        }
            
        
    }
}
