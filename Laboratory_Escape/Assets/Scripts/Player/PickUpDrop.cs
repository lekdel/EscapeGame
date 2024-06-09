using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabbable objectGrabbable;

    private float pickUpDistance = 2f;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                if(objectGrabbable == null)
                {
                    if(raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabPointTransform);
                    }
                } else
                {
                    objectGrabbable.Drop();
                    objectGrabbable = null;
                }
                
            }
        }
        if (Input.GetMouseButtonUp(0) && objectGrabbable != null)
        {
            objectGrabbable.Drop();
            objectGrabbable = null;
        }
    }
}
