using Prophet.Core;

namespace Prophet.ConsoleVisualizer
{
    public interface IUiElement
    {
        ColoredCharacter[,] GetCurrentView();
    }
}