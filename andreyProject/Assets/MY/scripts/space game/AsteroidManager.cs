using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public GameObject AsteroidPrefab;
    public int AsteroidCount;
    public float dencity;

    private void Start()
    {
        for (int i = 0; i < AsteroidCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(point1.position.x, point2.position.x), Random.Range(point1.position.y, point2.position.y), Random.Range(point1.position.z, point2.position.z));
            Vector3 randomScale = new Vector3(Random.Range(point1.localScale.x, point2.localScale.x), Random.Range(point1.localScale.y, point2.localScale.y), Random.Range(point1.localScale.z, point2.localScale.z));
            GameObject G = Instantiate(AsteroidPrefab, randomPos, Quaternion.Euler(randomPos));
            G.transform.localScale = randomScale;
            randomScale /= 100;
            G.GetComponent<Rigidbody>().mass = dencity * randomScale.x * randomScale.y * randomScale.z;
        }
    }

    private void Update()
    {
    }
}