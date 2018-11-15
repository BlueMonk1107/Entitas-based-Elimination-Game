using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique]
public sealed class SlideComponent : IComponent
{
    public IntVector2 clickPos;
    public SlideDirection direction;
}
