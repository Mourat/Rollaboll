using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float apwardBounce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // Если другой коллайдер является игроком
        if (other.gameObject.CompareTag("Player"))
        {
            // Получить жесткое тело игрока
            Rigidbody playerRigidBody = other.gameObject.GetComponent<Rigidbody>();
            // Если тело найдено, применить к нему силу
            if (playerRigidBody != null)
            {
                // Применить вертикальную скорость к игроку
                playerRigidBody.velocity = new Vector3(0, apwardBounce, 0);
            }
        }
    }
}
