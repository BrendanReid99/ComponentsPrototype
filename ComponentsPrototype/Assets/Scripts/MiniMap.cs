using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        Vector3 updatePosition = target.position; //finds the player position 
        updatePosition.y = transform.position.y; //set the y position to itself (keeps it zoomed out)
        transform.position = updatePosition;  //set the position of the map to the updated position

        transform.rotation = Quaternion.Euler(90.0f, target.eulerAngles.y, 0.0f); //camera now rotates with the player 
    }
}
