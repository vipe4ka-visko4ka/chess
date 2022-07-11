using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    private SquareSelector _squareSelector;
    private MoveSelector _moveSelector;
    private List<Piece> _pieces = new List<Piece>();
    private Piece _selectedPiece;

    private void Awake()
    {
        _squareSelector = GetComponent<SquareSelector>();
        _moveSelector = GetComponent<MoveSelector>();
    }

    private void Start()
    {
        MakePieces();
    }

    private void Update()
    {
        HandleInput();
    }


    private void MakePieces()
    {
        PieceCreator pieceCreator = new PieceCreator();

        for (int i = 0; i < 8; i++)
            _pieces.Add(pieceCreator.CreatePiece(PieceType.Pawn, Team.White, new Vector2Int(i, 1)));

        for (int i = 0; i < 8; i++)
            _pieces.Add(pieceCreator.CreatePiece(PieceType.Pawn, Team.Black, new Vector2Int(i, 6)));
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) && _squareSelector.selectedSquareIndex != null)
        {
            Piece piece = GetPiece(_squareSelector.selectedSquareIndex.Value);

            if (_selectedPiece != null)
            {
                _selectedPiece.Deselect();
                _moveSelector.HideAvailableMoves();
            }

            if (piece != null)
            {
                piece.Select();
                _selectedPiece = piece;
                _moveSelector.ShowAvailableMoves(piece.GetMoves());
            }
        }

    }

    private Piece GetPiece(Vector2Int squareIndex)
    {
        return _pieces.Find(piece => piece.position == squareIndex);
    }
}
