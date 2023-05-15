using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDestroying : MonoBehaviour
{
    public int expValue = 1;
    void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if (!collider.CompareTag("Player")) return;
        ExpAttracting expatr = collider.transform.Find("MagneticField").GetComponent<ExpAttracting>();
        expatr.attractedObjects.Remove(gameObject);
        PlayerStats playerStats = collider.GetComponent<PlayerStats>();
        playerStats.RecieveEXP(expValue);
        Destroy(gameObject, 0f);
    }
}
