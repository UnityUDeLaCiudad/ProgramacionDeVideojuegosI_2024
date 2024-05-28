using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet prefab;
    [SerializeField] private Transform shootingPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(prefab, shootingPoint.position, shootingPoint.rotation);
        bullet.SetDirection(shootingPoint.forward);
    }
}