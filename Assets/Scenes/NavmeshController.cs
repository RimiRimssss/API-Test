using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshController : MonoBehaviour
{
    public LayerMask layer;
    public NavMeshAgent navAgent;
    public float rayDistance = 100f;
    public GameObject cursor;

    void Start()
    {
        navAgent= GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(1)) {
            if (Physics.Raycast(ray, out hit, rayDistance, layer))
            {
                Vector3 targetPosition = hit.point;
                cursor.transform.position = targetPosition;
                navAgent.SetDestination(targetPosition);
                Debug.Log("Moving to ground position: " + hit.point + hit.collider.gameObject.name);
                
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        Debug.Log(Vector3.Distance(transform.position, cursor.transform.position));
    }

    
}
