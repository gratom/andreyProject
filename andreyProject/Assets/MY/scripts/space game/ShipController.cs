using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Rigidbody rigid;
    public GameObject cameraGameObject;
    public float speed;

    public Vector3 angle;
    public Vector3 angle2;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        angle = cameraGameObject.transform.rotation.eulerAngles - transform.rotation.eulerAngles;
    }

    private void Update()
    {
        ShipControl();
        CameraFollower();
        CameraRotate();

        angle2 = cameraGameObject.transform.rotation.eulerAngles - angle;
    }

    public void CameraFollower()
    {
        cameraGameObject.transform.position = gameObject.transform.position + new Vector3(0, 1.52f, -2.313f);
    }

    public void CameraRotate()
    {
        //izmenenie povorota cameri na raznitcu mezhdu polozheniyami cursora vo vremya smeny kadrov.
        cameraGameObject.transform.Rotate(new Vector2(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X")));
        //vector3 = nazvanie "rotation", zadal ravenstvo k povorotu kameri.
        Vector3 rotation = cameraGameObject.transform.localRotation.eulerAngles;
        rotation.z = 0;
        //prisvoenie localnogo povorota kamery k soderjimomu "()"
        cameraGameObject.transform.localRotation = Quaternion.Euler(rotation);
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