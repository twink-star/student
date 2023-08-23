using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] public float CameraSpeed;
    private Vector3 angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = this.gameObject.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        angle.y += Input.GetAxis("Mouse X") * CameraSpeed;

        angle.x -= Input.GetAxis("Mouse Y") * CameraSpeed;

        this.gameObject.transform.localEulerAngles = angle;
    }
}
