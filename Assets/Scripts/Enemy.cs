using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Player player;
    [SerializeField] private EnemyTypes enemyType;
    [SerializeField] private float speed;
    [SerializeField] private float fleeThreshold;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float pursuitThreshold;
    //Necesito que al chocar con el player, le quite vida

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision enter");
    }

    private void Update()
    {
        switch (enemyType)
        {
            case EnemyTypes.Pursuer:
                PursuitPlayer();
                break;
            case EnemyTypes.Escaper:
                EscapeFromPlayer();
                break;
            case EnemyTypes.Idle:
                Idle();
                break;
        }
    }

    private void PursuitPlayer()
    {
        Vector3 diff = player.transform.position - transform.position;
        float distance = diff.magnitude;
        Vector3 directionToPlayer = diff.normalized;

        if (distance > pursuitThreshold)
        {
            return;
            //
        }

        transform.position += directionToPlayer * (Time.deltaTime * speed);
        LookAtPlayer();
    }

    private void EscapeFromPlayer()
    {
        Vector3 diff = transform.position - player.transform.position;
        float distance = diff.magnitude;
        Vector3 directionOppositeToPlayer = diff.normalized;

        if (distance > fleeThreshold)
        {
            return;
        }

        transform.position += directionOppositeToPlayer * (Time.deltaTime * speed);
        LookAtPlayerOwnRotation();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(player.transform);
    }

    private void LookAtPlayerOwnRotation()
    {
        Quaternion newRotation = Quaternion.LookRotation(transform.position - player.transform.position);
        Quaternion currentRotation = transform.rotation;
        Quaternion finalRotation = Quaternion.Lerp(currentRotation, newRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = finalRotation;
    }

    private void Idle()
    {
        //
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("Collision stay");

        //Conseguir informacion sobre con quien colisione!
        //Estoy esperando que contra lo que colisione, sea el player! 

        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage * Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log("Choque contra algo que no era el player");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("Collision exit");
    }
}