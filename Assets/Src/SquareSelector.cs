using UnityEngine;

public class SquareSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject _squareSelectorPrefab;
    private GameObject _squareSelectorModel;

    public Vector2Int? selectedSquareIndex => 
        _squareSelectorModel != null 
            ? new Vector2Int(
                (int)_squareSelectorModel.transform.position.x, 
                (int)_squareSelectorModel.transform.position.z
            )
            : (Vector2Int?)null;

    private void Update()
    {
        Vector3? mousePosition = GetMousePosition();

        if (mousePosition.HasValue && IsMousePositionOnBoard(mousePosition.Value))
        {
            if (_squareSelectorModel == null)
            {
                _squareSelectorModel = Instantiate(_squareSelectorPrefab, mousePosition.Value, Quaternion.identity);
            }
            else
            {
                _squareSelectorModel.transform.position = mousePosition.Value;
            }
        }
        else if (_squareSelectorModel != null)
        {
            Destroy(_squareSelectorModel);
        }
    }

    private Vector3? GetMousePosition() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit))
            return null;
        
        return new Vector3(Mathf.FloorToInt(hit.point.x), 0, Mathf.FloorToInt(hit.point.z));
    }

    private bool IsMousePositionOnBoard(Vector3 mousePosition)
    {
        return mousePosition.x >= 0 && mousePosition.z >= 0 && mousePosition.x < Constants.BOARD_SIZE && mousePosition.z < Constants.BOARD_SIZE;
    }
}
