using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingArea : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.SetCanShoot(false);
        }

        //Si es el jugador, entonces imprimo un mensaje.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Choquie con el player");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damageAmount * Time.fixedDeltaTime);
        }
    }
}
