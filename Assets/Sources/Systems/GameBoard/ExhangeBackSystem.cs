using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ExhangeBackSystem : ReactiveSystem<GameEntity>
{
    public ExhangeBackSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Eliminate);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasExchange 
            && entity.hasEliminate 
            && !entity.eliminate.canEliminate
            && entity.exchange.exchangeState == ExchangeState.MOVING;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity gameEntity in entities)
        {
            gameEntity.ReplaceExchange(ExchangeState.END);
        }
    }
}
