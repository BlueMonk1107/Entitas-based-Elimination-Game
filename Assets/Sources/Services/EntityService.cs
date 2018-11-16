public class EntityService {

    public RandomService randomService = RandomService.game;

    public static EntityService singleton = new EntityService();

    static readonly string[] _items = {
        Res.RED_NAME,
        Res.GREEN_NAME,
        Res.BLUE_NAME,
        Res.YELLOW_NAME,
        Res.PURPLE_NAME,
        Res.CYAN_NAME
    };

    Contexts _contexts;

    public void Initialize(Contexts contexts) {
        _contexts = contexts;
    }

    public GameEntity CreateGameBoard() {
        var entity = _contexts.game.CreateEntity();
        entity.AddGameBoard(8, 9);
        return entity;
    }

    public GameEntity CreateRandomPiece(int x, int y) {
        var entity = _contexts.game.CreateEntity();
        entity.isGameBoardElement = true;
        entity.isMovable = true;
        entity.isInteractive = true;
        entity.AddMove(new IntVector2(x, y));
        entity.AddEffectState(ItemEffctName.NONE);
        entity.AddLoadPrefab(randomService.Element(_items));
        return entity;
    }

    public GameEntity CreateBlocker(int x, int y) {
        var entity = _contexts.game.CreateEntity();
        entity.isGameBoardElement = true;
        entity.AddMove(new IntVector2(x, y));
        entity.AddLoadPrefab(Res.OBSTACLE_NAME);
        return entity;
    }
}
