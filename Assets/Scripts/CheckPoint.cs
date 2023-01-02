using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Найти скрипт контроллера игрока
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if(playerController != null)
            {
                // Получить координаты текущего чекпоинта
                Vector3 newSpawnPoint = transform.position;
                // Отправить координаты игрока в контроллер игрока
                playerController.SetNewRespawn(newSpawnPoint);
            }
        }
    }
}
