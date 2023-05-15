using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTurning : MonoBehaviour
{
    public NearestEnemyDetecting ned1;
    public GameObject closestEnemy;
    public float rotation_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        ned1 = transform.parent.transform.parent.GetComponent<NearestEnemyDetecting>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ned1 != null){
            closestEnemy = ned1.closestEnemy;
            if(closestEnemy == null) return;
            Vector3 direction = closestEnemy.transform.position - transform.position;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion targetQuaterion = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaterion, rotation_speed*Time.deltaTime);
        }
    }
}
