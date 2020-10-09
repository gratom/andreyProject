using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public GameObject AsteroidPrefab;
    public int AsteroidCount;

    private void Start()
    {
        for (int i = 0; i < AsteroidCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(point1.position.x, point2.position.x), Random.Range(point1.position.y, point2.position.y), Random.Range(point1.position.z, point2.position.z));
            Instantiate(AsteroidPrefab, randomPos, Quaternion.Euler(randomPos));
        }
    }

    private void Update()
    {
    }
}