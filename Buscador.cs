using Proyecto;

class Buscador
{
    public static void BuscarAlumnoPorLegajo(Program.Alumno[] alumnos, int contador)
    {
        int posicionEncontrada = -1;
        int legajoIngresado = 0;

        for(int i = 0; i < contador; i++)
        {
            System.Console.WriteLine("Ingrese numero de Legajo del Alumno");
            legajoIngresado = Convert.ToInt32(Console.ReadLine());

            if(alumnos[i].legajo == legajoIngresado)
            {
                posicionEncontrada = i;

                System.Console.WriteLine("--------------------------------------------");
                System.Console.WriteLine("Alumno Encontrado");
                System.Console.WriteLine("--------------------------------------------");
                System.Console.WriteLine("Nombre completo: {0} {1}", alumnos[posicionEncontrada].nombre, alumnos[posicionEncontrada].apellido);
                System.Console.WriteLine("Legajo: {0}", alumnos[posicionEncontrada].legajo);
                System.Console.WriteLine("DNI: {0}", alumnos[posicionEncontrada].dni);

                if(alumnos[posicionEncontrada].promedioCalculado == false)
                {
                    double promedioCalculado = Calculador.CalcularPromedioIndividual(alumnos[posicionEncontrada].nota1,alumnos[posicionEncontrada].nota2,alumnos[posicionEncontrada].nota3);
                    alumnos[posicionEncontrada].promedioCalculado = true;

                    System.Console.WriteLine("Promedio de notas____: {0}", alumnos[posicionEncontrada].promedioCalculado);

                    alumnos[posicionEncontrada].promedioNotas = promedioCalculado;

                    if(promedioCalculado < 5)
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "No apto";
                        System.Console.WriteLine("Estado del Postulante: {0}", alumnos[posicionEncontrada].estadoPostulante);
                    }
                    else if(promedioCalculado >= 8)
                    {
                        alumnos[posicionEncontrada].estadoEntrevista =  "Candidato a la Beca";
                        System.Console.WriteLine("Estado del Postulante: {0}", alumnos[posicionEncontrada].estadoPostulante);
                    }
                    else
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "Pendiente";
                        System.Console.WriteLine("Estado del Postulante: {0}", alumnos[posicionEncontrada].estadoPostulante);
                    }

                }
                else
                {
                    System.Console.WriteLine("Promedio de notas: {0}", alumnos[posicionEncontrada].promedioNotas);
                }

                System.Console.WriteLine("Estado del Postulante: {0}", alumnos[posicionEncontrada].estadoPostulante);

                if(alumnos[posicionEncontrada].entrevistaIngresada == false)
                {
                    alumnos[posicionEncontrada].estadoEntrevista = "Pendiente";

                    System.Console.WriteLine("Entrevista: {0}", alumnos[posicionEncontrada].estadoEntrevista);
                }
            }

            string decision ="";

            while(decision != "S" && decision != "N")
            {
                System.Console.WriteLine("¿Desea buscar otro alumno? (S/N)");
                decision = Console.ReadLine().ToUpper();

                if(decision != "S" && decision != "N")
                {
                    System.Console.WriteLine("La opción ingresada no es válida");
                    System.Console.WriteLine("Ingrese 'S' o 'N'");
                }

            }

            if(decision == "N")
            {
                System.Console.WriteLine("Volviendo al menú principal");
                break;
            }
        }
    }
}