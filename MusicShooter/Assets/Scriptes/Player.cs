using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed = 1;

    Vector3 moveDirection;

    public float yMin = -1.05f, yMax = 1.05f, xMin = -1.96f, xMax = 1.96f;

    public GameObject camera;

    float cameraY;
    float cameraX;

    public float diffY;
    public float diffX;

    //Vector3 yClamp;
    //Vector3 xClamp;

    public ScoreController sCont;

    void Start ()
    {
        moveDirection = transform.position;
        cameraY = camera.transform.position.y;
        cameraX = camera.transform.position.x;
        //yClamp = new Vector3(Mathf.Clamp()
    }

	void Update () 
    {
        Move();
	}

    void OnTriggerEnter(Collider col)
    {
        sCont.damage();
    }

    void Move()
    {
        moveDirection.y = Mathf.Clamp(transform.position.y, yMin, yMax);
        moveDirection.x = Mathf.Clamp(transform.position.x, xMin, xMax);

        if(Input.GetKey(KeyCode.S))
        {
            moveDirection.y += -0.01f * playerSpeed;

            if (moveDirection.y > -diffY && moveDirection.y < diffY)
            {
                cameraY = this.gameObject.transform.position.y;
            }
        }

        if(Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 0.01f * playerSpeed;

            if (moveDirection.y > -diffY && moveDirection.y < diffY)
            {
                cameraY = this.gameObject.transform.position.y;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x += -0.01f * playerSpeed;

            if (moveDirection.x > -diffX && moveDirection.x < diffX)
            {
                cameraX = this.gameObject.transform.position.x;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 0.01f * playerSpeed;

            if (moveDirection.x > -diffX && moveDirection.x < diffX)
            {
                cameraX = this.gameObject.transform.position.x;
            }
        }
        transform.position = moveDirection;
        camera.transform.position = new Vector3(cameraX, cameraY, camera.transform.position.z);
        
    }
}
