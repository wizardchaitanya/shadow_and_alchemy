using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public Transform footPoint;        // Player Foot Position
    public Transform lightSource;   // Sun / Moon

    //public float shadowDistance = 0.5f;
    public float maxLightDistance = 10f;
    public float baseLength = 0.4f;
    public float maxLength = 1.5f;

    void Update()
    {
        if (!footPoint || !lightSource) return;

        ShadowBehavior();
    }

    void ShadowBehavior()
    {
        // Direction away from light
        Vector2 dir = (footPoint.position - lightSource.position).normalized;
        // Distance from light
        float dist = Vector2.Distance(footPoint.position, lightSource.position);
        // Shadow length
        float length = Mathf.Lerp(baseLength, maxLength, dist / maxLightDistance);
        // Rotation
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        // Scale ONLY in Y (because pivot is at bottom)
        transform.localScale = new Vector3(length, 1f, 1f);
        // Position stays locked to player's feet
        transform.position = footPoint.position + (Vector3)(0.5f * Vector2.up);
    }
}
