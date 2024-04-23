using System;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float explosionForce;
    [SerializeField] private LayerMask resistantLayerMask;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Collider[] collidedObjects = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);

        foreach (Collider collidedObject in collidedObjects)
        {
            if (collidedObject.attachedRigidbody != null && CanSeeExplosionObject(collidedObject.attachedRigidbody))
            {
                ApplyExplosionForce(collidedObject.attachedRigidbody);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void ApplyExplosionForce(Rigidbody body)
    {
        Vector3 diffVector = body.position - transform.position;
        var finalExplosionForce = explosionForce / diffVector.magnitude;
        var explosionDirection = diffVector.normalized + Vector3.up;
        explosionDirection = explosionDirection.normalized;
        var finalExplosion = explosionDirection * finalExplosionForce;
        body.AddForce(finalExplosion, ForceMode.Impulse);
    }

    private bool CanSeeExplosionObject(Rigidbody body)
    {
        Vector3 diffVector = (body.position - transform.position);
        float maxDistance = diffVector.magnitude;
        Vector3 direction = diffVector.normalized;
        bool hasCollided = Physics.Raycast(transform.position, direction, maxDistance, resistantLayerMask);
        return !hasCollided;
    }
}