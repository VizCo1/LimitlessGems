using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    // This camera system only works on mobile devices, but it can be adapted for other platforms

    bool dragPanMoveActive = false;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [Space]

    [Header("Target configuration")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;

    [Space]

    [Header("Drag configuration")]

    [SerializeField] float maxMovementDragSpeed = 10;
    [SerializeField] float minMovementDragSpeed = 5;
    float currentMovementDragSpeed;

    Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0)); // Change movement directions;

    Vector2 lastMousePosition;
    Vector3 moveDir = Vector3.zero;

    [Space]

    [Header("Zoom configuration")]

    [SerializeField] float MaxOrthoSize = 50;
    [SerializeField] float MinOrthoSize = 10;
    [SerializeField] float zoomSpeed = 10;

    float targetOrthoSize = 50;

    private void Start()
    {
        currentMovementDragSpeed = maxMovementDragSpeed;
    }

    void Update()
    {
        ClampTarget();
        HandleCameraMovementDragPan();
        HandleCameraZoom();
    }

    private void ClampTarget()
    {
        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float z = Mathf.Clamp(transform.position.z, minZ, maxZ);

        transform.position = new Vector3(x, transform.position.y, z);
    }

    private void HandleCameraZoom()
    {
        if (Input.touchCount == 2)
        {
            dragPanMoveActive = false;

            Touch touchOne = Input.GetTouch(0);
            Touch touchTwo = Input.GetTouch(1);

            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;

            float prevMagnitude = (touchOnePrevPos - touchTwoPrevPos).magnitude;
            float currentMagnitude = (touchOne.position - touchTwo.position).magnitude;

            if (prevMagnitude > currentMagnitude * 1.1f)
            {
                targetOrthoSize += 1;
            }
            else if (currentMagnitude > prevMagnitude * 1.1f)
            {
                targetOrthoSize -= 1;
            }

            targetOrthoSize = Mathf.Clamp(targetOrthoSize, MinOrthoSize, MaxOrthoSize);

            virtualCamera.m_Lens.OrthographicSize = 
                Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, Time.deltaTime * zoomSpeed);

            AdjustDraggingSpeedByZoom();
        }
    }

    void AdjustDraggingSpeedByZoom()
    {
        // Change the dragging speed as the zoom changes.
        float t = (virtualCamera.m_Lens.OrthographicSize - MinOrthoSize) / (MaxOrthoSize - MinOrthoSize);

        currentMovementDragSpeed = Mathf.Lerp(minMovementDragSpeed, maxMovementDragSpeed, t);
        Debug.Log("T: " + t + "\nCurrent speed: " + currentMovementDragSpeed);
    }

    void HandleCameraMovementDragPan()
    {
        if (Input.touchCount == 1)
        {
            Vector3 inputDir = Vector3.zero;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                inputDir = Vector3.zero;
                dragPanMoveActive = true;
                lastMousePosition = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                dragPanMoveActive = false;
            }

            if (dragPanMoveActive)
            {
                Vector2 mouseMovementDelta = (Vector2)Input.GetTouch(0).position - lastMousePosition;

                float dragPanSpeed = 2f;

                inputDir.x = mouseMovementDelta.x * dragPanSpeed;
                inputDir.y = mouseMovementDelta.y * dragPanSpeed;

                lastMousePosition = Input.GetTouch(0).position;
            }

            moveDir = transform.forward * inputDir.y + inputDir.x * transform.right;

            moveDir *= -1;

            moveDir = isoMatrix.MultiplyPoint3x4(moveDir);

            transform.position += moveDir * currentMovementDragSpeed * Time.deltaTime;
        }
    }
}
