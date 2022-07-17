using System.Collections.Generic;
using UnityEngine;

public class MoveSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject _selectorPrefab;
    private GameObject _parent;
    private List<GameObject> _selectedMoves = new List<GameObject>();

    private void Awake()
    {
        _parent = new GameObject("Moves");
    }

    public void SelectMoves(List<Vector2Int> moves)
    {
        foreach (Vector2Int move in moves)
        {
            GameObject selectedMove = Instantiate(_selectorPrefab, new Vector3(move.x, 0, move.y), Quaternion.identity, _parent.transform);
            _selectedMoves.Add(selectedMove);
        }
    }

    public void DeselectMoves()
    {
        foreach (GameObject move in _selectedMoves)
            Destroy(move);
        _selectedMoves.Clear();
    }
}
