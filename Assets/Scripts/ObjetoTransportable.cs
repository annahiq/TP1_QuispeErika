using UnityEngine;

public class ObjetoTransportable : MonoBehaviour
{
    public Transform puntoTransporte;

    private Rigidbody rb;
    private bool estaCerca = false;
    private bool estaAgarrado = false;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        if (estaCerca && Input.GetKeyDown(KeyCode.E)){
            if (!estaAgarrado){
                AgarrarObjeto();
            } else {
                SoltarObjeto();
            }
        }
    }

    void AgarrarObjeto(){
        estaAgarrado = true;
        rb.isKinematic = true;

        transform.SetParent(puntoTransporte);
        transform.localPosition = Vector3.zero;
    }

    void SoltarObjeto(){
        estaAgarrado = false;
        transform.SetParent(null);
        rb.isKinematic = false;
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            estaCerca = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            estaCerca = false;
        }
    }
}