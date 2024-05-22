using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownDificultad : MonoBehaviour
{
    public Opciones opciones;
    private Dropdown dificultad;
    private Bloque[] allBlocks;

    public void Start()
    {
        dificultad = GetComponent<Dropdown>();
        dificultad.onValueChanged.AddListener(delegate { UpdateDifficulty(); });
        
        allBlocks = FindObjectsOfType<Bloque>();
    }

    private void UpdateDifficulty()
    {
        opciones.CambiarDificultad(dificultad.value);

        foreach (var block in allBlocks)
        {
            block.UpdateResistanceBasedOnDifficulty();
        }
    }
}
