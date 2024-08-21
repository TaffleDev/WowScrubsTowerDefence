using UnityEngine;

public class GridOverlay : MonoBehaviour
{
    public Vector2 gridSize; // Size of your grid
    public float cellSize; // Size of each cell

    void Start()
    {
        DrawGrid();
    }

    void DrawGrid()
    {
        for (float x = 0; x <= gridSize.x; x += cellSize)
        {
            DrawLine(new Vector2(x, 0), new Vector2(x, gridSize.y));
        }

        for (float y = 0; y <= gridSize.y; y += cellSize)
        {
            DrawLine(new Vector2(0, y), new Vector2(gridSize.x, y));
        }
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        GameObject line = new GameObject("Line");
        line.transform.parent = transform;
        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.startWidth = 0.05f; // Width of the line
        lr.endWidth = 0.05f;
        lr.useWorldSpace = true;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.black;
        lr.endColor = Color.black;
    }
}
