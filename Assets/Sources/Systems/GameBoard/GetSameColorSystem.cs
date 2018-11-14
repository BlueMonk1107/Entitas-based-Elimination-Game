using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

/// <summary>
/// 获取相邻的同色元素
/// </summary>
public class GetSameColorSystem : ReactiveSystem<GameEntity>
{
    public GetSameColorSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GetSameColor);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGetSameColor;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity gameEntity in entities)
        {
            gameEntity.ReplaceDetectionSameItem(JudgeSameColor(gameEntity));
            gameEntity.isGetSameColor = false;
        }
    }

    //判断同颜色元素
    private List<IEntity> JudgeSameColor(GameEntity thisGameEntity)
    {
        List<IEntity> sameColorItem = new List<IEntity>();
        sameColorItem.AddRange(JudgeHorizontal(thisGameEntity));
        sameColorItem.AddRange(JudgeVertical(thisGameEntity));
        sameColorItem.Add(thisGameEntity);

        return sameColorItem;
    }

    //判断横向同颜色元素
    private List<GameEntity> JudgeHorizontal(GameEntity thisGameEntity)
    {
        string colorName = thisGameEntity.asset.value;
        IntVector2 thisPos = thisGameEntity.move.target;
        List<GameEntity> sameColorItems = new List<GameEntity>();
        for (int i = thisPos.x - 1; i >= 0; i--)
        {
            if (!AddSameColorItem(sameColorItems, i, thisPos.y, colorName))
                break;
        }

        for (int i = thisPos.x + 1; i < Contexts.sharedInstance.game.gameBoard.columns; i++)
        {
            if (!AddSameColorItem(sameColorItems, i, thisPos.y, colorName))
                break;
        }

        return sameColorItems;
    }

    //判断纵向同颜色元素
    private List<GameEntity> JudgeVertical(GameEntity thisGameEntity)
    {
        string colorName = thisGameEntity.asset.value;
        IntVector2 thisPos = thisGameEntity.move.target;
        List<GameEntity> sameColorItems = new List<GameEntity>();
        for (int i = thisPos.y - 1; i >= 0; i--)
        {
            if (!AddSameColorItem(sameColorItems, thisPos.x, i, colorName))
                break;
        }

        for (int i = thisPos.y + 1; i < Contexts.sharedInstance.game.gameBoard.rows; i++)
        {
            if (!AddSameColorItem(sameColorItems, thisPos.x, i, colorName))
                break;
        }

        return sameColorItems;
    }

    //添加同颜色相邻元素
    private bool AddSameColorItem(List<GameEntity> sameColorItems, int x, int y, string colorName)
    {
        var array = Contexts.sharedInstance.game.GetEntitiesWithMove(new IntVector2(x, y));
        if (array.Count == 1)
        {
            var targetEntity = array.Single();

            if (!targetEntity.isMovable)
                return false;

            if (targetEntity.asset.value == colorName)
            {
                sameColorItems.Add(targetEntity);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Contexts.sharedInstance.game.CreateEntity().ReplaceDebugMsg("坐标 x"+x+" y"+y+" 元素数目错误,数目为："+ array.Count);
            return false;
        }

    }
}
