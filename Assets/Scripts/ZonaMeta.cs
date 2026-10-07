using UnityEngine;

public class ZonaMeta : MonoBehaviour
{
    public Transform puntoTransporte;
    public GameObject mensajeVictoria;

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            if (puntoTransporte.childCount > 0){
                Debug.Log("Objeto entregado. ¡Victoria!");
                mensajeVictoria.SetActive(true);
            } else {
                Debug.Log("Necesitás llevar el objeto.");
            }
        }
    }
}