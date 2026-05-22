using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Proyecto;

class Adminsitrador
{
    public static void AdministradorAlumno(Program.Alumno[] alumnos, int contador)
    {
        int posicionEncontrada = -1;
        System.Console.WriteLine("Ingrese numero de DNI o Legajo del alumno");
        int datoIngresado = Convert.ToInt32(Console.ReadLine());
        string des = "";
        int i;

        while(datoIngresado != 0)
        {
            for(i = 0; i <contador; i++)
            {
                posicionEncontrada = i;
                
                if(alumnos[i].dni == datoIngresado || alumnos[i].legajo == datoIngresado)
                { 
                    
                    if(alumnos[posicionEncontrada].promedioCalculado == false)
                    {
                        alumnos[posicionEncontrada].promedioNotas = Calculador.CalcularPromedioIndividual(alumnos[posicionEncontrada].nota1,alumnos[posicionEncontrada].nota2,alumnos[posicionEncontrada].nota3);

                        alumnos[posicionEncontrada].promedioCalculado = true;
                    }
                    
                    if(alumnos[posicionEncontrada].promedioNotas < 5)
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "No Apto";

                        System.Console.WriteLine("El Alumno {0} {1} no es apto", alumnos[posicionEncontrada].nombre, alumnos[posicionEncontrada].apellido);

                        des = "";

                        while(des != "S" && des != "N")
                        {
                            System.Console.WriteLine("¿Desea buscar otro Alumno? (S/N)");
                            des = Console.ReadLine().ToUpper();

                            if(des != "S" && des != "N")
                            {
                                System.Console.WriteLine("La opción ingresada es incorrecta");
                                System.Console.WriteLine("Ingrese (S/N)");
                            }
                            
                        }

                        if(des == "N")
                        {
                            System.Console.WriteLine("Volviendo al menu principal...");
                            return;
                        }
                        else if (des == "S")
                        {
                            System.Console.WriteLine("Ingrese el numero de Legajo o DNI de un alumno");
                            System.Console.WriteLine("o ingrese 0 para salir");
                            datoIngresado = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        break;
                       
                    }

                    else if(alumnos[posicionEncontrada].promedioNotas >= 8)
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "Candidato a Beca";
                        System.Console.WriteLine("El alumno {0} {1} es {2}", alumnos[posicionEncontrada].nombre,alumnos[posicionEncontrada].apellido,alumnos[posicionEncontrada].estadoPostulante);

                        System.Console.WriteLine("Pero el estado de su entrevista está: {0}", alumnos[posicionEncontrada].estadoEntrevista);

                        string des2 = "";

                        while(des2 != "S" && des2 != "N")
                        {
                            System.Console.WriteLine("¿Desea agregar la nota de la entrevista? (S/N)");
                            des2 = Console.ReadLine().ToUpper();

                            if(des2 != "S" && des2 != "N")
                            {
                                System.Console.WriteLine("Opción no válida, ingrese (S/N)");
                            }
                        }
                        if(des2 == "N")
                        {
                            System.Console.WriteLine("Volviendo al menú principal");
                            return;
                        }
                        else if (des2 == "S")
                        {
                            System.Console.WriteLine("Ingrese la nota de la entrevista:");
                            double notaNuevaEntrevista = Math.Round(Convert.ToDouble(Console.ReadLine()));

                            alumnos[posicionEncontrada].notaEntrevista = notaNuevaEntrevista;
                            alumnos[posicionEncontrada].entrevistaIngresada = true;
                            

                        }

                        des = "";

                        while(des != "S" && des != "N")
                        {
                            System.Console.WriteLine("¿Desea buscar otro Alumno? (S/N)");
                            des = Console.ReadLine().ToUpper();

                            if(des != "S" && des != "N")
                            {
                                System.Console.WriteLine("La opción ingresada es incorrecta");
                                System.Console.WriteLine("Ingrese (S/N)");
                            }
                            
                        }

                        if(des == "N")
                        {
                            System.Console.WriteLine("Volviendo al menu principal...");
                            return;
                        }
                        else if (des == "S")
                        {
                            System.Console.WriteLine("Ingrese el numero de Legajo o DNI de un alumno");
                            datoIngresado = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        
                    }

                    else if(alumnos[posicionEncontrada].promedioNotas > 5 && alumnos[posicionEncontrada].promedioNotas < 8)
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "Pendiente";
                        System.Console.WriteLine("El alumno {0} {1} es {2}", alumnos[posicionEncontrada].nombre,alumnos[posicionEncontrada].apellido,alumnos[posicionEncontrada].estadoPostulante);

                        System.Console.WriteLine("Pero el estado de su entrevista está: {0}", alumnos[posicionEncontrada].estadoEntrevista);

                        string des2 = "";

                        while(des2 != "S" && des2 != "N")
                        {
                            System.Console.WriteLine("¿Desea agregar la nota de la entrevista? (S/N)");
                            des2 = Console.ReadLine().ToUpper();

                            if(des2 != "S" && des2 != "N")
                            {
                                System.Console.WriteLine("Opción no válida, ingrese (S/N)");
                            }
                        }
                        if(des2 == "N")
                        {
                            System.Console.WriteLine("Volviendo al menú principal");
                            return;
                        }
                        else if (des2 == "S")
                        {
                            System.Console.WriteLine("Ingrese la nota de la entrevista:");
                            double notaNuevaEntrevista = Math.Round(Convert.ToDouble(Console.ReadLine()));

                            alumnos[posicionEncontrada].notaEntrevista = notaNuevaEntrevista;
                            alumnos[posicionEncontrada].entrevistaIngresada = true;
                            
                            Calculador.VeredictoFinal(ref alumnos[posicionEncontrada]);
                        }

                        des = "";

                        while(des != "S" && des != "N")
                        {
                            System.Console.WriteLine("¿Desea buscar otro Alumno? (S/N)");
                            des = Console.ReadLine().ToUpper();

                            if(des != "S" && des != "N")
                            {
                                System.Console.WriteLine("La opción ingresada es incorrecta");
                                System.Console.WriteLine("Ingrese (S/N)");
                            }
                            
                        }

                        if(des == "N")
                        {
                            System.Console.WriteLine("Volviendo al menu principal...");
                            return;
                        }
                        else if (des == "S")
                        {
                            System.Console.WriteLine("Ingrese el numero de Legajo o DNI de un alumno");
                            datoIngresado = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        
                    }
                    else
                    {
                        Calculador.VeredictoFinal(ref alumnos[posicionEncontrada]);
                        System.Console.WriteLine("Veredicto final realizado");
                        datoIngresado = 0;
                        break;
                    }
                    
                    }

         

                }
        }
        
    
    }

    
}