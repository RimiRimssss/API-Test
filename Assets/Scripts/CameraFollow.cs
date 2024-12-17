using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerNavigation playerNavigation;

    private Vector3 lastPlayerPosition;
    private float distanceToMoveX;
    private float distanceToMoveZ;

    void Start()
    {
        lastPlayerPosition = playerNavigation.transform.position;
    }

    void Update()
    {
        distanceToMoveX = playerNavigation.transform.position.x - lastPlayerPosition.x;
        distanceToMoveZ = playerNavigation.transform.position.z - lastPlayerPosition.z;

        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y, transform.position.z + distanceToMoveZ);
        lastPlayerPosition = playerNavigation.transform.position;
    }
}
