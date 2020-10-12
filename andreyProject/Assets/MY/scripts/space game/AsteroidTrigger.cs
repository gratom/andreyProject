using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    public GameObject currentAsteroid;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            if (currentAsteroid == null)
            {
                currentAsteroid = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            if (currentAsteroid == other.gameObject)
            {
                currentAsteroid = null;
            }
        }
    }
}