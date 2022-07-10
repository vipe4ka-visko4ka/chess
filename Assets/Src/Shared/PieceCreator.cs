using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Shared.Model;

namespace Shared
{
    public class PieceCreator
    {
        private Dictionary<string, GameObject> _piecesPrefabsDictionary = new Dictionary<string, GameObject>();
        private List<PieceInfo> pieces = new List<PieceInfo>();

        public PieceCreator()
        {
            GetPiecesPrefabs();
        }

        public void InitializePiece(PieceType pieceType, Team team, Vector2Int position)
        {
            GameObject piecePrefab = _piecesPrefabsDictionary[pieceType.ToString()];
            GameObject pieceObject = GameObject.Instantiate(piecePrefab, new Vector3(position.x, 0, position.y), Quaternion.identity);
            pieces.Add(new PieceInfo(pieceType, team, position));
        }

        private void GetPiecesPrefabs()
        {
            string [] piecesPrefabsGuids = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefabs/Piece" });;
            foreach (string guid in piecesPrefabsGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                GameObject piecePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                _piecesPrefabsDictionary.Add(piecePrefab.name, piecePrefab);
            }
        }
    }
}
