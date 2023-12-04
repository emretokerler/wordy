using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static Bounds GetMaxBounds(this Transform t)
    {
        var renderers = t.GetComponentsInChildren<Renderer>();
        var bounds = new Bounds(t.position, Vector3.zero);

        foreach (var r in renderers)
        {
            bounds.Encapsulate(r.bounds);
        }

        return bounds;
    }
}
