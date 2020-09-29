using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Rigidbody rigid;
    public GameObject cameraGameObject;
    public float speed;

    private void Start()
    {
    }

    private void Update()
    {
        ShipControl();
        CameraFollower();
    }

    public void CameraFollower()
    {
        cameraGameObject.transform.position = gameObject.transform.position + new Vector3(0, 1.52f, -2.313f);
    }

    public void ShipControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(transform.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(-transform.forward * Time.deltaTime * speed);
        }
    }
}