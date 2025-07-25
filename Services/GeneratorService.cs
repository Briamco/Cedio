using System.Media;
using Data;
using Utils;

namespace Services;

class GeneratorServices
{
  private static string[] ideas = IdeaData.ideas;
  private static string[] promblem = IdeaData.promblem;
  private static string[] techno = IdeaData.techno;
  private static string[] contra = IdeaData.contra;
  private static Random random = new Random();

  private static bool PastConvination(string text)
  {
    for (int i = 0; i < ideas.Length; i++)
    {
      if (text == ideas[i]) return true;
    }
    return false;
  }

  private static string? IdeaGenerator()
  {
    string idea;
    int totalConvinations = promblem.Length * techno.Length * contra.Length;

    if (ideas.Length == totalConvinations) return null;

    do
    {
      Sound.StopSound();
      Sound.TamboreSound();
      StyleConsole.WriteLine("Problema: ", ConsoleColor.Green);
      idea = AnimationHelper.LoopAnimation(promblem, TextHelper.CapitalText(promblem[random.Next(promblem.Length)]), 1.4, false);
      StyleConsole.WriteLine("Tecnologia: ", ConsoleColor.Green);
      idea += $" {AnimationHelper.LoopAnimation(techno, techno[random.Next(techno.Length)], 1.4, false, true)}";
      StyleConsole.WriteLine("Contra: ", ConsoleColor.Green);
      idea += $" {AnimationHelper.LoopAnimation(contra, contra[random.Next(contra.Length)], 1.4, false, true)}";
    } while (PastConvination(idea));

    return idea;
  }

  public static void Generator()
  {
    while (true)
    {
      Console.Clear();
      StyleConsole.Title("GENERANDO IDEA...");
      string? idea = IdeaGenerator();

      if (idea == null)
      {
        StyleConsole.Error("Ya no hay más combinaciones posibles.");
        return;
      }

      Console.Clear();
      Sound.StopSound();
      Sound.SucessSound();
      StyleConsole.Title("IDEA");
      StyleConsole.WriteLine($"💡 Idea loca generada:", ConsoleColor.Cyan);
      StyleConsole.WriteLine(idea, ConsoleColor.Green);

      string input = InputHelper.ReadString("\n¿Deseas guardar esta idea? (s = sí / cualquier otra tecla = no / x = salir)", false, true).Trim().ToLower() ?? "";

      if (input == "s")
      {
        IdeaData.AddIdea(idea);
        StyleConsole.WriteLine("✅ Idea guardada exitosamente.\n", ConsoleColor.Green);
        Thread.Sleep(1000);
      }
      else if (input == "x")
      {
        StyleConsole.Error("🚪 Saliendo del generador...");
        Thread.Sleep(1000);
        return;
      }
      else
      {
        StyleConsole.Error("❌ Idea descartada. Generando otra...\n");
        Thread.Sleep(1000);
      }
    }
  }

}