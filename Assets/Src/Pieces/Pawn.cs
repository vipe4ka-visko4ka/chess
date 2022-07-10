using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
  public override List<Vector2Int> GetMoves()
  {
    List<Vector2Int> moves = new List<Vector2Int>();
    int direction = Team == Team.White ? 1 : -1;
    moves.Add(new Vector2Int(position.x, position.y + direction));
    return moves; 
  }
}
