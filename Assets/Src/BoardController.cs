using UnityEngine;

public class BoardController : MonoBehaviour
{
    private Piece _selectedPiece;
    private SquareSelector _squareSelector;
    private Board _board;

    private void Awake()
    {
        _squareSelector = GetComponent<SquareSelector>();
        _board = GetComponent<Board>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _squareSelector.SelectedSquarePosition.HasValue)
        {
            Piece piece = _board.GetPiece(_squareSelector.SelectedSquarePosition.Value);
            SelectPiece(piece);
        }
    }

    private void SelectPiece(Piece piece)
    {
        if (_selectedPiece != null)
        {
            _selectedPiece.Deselect();
        }

        piece.Select();
        _selectedPiece = piece;
    }
}
