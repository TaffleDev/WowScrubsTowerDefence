using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlacement : MonoBehaviour
{
    public Tilemap tilemap;
    public Color highlightColor;
    public TowerData[] availableTowers; // Array of available towers
    private TowerData selectedTower; // Currently selected tower
    private Vector3Int previousCell;

    void Update()
    {
        if (selectedTower == null)
            return;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);

        // Highlight the current cell
        if (cellPosition != previousCell)
        {
            ResetPreviousCell();
            HighlightCurrentCell(cellPosition);
            previousCell = cellPosition;
        }

        // Place the tower on left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            TileBase clickedTile = tilemap.GetTile(cellPosition);
            if (clickedTile != null)
            {
                PlaceTower(cellPosition);
            }
        }
    }

    public void SelectTower(int towerIndex)
    {
        if (towerIndex < availableTowers.Length)
        {
            selectedTower = availableTowers[towerIndex];
        }
    }

    void HighlightCurrentCell(Vector3Int cellPosition)
    {
        TileBase tile = tilemap.GetTile(cellPosition);
        if (tile != null)
        {
            tilemap.SetColor(cellPosition, highlightColor);
        }
    }

    void ResetPreviousCell()
    {
        if (tilemap.GetTile(previousCell) != null)
        {
            tilemap.SetColor(previousCell, Color.white);
        }
    }

    void PlaceTower(Vector3Int cellPosition)
    {
        Vector3 towerPosition = tilemap.CellToWorld(cellPosition);
        towerPosition += tilemap.cellSize / 2;
        GameObject newTower = Instantiate(selectedTower.towerPrefab, towerPosition, Quaternion.identity);

        // Assign the selected TowerData to the new tower instance
        Tower towerComponent = newTower.GetComponent<Tower>();
        if (towerComponent != null)
        {
            towerComponent.towerData = selectedTower;
        }
    }
}
