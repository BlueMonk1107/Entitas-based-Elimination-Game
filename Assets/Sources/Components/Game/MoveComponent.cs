using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class MoveComponent : IComponent {

    [EntityIndex]
    public IntVector2 target;
}
