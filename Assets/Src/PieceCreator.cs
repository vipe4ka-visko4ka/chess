using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PieceCreator
{
    private Dictionary<string, GameObject> _piecesPrefabsDictionary = new Dictionary<string, GameObject>();

    public PieceCreator()
    {
        GetPiecesPrefabs();
    }

    public Piece CreatePiece(PieceType pieceType, Team team, Vector2Int position)
    {
        GameObject piecePrefab = _piecesPrefabsDictionary[pieceType.ToString()];
        Piece piece = GameObject.Instantiate(piecePrefab, new Vector3(position.x, 0, position.y), Quaternion.identity).GetComponent<Piece>();
        piece.Team = team;
        return piece;
    }

    private void GetPiecesPrefabs()
    {
        string [] piecesPrefabsGuids = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/Pieces" });;
        foreach (string guid in piecesPrefabsGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject piecePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            _piecesPrefabsDictionary.Add(piecePrefab.name, piecePrefab);
        }
    }
}
