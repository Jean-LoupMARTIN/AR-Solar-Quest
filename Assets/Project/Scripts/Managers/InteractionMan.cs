
using UnityEngine;
using UnityEngine.UI;

public class InteractionMan : MonoBehaviour
{
    public static InteractionMan inst;

    public float scaleSpeed = 1, rotSpeed = 1;
    public Transform target;
    bool fingers;
    Vector2 finger1, finger2;

    void Awake() { inst = this; }

    public Text aze;

    void Update()
    {
        if (target) {

            if (!fingers) {
                if (Input.touchCount >= 2) {
                    fingers = true;
                    finger1 = Input.GetTouch(0).position;
                    finger2 = Input.GetTouch(1).position;
                    aze.text = finger1.ToString();
                }
            }

            else {
                if (Input.touchCount < 2)
                    fingers = false;

                else {
                    Vector2 newFinger1 = Input.GetTouch(0).position;
                    Vector2 newFinger2 = Input.GetTouch(1).position;
                    Vector2 dNewFinger = newFinger1 - newFinger2;
                    Vector2 dLastFinger = finger1 - finger2;

                    
                    // scale
                    float lastDist = dLastFinger.magnitude;
                    float newDist = dNewFinger.magnitude;

                    float dDist = newDist - lastDist;
                    float dScale = dDist / 1000 * scaleSpeed;
                    target.localScale += dScale * Vector3.one;

                    // rotation
                    float lastAngle = Tool.Angle(dLastFinger);
                    float newAngle = Tool.Angle(dNewFinger);
                    float rot = newAngle - lastAngle;

                    finger1 = newFinger1;
                    finger2 = newFinger2;
                }
            }

            target.Rotate(0, 1, 0);

        }
    }
}
