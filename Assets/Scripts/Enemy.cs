using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    //Necesito que al chocar con el player, le quite vida

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision enter");
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