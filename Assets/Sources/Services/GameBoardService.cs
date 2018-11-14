using System.Linq;
using Entitas;
using UnityEngine;

public class GameBoardService
{

    public static GameBoardService singleton = new GameBoardService();

    Contexts _contexts;

    public void Initialize(Contexts contexts)
    {
        _contexts = contexts;
    }

    public int GetNextEmptyRow(IntVector2 position)
    {
        int row = position.y;
        for (int i = position.y - 1; i >= 0; i--)
        {
            var entities = _contexts.game.GetEntitiesWithMove(new IntVector2(position.x,i)).ToArray();

            if (entities.Length == 0)
            {
                row = i;
            }
            else
            {
                if (!entities[0].isMovable)
                {
                    continue;
                }
                break;
            }
        }

        return row;
    }
}
