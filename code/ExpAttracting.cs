using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpAttracting : MonoBehaviour
{
    public float magnetingForce = 10f;
    public float magneticDistance = 5f;
    public List<GameObject> attractedObjects = new List<GameObject>();

    void Start()
    {
        transform.localScale = new Vector3(magneticDistance, magneticDistance, magneticDistance);
    }

    void FixedUpdate()
    {
        foreach (GameObject attractedObject in attractedObjects)
        {
            Vector3 direction = transform.parent.position - attractedObject.transform.position;
            attractedObject.GetComponent<Rigidbody>().AddForce(direction.normalized * magnetingForce);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("EXP")) return;
        attractedObjects.Add(collider.gameObject);
    }
    void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("EXP")) return;
        attractedObjects.Remove(collider.gameObject);
    }
}
