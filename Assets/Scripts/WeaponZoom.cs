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
        camera = GetComponentInParent<Camera>();
        rbc = GetComponentInParent<RigidbodyFirstPersonController>();
    }
    void Update()
    {
        Zoom();
    }
    private void OnDisable()
    {
        ZoomOut();
    }
    void Zoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZoom)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        isZoom = false;
        camera.fieldOfView = zoomOut;
        rbc.mouseLook.XSensitivity = zoomOutSensitivity;
        rbc.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        isZoom = true;
        camera.fieldOfView = zoomIn;
        rbc.mouseLook.XSensitivity = zoomInSensitivity;
        rbc.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
