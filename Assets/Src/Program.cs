using UnityEngine;

public class Program : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;
    private readonly int BOARD_SIZE = 8;

    private void Start()
    {
        MakeBoardUI();
    }

    private void MakeBoardUI()
    {
        GameObject squareParent = new GameObject("Squares");
        for (int row = 0; row < BOARD_SIZE; row++) {
            for (int coll = 0; coll < BOARD_SIZE; coll++) {
                GameObject square = Instantiate(squarePrefab, new Vector3(row, 0, coll), Quaternion.identity, squareParent.transform);
                square.GetComponentInChildren<Renderer>().material.color = row % 2 == coll % 2 ? Color.black : Color.white;
            }
        }
    }
}
