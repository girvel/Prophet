using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer
{
    public interface IUiElement
    {
        Vector2 Position { get; set; }
        
        ColoredCharacter[,] GetCurrentView();
    }
}