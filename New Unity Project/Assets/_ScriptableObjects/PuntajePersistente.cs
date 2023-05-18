using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



//[CreateAssetMenu(fileName = "PuntajePersistente", menuName = "New Unity Project/PuntajePersistente", order = 0)]

public abstract class PuntajePersistente : ScriptableObject 
{
    public void Guardar(string NombreArchivo = null)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(ObtenerRuta(NombreArchivo));
        var json = JsonUtility.ToJson(this);

        bf.Serialize(file, json);
        file.Close();
    }


    public virtual void Cargar(string nombreArchivo = null)
    {
        if(File.Exists(ObtenerRuta(nombreArchivo)))
        {
            var bf = new BinaryFormatter();
            var archivo = File.Open(ObtenerRuta(nombreArchivo), FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(archivo),this);
            archivo.Close();
        }
    }

    public string ObtenerRuta(string nombreArchivo = null)
    {
        var nombreArchivoCompleto = string.IsNullOrEmpty(nombreArchivo) ? name : nombreArchivo;
        return string.Format("{0}/{1}.kioan", Application.persistentDataPath, nombreArchivoCompleto);
    }


}

