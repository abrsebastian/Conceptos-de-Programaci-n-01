using System.Runtime.Serialization.Formatters;
using Proyecto;

class CargarDatos
{
    public static int CargarAlumnos(Alumno[] alumnos, int contador)
    {
        for(int i = contador; i < 100; i++)
        {
            System.Console.WriteLine("Ingrese nombre del Alumno:");
            alumnos[i].nombre = Console.ReadLine();
            System.Console.WriteLine("Ingrese el apellido del Alumno");
            alumnos[i].apellido = Console.ReadLine();

            while (true)
            {   
                System.Console.WriteLine("Ingrese el DNI");
                int dniIngresado = Convert.ToInt32(Console.ReadLine());
                bool dniDuplicado = false;

                for(int j = 0; j < contador; j++)
                {
                    if(alumnos[j].dni == dniIngresado)
                    {
                        dniDuplicado = true;
                        System.Console.WriteLine("El DNI ingresado le corresponde a {0} {1}", alumnos[j].nombre, alumnos[j].apellido);
                        System.Console.WriteLine("Ingrese el DNI correctamente");
                        System.Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                    }
                }

                if(dniDuplicado != true)
                {
                    alumnos[i].dni = dniIngresado;
                    break;
                }
            }

            while (true)
            {
                System.Console.WriteLine("Ingrese el número de legajo");
                int legajoIngresado = Convert.ToInt32(Console.ReadLine());
                bool legajoDuplicado = false;

                for(int j = 0; j < contador; j++)
                {
                    if(alumnos[j].legajo == legajoIngresado)
                    {
                        legajoDuplicado = true;
                        System.Console.WriteLine("El legajo ingresado es del alumno {0} {1}", alumnos[j].nombre, alumnos[j].apellido);
                        System.Console.WriteLine("Ingrese otro número de legajo");
                        break;
                    }
                }
                if(legajoDuplicado != true)
                {
                    alumnos[i].legajo = legajoIngresado;
                    break;
                } 
            }
            

            alumnos[i].estadoPostulante = "Pendiente";
            alumnos[i].estadoEntrevista = "Pendiente";
            System.Console.WriteLine("Ingrese la carrera que cursa");
            alumnos[i].carrera = Console.ReadLine();
            System.Console.WriteLine("Ingrese la nota 1:");
            alumnos[i].nota1 = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Ingrese la nota 2:");
            alumnos[i].nota2 = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Ingrese la nota 3:");
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

    public static void CargarEntrevista(Alumno[] alumno, int contador)
    {

        int datoIngresado = 0;

        System.Console.WriteLine("Ingrese DNI o Numero de Legajo del Alumno");
        datoIngresado = Convert.ToInt32(Console.ReadLine());
        
        while(datoIngresado != 0)
        {
            int posicionEncontrada = -1;

            for (int i = 0; i< contador; i++)
            {
                if(alumno[i].dni == datoIngresado || alumno[i].legajo == datoIngresado)
                {
                    posicionEncontrada = i;
                    break;
                }
                
            }


            if(posicionEncontrada!=-1)
            {

                System.Console.WriteLine("Resultado:");
                System.Console.WriteLine("Alumno: {0} {1}", alumno[posicionEncontrada].nombre, alumno[posicionEncontrada].apellido);
                System.Console.WriteLine("N° de Legajo: {0}", alumno[posicionEncontrada].legajo);
                System.Console.WriteLine("DNI: {0}", alumno[posicionEncontrada].dni);
                System.Console.WriteLine("Entrevista: {0}", alumno[posicionEncontrada].estadoEntrevista);
                System.Console.WriteLine("Estado de su Beca: {0}", alumno[posicionEncontrada].estadoPostulante);

                System.Console.WriteLine("¿Son correctos los datos encontrados? (S/N)");

                string res = "";

                while(res != "S" && res != "N")
                {
                    res = Console.ReadLine().ToUpper();

                    if(res != "S" && res != "N")
                    {
                        System.Console.WriteLine("El dato ingresado no es correcto");
                        System.Console.WriteLine("Ingrese (S/N)");
                    }
                }

                if(res == "N")
                {
                    System.Console.WriteLine("Ingrese DNI o Legajo del alumno");
                    datoIngresado = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else if (res == "S")
                {
                    System.Console.WriteLine("Ingrese nota de la Entrevista");
               
                    alumno[posicionEncontrada].notaEntrevista = Convert.ToDouble(Console.ReadLine());  
                    alumno[posicionEncontrada].entrevistaIngresada = true;
                    alumno[posicionEncontrada].estadoEntrevista = "Ingresada";

                    System.Console.WriteLine("La entrevista del Alumno {0} {1} fue cargada con éxito", alumno[posicionEncontrada].nombre, alumno[posicionEncontrada].apellido);
                }

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
                return;

            }

            else if(decision == "S")
            {
                System.Console.WriteLine("Ingrese DNI o Legajo del alumno_______");
                datoIngresado = Convert.ToInt32(Console.ReadLine());
            }
                
        }

    }
}


        
