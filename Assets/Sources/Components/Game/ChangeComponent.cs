using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class ChangeComponent : IComponent
{
    [EntityIndex]
    public IntVector2 firstPos;
    [EntityIndex]
    public IntVector2 secondPos;
}
