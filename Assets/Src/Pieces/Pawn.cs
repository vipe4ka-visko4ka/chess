using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
  public override List<Vector2Int> GetMoves()
  {
    List<Vector2Int> moves = new List<Vector2Int>();
    moves.Add(new Vector2Int(position.x, position.y + 1));
    return moves;
  }
}
