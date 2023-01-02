using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float bounceAmount = 300f;

    private void OnTriggerEnter(Collider other)
    {
        // Если другой коллайдер является игроком
        if(other.gameObject.CompareTag("Player"))
        {
            // Получить жесткое тело игрока
            Rigidbody playerRigidBody =  other.gameObject.GetComponent<Rigidbody>();
            // Если тело найдено, применить к нему силу
            if(playerRigidBody != null )
            {
                // Получить скорость игрока и инвертировать ее
                Vector3 bounceDirection= -playerRigidBody.velocity;
                // Применить силу
                playerRigidBody.AddForce(bounceDirection * bounceAmount);
            }
        }
    }
}
