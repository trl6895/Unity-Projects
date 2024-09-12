using TMPro;
using UnityEngine;
public class FrameRateCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI display;

    public enum DisplayMode { FPS, MS }

    [SerializeField]
    DisplayMode displayMode = DisplayMode.FPS;

    [SerializeField, Range(0.1f, 2f)]
    float sampleDuration = 1f;

    int frames;
    // you want the durations to be small, so the best duration would be closest to zero
    float duration, bestDuration = float.MaxValue, worstDuration;

    private void Update()
    {
        float frameDur = Time.unscaledDeltaTime;
        // used to get avg fps over a sample period
        frames++;
        duration += frameDur;

        if (frameDur < bestDuration)
        {
            bestDuration = frameDur;
        }

        if (frameDur > worstDuration)
        {
            worstDuration = frameDur;
        }

        if (duration >= sampleDuration)
        {
            if (displayMode == DisplayMode.FPS)
            {
                // display the avg frame rate over this duration, shortest frameDur of this duration, longest frameDur of this duration
                display.SetText("FPS\n{0:1}\n{1:1}\n{2:1}", frames / duration, 1f / bestDuration, 1f / worstDuration);
            }
            else
            {
                display.SetText("MS\n{0:1}\n{1:1}\n{2:1}", 1000f * (duration / frames), 1000f * bestDuration, 1000f * worstDuration);
            }
            frames = 0;
            duration = 0f;
            bestDuration = float.MaxValue;
            worstDuration = 0f;
        }

    }
}
