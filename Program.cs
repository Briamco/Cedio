using Utils;
using Screen;
using Data;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.Clear();
    StyleConsole.WriteLine(@"
      _____        ______        _____    ____         _____    
  ___|\    \   ___|\     \   ___|\    \  |    |   ____|\    \   
 /    /\    \ |     \     \ |    |\    \ |    |  /     /\    \  
|    |  |    ||     ,_____/||    | |    ||    | /     /  \    \ 
|    |  |____||     \--'\_|/|    | |    ||    ||     |    |    |
|    |   ____ |     /___/|  |    | |    ||    ||     |    |    |
|    |  |    ||     \____|\ |    | |    ||    ||\     \  /    /|
|\ ___\/    /||____ '     /||____|/____/||____|| \_____\/____/ |
| |   /____/ ||    /_____/ ||    /    | ||    | \ |    ||    | /
 \|___|    | /|____|     | /|____|____|/ |____|  \|____||____|/ 
   \( |____|/   \( |_____|/   \(    )/     \(       \(    )/    
    '   )/       '    )/       '    '       '        '    '     
        '             '", ConsoleColor.Blue);
    InputHelper.Continuar();

    if (!OperatingSystem.IsWindows())
    {
      StyleConsole.Error("No se podran reproducir los sonidos en este sistema operativo.");
    }

    IdeaData.Load();
    AnimationHelper.LoadingAnimation("Cargando");

    ScreenMain.Screen();
  }
}