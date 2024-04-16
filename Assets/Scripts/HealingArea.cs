using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    [SerializeField] private float healingAmount;

    private void OnCollisionEnter(Collision other)
    {
    }

    private void OnCollisionExit(Collision other)
    {
    }

    private void OnCollisionStay(Collision other)
    {
    }

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

    private void OnTriggerExit(Collider other)
    {
        // Player player = other.GetComponent<Player>();
        // if (player != null)
        // {
        //     player.SetCanShoot(true);
        // }
    }

    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.HealDamage(healingAmount * Time.fixedDeltaTime);
        }
    }
}