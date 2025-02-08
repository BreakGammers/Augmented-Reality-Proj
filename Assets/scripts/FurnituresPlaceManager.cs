using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FurnituresPlaceManager : MonoBehaviour
{
    public GameObject _placementFurnitureObject;
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

            if (collision && IsButtonPressed()==false)
            {
                GameObject _instantiatedObject = Instantiate(_placementFurnitureObject);
                _instantiatedObject.transform.position = _raycastHits[0].pose.position;
                _instantiatedObject.transform.rotation = _raycastHits[0].pose.rotation;

                foreach (ARPlane plane in _planeManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                _planeManager.enabled = false;
            }
        }
    }
    public bool IsButtonPressed()
    {
        if (EventSystem.current.currentSelectedGameObject?.GetComponent<Button>() == null)

            return false;
        else

            return true;
    }

    public void changeFurniture(GameObject furnitureObject)
    {
        _placementFurnitureObject = furnitureObject;
    }
}
