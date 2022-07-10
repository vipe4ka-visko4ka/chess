using UnityEngine;

namespace Shared
{
    public class BoardCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject squarePrefab;

        private void Start()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            GameObject squareParent = new GameObject("Squares");
            for (int row = 0; row < 8; row++) {
                for (int coll = 0; coll < 8; coll++) {
                    GameObject square = Instantiate(squarePrefab, new Vector3(row, 0, coll), Quaternion.identity, squareParent.transform);
                    square.GetComponentInChildren<Renderer>().material.color = row % 2 == coll % 2 ? Color.black : Color.white;
                }
            }
        }
    }
}