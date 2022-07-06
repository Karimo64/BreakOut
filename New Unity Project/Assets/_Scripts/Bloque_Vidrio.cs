using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Vidrio : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 1;
    }

    public override void RebotarBola()
    {
        base.RebotarBola();
    }
}
