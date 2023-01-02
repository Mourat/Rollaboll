using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private int count;
    private float movementX, movementY;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float speed = 0;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] GameObject winTextObject;
    [SerializeField] Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + " - Speed: " + Math.Round(rigidBody.velocity.magnitude, 1);
        if (count >= 11)
        {
            winTextObject.SetActive(true);
        }
    }

    void EnforceMaxSpeed()
    {
        // Если скорость игрока выше максимальной
        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            // Ограничить скорость
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rigidBody.AddForce(movement * speed);

        EnforceMaxSpeed();
        SetCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    public void SetNewRespawn(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    public void KillPlayer()
    {
        // Переместить игрока на точку спавна
        transform.position = respawnPoint;
        // убать всю скорость игрока
        rigidBody.velocity = Vector3.zero;
    }
}
