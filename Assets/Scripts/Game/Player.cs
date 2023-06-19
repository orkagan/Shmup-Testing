using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _moveSpeed = 8f;
    public bool alive;
    public GameObject laserPrefab;

    void Start()
    {
        alive = true;
    }

    void Update()
    {
        //shmovement
        Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        //maybe do screen wrapping later idk

        //shooty shoot
        if (Input.GetButtonDown("Jump"))
        {
            Destroy(Instantiate(laserPrefab, transform.position, transform.rotation),4f);
        }
    }

    public void Move(Vector2 movement)
    {
        transform.position += (Vector3) (movement * _moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Asteroid"))
        {
            alive = false;
            Destroy(gameObject);
        }
    }
}
