using UnityEngine;

namespace  Shared.Model
{
    [System.Serializable]
    public class PieceInfo
    {
        public PieceType PieceType;
        public Team Team;
        public Vector2Int Position;

        public PieceInfo(PieceType pieceType, Team team, Vector2Int position)
        {
            PieceType = pieceType;
            Team = team;
            Position = position;
        }
    }
}
