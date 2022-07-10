using UnityEngine;

namespace Shared
{
    public class SquareSelector : MonoBehaviour
    {
        [SerializeField]
        private GameObject _squareSelectorPrefab;
        private GameObject _squareSelectorObject;

        public Vector2Int? selectedSquareIndex => 
            _squareSelectorObject != null 
                ? new Vector2Int(
                    (int)_squareSelectorObject.transform.position.x,
                    (int)_squareSelectorObject.transform.position.z
                )
                : (Vector2Int?)null;

        private void Update()
        {
            Vector3? mousePosition = GetMousePosition();

            if (mousePosition.HasValue && IsMousePositionOnBoard(mousePosition.Value))
            {
                if (_squareSelectorObject == null)
                {
                    _squareSelectorObject = Instantiate(_squareSelectorPrefab, mousePosition.Value, Quaternion.identity);
                }
                else
                {
                    _squareSelectorObject.transform.position = mousePosition.Value;
                }
            }
            else if (_squareSelectorObject != null)
            {
                Destroy(_squareSelectorObject);
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
            return mousePosition.x >= 0 && mousePosition.z >= 0 && mousePosition.x < 8 && mousePosition.z < 8;
        }
    }
}