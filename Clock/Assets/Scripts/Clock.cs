using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;

    [SerializeField]
    Transform hourPivot, minutePivot, secondPivot;

    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
        minutePivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
    }
}