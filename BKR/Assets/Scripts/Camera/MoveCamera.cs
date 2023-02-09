using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float speedZoom = 0.1f;
    [SerializeField] float maxZoom = 10;
    [SerializeField] float minZoom = 1;
    [SerializeField] float maxHeight = 10;
    [SerializeField] float maxWidth = 10;
    private Camera camera;
    private Vector2 positionMouse;

    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y > 0.0f && camera.orthographicSize > minZoom)
        {
            camera.orthographicSize -= speedZoom;
        }
        else if (Input.mouseScrollDelta.y < 0.0f && camera.orthographicSize < maxZoom)
        {
            camera.orthographicSize += speedZoom;
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            float deltaX = positionMouse.x - Input.mousePosition.x;
            float deltaY = positionMouse.y - Input.mousePosition.y;

            if (Mathf.Abs(deltaX + deltaY) > 0)
            {
                this.transform.position += new Vector3(deltaX / 100, deltaY / 100, 0);

                if (Mathf.Abs(this.transform.position.x) > maxWidth)
                    if (this.transform.position.x > 0)
                        this.transform.position = new Vector3(maxWidth, this.transform.position.y, this.transform.position.z);
                    else
                        this.transform.position = new Vector3(-maxWidth, this.transform.position.y, this.transform.position.z);

                if (Mathf.Abs(this.transform.position.y) > maxHeight)
                    if (this.transform.position.y > 0)
                        this.transform.position = new Vector3(this.transform.position.x, maxHeight, this.transform.position.z);
                    else
                        this.transform.position = new Vector3(this.transform.position.x, -maxHeight, this.transform.position.z);
            }
        }
        positionMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
}
