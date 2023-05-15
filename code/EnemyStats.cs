using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth = 10f;
    public float enemyDamage = 1f;
    [SerializeField] GameObject target;
    public GameObject drop;

    void Start()
    {
        target = GetComponent<EnemyMoving>().target;
    }

    public void RecieveDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            TowerTurning tower = target.transform.Find("PlayerModelBod/PlayerTower").GetComponent<TowerTurning>();
            if(tower.closestEnemy != null && tower.closestEnemy == gameObject)
            {
                tower.closestEnemy = null;
            }
            Instantiate(drop, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject, 0f);
        }
    }
}
