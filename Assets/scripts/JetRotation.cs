using UnityEngine;

public class JetRotation : MonoBehaviour
{
    public Vector3 _PlaneRoatation;
    void Update()
    {
        transform.Rotate(_PlaneRoatation * Time.deltaTime); // Rotate the jet around the vertical axis (y-axis) based on the plane's rotation
    }
}
