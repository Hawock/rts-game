using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float speed = 10f;

    public Camera camera;

    public float zoomSpeed = 5000f;
    private float _mult = 1f;

    private void Start () {
        camera = Camera.main;
    }

    private void Update () {
        RotateMap();
        MoveMap();
        ZoomMap();
    }
    /* Повороты камеры */
    private void RotateMap () {
        float isRotate = 0f;
        if(Input.GetKey(KeyCode.Q)) isRotate = -1f;
        if(Input.GetKey(KeyCode.E)) isRotate = 1f;
        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * isRotate * _mult, Space.World);
    }

    /* Движение камеры */
    private void MoveMap () {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);
    }

    /* Зум камеры */
    private void ZoomMap () {
        /* camera.orthographicSize += Time.deltaTime * zoomSpeed * -Input.GetAxis("Mouse ScrollWheel");
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 5f, 50f); */
        transform.position += transform.up * Time.deltaTime * zoomSpeed * -Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, 5f, 50f),
            transform.position.z
        );
    }
}
