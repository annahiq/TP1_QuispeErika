using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public float velocidadExtra = 10f;
    public float duracion = 8f;
    private bool activo = false;

    private Collider powerUpCollider;
    private Renderer powerUpRenderer;

    void Awake(){
        powerUpCollider = GetComponent<Collider>();
        powerUpRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player") && !activo){
            StartCoroutine(ActivarPowerUp(other.gameObject));
        }
    }

    IEnumerator ActivarPowerUp(GameObject jugador){
        activo = true;

        MovementPlayer movimiento = jugador.GetComponent<MovementPlayer>();
        float velocidadOriginal = movimiento.speed;
        movimiento.speed = velocidadExtra;

        powerUpCollider.enabled = false;
        powerUpRenderer.enabled = false;

        yield return new WaitForSeconds(duracion);

        movimiento.speed = velocidadOriginal;

        powerUpCollider.enabled = true;
        powerUpRenderer.enabled = true;

        activo = false;
    }
}