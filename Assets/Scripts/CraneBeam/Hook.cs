using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private Transform target;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();        
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, target.position);
        lineRenderer.SetPosition(1, transform.position);
    }
}
