using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;

    private void Update() => transform.position = new Vector2(Input.mousePosition.x / Screen.width * screenWidthInUnits, transform.position.y);
}
