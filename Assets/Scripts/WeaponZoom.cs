using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] int zoomIn;
    [SerializeField] int zoomOut;

    [SerializeField] float zoomInSensitivity;
    [SerializeField] float zoomOutSensitivity;

    bool isZoom;
    Camera camera;
    RigidbodyFirstPersonController rbc;
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        rbc = GetComponent<RigidbodyFirstPersonController>();
    }
    void Update()
    {
        Zoom();
    }
    void Zoom()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!isZoom)
            {
                isZoom = true;
                camera.fieldOfView = zoomIn;
                rbc.mouseLook.XSensitivity = zoomInSensitivity;
                rbc.mouseLook.YSensitivity = zoomInSensitivity;
            }
            else
            {
                isZoom = false;
                camera.fieldOfView = zoomOut;
                rbc.mouseLook.XSensitivity = zoomOutSensitivity;
                rbc.mouseLook.YSensitivity = zoomOutSensitivity;
            }
        }
    }

}
