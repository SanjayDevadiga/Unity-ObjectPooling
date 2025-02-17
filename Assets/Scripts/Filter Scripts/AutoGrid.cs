using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class AutoGrid : MonoBehaviour
{
    public RectTransform viewport; 
    public int columns = 2; 
    public float spacing = 10f;

    private GridLayoutGroup gridLayout;

    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        UpdateCellSize();
    }

    void Update()
    {
        UpdateCellSize();
    }

    void UpdateCellSize()
    {
        if (viewport == null)
            return;

        float totalSpacing = (columns - 1) * spacing;
        float cellSize = (viewport.rect.width - totalSpacing - gridLayout.padding.left - gridLayout.padding.right) / columns;

        gridLayout.cellSize = new Vector2(cellSize, cellSize);
        gridLayout.spacing = new Vector2(spacing, spacing);
    }
}
