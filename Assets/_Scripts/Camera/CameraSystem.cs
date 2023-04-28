using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraSystem : MonoBehaviour
{
    [Header("Mouse controls")]
    [SerializeField] bool mouseEnabled;
    
    [Space]

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [Space]

    [Header("Target configuration")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;

    [Space]

    [Header("Drag configuration")]

    [SerializeField] float maxMovDragSpeed = 1;
    [SerializeField] float minMovDragSpeed = 0.5f;

    [SerializeField] float reduceInputDuration;

    float currentMovementDragSpeed;

    bool dragPanMoveActive = false;
    
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

    Tween reduceInputTween;

    private void Start()
    {
        currentMovementDragSpeed = maxMovDragSpeed;
        maxOrthoSize += 0.1f;
        minOrthoSize -= 0.1f;
    }

    void Update()
    {
        if (inGame)
        {
            ClampTarget();
            if (mouseEnabled)
            {
                MouseHandleCameraMovementDragPan();
            }
            else
            {
                HandleCameraMovementDragPan();
                HandleCameraZoom();
            }
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

        currentMovementDragSpeed = Mathf.Lerp(minMovDragSpeed, maxMovDragSpeed, t);
        //Debug.Log("T: " + t + "\nCurrent speed: " + currentMovementDragSpeed);
    }

    void HandleCameraMovementDragPan()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                dragPanMoveActive = true;
                lastMousePosition = Input.GetTouch(0).position;

                if (reduceInputTween.IsActive())
                {
                    reduceInputTween.Kill();
                    inputDir = Vector2.zero;
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                dragPanMoveActive = false;

                //Debug.Log(inputDir);
                reduceInputTween = DOVirtual.Vector3(inputDir, Vector3.zero, reduceInputDuration, (Vector3 v) => inputDir = v);
            }

            if (dragPanMoveActive)
            {
                Vector2 mouseMovementDelta = (Vector2)Input.GetTouch(0).position - lastMousePosition;

                float dragPanSpeed = 2f;

                inputDir.x = mouseMovementDelta.x * dragPanSpeed;
                inputDir.y = mouseMovementDelta.y * dragPanSpeed;

                lastMousePosition = Input.GetTouch(0).position;
            }                  
        }

        moveDir = transform.forward * inputDir.y + inputDir.x * transform.right;

        moveDir *= -1;

        moveDir = isoMatrix.MultiplyPoint3x4(moveDir);

        transform.position += currentMovementDragSpeed * Time.deltaTime * moveDir;
    }

    void MouseHandleCameraMovementDragPan()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragPanMoveActive = true;
            lastMousePosition = Input.mousePosition;

            if (reduceInputTween.IsActive())
                reduceInputTween.Kill();
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragPanMoveActive = false;

            reduceInputTween = DOVirtual.Vector3(inputDir, Vector3.zero, reduceInputDuration, (Vector3 v) => inputDir = v);
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

        transform.position += currentMovementDragSpeed * Time.deltaTime * moveDir;      
    }
}
