using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{

    public Rigidbody enemyRigidBody;
    public NavMeshAgent navMeshAgent;

    public GameObject player;
    public GameObject playerBase;
    public GameObject pathOne;
    public GameObject pathTwo;

    public GameObject ambientBGM;
    public GameObject conflictBGM;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        playerBase = GameObject.Find("PlayerBase");
        pathOne = GameObject.Find("PathOne");
        pathTwo = GameObject.Find("PathTwo");
        ambientBGM = GameObject.Find("Ambient");
        conflictBGM = GameObject.Find("Conflict");

    }

    // Update is called once per frame
    void Update()
    {
        int pathTaken = Random.Range(1,3);
        if(pathTaken == 1){
            navMeshAgent.SetDestination(pathOne.transform.position);
        }
        else if(pathTaken == 2){
            navMeshAgent.SetDestination(pathTwo.transform.position);
        }
        else{
            navMeshAgent.SetDestination(playerBase.transform.position);
        }
        float playerDist = (Vector3.Distance(player.transform.position,transform.position));
            if (playerDist <= 20f){
                navMeshAgent.SetDestination(player.transform.position);
            }
    } 
        

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ambientBGM.gameObject.SetActive(false);
            conflictBGM.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ambientBGM.gameObject.SetActive(true);
            conflictBGM.gameObject.SetActive(false);
        }
    }
}
