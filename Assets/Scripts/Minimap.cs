using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject cameraHolder;
    public Camera minimapCamera;
    Vector3 worldPosition;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraToPoint();
    }

    private void MoveCameraToPoint()
    {
        ray = minimapCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;

            
            if (Input.GetMouseButton(0))
            {
                cameraHolder.transform.position = new Vector3(hitData.point.x, cameraHolder.transform.position.y,
                    hitData.point.z);

            }
        }
    }
}
