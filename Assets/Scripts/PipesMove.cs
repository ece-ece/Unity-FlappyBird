using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMove : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 5);
    }
    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(-1 * speed * Time.deltaTime, 0, 0);

    }

    
}
