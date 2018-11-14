using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

/// <summary>
/// 负责元素的下落移动
/// </summary>
public sealed class FallSystem : ReactiveSystem<GameEntity> {

    public GameBoardService gameBoardService = GameBoardService.singleton;

    readonly Contexts _contexts;

    public FallSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return !entity.isGameBoardElement;
    }

    protected override void Execute(List<GameEntity> entities) {
        //每个元素检测自己是否能动
        //能动，就检测下一个元素的位置是否为空
        //为空就向下移动
        //只负责已有元素的移动，新生成元素的移动不在这里
        var gameBoard = _contexts.game.gameBoard;
        for (int column = 0; column < gameBoard.columns; column++)
        {
            for (int row = 1; row < gameBoard.rows; row++)
            {
                //isMovable标记物体是否可移动
                var position = new IntVector2(column, row);
                var movables = _contexts.game.GetEntitiesWithMove(position)
                    .Where(e => e.isMovable)
                    .ToArray();

                foreach (var e in movables)
                {
                    MoveDown(e, position);
                }
            }
        }
    }

    void MoveDown(GameEntity e, IntVector2 position) {
        var nextRowPos = gameBoardService.GetNextEmptyRow(position);
        if (nextRowPos != position.y) {
            e.ReplaceMove(new IntVector2(position.x, nextRowPos));
        }
    }
}
