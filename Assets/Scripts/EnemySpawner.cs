using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Object enemyRef;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRef = Resources.Load("EnemyMilee");
        Invoke("SpawnEnemyMilee", 5f);
    }

    void SpawnEnemyMilee()
    {
        GameObject enemyMilee = (GameObject)Instantiate(enemyRef);
        enemyMilee.transform.position = new Vector3(transform.position.x + 5, transform.position.y + 5, transform.position.z + 5);
        Invoke("SpawnEnemyMilee", 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
