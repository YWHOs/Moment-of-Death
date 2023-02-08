using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lighting;
    [SerializeField] float angle;
    [SerializeField] float minimumAngle;

    Light flashLight;

    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLight();
    }

    void DecreaseLight()
    {
        flashLight.intensity -= lighting * Time.deltaTime;

        if(flashLight.spotAngle <= minimumAngle) { return; }
        else
            flashLight.spotAngle -= angle * Time.deltaTime;
    }

    public void LightBattery(float _light, float _angle)
    {
        flashLight.intensity += _light;
        flashLight.spotAngle = _angle;
    }
}
