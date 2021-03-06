﻿using DG.Tweening;
using Entitas;
using UnityEngine;

public class GameBoardElementView : View, ILoadSpriteListener
{
    public SpriteRenderer sprite;
    public float destroyDuration;

    public override void Link(IEntity entity, IContext context)
    {
        base.Link(entity, context);
        _thisGameEntity.AddLoadSpriteListener(this);
        transform.position = new Vector3(_thisGameEntity.move.target.x, Contexts.sharedInstance.game.gameBoard.rows, 0);

    }

    public override void OnMove(GameEntity entity, IntVector2 target)
    {
        transform.DOLocalMove(new Vector3(target.x, target.y, 0f), 2f).OnComplete(() =>
        {
            _thisGameEntity.isMoveComplete = true;
        });
    }

    protected override void Destroy()
    {
        destroyDuration = 2;
        var color = sprite.color;
        color.a = 0f;
        sprite.material.DOColor(color, destroyDuration);
        gameObject.transform
            .DOScale(Vector3.one * 1.5f, destroyDuration)
            .OnComplete(base.Destroy);
    }

    public void OnLoadSprite(GameEntity entity, string path)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }
    
}
