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

  public void Select()
  {
    GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
  }

  public void Deselect()
  {
    SetColorBaseOnTeam();
  }

  public abstract List<Vector2Int> GetMoves();

  private void SetColorBaseOnTeam()
  {
    Color pieceColor = _team == Team.White ? Color.white : Color.black;
    GetComponentInChildren<MeshRenderer>().material.color = pieceColor;
  }
}
