using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class EliminateSameColorSystem : ReactiveSystem<GameEntity>
{
    public EliminateSameColorSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasEffectState && entity.effectState.itemEffctName == ItemEffctName.ELIMINATE_SAME_COLOR;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        string name = "";
        GameEntity tempEntity;

        foreach (GameEntity entity in entities)
        {
            name = entity.loadPrefab.name;
            for (int x = 0; x < Contexts.sharedInstance.game.gameBoard.columns; x++)
            {
                for (int y = 0; y < Contexts.sharedInstance.game.gameBoard.rows; y++)
                {
                    try
                    {
                        tempEntity = Contexts.sharedInstance.game.GetEntitiesWithMove(new IntVector2(x, y))
                            .FirstOrDefault(u => u.loadPrefab.name == name);
                        if (tempEntity != null)
                        {
                            Debug.Log(tempEntity.loadPrefab.name+"  "+ name);
                            tempEntity.isDestroyed = true;
                        }
                            
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }
        }
    }
}
