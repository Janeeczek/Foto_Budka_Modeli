using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //VECTORS
    Vector3 normal;

    //VARIABLES
    public float rotationSpeed = 100;
    public float zoomSpeed = 20;

    void Update () {
        //nn left mouse button click
        if (Input.GetMouseButton(0))
        {
            //rotate object with mouse movement
            this.transform.Rotate((Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime), 0, Space.Self);       
        }
        //zoom at the model
        transform.Translate(0, 0, Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed, Space.World);
    }
}
