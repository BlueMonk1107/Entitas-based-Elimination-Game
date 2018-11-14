using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

/// <summary>
/// 元素的填充
/// </summary>
public sealed class FillSystem : ReactiveSystem<GameEntity>
{

    public EntityService entityService = EntityService.singleton;
    public GameBoardService gameBoardService = GameBoardService.singleton;

    readonly Contexts _contexts;

    public FillSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameBoardElement.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.isGameBoardElement;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //foreach (GameEntity gameEntity in entities)
        //{
        //    if(!gameEntity.hasPosition)
        //        continue;
        //    var rowPos = gameBoardService.GetNextEmptyRow(gameEntity.position.value);
        //    var temp = entityService.CreateRandomPiece(gameEntity.position.value.x, rowPos);
        //    temp.ReplaceMove(temp.position.value);
        //}

        var gameBoard = _contexts.game.gameBoard;
        for (int column = 0; column < gameBoard.columns; column++)
        {
            var position = new IntVector2(column, gameBoard.rows + 1);
            var rowPosMin = gameBoardService.GetNextEmptyRow(position);
            for (int i = rowPosMin; i < gameBoard.rows; i++)
            {
                entityService.CreateRandomPiece(column, i);
            }
        }
    }
}
