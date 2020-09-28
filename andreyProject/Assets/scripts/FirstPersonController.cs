using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed;

    public GameObject personCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(new Vector2(0, Input.GetAxis("Mouse X")));
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * Time.deltaTime * speed;
        }
        personCamera.transform.Rotate(new Vector2(Input.GetAxis("Mouse Y") * -1, 0));
    }
}