using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab;
    [SerializeField]
    private Color blackSquareColor;
    [SerializeField]
    private Color whiteSquareColor;

    private readonly int BOARD_SIZE = 8;

    private void Start()
    {
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        GameObject squareParent = new GameObject("Squares");
        for (int row = 0; row < BOARD_SIZE; row++) {
            for (int coll = 0; coll < BOARD_SIZE; coll++) {
                GameObject square = Instantiate(squarePrefab, new Vector3(row + 0.5f, 0, coll + 0.5f), Quaternion.identity, squareParent.transform);
                square.GetComponent<Renderer>().material.color = row % 2 == coll % 2 ? blackSquareColor : whiteSquareColor;
            }
        }
    }
}
