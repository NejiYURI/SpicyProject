using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EdgeCollider2D))]
public class WallGenerator : MonoBehaviour
{
    public int edgeNums;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        EdgeCollider2D edgeCollider2D=GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[edgeNums + 1];

        for (int i = 0; i < edgeNums; i++)
        {
            float angle = 2 * Mathf.PI * i / edgeNums;
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);
        }
        points[edgeNums] = points[0];

        edgeCollider2D.points = points;
    }

   
}
