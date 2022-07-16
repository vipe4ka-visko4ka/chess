using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PieceFactory
{
    private readonly Dictionary<string, GameObject> _piecesPrefabs = new Dictionary<string, GameObject>();
    private readonly GameObject parent = new GameObject("Pieces");

    public PieceFactory()
    {
        GetPiecesPrefabs();
    }

    public Piece CreatePiece(PieceInfo pieceInfo)
    {
        GameObject piecePrefab = _piecesPrefabs[pieceInfo.PieceType.ToString()];
        Piece piece = GameObject
            .Instantiate(piecePrefab, new Vector3(pieceInfo.Position.x, 0, pieceInfo.Position.y), Quaternion.identity, parent.transform)
            .GetComponent<Piece>();
        piece.Team = pieceInfo.Team;
        return piece;
    }

    private void GetPiecesPrefabs()
    {
        string [] piecesPrefabsGuids = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/Pieces" });;
        foreach (string guid in piecesPrefabsGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject piecePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            _piecesPrefabs.Add(piecePrefab.name, piecePrefab);
        }
    }
}
