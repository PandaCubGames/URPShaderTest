using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private Renderer material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>();
        material.material.SetColor("_Color", Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
