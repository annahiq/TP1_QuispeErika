using UnityEngine;

public class MovingStep : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 4f;

    private Vector3 extendedPosition;
    private Vector3 retractedPosition;

    private bool isExtending = false;
    private bool isRetracting = false;

    void Start(){
        extendedPosition = transform.position;
        retractedPosition = extendedPosition + Vector3.forward * moveDistance;
        transform.position = retractedPosition;
    }

    void Update(){
        if (isExtending){
            transform.position = Vector3.MoveTowards(transform.position, extendedPosition, moveSpeed * Time.deltaTime);
            if (transform.position == extendedPosition){
                isExtending = false;
            }
        }

        if (isRetracting){
            transform.position = Vector3.MoveTowards(transform.position, retractedPosition, moveSpeed * Time.deltaTime);
            if (transform.position == retractedPosition){
                isRetracting = false;
            }
        }
    }
    public void ExtendStep(){
        isExtending = true;
    }

    public void RetractStep(){
        isRetracting = true;
    }
}