using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public int resistencia = 2; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(resistencia <= 1)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void RebotarBola()
    {
        
    }
}
