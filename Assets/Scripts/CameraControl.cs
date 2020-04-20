using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Camera camera;

    [SerializeField]
    private Rect bounds;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float minZoom;
    [SerializeField]
    private float maxZoom;
    [SerializeField]
    private float zoomSpeed;

    private Vector3 movement = Vector3.zero;
    private Vector3 position = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        position = camera.transform.position;
        if (Input.mouseScrollDelta.y != 0)
        {
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize + Input.mouseScrollDelta.y * zoomSpeed, minZoom, maxZoom);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement.y += movementSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement.y -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x += movementSpeed;
        }
        if (movement != Vector3.zero)
        {
            position += movement;
            position.y = Mathf.Clamp(position.y, bounds.yMin + camera.orthographicSize, bounds.yMax - camera.orthographicSize);
            position.x = Mathf.Clamp(position.x, bounds.xMin + camera.orthographicSize * camera.aspect, bounds.xMax - camera.orthographicSize * camera.aspect);
            camera.transform.position = position;
        }
    }
}
