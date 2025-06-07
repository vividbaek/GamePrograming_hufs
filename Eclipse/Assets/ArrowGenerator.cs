using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab2;
    float span = 1.0f;
    float delta = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab2);
            int px = Random.Range(0, 9);
            int py = 8;
            go.transform.position = new Vector3(px, py, 0);
        }
    }
}
