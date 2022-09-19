using System;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        // vamos a declarar e inicializar un objeto de tipo RepositorioPaciente
        
        // que sera un campo propio de la clase program 

        private static IRepositorioPaciente _repoPaciente= new RepositorioPaciente(new Persistencia.AppContext());

        static void Main(string[] args)
        {   
            System.Console.WriteLine("hola githug");
            sistema _ consola _ wiriteline("esto lo hago desde la web");
            bool control = true;
            while (control) 
            {
                
                Console.WriteLine("BIENVENIDO AL PROGRAMA HOSPITAL EN CASA G44");
                System.Console.WriteLine(" #### MENU PRINCIPAL ####");
                
                System.Console.WriteLine(" 1. Adicionar paciente ");
                System.Console.WriteLine(" 2. borrar paciente ");
                System.Console.WriteLine(" 3. buscar paciente ");
                System.Console.WriteLine(" 4. Asignar paciente ");
                System.Console.WriteLine(" 5. Salir ");
                System.Console.WriteLine("Digite su opcion: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AdicionarPaciente();
                        break;
                    case 2:
                        System.Console.WriteLine("BIENVENIDO A LA OPCION ELIMINAR PACIENTE");
                        System.Console.WriteLine("Digite el id del paciente a eliminar: ");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        EliminarPaciente(idEliminar);
                        break;
                    case 3:
                        System.Console.WriteLine("BIENVENIDO A LA OPCION BUSCAR PACIENTE");
                        System.Console.WriteLine("Digite el id del paciente a buscar: ");
                        int idBuscar = Convert.ToInt32(Console.ReadLine());
                        BuscarPaciente(idBuscar);
                        break;
                    case 4:
                        break;
                    case 5:
                        System.Console.WriteLine("GRACIAS POR USAR NUESTRO PROGRAMA");
                        control = false;
                        break;
                    default:
                        System.Console.WriteLine("OPCION INVALIDA, DIGITE NUEVAMENTE");
                        break;
                }
            }
        }
        //metodos para realizar el CRUD con la base de datos

        private static void AdicionarPaciente() // metodo que va a crear un objeto tipo paciente
        {
            var paciente = new Paciente //variable
            {
                Nombre = "Pepito",
                Apellidos = "Perez",  
                NumeroTelefono = "123456789",
                Genero = Genero.Masculino,
                Direccion = "Calle cangrejo",
                Longitud = 12.002F,
                Latitud = -6.1212F,
                Ciudad = "New York",
                FechaNacimiento = new DateTime(2000, 02, 14)
            };
            System.Console.WriteLine($"El paciente {paciente.Nombre} {paciente.Apellidos} sera ingresado a la BD");
            _repoPaciente.AddPaciente(paciente); 
            System.Console.WriteLine();
            System.Console.WriteLine($"El paciente {paciente.Nombre} {paciente.Apellidos} ha sido ingresado a la BD");
        }
        //metodo para eliminar paciente
        private static void EliminarPaciente(int idPaciente)
        {
            System.Console.WriteLine("¿Esta seguro de elimina el paciente? \n1. \nSI 2. NO");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                System.Console.WriteLine($"El paciente con id {idPaciente} sera elminado");
                _repoPaciente.DeletePaciente(idPaciente);
                System.Console.WriteLine("PACIENTE ELIMINADO CON EXITO");
            }
        }

        private static void BuscarPaciente (int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            System.Console.WriteLine($"El paciente con id No {idPaciente} es {paciente.Nombre} {paciente.Apellidos}");
            System.Console.WriteLine($"Su informacion es: ");
            System.Console.WriteLine($"Telefono: {paciente.NumeroTelefono}");
            System.Console.WriteLine($"Direccion: {paciente.Direccion}");
        }
    }
}
