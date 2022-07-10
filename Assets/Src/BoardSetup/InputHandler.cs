using UnityEngine;
using Shared;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private PieceCreator _pieceCreator; 
    [SerializeField]
    private PieceCreationMenu _pieceCreationMenu; 
    [SerializeField]
    private SquareSelector _squareSelector; 

    private void Update()
    {
        if (
            Input.GetMouseButtonDown(0) &&
            _squareSelector.selectedSquareIndex != null &&
            _pieceCreationMenu.selectedPieceType != null &&
            _pieceCreationMenu.selectedTeam != null
        )
        {
            _pieceCreator.InitializePiece(
                _pieceCreationMenu.selectedPieceType.Value,
                _pieceCreationMenu.selectedTeam.Value, 
                _squareSelector.selectedSquareIndex.Value
            );
        }
    }
}
