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

    [SerializeField] float movementDragSpeed = 10;
    [SerializeField] float releaseDragSpeed = 1;

    Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0)); // Change movement directions;

    Vector2 lastMousePosition;
    Vector3 moveDir = Vector3.zero;

    [Space]

    [Header("Zoom configuration")]

    [SerializeField] float orthoSizeMax = 50;
    [SerializeField] float orthoSizeMin = 10;
    [SerializeField] float zoomSpeed = 10;

    float targetOrthoSize = 50;
    
    void Update()
    {
        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float z = Mathf.Clamp(transform.position.z, minZ, maxZ);

        transform.position = new Vector3(x, transform.position.y, z);

        HandleCameraMovementDragPan();
        HandleCameraZoom();
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

            targetOrthoSize = Mathf.Clamp(targetOrthoSize, orthoSizeMin, orthoSizeMax);

            virtualCamera.m_Lens.OrthographicSize = 
                Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, Time.deltaTime * zoomSpeed);
        }
    }

    void HandleCameraMovementDragPan()
    {
        if (Input.touchCount < 2)
        {
            Vector3 inputDir = Vector3.zero;
            
            if (Input.GetMouseButtonDown(0))
            {
                dragPanMoveActive = true;
                lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                dragPanMoveActive = false;
            }

            if (dragPanMoveActive)
            {
                Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

                float dragPanSpeed = 2f;

                inputDir.x = mouseMovementDelta.x * dragPanSpeed;
                inputDir.y = mouseMovementDelta.y * dragPanSpeed;

                lastMousePosition = Input.mousePosition;
            }

            moveDir = transform.forward * inputDir.y + inputDir.x * transform.right;

            moveDir *= -1;

            moveDir = isoMatrix.MultiplyPoint3x4(moveDir);

            transform.position += moveDir * movementDragSpeed * Time.deltaTime;
        }
    }
}
