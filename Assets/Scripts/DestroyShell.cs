using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShell : MonoBehaviour
{
    private float currentLifeTime;
    public float maxLifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentLifeTime += 0.2f * Time.deltaTime;

        if(currentLifeTime >= maxLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
