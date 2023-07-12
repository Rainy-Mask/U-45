using UnityEngine;

public class Pipe_2 : MonoBehaviour
{
    [SerializeField] private GameObject pipe2;
    PipeController controller;

    private void Start()
    {
        controller = FindObjectOfType<PipeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe_3"))
        {
            controller.pipeCount--;
            Destroy(other.gameObject);
            pipe2.SetActive(true);
        }
    }
}
