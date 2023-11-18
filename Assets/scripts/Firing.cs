using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {

    public float bulletSpeed = 1;
    Vector3 worldPosition;
    string bulletState = "still";

    GameObject Hero;
    Vector3 bulletDirection;

    // Use this for initialization
    void Start () {
        Hero = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (bulletState == "moving")
        {
            transform.position += bulletDirection * Time.deltaTime;
        }

    }

    void shooting()
    {
        if (bulletState == "still")
        {
            //Debug.Log(Hero.transform.position.x);
            Vector3 mousePos = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            float dx = worldPosition.x - Hero.transform.position.x;
            float dy = worldPosition.y - Hero.transform.position.y;
            float bulletGradient = (dy / dx);

            bulletDirection = new Vector3(dx, dy, 0);
            bulletDirection = bulletDirection.normalized * bulletSpeed;
            //Debug.Log("dir="+bulletDirection);


            //mousePos.z = Camera.main.nearClipPlane;
            //Debug.Log(worldPosition);
            transform.SetPositionAndRotation(new Vector3(Hero.transform.position.x, Hero.transform.position.y ,0), Quaternion.identity);
            bulletState = "moving";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        //Debug.Log("HIT!"+other.otherCollider.tag);
        Debug.Log("HIT!" + other.gameObject.tag);

        if (other.gameObject.tag == "wall")
        {
            bulletState = "still";
            Debug.Log("dead bullet");
            Hero.SendMessage("resetFiringFlag");
        }
        
    }
}
