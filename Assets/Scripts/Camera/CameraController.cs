using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private GameObject thirdPersonCamera;
    private bool canSwitchCamera;


    public void SetCanSwitchCamera(bool canSwitchCamera)
    {
        this.canSwitchCamera = canSwitchCamera;
    }

    private void Awake()
    {
        SetCameraInitialState();
        SetCanSwitchCamera(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleCameras();
        }
    }

    private void ToggleCameras()
    {
        if (!canSwitchCamera)
        {
            return;
        }

        if (thirdPersonCamera == null || firstPersonCamera == null)
        {
            return;
        }

        //Si la first person camera esta activada, la desactivo
        //Si la third person camera esta desactivada, la activo

        bool thirdPersonCameraActive = thirdPersonCamera.activeInHierarchy;
        thirdPersonCamera.SetActive(!thirdPersonCameraActive);
        firstPersonCamera.SetActive(thirdPersonCameraActive);
    }

    private void SetCameraInitialState()
    {
        thirdPersonCamera.SetActive(true);
        firstPersonCamera.SetActive(false);
    }
}