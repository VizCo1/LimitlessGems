using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    bool dragPanMoveActive = false;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [Space]

    [Header("Drag configuration")]

    [SerializeField] float movementDragSpeed = 10;

    [Space]

    [Header("Zoom configuration")]

    [SerializeField] float orthoSizeMax = 50;
    [SerializeField] float orthoSizeMin = 10;
    [SerializeField] float zoomSpeed = 10;

    Vector2 lastMousePosition;
    float targetOrthoSize = 50;

    void Update()
    {
        HandleCameraMovementDragPan();
        HandleCameraZoom();

        Debug.Log(lastMousePosition);
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
        if (Input.touchCount == 1)
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

            Vector3 moveDir = transform.forward * inputDir.z + inputDir.x * transform.right;

            moveDir *= -1;

            transform.position += moveDir * movementDragSpeed * Time.deltaTime;
        }
    }
}
