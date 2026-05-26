using System.Net;
using Proyecto;

class Buscador
{
    public static void BuscarAlumnoPorLegajo(Alumno[] alumnos, int contador)
    {
        System.Console.WriteLine("Ingrese numero de Legajo del Alumno");
        int legajoIngresado = Convert.ToInt32(Console.ReadLine());

        while(legajoIngresado != 0)
        {
            int posicionEncontrada = -1;

            for(int i = 0; i < contador; i++)
            {
                if(alumnos[i].legajo == legajoIngresado)
                {
                    posicionEncontrada = i;
                    break;
                }
            
            }
            
            if(posicionEncontrada != -1)
            {
                System.Console.WriteLine("--------------------------------------------");
                System.Console.WriteLine("Alumno Encontrado");
                System.Console.WriteLine("--------------------------------------------");
                System.Console.WriteLine("Nombre completo: {0} {1}", alumnos[posicionEncontrada].nombre, alumnos[posicionEncontrada].apellido);
                System.Console.WriteLine("Legajo: {0}", alumnos[posicionEncontrada].legajo);
                System.Console.WriteLine("DNI: {0}", alumnos[posicionEncontrada].dni);
                System.Console.WriteLine("Carera: {0}", alumnos[posicionEncontrada].carrera);
                
                if(alumnos[posicionEncontrada].promedioCalculado == false)
                {
                    double promedioCalculado = Calculador.CalcularPromedioIndividual(alumnos[posicionEncontrada].nota1,alumnos[posicionEncontrada].nota2,alumnos[posicionEncontrada].nota3);
                    alumnos[posicionEncontrada].promedioCalculado = true;

                    alumnos[posicionEncontrada].promedioNotas = promedioCalculado;

                    System.Console.WriteLine("Promedio de notas: {0}", alumnos[posicionEncontrada].promedioNotas);

                    if(promedioCalculado < 5)
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "No apto";
                        System.Console.WriteLine("Estado de la Beca: {0}", alumnos[posicionEncontrada].estadoPostulante);
                    }
                    else if(promedioCalculado >= 8)
                    {
                        alumnos[posicionEncontrada].estadoPostulante =  "Candidato a la Beca";
                        System.Console.WriteLine("Estado de la Beca: {0}", alumnos[posicionEncontrada].estadoPostulante);
                    }
                    else
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "Pendiente";
                        System.Console.WriteLine("Estado de la Beca: {0}", alumnos[posicionEncontrada].estadoPostulante);
                    }

                }
                else
                {
                    System.Console.WriteLine("Promedio de notas: {0}", alumnos[posicionEncontrada].promedioNotas);
                }
                
                System.Console.WriteLine("Estado de la Beca: {0}", alumnos[posicionEncontrada].estadoPostulante);
                
                if(alumnos[posicionEncontrada].entrevistaIngresada == false)
                {
                    alumnos[posicionEncontrada].estadoEntrevista = "Pendiente";

                    System.Console.WriteLine("Entrevista: {0}", alumnos[posicionEncontrada].estadoEntrevista);
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
                    return;
                }
                else if(decision == "S")
                {
                    System.Console.WriteLine("Ingrese número de Legajo");
                    legajoIngresado = Convert.ToInt32(Console.ReadLine()); 
                    continue;

                }
            }

            else
            {
                System.Console.WriteLine("No se ha encontrado alumno con legajo: {0}", legajoIngresado);

                string desFinal ="";

                while(desFinal != "N" && desFinal != "S")
                {
                    System.Console.WriteLine("¿Desea intentar con otro Legajo? (S/N)");
                    desFinal = Console.ReadLine();

                    if(desFinal != "N" && desFinal != "S")
                    {
                        System.Console.WriteLine("La opción ingresada no es correcta. Ingrese (S/N)");
                    }
                }

                if(desFinal == "N")
                {
                    System.Console.WriteLine("Volviendo al menú principal...");
                    return;
                }
                else if(desFinal == "S")
                {
                    System.Console.WriteLine("Ingrese el número de Legajo");
                    legajoIngresado = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }

        
}