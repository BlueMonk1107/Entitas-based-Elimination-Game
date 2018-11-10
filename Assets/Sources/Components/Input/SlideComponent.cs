using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique, Event(EventTarget.Any)]
public sealed class SlideComponent : IComponent
{
    public SlideDirection direction;
}
