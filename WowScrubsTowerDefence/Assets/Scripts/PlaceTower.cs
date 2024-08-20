using UnityEngine;
using UnityEngine.Tilemaps;
public class PlaceTower : MonoBehaviour
{
    public Tilemap tilemap; // Reference to your Tilemap
    public GameObject towerPrefab; // The tower you want to place

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get world position from mouse position
            Vector3Int cellPosition = tilemap.WorldToCell(worldPosition); // Convert world position to cell position

            // Optionally, you can check if the tile is a specific type before placing the tower
            TileBase clickedTile = tilemap.GetTile(cellPosition);
            if (clickedTile != null)
            {
                // Place tower on this tile
                PlaceTowerInWorld(cellPosition);
            }
        }
    }

    void PlaceTowerInWorld(Vector3Int cellPosition)
    {
        // Convert the cell position back to world position for accurate placement
        Vector3 towerPosition = tilemap.CellToWorld(cellPosition);

        // Place the tower at the center of the cell
        towerPosition += tilemap.cellSize / 2;

        Instantiate(towerPrefab, towerPosition, Quaternion.identity);
    }
}
