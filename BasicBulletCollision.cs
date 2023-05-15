using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletCollision : MonoBehaviour
{
    public EnemyStats enemyStats;

    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }
    private void OnParticleCollision(GameObject particle)
    {
        Debug.Log(particle.tag + "Hit me");
        enemyStats.RecieveDamage(2f);
    }
}
