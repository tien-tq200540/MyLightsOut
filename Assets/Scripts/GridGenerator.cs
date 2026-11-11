using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] protected int rows = 3;
    [SerializeField] protected int cols = 5;
    [SerializeField] protected float cellHeight = 1f;
    [SerializeField] protected float cellWidth = 1f;
    [SerializeField] protected float spacing = 1.5f;
    [SerializeField] protected GameObject prefab;

    private void Start()
    {
        GenerateGrid(rows, cols);
    }

    protected virtual void GenerateGrid(int rows, int cols)
    {
        Vector2 spawnPos;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                spawnPos.y = (i - 1) * (cellHeight + spacing) / 2f;
                spawnPos.x = (j - 1) * (cellWidth + spacing) / 2f;
                Instantiate(prefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
