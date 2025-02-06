using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
 public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = -9.81f;
     private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Bewegung
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Erstelle die Bewegungsvektor basierend auf der aktuellen Rotation des Charakters
        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        movement.y = 0f; // Behalte die Bewegung in der Ebene bei, nicht vertikal

        transform.Translate(movement.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Springen
       if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }



        // Bodenerkennung
        RaycastHit hit;
        isGrounded = Mathf.Abs(rb.velocity.y) < 0.01f;
    }
}
