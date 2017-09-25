using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer.Interface
{
    public interface IPositionedUiElement : IUiElement
    {
        Vector2 Position { get; set; }
    }
}