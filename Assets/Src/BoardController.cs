using UnityEngine;

public class BoardController : MonoBehaviour
{
    private Piece _selectedPiece;
    private SquareSelector _squareSelector;
    private MoveSelector _moveSelector;
    private Board _board;
    private Team _currentTeam = Team.White;

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
            Vector2Int position = _squareSelector.SelectedSquarePosition.Value;
            Piece piece = _board.GetPiece(position);
            if (piece != null && !piece.IsOpposite(_currentTeam))
                SelectPiece(piece);
            if (_selectedPiece != null && piece == null && _selectedPiece.IsCanMove(position))
                MovePiece(position);
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
        _moveSelector.SelectMoves(piece.GetMoves());
        _selectedPiece = piece;
    }

    private void MovePiece(Vector2Int position)
    {
        _selectedPiece.Deselect();
        _moveSelector.DeselectMoves();
        _board.MovePiece(_selectedPiece, position);
        _selectedPiece = null;

        SwitchCurrentTeam();
    }

    private void SwitchCurrentTeam()
    {
        _currentTeam = _currentTeam == Team.White ? Team.Black : Team.White;
    }
}
