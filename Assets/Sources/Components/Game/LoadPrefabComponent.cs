using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Any)]
public sealed class LoadPrefabComponent : IComponent {
    public string path;
}
