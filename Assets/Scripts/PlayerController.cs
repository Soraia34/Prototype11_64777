using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    private float zBound = 6;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

    }

    void MovePlayer()
    {
        float horizontaInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontaInput);
    }

    void ConstrainPlayerPosition()
    {
        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }
}
