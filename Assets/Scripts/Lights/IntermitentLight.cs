using System;
using UnityEngine;

public class IntermitentLight : MonoBehaviour
{
    [SerializeField] private Light lightToAffect;

    [SerializeField] private Color lightColor;
    [SerializeField] private float maxLightIntensity;
    [SerializeField] private float lightIntensityLerpTime;

    private void Start()
    {
        lightToAffect.color = lightColor;
    }

    private void Update()
    {
        lightToAffect.intensity = Mathf.Lerp(lightToAffect.intensity, maxLightIntensity, lightIntensityLerpTime * Time.deltaTime);
    }
}