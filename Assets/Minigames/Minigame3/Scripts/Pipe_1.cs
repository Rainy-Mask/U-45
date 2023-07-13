using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_1 : MonoBehaviour
{
    [SerializeField] private GameObject pipe1;
    PipeController controller;

    private void Start()
    {
        controller = FindObjectOfType<PipeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe_1") || other.gameObject.CompareTag("Pipe_2"))
        {
            controller.pipeCount--;
            Destroy(other.gameObject);
            pipe1.SetActive(true);
        }
    }
}
