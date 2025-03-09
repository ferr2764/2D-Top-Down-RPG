using Unity.Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineCamera virtualCamera;

    private void Start()
    {
        SetCameraFollow();
    }
    public void SetCameraFollow()
    {
        virtualCamera = FindFirstObjectByType<CinemachineCamera>();
        virtualCamera.Follow = PlayerController.Instance.transform;
    }
}
