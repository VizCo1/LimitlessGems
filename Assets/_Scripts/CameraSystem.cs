using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    bool dragPanMoveActive = false;

    [SerializeField] float movementDragSpeed = 10;

    [SerializeField] float fieldOfViewMax = 50;
    [SerializeField] float fieldOfViewMin = 10;

    Vector2 lastMousePosition;
    float targetFieldOfView = 50;

    void Update()
    {
        HandleCameraMovementDragPan();
        //HandleCameraZoom();
    }

    private void HandleCameraZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touchOne = Input.GetTouch(0);
            Touch touchTwo = Input.GetTouch(1);

            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;

            float prevMagnitude = (touchOnePrevPos - touchTwoPrevPos).magnitude;
            float currentMagnitude = (touchOne.position - touchTwo.position).magnitude;

            if (prevMagnitude > currentMagnitude)
            {
                targetFieldOfView -= prevMagnitude - currentMagnitude;
            }
            else
            {
                targetFieldOfView += currentMagnitude - prevMagnitude;
            }

            targetFieldOfView = Mathf.Clamp(targetFieldOfView, fieldOfViewMin, fieldOfViewMax);

            float zoomSpeed = 10f;

            virtualCamera.m_Lens.FieldOfView =
                Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, targetFieldOfView, Time.deltaTime * zoomSpeed);
        }
    }

    void Zoom(float increment)
    {

    }

    void HandleCameraMovementDragPan()
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

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x * -1; 

        transform.position += moveDir * movementDragSpeed * Time.deltaTime;
    }
}
