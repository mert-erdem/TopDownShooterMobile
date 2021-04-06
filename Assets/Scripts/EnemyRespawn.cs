using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    private Transform[] resPointS;
    [SerializeField]
    private GameObject enemy;
    private int randomPoint;
    private float respawnDelay = 2f; private bool optimizer = true;

    void Start()
    {
        resPointS = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if(optimizer)
        {
            StartCoroutine(Spawn());
        }       
    }

    IEnumerator Spawn()
    {
        optimizer = false;

        yield return new WaitForSeconds(respawnDelay);

        randomPoint = Random.Range(1, resPointS.Length);
        Instantiate(enemy, resPointS[randomPoint].position, Quaternion.identity);

        optimizer = true;
    }
}
