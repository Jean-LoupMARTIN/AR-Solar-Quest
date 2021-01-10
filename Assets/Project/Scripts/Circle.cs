using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Circle : MonoBehaviour
{
    public Transform center;
    public float radius = 1;
    int segments;
    LineRenderer line;


    public void Awake()
    {
        if (!center) center = transform;
        Draw();
    }

    public void Draw()
    {
        segments = (int)(10 * radius);
        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, 0, y) + (center.position - transform.position) / transform.lossyScale.x);

            angle += (360f / segments);
        }
    }
}