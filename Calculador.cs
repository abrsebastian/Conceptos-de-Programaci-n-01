using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using Proyecto;

class Calculador
{

    public static double CalcularPromedioIndividual(double n1, double n2, double n3)
    {
        return Math.Round((n1 + n2 + n3)/3, 2);
    }

    public static void VeredictoFinal(ref Alumno alumno)
    {
        double promedioGlobal = Math.Round((alumno.promedioNotas + alumno.notaEntrevista)/2,2);
        alumno.promedioFinal = promedioGlobal;

        if(promedioGlobal >= 7)
        {
            alumno.estadoPostulante = "Aceptada";

            System.Console.WriteLine("Alumno: {0} {1}", alumno.nombre, alumno.apellido);
            System.Console.WriteLine("N° de Legajo: {0}", alumno.legajo);
            System.Console.WriteLine("DNI: {0}", alumno.dni);
            System.Console.WriteLine("Promedio Final: {0}", alumno.promedioFinal);
            System.Console.WriteLine("Estado de su Beca: {0}", alumno.estadoPostulante);        
        }
        else
        {
            alumno.estadoPostulante = "Rechazada";

            System.Console.WriteLine("Alumno: {0} {1}", alumno.nombre, alumno.apellido);
            System.Console.WriteLine("N° de Legajo: {0}", alumno.legajo);
            System.Console.WriteLine("DNI: {0}", alumno.dni);
            System.Console.WriteLine("Promedio Final: {0}", alumno.promedioFinal);
            System.Console.WriteLine("Estado de su Beca: {0}", alumno.estadoPostulante);
        }
    }

    public static void CalcularPromedio(Alumno[] alumnos, int contador)
    {
        for(int i = 0; i<contador; i++)
        {
            double suma = Math.Round((alumnos[i].nota1 + alumnos[i].nota2 + alumnos[i].nota3)/3,2);

            alumnos[i].promedioNotas = suma;

            System.Console.WriteLine("El alumno: {0} {1} tiene un promedio de {2}",
            alumnos[i].nombre, alumnos[i].apellido, alumnos[i].promedioNotas); 

            alumnos[i].promedioCalculado = true;
        }
    }

    public static void PromediosNoAptos(Alumno[] alumnosNoAptos, int contador)
    {
        System.Console.WriteLine("Alumnos desestimados de la beca:");
        System.Console.WriteLine("------------------------------------------------------------");    

        bool datoEncontrado = false;

        for(int i = 0; i < contador; i++)
        {
            if(alumnosNoAptos[i].promedioCalculado == false)
            {
                alumnosNoAptos[i].promedioNotas = CalcularPromedioIndividual(alumnosNoAptos[i].nota1,alumnosNoAptos[i].nota2,alumnosNoAptos[i].nota3);
                alumnosNoAptos[i].promedioCalculado = true;
            }
            
            if(alumnosNoAptos[i].promedioNotas < 5)
            {
                alumnosNoAptos[i].estadoPostulante = "No apto";

                datoEncontrado = true;
                //System.Console.WriteLine("------------------------------------------------------");
                System.Console.WriteLine("Alumno: {0} {1}", alumnosNoAptos[i].nombre, alumnosNoAptos[i].apellido);
                System.Console.WriteLine("Promedio: {0}", alumnosNoAptos[i].promedioNotas);
                System.Console.WriteLine("Estado del Postulante: {0}",alumnosNoAptos[i].estadoPostulante);
                System.Console.WriteLine("------------------------------------------------------------");
            }

            
        }

        if(datoEncontrado == false)
        {
            System.Console.WriteLine("Sin resultados encontrados");
            System.Console.WriteLine("------------------------------------------------------------");
        }  


    }


    public static void PromediosCandidatos(Alumno[] alumnosCandidatos, int contador)
    {
        System.Console.WriteLine("Alumnos candidatos a la Beca:");
        System.Console.WriteLine("------------------------------------------------------------");

        bool datoEncontrado = false;

        for(int i = 0; i < contador; i++)
        {
            if(alumnosCandidatos[i].promedioCalculado == false)
            {
                alumnosCandidatos[i].promedioNotas = CalcularPromedioIndividual(
                    alumnosCandidatos[i].nota1,alumnosCandidatos[i].nota2,
                    alumnosCandidatos[i].nota3);
                
                alumnosCandidatos[i].promedioCalculado = true;
            }

            if(alumnosCandidatos[i].promedioNotas >= 8)
            {
                alumnosCandidatos[i].estadoPostulante = "Candidato a Beca";

                datoEncontrado = true;

                System.Console.WriteLine("Alumno: {0} {1}", alumnosCandidatos[i].nombre, alumnosCandidatos[i].apellido);
                System.Console.WriteLine("Promedio: {0}", alumnosCandidatos[i].promedioNotas);
                System.Console.WriteLine("Estado del Postulante: {0}",alumnosCandidatos[i].estadoPostulante);
                System.Console.WriteLine("------------------------------------------------------------");
            }

            
        }
        if(datoEncontrado == false)
        {
            System.Console.WriteLine("Sin resultados encontrados");
            System.Console.WriteLine("------------------------------------------------------------");
        } 


    }
}