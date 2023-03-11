using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_1
{
    internal class ClsTransacciones
    {
        private const int Max_Vehiculos = 15;

        private int[] numeroFactura = new int[Max_Vehiculos];
        private string[] numeroPlaca = new string[Max_Vehiculos];
        private string[] fecha = new string[Max_Vehiculos];
        private string[] hora = new string[Max_Vehiculos];
        private int[] tipoVehiculo = new int[Max_Vehiculos];
        private int[] numeroCaseta = new int[Max_Vehiculos];
        private double[] montoPagar = new double[Max_Vehiculos];
        private double[] pagaCon = new double[Max_Vehiculos];
        private double[] vuelto = new double[Max_Vehiculos];
        private int numVehiculos = 0;


        public void inicializarVector()
        {
            for (int i = 0; i < 5; i++)
            {
                numeroFactura[i] = 0;
                numeroPlaca[i] = "";
                fecha[i] = "";
                hora[i] = "";
                tipoVehiculo[i] = 0;
                numeroCaseta[i] = 0;
                montoPagar[i] = 0;
                pagaCon[i] = 0;
                vuelto[i] = 0;
            }
            numVehiculos = 0;

        }
        public void Ingresar()
        {
            Console.WriteLine("Ingrese los datos del paso vehicular:");

            if (numVehiculos == numeroFactura.Length)
            {
                Console.WriteLine("No se pueden ingresar más registros.");
                return;
            }

            Console.Write("Número de factura: ");
            numeroFactura[numVehiculos] = int.Parse(Console.ReadLine());

            Console.Write("Número de placa: ");
            numeroPlaca[numVehiculos] = Console.ReadLine();

            Console.Write("Fecha (dd/mm/aaaa): ");
            fecha[numVehiculos] = Console.ReadLine();

            Console.Write("Hora (hh:mm): ");
            hora[numVehiculos] = Console.ReadLine();

            Console.Write("Tipo de vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
            tipoVehiculo[numVehiculos] = int.Parse(Console.ReadLine());

            Console.Write("Número de caseta (1, 2, 3): ");
            numeroCaseta[numVehiculos] = int.Parse(Console.ReadLine());

            
            switch (tipoVehiculo[numVehiculos])
            {
                case 1:
                    montoPagar[numVehiculos] = 500;
                    break;
                case 2:
                    montoPagar[numVehiculos] = 700;
                    break;
                case 3:
                    montoPagar[numVehiculos] = 2700;
                    break;
                case 4:
                    montoPagar[numVehiculos] = 3700;
                    break;
                default:
                    Console.WriteLine("No existe ese vehiculo");
                    break;
            }

            Console.WriteLine($"El monto a pagar es: {montoPagar}");

            Console.Write("Paga con: ");
            pagaCon[numVehiculos] = double.Parse(Console.ReadLine());

            vuelto[numVehiculos] = pagaCon[numVehiculos] - montoPagar[numVehiculos];

            Console.WriteLine("Registro ingresado correctamente.");
            numVehiculos++;
        }

        public void ConsultarVehiculo(string placa)
        {
            if (numeroPlaca[Max_Vehiculos] == placa)
            {
                Console.WriteLine("Datos del vehículo:");
                Console.WriteLine("Número de factura: {0}", numeroFactura[Max_Vehiculos]);
                Console.WriteLine("Número de placa: {0}", numeroPlaca[Max_Vehiculos]);
                Console.WriteLine("Fecha: {0}", fecha[Max_Vehiculos]);
                Console.WriteLine("Hora: {0}", hora[Max_Vehiculos]);
                Console.WriteLine("Tipo de vehículo: {0}", tipoVehiculo[Max_Vehiculos]);
                Console.WriteLine("Número de caseta: {0}", numeroCaseta[Max_Vehiculos]);
                Console.WriteLine("Monto a pagar: {0}", montoPagar[Max_Vehiculos]);
                Console.WriteLine("Paga con: {0}", pagaCon[Max_Vehiculos]);
                Console.WriteLine("Vuelto: {0}", vuelto[Max_Vehiculos]);
            }
            else
            {
                Console.WriteLine("No se encontró ningún vehículo con la placa {0}", placa);
            }
        }

        public void Modificar()
        {
            Console.WriteLine("Datos originales:");
            Console.WriteLine("Número de factura: " + numeroFactura[Max_Vehiculos]);
            Console.WriteLine("Número de placa: " + numeroPlaca[Max_Vehiculos]);
            Console.WriteLine("Fecha: " + fecha[Max_Vehiculos]);
            Console.WriteLine("Hora: " + hora[Max_Vehiculos]);
            Console.WriteLine("Tipo de vehículo: " + tipoVehiculo[Max_Vehiculos]);
            Console.WriteLine("Número de caseta: " + numeroCaseta[Max_Vehiculos]);
            Console.WriteLine("Monto a pagar: " + montoPagar[Max_Vehiculos]);
            Console.WriteLine("Paga con: " + pagaCon[Max_Vehiculos]);
            Console.WriteLine("Vuelto: " + vuelto[Max_Vehiculos]);


            Console.WriteLine("\n¿Qué dato desea modificar?");
            Console.WriteLine("1. Fecha");
            Console.WriteLine("2. Hora");
            Console.WriteLine("3. Tipo de vehículo");
            Console.WriteLine("4. Número de caseta");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese la nueva fecha (dd/mm/aaaa):");
                    string nuevaFecha = Console.ReadLine();
                    fecha[Max_Vehiculos] = nuevaFecha;
                    break;
                case 2:
                    Console.WriteLine("Ingrese la nueva hora (hh:mm):");
                    string nuevaHora = Console.ReadLine();
                    hora[Max_Vehiculos] = nuevaHora;
                    break;

                case 3:
                    Console.WriteLine("Ingrese el nuevo tipo de vehículo:");
                    Console.WriteLine("1. Moto");
                    Console.WriteLine("2. Vehículo liviano");
                    Console.WriteLine("3. Camión o pesado");
                    Console.WriteLine("4. Autobús");
                    int nuevoTipo = int.Parse(Console.ReadLine());

                    while (nuevoTipo < 1 || nuevoTipo > 4)
                    {
                        Console.WriteLine("Tipo de vehículo inválido. Ingrese un valor entre 1 y 4:");
                        nuevoTipo = int.Parse(Console.ReadLine());
                    }

                    // Actualizamos el tipo de vehículo y el monto a pagar
                    tipoVehiculo[Max_Vehiculos] = nuevoTipo;
                    montoPagar[Max_Vehiculos] = montoPagar[nuevoTipo];
                    break;

                case 4:
                    Console.WriteLine("Ingrese el nuevo número de caseta (1, 2 o 3):");
                    int nuevaCaseta = int.Parse(Console.ReadLine());

                    while (nuevaCaseta < 1 || nuevaCaseta > 3)
                    {
                        Console.WriteLine("Número de caseta inválido. Ingrese un valor entre 1 y 3:");
                        nuevaCaseta = int.Parse(Console.ReadLine());
                    }

                    numeroCaseta[Max_Vehiculos] = nuevaCaseta;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            Console.WriteLine("Datos modificados con éxito.");
        }

        public void ReporteTodosLosDatos()
        {
            Console.WriteLine("Reporte de todos los vehículos registrados:\n");
            Console.WriteLine("Número de factura\tNúmero de placa\tFecha\tHora\tTipo de vehículo\tNúmero de caseta\tMonto a pagar\tPaga con\tVuelto");

            for (int i = 0; i < numeroPlaca.Length; i++)
            {
                if (!string.IsNullOrEmpty(numeroPlaca[i]))
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", numeroFactura[i], numeroPlaca[i], fecha[i], hora[i], tipoVehiculo[i], numeroCaseta[i], montoPagar[i], pagaCon[i], vuelto[i]);
                }
            }
        }




    }
}
