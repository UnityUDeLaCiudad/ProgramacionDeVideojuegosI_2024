using UnityEngine;

public class ChNonPBR : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;


    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, 0, vertical).normalized;
        var movement = direction * speed;
        //actualizar el animator con la velocidad actual
        var currentSpeed = movement.magnitude;
        animator.SetFloat("WalkSpeed", currentSpeed);
        transform.position += movement * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.K))
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        //Actualizar el animator para decir que ataco
        animator.SetTrigger("Attack");
    }
}