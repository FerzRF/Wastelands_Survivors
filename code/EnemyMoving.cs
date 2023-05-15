using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public GameObject target;
    public float rotation_speed;
    public float movement_speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            Quaternion targetQuaterion = Quaternion.Euler(0, targetAngle, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaterion, rotation_speed*Time.deltaTime);
            transform.position += transform.forward * movement_speed * Time.deltaTime;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
