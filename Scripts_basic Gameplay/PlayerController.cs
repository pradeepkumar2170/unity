using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public float verticalInput;
    public float speed=400.0f;
    public float xRange=7.0f;
     public float zRange=4.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
       ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        verticalInput=Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward*speed*verticalInput);

        horizontalInput=Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right*speed*horizontalInput);
    }

    void ConstrainPlayerPosition()
    {
                        //keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,-zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,zRange);
        }
    }

    private void OnCollisionEnter ( Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy.");
        }
    }

    private void OnTriggerEnter( Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
