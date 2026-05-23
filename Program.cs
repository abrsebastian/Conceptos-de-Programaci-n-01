using System;

namespace Proyecto
{
    public struct Alumno
    {
        public string nombre;
        public string apellido;
        public int dni; 
        public int legajo;
        public string email;
        public string carrera;
        public double nota1;
        public double nota2;
        public double nota3;
        public double promedioNotas;
        public double notaEntrevista;
        public double promedioFinal;
        public string estadoPostulante;
        public string estadoEntrevista; 
        public bool entrevistaIngresada;
        public bool promedioCalculado;       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Alumno[] lista = new Alumno[100];
            int contador = 0;
            int opcion = 0;

            do
            {
                System.Console.WriteLine("------------------------------------------------------");
                System.Console.WriteLine("ingrese una opcion");
                System.Console.WriteLine("1. Cargar datos de alumno");
                System.Console.WriteLine("2. Calcular Promedios");
                System.Console.WriteLine("3. Mostrar Candidatos no aptos");
                System.Console.WriteLine("4. Mostrar candidatos a beca");
                System.Console.WriteLine("5. Cargar entrevista anexa a un Alumno");
                System.Console.WriteLine("6. Buscar Alumno por N° de Legajo");
                System.Console.WriteLine("7. Admistrar estado de Alumnos");
                System.Console.WriteLine("8. Salir");
                System.Console.WriteLine("------------------------------------------------------");
                
                opcion = Convert.ToInt32(Console.ReadLine());

                if(opcion >= 2 && opcion <= 5 && contador == 0)
                {   
                    System.Console.WriteLine("------------------------------------------------------");
                    System.Console.WriteLine("No puede ingresar a esta opción porque no hay alumnos cargados");
                    System.Console.WriteLine("------------------------------------------------------");
                    Console.ReadKey();
                }

                switch (opcion)
                {
                    case 1:
                        contador = CargarDatos.CargarAlumnos(lista, contador);
                        break;
                    case 2:
                        Calculador.CalcularPromedio(lista, contador);
                        break;
                    case 3:
                        Calculador.PromediosNoAptos(lista, contador);
                        break;
                    case 4:
                        Calculador.PromediosCandidatos(lista, contador);
                        break;
                    case 5:
                        CargarDatos.CargarEntrevista(lista, contador);
                        break;
                    case 6:
                        Buscador.BuscarAlumnoPorLegajo(lista, contador);
                        break;
                    case 7:
                        Adminsitrador.AdministradorAlumno(lista, contador);
                        break;
                } 
            }
            while(opcion != 8);     
        }
    }
    }