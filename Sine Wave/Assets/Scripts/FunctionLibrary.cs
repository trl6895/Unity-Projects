using static UnityEngine.Mathf; // make all static members of Mathf available implicitly

public static class FunctionLibrary
{
    public delegate float Function(float x, float z, float t);

    public enum FunctionName { Wave, MultiWave, Ripple }

    static Function[] functions = { Wave, Multiwave, Ripple };

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }

    public static float Wave(float x, float z, float t)
    {
        return Sin(PI * (x + t));
    }

    public static float Multiwave(float x, float z, float t)
    {
        float y = Sin(PI * (x + (0.5f * t)));
        y += Sin(2f * PI * (x + t)) * (1f / 2f); // 1f/2f reduced to 0.5f by compiler. avoid dividing constants from non-constants (so use * 0.5f instead of / 2f)
        return y * (2f / 3f);
    }

    public static float Ripple(float x, float z, float t)
    {
        float d = Abs(x);
        float y = Sin(PI * ((4f * d) - t));
        return y / (1f + (10f * d));
    }

}
