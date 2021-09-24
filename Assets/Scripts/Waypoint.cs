using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
 
    public Vector3 getPosition()
    {
        Vector3 position = transform.position;
        position.y += 0.5f;
        return position;
    }

    
}