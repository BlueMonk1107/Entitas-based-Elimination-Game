using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class ExchangeComponent : IComponent
{
    public ExchangeState exchangeState;
}
