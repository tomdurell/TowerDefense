using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

    public static Transform[] wayPoints;

    void Awake()
    {
        wayPoints = new Transform[transform.childCount]; //creates a new array of size equal to the children of this game object.
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
            
        }
    }
}
