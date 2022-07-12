using UnityEngine;

public class Board : MonoBehaviour
{
[SerializeField]
    private GameObject squarePrefab;

    private void Start()
    {
        CreateBoardUI();
    }

    private void CreateBoardUI()
    {
        for (int row = 0; row < 8; row++) {
            for (int coll = 0; coll < 8; coll++) {
                GameObject square = Instantiate(squarePrefab, new Vector3(row, 0, coll), Quaternion.identity, transform);
                square.GetComponentInChildren<Renderer>().material.color = row % 2 == coll % 2 ? Color.black : Color.white;
            }
        }
    }
}
