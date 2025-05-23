using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToAndFro : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform Player;
    Vector3 differenceVector;
    float distance;
    Vector3 direction;
    [SerializeField] TextMeshProUGUI stopwatch;
    float time = 0;
    float duration;
    bool FromAToB = true;

    void Start()
    {
        Debug.Log(distance);
        Player.position = A.position;
    }

    void Update()
    {
        if (FromAToB)
        {
            differenceVector = B.position - A.position;
        }
        else
        {
            differenceVector = A.position - B.position;
        }
        distance = differenceVector.magnitude;
        duration = distance / 1;
        direction = differenceVector.normalized;

        Player.position += direction * Time.deltaTime;
        time += Time.deltaTime;
        stopwatch.text = time.ToString("F3");

        if (time > duration)
        {
            FromAToB = !FromAToB;
            time = 0;
        }
    }
}
