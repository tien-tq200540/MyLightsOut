using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public static GridGenerator Instance;

    [SerializeField] protected int rows = 3;
    [SerializeField] protected int cols = 5;
    [SerializeField] protected float cellHeight = 1f;
    [SerializeField] protected float cellWidth = 1f;
    [SerializeField] protected float spacing = 1.5f;
    [SerializeField] protected LightTrigger prefab;
    protected LightTrigger[,] lightArrs;
    protected int[,] lightStates;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        lightArrs = new LightTrigger[rows, cols];
        lightStates = new int[rows, cols];
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
                lightArrs[i, j] = Instantiate(prefab, spawnPos, Quaternion.identity);
                lightArrs[i, j].rowIndex = i;
                lightArrs[i, j].columnIndex = j;
                lightStates[i, j] = 1;
            }
        }
    }

    public virtual void Press(int rowIndex, int colIndex)
    {
        lightStates[rowIndex, colIndex] = 1 - lightStates[rowIndex, colIndex];
        lightArrs[rowIndex, colIndex].TriggerLight();

        if (rowIndex-1 >= 0)
        {
            lightStates[rowIndex-1, colIndex] = 1 - lightStates[rowIndex-1, colIndex];
            lightArrs[rowIndex - 1, colIndex].TriggerLight();
        }

        if (rowIndex + 1 < rows)
        {
            lightStates[rowIndex +1, colIndex] = 1 - lightStates[rowIndex + 1, colIndex];
            lightArrs[rowIndex + 1, colIndex].TriggerLight();
        }

        if (colIndex - 1  >= 0)
        {
            lightStates[rowIndex, colIndex - 1] = 1 - lightStates[rowIndex, colIndex - 1];
            lightArrs[rowIndex, colIndex - 1].TriggerLight();
        }

        if (colIndex + 1 < cols)
        {
            lightStates[rowIndex, colIndex + 1] = 1 - lightStates[rowIndex, colIndex + 1];
            lightArrs[rowIndex, colIndex + 1].TriggerLight();
        }
    }
}
