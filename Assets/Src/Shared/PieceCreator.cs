using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Shared.Model;

namespace Shared
{
    public class PieceCreator : MonoBehaviour
    {
        private Dictionary<string, GameObject> _piecesPrefabsDictionary = new Dictionary<string, GameObject>();

        private void Awake()
        {
            GetPiecesPrefabs();
        }

        public void InitializePiece(PieceType pieceType, Team team, Vector2Int position)
        {
            GameObject piecePrefab = _piecesPrefabsDictionary[pieceType.ToString()];
            GameObject pieceObject = Instantiate(piecePrefab, new Vector3(position.x, 0, position.y), Quaternion.identity);
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
