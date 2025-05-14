using UnityEngine;

public class MouseHover : MonoBehaviour
{
    private Vector3 originalScale;
    public Texture2D originalCursor, hoverCursor;
    private void Start()
    {
        originalScale = transform.localScale;
    }
    public void OnMouseEnter()
    {
        // Change the cursor to the hover cursor
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
        transform.localScale = originalScale * 1.1f;
    }
    public void OnMouseExit()
    {
        // Change the cursor back to the original cursor
        Cursor.SetCursor(originalCursor, Vector2.zero, CursorMode.Auto);
        transform.localScale = originalScale;
    }
}
