namespace BridgeMadison
{
    public class BridgeMadison()
    {
        static void Main()
        {
            //Infinite loop until the user decides to exit
            while (true)
            {
                Console.Write("Ingrese el puente (o escriba 'salir' para terminar): ");
                string puente = Console.ReadLine()!;

                // Add program to exit the program
                if (puente.ToLower() == "salir")
                    break;

                if (string.IsNullOrEmpty(puente) || puente[0] != '*' || puente[puente.Length - 1] != '*')
                {
                    Console.WriteLine("INVALIDO\n");
                    continue;
                }

                bool valido = true;

                //Check symmetry
                for (int i = 0; i < puente.Length / 2; i++)
                    if (puente[i] != puente[puente.Length - 1 - i]) { valido = false; break; }

                //Analyze the platform sequences
                for (int i = 0; i < puente.Length; i++)
                {
                    if (puente[i] == '=')
                    {
                        int count = 0;
                        while (i + count < puente.Length && puente[i + count] == '=') count++;

                        if (count > 3) { valido = false; break; }

                        if (count == 2)
                        {
                            bool left = i - 1 >= 0 && puente[i - 1] == '+';
                            bool right = i + 2 < puente.Length && puente[i + 2] == '+';
                            if (!left && !right) { valido = false; break; }
                        }

                        if (count == 3)
                        {
                            int center = puente.Length / 2;
                            if (!(i <= center && i + 2 >= center)) { valido = false; break; }
                        }

                        i += count - 1;
                    }
                }

                Console.WriteLine(valido ? "VALIDO\n" : "INVALIDO\n");
            }
        }
    }
}
