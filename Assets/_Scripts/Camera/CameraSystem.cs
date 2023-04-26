using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    [SerializeField] float maxMovementDragSpeed = 1;
    [SerializeField] float minMovementDragSpeed = 0.5f;
    float currentMovementDragSpeed;

    Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0)); // Change movement directions;

    Vector2 lastMousePosition;
    Vector3 moveDir = Vector3.zero;
    Vector3 inputDir = Vector3.zero;

    /*[Space]

    [Header("Momentum configuration")]
    [SerializeField] float momentumDuration = 0.5f;
    [SerializeField] float requiredInputStrenght = 25f;

    Tween momentumTween;*/

    [Space]

    [Header("Zoom configuration")]

    [SerializeField] float maxOrthoSize = 50;
    [SerializeField] float minOrthoSize = 40;
    [SerializeField] float zoomSpeed = 3;

    float targetOrthoSize = 50;

    public static bool inGame;

    private void Start()
    {
        currentMovementDragSpeed = maxMovementDragSpeed;
        maxOrthoSize += 0.1f;
        minOrthoSize -= 0.1f;
    }

    void Update()
    {
        if (inGame)
        {
            ClampTarget();
            HandleCameraMovementDragPan();
            HandleCameraZoom();
        }
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

            targetOrthoSize = Mathf.Clamp(targetOrthoSize, minOrthoSize, maxOrthoSize);

            virtualCamera.m_Lens.OrthographicSize = 
                Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetOrthoSize, Time.deltaTime * zoomSpeed);

            AdjustDraggingSpeedByZoom();
        }
    }

    void AdjustDraggingSpeedByZoom()
    {
        // Change the dragging speed as the zoom changes.
        float t = (virtualCamera.m_Lens.OrthographicSize - minOrthoSize) / (maxOrthoSize - minOrthoSize);

        currentMovementDragSpeed = Mathf.Lerp(minMovementDragSpeed, maxMovementDragSpeed, t);
        Debug.Log("T: " + t + "\nCurrent speed: " + currentMovementDragSpeed);
    }

    void HandleCameraMovementDragPan()
    {
        //if (Input.touchCount < 2)
        if (Input.touchCount == 1)
        {
            //if (Input.GetMouseButtonDown(0))
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                /*if (momentumTween.IsActive())
                    momentumTween.Kill();*/

                dragPanMoveActive = true;
                //lastMousePosition = Input.mousePosition;
                lastMousePosition = Input.GetTouch(0).position;
            }

            if (dragPanMoveActive)
            {
                Vector2 mouseMovementDelta = (Vector2)Input.GetTouch(0).position - lastMousePosition;
                //Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

                float dragPanSpeed = 2f;

                inputDir.x = mouseMovementDelta.x * dragPanSpeed;
                inputDir.y = mouseMovementDelta.y * dragPanSpeed;

                lastMousePosition = Input.GetTouch(0).position;
                //lastMousePosition = Input.mousePosition;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Debug.Log(inputDir.magnitude);
                dragPanMoveActive = false;

                /*if (inputDir.magnitude > requiredInputStrenght)
                {
                    momentumTween = DOVirtual.Vector3(inputDir, Vector3.zero, momentumDuration, (Vector3 v) =>
                    {
                        inputDir = v;
                        moveDir = transform.forward * inputDir.y + inputDir.x * transform.right;
                        moveDir *= -1;
                        moveDir = isoMatrix.MultiplyPoint3x4(moveDir);
                        transform.position += currentMovementDragSpeed * Time.deltaTime * moveDir;
                    }).SetSpeedBased();
                }*/
            }     
            else
            {
                moveDir = transform.forward * inputDir.y + inputDir.x * transform.right;

                moveDir *= -1;

                moveDir = isoMatrix.MultiplyPoint3x4(moveDir);

                transform.position += currentMovementDragSpeed * Time.deltaTime * moveDir;

            }

        }
    }
}
