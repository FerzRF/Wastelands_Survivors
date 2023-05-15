using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemyDetecting : MonoBehaviour
{

    public string targetTag = "Enemy";
    public float searchRadius = 100f;
    public GameObject closestEnemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NearestEnemyDetect", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NearestEnemyDetect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);
        closestEnemy = null;
        float closestDistance = 150f;

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == targetTag)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.gameObject;
                }
            }
        }
    }
}
