using System.Linq;
using UnityEngine;

public class GameBoardService {

    public static GameBoardService singleton = new GameBoardService();

    Contexts _contexts;

    public void Initialize(Contexts contexts) {
        _contexts = contexts;
    }

    public int GetNextEmptyRow(IntVector2 position) {
        position.y -= 1;
        var entities = _contexts.game.GetEntitiesWithPosition(position).ToArray();
        while (position.y >= 0 && (entities.Length == 0 || !entities[0].isMovable)) {
            position.y -= 1;
            entities = _contexts.game.GetEntitiesWithPosition(position).ToArray();
        }

        position.y += 1;
        entities = _contexts.game.GetEntitiesWithPosition(position).ToArray();
        while (position.y < _contexts.game.gameBoard.rows && entities.Length != 0 && !entities[0].isMovable)
        {
            position.y += 1;
            entities = _contexts.game.GetEntitiesWithPosition(position).ToArray();
        }
        return position.y;
    }
}
