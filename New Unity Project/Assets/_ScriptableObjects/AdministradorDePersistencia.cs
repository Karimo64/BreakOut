using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDePersistencia : MonoBehaviour
{
    public List<PuntajePersistente> ObjetosAGuardar;

    private void OnEnable() 
    {
        for ( int i = 0; i< ObjetosAGuardar.Count; i++)
        {
            var so = ObjetosAGuardar[i];
            so.Cargar();
        }    
    }

    public void OnDisable()
    {
        for ( int i = 0; i< ObjetosAGuardar.Count; i++)
        {
            var so = ObjetosAGuardar[i];
            so.Guardar();
        }   
    }
}
