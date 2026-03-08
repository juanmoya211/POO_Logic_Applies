namespace HarvestingHorse
{
    public class HarvestingHorse()
    {
        static void Main()
        {
            //Board. 8 x 8
            char[,] tablero = new char[8, 8];

            //Fruit location
            Console.Write("Ingrese ubicación de los frutos: ");
            string[] datos = Console.ReadLine()!.Split(',');

            //Fruit entry on the board
            foreach (string f in datos)
            {
                int fila = int.Parse(f[1].ToString()) - 1;
                int col = f[0] - 'A';
                tablero[fila, col] = f[2];
            }

            //Movements
            Console.Write("Ingrese posición inicial del caballo: ");
            string pos = Console.ReadLine()!;

            int r = int.Parse(pos[1].ToString()) - 1;
            int c = pos[0] - 'A';

            Console.Write("Ingrese los movimientos del caballo: ");
            string[] mov = Console.ReadLine()!.Split(',');

            //Dictionary of horse movements
            Dictionary<string, int[]> pasos = new Dictionary<string, int[]>();

            pasos["UL"] = new int[] { 2, -1 };
            pasos["UR"] = new int[] { 2, 1 };
            pasos["LU"] = new int[] { 1, -2 };
            pasos["LD"] = new int[] { -1, -2 };
            pasos["RU"] = new int[] { 1, 2 };
            pasos["RD"] = new int[] { -1, 2 };
            pasos["DL"] = new int[] { -2, -1 };
            pasos["DR"] = new int[] { -2, 1 };

            //List of harvested fruits
            List<char> frutos = new List<char>();

            //Movement path
            foreach (string m in mov)
            {
                r += pasos[m][0];
                c += pasos[m][1];

                //Check the board limits
                if (r >= 0 && r < 8 && c >= 0 && c < 8)
                {
                    //Check if there is fruit
                    if (tablero[r, c] != '\0')
                    {
                        frutos.Add(tablero[r, c]);
                        tablero[r, c] = '\0';
                    }
                }
            }

            Console.WriteLine("Los frutos recogidos son: " + string.Join(" ", frutos));
            Console.ReadLine();
        }
    }
}