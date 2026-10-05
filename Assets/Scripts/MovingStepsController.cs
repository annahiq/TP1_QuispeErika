using UnityEngine;

public class MovingStepsController : MonoBehaviour
{
    public MovingStep step01;
    public MovingStep step02;
    public MovingStep step03;

    void Start(){
        Invoke("StartStep01", 2f);
    }

    void StartStep01(){
        step01.ExtendStep();
        Invoke("StartStep02", 1f);
    }
    void StartStep02(){
        step02.ExtendStep();
        Invoke("StartStep03", 1f);
    }
    void StartStep03(){
        step03.ExtendStep();
        Invoke("RetractStep01", 2f);
    }

    void RetractStep01(){
        step01.RetractStep();
        Invoke("RetractStep02", 1f);
    }

    void RetractStep02(){
        step02.RetractStep();
        Invoke("RetractStep03", 1f);
    }

    void RetractStep03(){
        step03.RetractStep();
        Invoke("StartStep01", 2f);
    }
}