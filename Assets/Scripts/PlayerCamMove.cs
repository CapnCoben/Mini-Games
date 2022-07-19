using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamMove : MonoBehaviour
{

    [SerializeField] private Vector2 camRot;
                     public GameObject player;
                     private float xMove;
                     private float zMove;
    [SerializeField] private float speed;
    [SerializeField] private float camSensitivity;


    // Update is called once per frame
    void Update()
    {
        //Mouse Input
        camRot.x += Input.GetAxis("Mouse X") * camSensitivity;
        camRot.y += Input.GetAxis("Mouse Y") * camSensitivity;
        //Apply Rotation to cam and player from mouse
        transform.localRotation = Quaternion.Euler(-camRot.y, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, camRot.x, 0);
        //Button Input
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        //Set movement
        Vector3 move = new Vector3(xMove, 0, zMove);

        //Apply movement
        player.transform.Translate(move * speed * Time.deltaTime, Space.Self);

        
        
    }
}
