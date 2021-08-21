using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 2;
    public BirdMove bird;
    public GameObject pipes;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(PipesAppear());
    }

    
    public IEnumerator PipesAppear()
    {
        while(bird.isDead==false)
        {
            
            Instantiate(pipes, new Vector3(3, Random.Range(-1.15f, 0.35f),0), Quaternion.identity);
            yield return new WaitForSeconds(2);

        }
        
    }
}
