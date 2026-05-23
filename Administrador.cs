using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Proyecto;

class Adminsitrador
{
    public static void AdministradorAlumno(Alumno[] alumnos, int contador)
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
                if(alumnos[i].dni == datoIngresado || alumnos[i].legajo == datoIngresado)
                {
                    posicionEncontrada = i;
                }
            }
            
            if (posicionEncontrada != -1)
            {
                { 
                    if(alumnos[posicionEncontrada].promedioCalculado == false)
                    {
                        alumnos[posicionEncontrada].promedioNotas = Calculador.CalcularPromedioIndividual(alumnos[posicionEncontrada].nota1,alumnos[posicionEncontrada].nota2,alumnos[posicionEncontrada].nota3);

                        alumnos[posicionEncontrada].promedioCalculado = true;
                    }
                    
                    if(alumnos[posicionEncontrada].promedioNotas < 5)
                    {
                        alumnos[posicionEncontrada].estadoPostulante = "Rechazada";

                        System.Console.WriteLine("La Solicitud para la beca quedó desestimada.");

                        System.Console.WriteLine("------------------------------------------------------------------------------------------------");
                        System.Console.WriteLine("Alumno: {0} {1}", alumnos[posicionEncontrada].nombre, alumnos[posicionEncontrada].apellido);
                        System.Console.WriteLine("N° de Legajo: {0}", alumnos[posicionEncontrada].legajo);
                        System.Console.WriteLine("DNI: {0}", alumnos[posicionEncontrada].dni);
                        System.Console.WriteLine("Promedio Final: {0}", alumnos[posicionEncontrada].promedioNotas);
                        System.Console.WriteLine("Estado de su Beca: {0}", alumnos[posicionEncontrada].estadoPostulante);
                        System.Console.WriteLine("------------------------------------------------------------------------------------------------");

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

                    else if(alumnos[posicionEncontrada].promedioNotas >= 8 && alumnos[posicionEncontrada].entrevistaIngresada == false)
                    {

                        alumnos[posicionEncontrada].estadoPostulante = "Candidato a Beca___";
                        alumnos[posicionEncontrada].estadoEntrevista = "Pendiente___";
                        
                        System.Console.WriteLine("El alumno {0} {1} es {2}", 
                        alumnos[posicionEncontrada].nombre,
                        alumnos[posicionEncontrada].apellido,
                        alumnos[posicionEncontrada].estadoPostulante);

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

                    else if(alumnos[posicionEncontrada].promedioNotas >= 5 && alumnos[posicionEncontrada].promedioNotas < 8)
                    {
                        System.Console.WriteLine("El alumno {0} {1}:", 
                        alumnos[posicionEncontrada].nombre,
                        alumnos[posicionEncontrada].apellido);

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
            
            else
            {
                System.Console.WriteLine("No hay alumno registrado con DNI/Legajo {0}", datoIngresado);
                string des3 = "";

                while(des3 != "S" && des3 != "N")
                {
                    System.Console.WriteLine("¿Desea buscar otro alumno? (S/N)");

                    des3 = Console.ReadLine().ToUpper();
                    if(des3 != "S" && des3 != "N")
                    {
                        System.Console.WriteLine("La opción ingresada es incorrecta");
                        System.Console.WriteLine("ingrese (S/N)");
                    }
                }
                
                if(des3 == "N")
                {
                    System.Console.WriteLine("Volviendo al menú principal...");
                    return;
                }
                else if(des3 == "S")
                {
                    System.Console.WriteLine("Ingrese el número de legajo o DNI");
                    datoIngresado = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }   
}

    
