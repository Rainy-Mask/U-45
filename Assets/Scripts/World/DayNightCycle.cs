using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private float dayDuration = 60f; // Tam bir günün saniye cinsinden süresi

    private void Start()
    {
        // Geçerli zamana göre güneşin dönüşü
        float initialRotation = (Time.time / dayDuration) * 360f;
        transform.eulerAngles = new Vector3(initialRotation, 0f, 0f);
    }

    private void Update()
    {
        // Gündüz ve gece döngüsünü simüle etmek için güneşin dönüşü
        transform.Rotate(Vector3.right, (360f / dayDuration) * Time.deltaTime);
    }
}
