using System.Collections.Generic;
using UnityEngine;

public class MoveSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject _moveSelectorPrefab;
    private readonly List<GameObject> _availableMoves = new List<GameObject>();

    public void ShowAvailableMoves(List<Vector2Int> availableMoves)
    {
        foreach (Vector2Int availableMove in availableMoves)
        {
            GameObject move = Instantiate(_moveSelectorPrefab, new Vector3(availableMove.x, 0, availableMove.y), Quaternion.identity);
            _availableMoves.Add(move);
        }
    }

    public void HideAvailableMoves()
    {
        foreach (GameObject availableMove in _availableMoves)
            Destroy(availableMove);
        _availableMoves.Clear();
    }
}
