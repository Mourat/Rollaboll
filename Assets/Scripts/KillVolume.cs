using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Доступ к контроллеру игрока
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController!= null )
            {
                // Убить игрока
                playerController.KillPlayer();
            }
        }
    }
}
