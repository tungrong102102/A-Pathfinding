using UnityEngine;

public class ChessboardLines : MonoBehaviour
{
    public int rows = 8;
    public int cols = 8;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawChessboardLines();
    }

    void DrawChessboardLines()
    {
        // Calculate positions for the lines and set them in the LineRenderer.
    }
}