using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float speed;
    public Vector3 target;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime);
        
        if(Vector3.Distance(gameObject.transform.position, target) < 0.1f) {
            Destroy(gameObject);
        }
    }
}
