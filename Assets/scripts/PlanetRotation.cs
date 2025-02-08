using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public GameObject _AR_Planet;
    public Vector3 vector3Roatation ;
    public int Speed;
     void Update() {
        _AR_Planet.transform.Rotate(vector3Roatation*Time.deltaTime*Speed);
    }
}
