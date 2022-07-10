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

  public void Move()
  {

  }

  public void Select()
  {
    GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
  }

  public void Deselect()
  {
    SetColorBaseOnTeam();
  }

  private void SetColorBaseOnTeam()
  {
    Color pieceColor = _team == Team.White ? Color.white : Color.black;
    GetComponentInChildren<MeshRenderer>().material.color = pieceColor;
  }
}
