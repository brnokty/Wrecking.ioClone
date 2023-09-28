using UnityEngine;

public class Joystick : MonoBehaviour
{
    private Vector2 startPosition;
    private bool isDragging = false;
    public float threshold = 0.1f;

    private float savedNormalizedDistanceX;
    private float savedNormalizedDistanceY;
    public float Horizontal => GetHorizontalValue();
    public float Vertical => GetVerticalValue();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    public float GetHorizontalValue()
    {
        if (isDragging)
        {
            Vector2 currentPosition = Input.mousePosition;
            float distanceX = currentPosition.x - startPosition.x;
            float normalizedDistanceX = distanceX / Screen.width;

            if (Mathf.Abs(normalizedDistanceX) < threshold)
            {
                return savedNormalizedDistanceX;
            }
            else
            {
                savedNormalizedDistanceX = normalizedDistanceX;
                return normalizedDistanceX;
            }
        }
        else
        {
            return 0f;
        }
    }

    public float GetVerticalValue()
    {
        if (isDragging)
        {
            Vector2 currentPosition = Input.mousePosition;
            float distanceY = currentPosition.y - startPosition.y;
            float normalizedDistanceY = distanceY / Screen.height;


            if (Mathf.Abs(normalizedDistanceY) < threshold)
            {
                return savedNormalizedDistanceY;
            }
            else
            {
                savedNormalizedDistanceY = normalizedDistanceY;
                return normalizedDistanceY;
            }
        }
        else
        {
            return 0f;
        }
    }
}