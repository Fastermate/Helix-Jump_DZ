using UnityEngine;

public class Controls : MonoBehaviour
{
    private Vector3 _previousMousePosition;
    public Transform Level;
    public float Sensitivity;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Level.Rotate(0, -delta.x * Sensitivity, 0);
        }

        _previousMousePosition = Input.mousePosition;
    }
}
