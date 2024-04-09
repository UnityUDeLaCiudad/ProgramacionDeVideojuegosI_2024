using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 2f;

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy <= 0)
        {
            //Destroy
            //instanciar efectos de explosion
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
    }
}