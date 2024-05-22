using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Vidrio : Bloque
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}
