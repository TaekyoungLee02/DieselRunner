using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField][Range(-1.0f, 1.0f)]
    private float moveSpeed = 0.1f;

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed * 10);
    }
}
