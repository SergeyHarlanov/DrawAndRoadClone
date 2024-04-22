using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private DrawingLine _drawingLine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _drawingLine.LevelFinish();
        }
    }
}
