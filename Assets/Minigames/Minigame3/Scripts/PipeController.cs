using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PipeController : MonoBehaviour
{
    float Distance = 5;
    public bool isTaked = false;
    public Image cross;
    public Transform pivot;
    GameObject item;
    public int pipeCount = 5;
    public TextMeshPro pipeCountText;
    private void Update()
    {
        PipeCommands();
    }
    public void PipeCommands()
    {
        pipeCountText.text = pipeCount.ToString();
        if (pipeCount == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (isTaked)
        {
            if (item == null)
            {
                isTaked = false;
                //pipeCount--;
                return;
            }

            var objComp = item.GetComponent<T_Pipe>();
            if (!objComp.taken)
            {
                isTaked = false;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                objComp.Force();
                isTaked = false;
                objComp.taken = false;

            }
            if (objComp.hasDestroyed)
            {
                isTaked = false;
            }
            cross.color = Color.white;
        }
        if (!isTaked)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, Distance * 2) && hit.collider.gameObject.layer == LayerMask.NameToLayer("pickable"))
            {
                cross.color = Color.red;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    item = hit.collider.gameObject;
                    item.GetComponent<T_Pipe>().hasReseted = false;
                    item.GetComponent<T_Pipe>().taken = true;
                    isTaked = true;
                }
            }
            else
            {
                cross.color = Color.white;
            }
        }
    }

}


