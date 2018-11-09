using System.Linq;
using DG.Tweening;
using UnityEngine;

public class GameBoardElementView : View
{

    public SpriteRenderer sprite;
    public float destroyDuration;

    public override void OnPosition(GameEntity entity, IntVector2 value)
    {
        IntVector2 target = value;
        value = ValidTop(value);

        var isTopRow = value.y == Contexts.sharedInstance.game.gameBoard.rows - 1;
        if (isTopRow)
        {
            transform.localPosition = new Vector3(value.x, value.y + 1);
        }

        transform.DOLocalMove(new Vector3(target.x, target.y, 0f), 0.3f);
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
}
