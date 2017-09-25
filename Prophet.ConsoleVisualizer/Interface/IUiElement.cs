using Prophet.Core;

namespace Prophet.ConsoleVisualizer.Interface
{
    public interface IUiElement
    {
        ColoredCharacter[,] GetCurrentView();
    }
}