using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject _squarePrefab;
    private PieceFactory _pieceFactory;
    private Piece[,] _grid = new Piece[8, 8];

    public Piece GetPiece(Vector2Int position)
    {
        return _grid[position.x, position.y];
    }

    private void Awake()
    {
        _pieceFactory = new PieceFactory();
    }

    private void Start()
    {
        CreateBoardUI();
        CreatePieces(BoardLayout.StandardLayout);
    }

    private void CreateBoardUI()
    {
        for (int row = 0; row < 8; row++) {
            for (int coll = 0; coll < 8; coll++) {
                GameObject square = Instantiate(_squarePrefab, new Vector3(row, 0, coll), Quaternion.identity, transform);
                square.GetComponentInChildren<Renderer>().material.color = row % 2 == coll % 2 ? Color.black : Color.white;
            }
        }
    }

    private void CreatePieces(BoardLayout boardLayout)
    {
        foreach (PieceInfo pieceInfo in boardLayout.PiecesInfos)
        {
            _grid[pieceInfo.Position.x, pieceInfo.Position.y] = _pieceFactory.CreatePiece(pieceInfo);
        }
    }
}
