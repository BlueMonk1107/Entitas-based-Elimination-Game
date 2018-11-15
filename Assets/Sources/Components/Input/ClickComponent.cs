using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique]
public sealed class ClickComponent : IComponent
{
    public int x;
    public int y;
}
