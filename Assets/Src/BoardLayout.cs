using System.Collections.Generic;
using UnityEngine;

public class PieceInfo
{
    public readonly Vector2Int Position;
    public readonly PieceType PieceType;
    public readonly Team Team;

    public PieceInfo(Vector2Int position, PieceType pieceType, Team team)
    {
        Position = position;
        PieceType = pieceType;
        Team = team;
    }
}

public class BoardLayout
{
    public readonly List<PieceInfo> PiecesInfos;

    public BoardLayout(List<PieceInfo> boardSquares)
    {
        PiecesInfos = boardSquares;
    }

    public static readonly BoardLayout StandardLayout = new BoardLayout(
        new List<PieceInfo>() { 
            // White team
            new PieceInfo(new Vector2Int(0, 0), PieceType.Rook, Team.White),
            new PieceInfo(new Vector2Int(1, 0), PieceType.Knight, Team.White),
            new PieceInfo(new Vector2Int(2, 0), PieceType.Bishop, Team.White),
            new PieceInfo(new Vector2Int(3, 0), PieceType.Queen, Team.White),
            new PieceInfo(new Vector2Int(4, 0), PieceType.King, Team.White),
            new PieceInfo(new Vector2Int(5, 0), PieceType.Bishop, Team.White),
            new PieceInfo(new Vector2Int(6, 0), PieceType.Knight, Team.White),
            new PieceInfo(new Vector2Int(7, 0), PieceType.Rook, Team.White),
            new PieceInfo(new Vector2Int(0, 1), PieceType.Pawn, Team.White),
            new PieceInfo(new Vector2Int(1, 1), PieceType.Pawn, Team.White),
            new PieceInfo(new Vector2Int(2, 1), PieceType.Pawn, Team.White),
            new PieceInfo(new Vector2Int(3, 1), PieceType.Pawn, Team.White),
            new PieceInfo(new Vector2Int(4, 1), PieceType.Pawn, Team.White),
            new PieceInfo(new Vector2Int(5, 1), PieceType.Pawn, Team.White),
            new PieceInfo(new Vector2Int(6, 1), PieceType.Pawn, Team.White),
            new PieceInfo(new Vector2Int(7, 1), PieceType.Pawn, Team.White),

            // Black team
            new PieceInfo(new Vector2Int(0, 7), PieceType.Rook, Team.Black),
            new PieceInfo(new Vector2Int(1, 7), PieceType.Knight, Team.Black),
            new PieceInfo(new Vector2Int(2, 7), PieceType.Bishop, Team.Black),
            new PieceInfo(new Vector2Int(3, 7), PieceType.Queen, Team.Black),
            new PieceInfo(new Vector2Int(4, 7), PieceType.King, Team.Black),
            new PieceInfo(new Vector2Int(5, 7), PieceType.Bishop, Team.Black),
            new PieceInfo(new Vector2Int(6, 7), PieceType.Knight, Team.Black),
            new PieceInfo(new Vector2Int(7, 7), PieceType.Rook, Team.Black),
            new PieceInfo(new Vector2Int(0, 6), PieceType.Pawn, Team.Black),
            new PieceInfo(new Vector2Int(1, 6), PieceType.Pawn, Team.Black),
            new PieceInfo(new Vector2Int(2, 6), PieceType.Pawn, Team.Black),
            new PieceInfo(new Vector2Int(3, 6), PieceType.Pawn, Team.Black),
            new PieceInfo(new Vector2Int(4, 6), PieceType.Pawn, Team.Black),
            new PieceInfo(new Vector2Int(5, 6), PieceType.Pawn, Team.Black),
            new PieceInfo(new Vector2Int(6, 6), PieceType.Pawn, Team.Black),
            new PieceInfo(new Vector2Int(7, 6), PieceType.Pawn, Team.Black),
        }
    );
}
