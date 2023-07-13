using UnityEngine;

public class Pipe_4 : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    PipeController controller;

    private void Start()
    {
        controller = FindObjectOfType<PipeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe_4"))
        {
            controller.pipeCount--;
            Destroy(other.gameObject);
            pipe.SetActive(true);
        }
    }
}
