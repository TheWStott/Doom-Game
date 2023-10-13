using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour {

    // Use this for initialization

    private Rigidbody2D rb;
    float speed;
    Vector2 movement;
    private Rigidbody2D rb2d;

    void Start () {
        speed = 5.1f;
        rb = GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }

    void resetPosition()
    {
        transform.SetPositionAndRotation(new Vector3(-26f, 1.5f, 0), Quaternion.identity);
    }

    void resetPositionReturn()
    {
        transform.SetPositionAndRotation(new Vector3(20,-25.2f, 0), Quaternion.identity);
    }




}
