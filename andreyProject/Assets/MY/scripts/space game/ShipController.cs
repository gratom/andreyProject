using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    //sdelat' tormoz, coordinati, sdacha mineraiov, dvizhenie vverh/vniz;
    public enum ShipMode
    {
        battleMode,
        mineMode
    }

    private ShipMode shipMode;

    public Rigidbody rigid;
    public GameObject cameraGameObject;
    public float speed;
    public float miningSpeed;
    public AsteroidTrigger asteroidTrigger;

    public Vector3 angle;
    public Vector3 angle2;
    public float gyroscopeSpeed;
    public float torgueSpeed;

    public float ore;
    public Text oreCount;

    public int money;
    public Text moneyCount;

    public float shipSpeed;
    public Text shipSpeedCount;

    public float coordinates_x;
    public Text coordinatesCount_x;

    public float coordinates_y;
    public Text coordinatesCount_y;

    public float coordinates_z;
    public Text coordinatesCount_z;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        angle = cameraGameObject.transform.rotation.eulerAngles - transform.rotation.eulerAngles;
    }

    private void Update()
    {
        ShipControl();
        //CameraFollower();
        //CameraRotate();

        angle2 = cameraGameObject.transform.rotation.eulerAngles - angle;
        oreCount.text = ore.ToString("0.0");
        moneyCount.text = money.ToString();
        shipSpeed = rigid.velocity.magnitude;
        shipSpeedCount.text = shipSpeed.ToString("0.00");
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
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(transform.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(-transform.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rigid.AddRelativeTorque(new Vector3(0, 0, -torgueSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rigid.AddRelativeTorque(new Vector3(0, 0, torgueSpeed * Time.deltaTime));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            shipMode = ShipMode.mineMode;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            shipMode = ShipMode.battleMode;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            rigid.drag = 10;
            speed = speed * 25;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            rigid.drag = 0;
            speed = speed / 25;
        }
        if (Input.GetMouseButton(0))
        {
            if (shipMode == ShipMode.mineMode)
            {
                if (asteroidTrigger.currentAsteroid != null)
                {
                    Mining();
                }
            }
        }
        rigid.AddRelativeTorque(new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0) * gyroscopeSpeed);
    }

    public void Mining()
    {
        asteroidTrigger.currentAsteroid.transform.localScale -= new Vector3(1, 1, 1) * miningSpeed * Time.deltaTime;
        Vector3 V = asteroidTrigger.currentAsteroid.transform.localScale;
        ore += miningSpeed * Time.deltaTime;
        if (V.x < 1 || V.y < 1 || V.z < 1)
        {
            Destroy(asteroidTrigger.currentAsteroid);
        }
    }
}