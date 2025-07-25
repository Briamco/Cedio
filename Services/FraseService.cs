using Utils;

namespace Services;

public class FraseService
{
    private static string path = "storage/frases.txt";
    private static string[] frases = new string[0];
    private static Random rand = new Random();

    public static void MostrarFraseAleatoria()
    {
        frases = StorageHelper.Load(path);

        int idx = rand.Next(frases.Length);

        string[] partes = frases[idx].Split('|');
        if (partes.Length == 2)
        {
            string frase = partes[0].Trim();
            string autor = partes[1].Trim();

            StyleConsole.WriteLine($"“{frase}”", ConsoleColor.Green);
            StyleConsole.WriteLine($"– {autor}", ConsoleColor.Blue);
        }
    }
}