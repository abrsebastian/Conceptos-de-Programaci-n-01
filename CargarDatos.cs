using Proyecto;

class CargarDatos
{
    public static int CargarAlumnos(Program.Alumno[] alumnos, int contador)
    {
        for(int i = contador; i < 100; i++)
        {
            System.Console.WriteLine("Ingrese nombre del Alumno:");
            alumnos[i].nombre = Console.ReadLine();
            System.Console.WriteLine("Ingrese el apellido del Alumno");
            alumnos[i].apellido = Console.ReadLine();
            System.Console.WriteLine("Ingrese su DNI");
            alumnos[i].dni = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Ingrese numero de Legajo");
            alumnos[i].legajo = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Ingrese la carrera que cursa");
            alumnos[i].carrera = Console.ReadLine();
            alumnos[i].estadoPostulante = "Pendiente";

            System.Console.WriteLine("Ingrese la nota 1:");
            alumnos[i].nota1 = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Ingrese la nota 2:");
            alumnos[i].nota2 = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Ingrese la nota 2:");
            alumnos[i].nota3 = Convert.ToDouble(Console.ReadLine());

            System.Console.WriteLine("------------------------------------------------------");
            System.Console.WriteLine("Datos Ingresados");
            System.Console.WriteLine("Nombre: {0}", alumnos[i].nombre);
            System.Console.WriteLine("Apellido: {0}", alumnos[i].apellido);
            System.Console.WriteLine("DNI: {0}", alumnos[i].dni);
            System.Console.WriteLine("Legajo {0}", alumnos[i].legajo);
            System.Console.WriteLine("Carrera: {0}", alumnos[i].carrera);
            System.Console.WriteLine("Estado de la Beca: {0}", alumnos[i].estadoPostulante);
            System.Console.WriteLine("------------------------------------------------------");

            contador++;

            string decision = "";    

            
            while(decision != "S" && decision != "N")
            {
                System.Console.WriteLine("¿Desea ingresar otro alumno? (S/N)" );
                decision = Console.ReadLine().ToUpper();

                if(decision != "S" && decision != "N")
                {
                    System.Console.WriteLine("Opción incorrecta, por favor ingrese 'S' o 'N'");
                }
            }

            if(decision == "N")
            {
                System.Console.WriteLine("Saliendo del bloque de carga...");
                System.Console.WriteLine("La cantidad actual de alumnos es de {0}/100", contador);

                break;

                Console.Clear();
            }

        }

        return contador;
    }

    public static void CargarEntrevista(Program.Alumno[] alumno, int contador)
    {
        int posicionEncontrada = -1;

        int datoIngresado = 0;

        System.Console.WriteLine("Ingrese DNI o Numero de Legajo del Alumno");
        datoIngresado = Convert.ToInt32(Console.ReadLine());
        

        for (int i = 0; i< contador; i++)
        {

            if(alumno[i].dni == datoIngresado || alumno[i].legajo == datoIngresado)
            {
                posicionEncontrada = i;

                System.Console.WriteLine("Ingrese nota de la Entrevista");

                double entrevistaIngresada = Convert.ToDouble(Console.ReadLine());

                entrevistaIngresada = alumno[posicionEncontrada].notaEntrevista;

                alumno[posicionEncontrada].entrevistaIngresada = true;

                alumno[posicionEncontrada].estadoEntrevista = "Ingresada";

                System.Console.WriteLine("La entrevista del Alumno {0} {1} fue cargada con éxito", alumno[posicionEncontrada].nombre, alumno[posicionEncontrada].apellido);
            }
            else
            {
                System.Console.WriteLine("No éxiste alumno con esos datos");
            }

            string decision = "";

            while(decision != "S" && decision != "N")
            {
                System.Console.WriteLine("¿Desea buscar otro alumno?");
                decision = Console.ReadLine().ToUpper();

                if(decision != "S" && decision != "N")
                {
                    System.Console.WriteLine("Opción incorrecta, ingrese 'S o 'N'");
                }
            }

            if(decision == "N")
            {   
                System.Console.WriteLine("Saliendo de la opción...");
                break;

                Console.Clear();
            }
          
        }

    }
}