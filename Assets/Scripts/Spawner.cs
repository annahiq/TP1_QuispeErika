using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject proyectil;

    void Start(){
        InvokeRepeating("CrearProyectil", 2f, 1f);
    }

    void CrearProyectil(){
        Instantiate(proyectil, transform.position, transform.rotation);
    }
}