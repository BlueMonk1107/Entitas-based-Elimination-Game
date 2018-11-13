using Entitas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 判断是否存在满足条件的相邻同色元素
/// </summary>
public class JudgeSameColorSystem : ReactiveSystem<GameEntity> {

    public JudgeSameColorSystem(Contexts context) : base(context.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity gameEntity in entities)
        {
            gameEntity.ReplaceDetectionSameItem(JudgeSameColor(gameEntity));
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
        IntVector2 thisPos = thisGameEntity.position.value;
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
        IntVector2 thisPos = thisGameEntity.position.value;
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
        var targetEntity = Contexts.sharedInstance.game.GetEntitiesWithPosition(new IntVector2(x, y)).Single();

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
}
