
using UnityEngine;



public class SmoothTranslate : MonoBehaviour
{
    float t;


    Vector3 target, lastPos;

    void Start() { t = STMan.inst.smoothTranslate_t; }

    void Update()
    {
        if (t < STMan.inst.smoothTranslate_t)
        {
            t += Time.deltaTime;
            float progress = Tool.Progress(t, STMan.inst.smoothTranslate_t);
            if (progress >= 1) transform.position = target;
            else transform.position = lastPos + (target - lastPos) * STMan.inst.smoothTranslate_curve.Evaluate(progress);
        }
    }

    public void SetTarget(Vector3 target)
    {
        if (gameObject.active)
        {
            this.target = target;
            lastPos = transform.position;
            t = 0;
        }
        else transform.position = target;
    }
}
