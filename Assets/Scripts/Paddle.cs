using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16f;

    private void Update() => transform.position = new Vector2(
        Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX),
        transform.position.y);
}
