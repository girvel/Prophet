using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer
{
    public interface IPositionedUiElement : IUiElement
    {
        Vector2 Position { get; set; }
    }
}