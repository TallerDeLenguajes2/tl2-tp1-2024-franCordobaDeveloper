using Cadeterias;

namespace MenuCadeterias
{
    public class MenuCadeteria(List<Cadeteria> cadeterias)
    {
        private List<Cadeteria> cadeterias = cadeterias;

        public Cadeteria SeleccionarCadeteria()
        {
            Console.WriteLine("----- [ Cadeterías Disponibles ] -----");
            for (int i = 0; i < cadeterias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cadeterias[i].NombreCadeteria}");
            }

            int seleccion = 0;
            while (seleccion < 1 || seleccion > cadeterias.Count)
            {
                Console.Write("Seleccione una cadetería (número): ");
                if (int.TryParse(Console.ReadLine(), out seleccion))
                {
                    if (seleccion < 1 || seleccion > cadeterias.Count)
                    {
                        Console.WriteLine("Selección no válida. Intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Ingrese un número.");
                }
            }
            return cadeterias[seleccion - 1];
        }
    }
}