using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
  private Team _team;
  public Team Team {
    get => _team;
    set
    {
      _team = value;
      SetColorBaseOnTeam();
    }
  }
  public Vector2Int position { 
    get
    {
      return new Vector2Int((int)transform.position.x, (int)transform.position.z);
    }
  }

  public abstract List<Vector2Int> GetMoves();

  public bool IsCanMove(Vector2Int position)
  {
    List<Vector2Int> availableMoves = GetMoves();
    return availableMoves.Contains(position);
  }

  public void Move(Vector2Int position)
  {
    transform.position = new Vector3(position.x, 0, position.y);
  }

  public void Select()
  {
    SetColor(Color.yellow);
  }

  public void Deselect()
  {
    SetColorBaseOnTeam();
  }

  private void SetColorBaseOnTeam()
  {
    Color color = _team == Team.White ? Color.white : Color.black;
    SetColor(color);
  }

  private void SetColor(Color color)
  {
    GetComponentInChildren<MeshRenderer>().material.color = color;
  }
}
