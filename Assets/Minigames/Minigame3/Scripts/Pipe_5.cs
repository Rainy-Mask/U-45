using UnityEngine;

public class Pipe_5 : MonoBehaviour
{
    [SerializeField] private GameObject pipe5;
    PipeController controller;

    private void Start()
    {
        controller = FindObjectOfType<PipeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe_5"))
        {
            controller.pipeCount--;
            Destroy(other.gameObject);
            pipe5.SetActive(true);
        }
    }
}
