using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed;

    public float jump;

    public GameObject personCamera;

    public Rigidbody rigid;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(new Vector2(0, Input.GetAxis("Mouse X")));
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(transform.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(-transform.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(transform.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(-transform.right * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && rigid.velocity.y == 0)
        {
            rigid.AddForce(transform.up * jump);
        }
        personCamera.transform.Rotate(new Vector2(Input.GetAxis("Mouse Y") * -1, 0));
    }
}