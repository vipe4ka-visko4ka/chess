using UnityEngine;
using Shared.Model;

public class PieceCreationMenu : MonoBehaviour
{
    public PieceType? selectedPieceType { get; private set; }
    public Team? selectedTeam { get; private set; }

    public void Select(Team team)
    {
        selectedTeam = Team.White;
    }

    // public void SelectBlackTeam()
    // {
    //     selectedTeam = Team.Black;
    // }

    // public void SelectPawn()
    // {
    //     selectedPieceType = PieceType.Pawn;
    // }

    // public void SelectRook()
    // {
    //     selectedPieceType = PieceType.Rook;
    // }

    // public void SelectKnight()
    // {
    //     selectedPieceType = PieceType.Knight;
    // }
    // public void SelectQueen()
    // {
    //     selectedPieceType = PieceType.Queen;
    // }
    // public void SelectKing()
    // {
    //     selectedPieceType = PieceType.King;
    // }
    // public void SelectBishop()
    // {
    //     selectedPieceType = PieceType.Bishop;
    // }

    public void Save()
    {
        // new LevelManager("default").SaveLevel();
    }
}
