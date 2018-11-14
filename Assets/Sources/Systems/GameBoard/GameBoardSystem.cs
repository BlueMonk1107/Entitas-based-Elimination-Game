using System.Collections.Generic;
using Entitas;

public sealed class GameBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem {

    public EntityService entityService = EntityService.singleton;
    public RandomService randomService = RandomService.game;

    readonly IGroup<GameEntity> _gameBoardElements;

    public GameBoardSystem(Contexts contexts) : base(contexts.game) {
        _gameBoardElements = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.GameBoardElement, GameMatcher.Move));
    }

    public void Initialize() {
        //初始化游戏面板数据
        var gameBoard = entityService.CreateGameBoard().gameBoard;
        //根据策略 选择生成障碍 还是 元素
        GameEntity temp = null;
        for (int row = 0; row < gameBoard.rows; row++) {
            for (int column = 0; column < gameBoard.columns; column++) {
                if (randomService.Bool(0.1f)) {
                    temp = entityService.CreateBlocker(column, row);
                } else {
                    temp = entityService.CreateRandomPiece(column, row);
                }
                temp.ReplaceMove(temp.move.target);
            }
        }
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoard);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasGameBoard;
    }

    protected override void Execute(List<GameEntity> entities) {
        var gameBoard = entities.SingleEntity().gameBoard;
        foreach (var e in _gameBoardElements) {
            if (e.move.target.x >= gameBoard.columns || e.move.target.y >= gameBoard.rows) {
                e.isDestroyed = true;
            }
        }
    }
}
