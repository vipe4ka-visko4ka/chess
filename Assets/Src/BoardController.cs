using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private Piece _selectedPiece;
    private SquareSelector _squareSelector;
    private MoveSelector _moveSelector;
    private Board _board;

    private void Awake()
    {
        _squareSelector = GetComponent<SquareSelector>();
        _moveSelector = GetComponent<MoveSelector>();
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
            _moveSelector.DeselectMoves();
        }

        piece.Select();
        _moveSelector.SelectMoves(new List<Vector2Int>(){ new Vector2Int(piece.position.x, piece.position.y + 1) });
        _selectedPiece = piece;
    }
}
