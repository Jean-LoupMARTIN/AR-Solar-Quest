
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class STMan : MonoBehaviour
{
    public static STMan inst;

    public float smoothTranslate_t;
    public AnimationCurve smoothTranslate_curve;

    public ARRaycastManager arRaycastManager;

    public SmoothTranslate target;
    public TMP_Text searchPlane, tapeToPlace;

    void Awake() { inst = this; }


    void Update()
    {
        if (target)
        {
            bool test = ProjectMan.test;
            Camera cam = ProjectMan.inst.cam;
            Vector3 pos;

            if ((test && Tool.MouseHit(cam, out pos, ProjectMan.LayerMask_NAR_Ground)) ||
                (!test && Tool.ScreenCenterHitAR(ProjectMan.inst.cam, arRaycastManager, out pos)))
            {
                // position
                target.SetTarget(pos);

                // active
                if (!target.gameObject.active) {
                    target.gameObject.SetActive(true);
                    searchPlane.gameObject.SetActive(false);
                    tapeToPlace.gameObject.SetActive(true);
                }
            }


            if (target.gameObject.active && Tool.Click()) {
                target = null;
                tapeToPlace.gameObject.SetActive(false);
            }
        }
    }


    public void SetTarget(SmoothTranslate target)
    {
        this.target = target;
        tapeToPlace.gameObject.SetActive(true);
    }
}
