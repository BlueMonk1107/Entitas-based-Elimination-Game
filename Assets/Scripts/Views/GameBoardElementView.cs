using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class GameBoardElementView : View, IChangeListener, ISlideListener
{
    public SpriteRenderer sprite;
    public float destroyDuration;
    private IntVector2 _lastPos;
    private static int _changeTimes;
    private ChangeState _changeState;

    public override void Link(IEntity entity, IContext context)
    {
        base.Link(entity, context);
        _thisGameEntity.AddChangeListener(this);
        _lastPos = new IntVector2(-1, -1);
        _changeState = ChangeState.NONE;
    }

    public override void OnPosition(GameEntity entity, IntVector2 value)
    {
        IntVector2 target = value;
        value = ValidTop(value);

        //var isTopRow = value.y == Contexts.sharedInstance.game.gameBoard.rows - 1;
        //if (isTopRow)
        //{
        //    transform.localPosition = new Vector3(value.x, value.y + 1);
        //}

        transform.DOLocalMove(new Vector3(target.x, target.y, 0f), 0.3f).OnComplete(() =>
        {
            bool hasSameColor = JudgeSameColor();
            if (_changeState == ChangeState.START)
            {
                _changeTimes++;
                if (_changeTimes == 2)
                {
                    _changeTimes = 0;
                    
                    if (!hasSameColor && _lastPos.x >= 0 && _lastPos.y >= 0)
                    {
                        var e = Contexts.sharedInstance.game.GetEntitiesWithPosition(_lastPos).Single();
                        e.ReplacePosition(_thisGameEntity.position.value);
                        _thisGameEntity.ReplacePosition(_lastPos);
                        _lastPos = new IntVector2(-1, -1);
                    }
                    else
                    {
                        _lastPos = new IntVector2(-1, -1);
                    }
                }
                _changeState = ChangeState.END;
            }
        });

        
    }
    //判断同颜色元素
    private bool JudgeSameColor()
    {
        bool success = false;
        List<GameEntity> sameColorItemsHor = JudgeHorizontal();
        if (sameColorItemsHor.Count > 2)
        {
            foreach (GameEntity entity in sameColorItemsHor)
            {
                entity.isDestroyed = true;
            }
            success = true;
        }

        List<GameEntity> sameColorItemsVer = JudgeVertical();
        if (sameColorItemsVer.Count > 2)
        {
            foreach (GameEntity entity in sameColorItemsVer)
            {
                entity.isDestroyed = true;
            }
            success = true;
        }

        return success;
    }
    //判断横向同颜色元素
    private List<GameEntity> JudgeHorizontal()
    {
        string colorName = _thisGameEntity.asset.value;
        IntVector2 thisPos = _thisGameEntity.position.value;
        List<GameEntity> sameColorItems = new List<GameEntity>();
        for (int i = thisPos.x; i >= 0; i--)
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
    private List<GameEntity> JudgeVertical()
    {
        string colorName = _thisGameEntity.asset.value;
        IntVector2 thisPos = _thisGameEntity.position.value;
        List<GameEntity> sameColorItems = new List<GameEntity>();
        for (int i = thisPos.y; i >= 0; i--)
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

    //计算有效的顶点元素坐标
    private IntVector2 ValidTop(IntVector2 value)
    {
        value = new IntVector2(value.x, value.y + 1);
        var entities = Contexts.sharedInstance.game.GetEntitiesWithPosition(value).ToArray();
        while (value.y < Contexts.sharedInstance.game.gameBoard.rows && entities.Length != 0 && !entities[0].isMovable)
        {
            value = new IntVector2(value.x, value.y + 1);
            entities = Contexts.sharedInstance.game.GetEntitiesWithPosition(value).ToArray();
        }
        return new IntVector2(value.x, value.y - 1);
    }

    protected override void Destroy()
    {
        var color = sprite.color;
        color.a = 0f;
        sprite.material.DOColor(color, destroyDuration);
        gameObject.transform
            .DOScale(Vector3.one * 1.5f, destroyDuration)
            .OnComplete(base.Destroy);
    }

    public void OnSlide(InputEntity entity, SlideDirection direction)
    {
        throw new NotImplementedException();
    }

    public void OnChange(GameEntity entity, IntVector2 firstPos, IntVector2 secondPos)
    {
        if (_thisGameEntity != null)
        {
            _changeState = ChangeState.START;
            _lastPos = _thisGameEntity.position.value;
            _thisGameEntity.ReplacePosition(_thisGameEntity.position.value.Equals(firstPos) ? secondPos : firstPos);
        }
    }
}
