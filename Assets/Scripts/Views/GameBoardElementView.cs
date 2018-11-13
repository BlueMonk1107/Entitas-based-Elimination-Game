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
        _lastPos = IntVector2.DefaultValue();
        _changeState = ChangeState.NONE;
        transform.position = new Vector3(_thisGameEntity.position.value.x, Contexts.sharedInstance.game.gameBoard.rows,0);
    }

    public override void OnPosition(GameEntity entity, IntVector2 value)
    {
        IntVector2 target = value;
    
        transform.DOLocalMove(new Vector3(target.x, target.y, 0f), 0.3f).OnComplete(() =>
        {
            _thisGameEntity.ReplaceDetectionSameItem(JudgeSameColor());
            _thisGameEntity.ReplaceEliminate(_thisGameEntity.detectionSameItem.sameEntities.Count > 2);

            if (_changeState == ChangeState.START)
            {
                var e = Contexts.sharedInstance.game.GetEntitiesWithPosition(_lastPos).Single();
                _changeTimes++;
                if (_changeTimes == 2)
                {
                    _changeTimes = 0;

                    if (!_thisGameEntity.eliminate.canEliminate && !e.eliminate.canEliminate)
                    {
                        e.ReplacePosition(_thisGameEntity.position.value);
                        _thisGameEntity.ReplacePosition(_lastPos);
                        _lastPos = IntVector2.DefaultValue();
                    }
                    else
                    {
                        _lastPos = IntVector2.DefaultValue();
                    }
                }
                _changeState = ChangeState.END;
            }
            
            if (_thisGameEntity.eliminate.canEliminate)
            {
                Eliminate(_thisGameEntity.detectionSameItem.sameEntities);
            }
        });


    }

    private void Eliminate(List<IEntity> sameEntities)
    {
        if (sameEntities != null && sameEntities.Count > 2)
        {
            GameEntity temp;
            foreach (IEntity e in sameEntities)
            {
                temp = e as GameEntity;
                if (temp != null) temp.isDestroyed = true;
            }
        }
    }

    //判断同颜色元素
    private List<IEntity> JudgeSameColor()
    {
        List<IEntity> sameColorItem = new List<IEntity>();
        sameColorItem.AddRange(JudgeHorizontal());
        sameColorItem.AddRange(JudgeVertical());
        sameColorItem.Add(_thisGameEntity);

        return sameColorItem;
    }

    //判断横向同颜色元素
    private List<GameEntity> JudgeHorizontal()
    {
        string colorName = _thisGameEntity.asset.value;
        IntVector2 thisPos = _thisGameEntity.position.value;
        List<GameEntity> sameColorItems = new List<GameEntity>();
        for (int i = thisPos.x -1; i >= 0; i--)
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
        for (int i = thisPos.y -1; i >= 0; i--)
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
