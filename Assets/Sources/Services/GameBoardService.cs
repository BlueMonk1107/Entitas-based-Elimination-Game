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
        while (position.y >= 0 && (_contexts.game.GetEntitiesWithPosition(position).Count == 0 || !_contexts.game.GetEntitiesWithPosition(position).ToArray()[0].isMovable)) {
            position.y -= 1;
        }

        position.y += 1;
        while (position.y < _contexts.game.gameBoard.rows && _contexts.game.GetEntitiesWithPosition(position).Count != 0 && !_contexts.game.GetEntitiesWithPosition(position).ToArray()[0].isMovable)
        {
            position.y += 1;
        }
        return position.y;
    }
}
