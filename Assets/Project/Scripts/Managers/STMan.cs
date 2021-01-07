
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class STMan : MonoBehaviour
{
    public static STMan inst;

    public float smoothTranslate_t;
    public AnimationCurve smoothTranslate_curve;

    public ARRaycastManager arRaycastManager;

    public SmoothTranslate target;


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
                // rotation
                Vector3 camProj = cam.transform.position;
                camProj.y = pos.y;
                Tool.LookDir(target, Tool.Dir(camProj, pos, false));

                // position
                target.SetTarget(pos);

                // active
                if (!target.gameObject.active)
                    target.gameObject.SetActive(true);
            }


            if (target.gameObject.active && Tool.Click())
                target = null;
        }
    }
}
