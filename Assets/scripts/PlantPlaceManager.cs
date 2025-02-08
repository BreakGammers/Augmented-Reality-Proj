using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantPlaceManager : MonoBehaviour
{
    public GameObject[] _placementObject;
    public ARRaycastManager _raycastManager;
    public XROrigin _origin;
    public ARPlaneManager _planeManager;
    private List<ARRaycastHit> _raycastHits = new List<ARRaycastHit>();
    private GameObject _instantiatedObject = null;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool collision = _raycastManager.Raycast(Input.GetTouch(0).position, _raycastHits, TrackableType.PlaneWithinPolygon);

            if (collision)
            {
                GameObject _instantiatedObject = Instantiate(_placementObject[Random.Range(0, _placementObject.Length - 1)]);
                _instantiatedObject.transform.position = _raycastHits[0].pose.position;
                foreach (ARPlane plane in _planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                _planeManager.enabled = false;
            }
        }
    }
}
