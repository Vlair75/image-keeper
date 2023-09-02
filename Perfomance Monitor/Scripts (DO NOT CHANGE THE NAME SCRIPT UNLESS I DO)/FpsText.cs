using System;
using UnityEngine;
using TMPro;
public class FpsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI low1PercentFpsText;
    [SerializeField] private TextMeshProUGUI low01PercentFpsText;
    [SerializeField] private TextMeshProUGUI averageFpsText;
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private TextMeshProUGUI fpsMsText;

    private int fpsSamplesCapacity = 1024;
    private int onePercentSamples = 10;
    private int zeroOnePercentSamples = 1;
    private int fpsSamplesCount = 0;
    private int indexSample = 0;

    private int updateInterval = 10;
    private int frames = 0;
    private float deltaTime = 0;

    private int[] fpsSamples;
    private int[] fpsSamplesSorted;
    private float currentFPS = 0;
    private float msFPS = 0;
    private float averageFPS = 0;
    private float onePercentFPS = 0;
    private float zeroOnePercentFPS = 0;

    private string msFormat = ".0";

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        // Update fps and ms

        deltaTime += Time.unscaledDeltaTime;
        frames++;
        if (deltaTime > 1 / updateInterval)
        {
            currentFPS = frames / deltaTime;
            msFPS = deltaTime / frames * 1000;

            fpsText.text = Mathf.RoundToInt(currentFPS).ToString() + " fps";
            fpsMsText.text = msFPS.ToString(msFormat) + " ms";

            deltaTime = 0;
            frames = 0;
        }

        // Update avg fps

        int averageAddedFps = 0;

        indexSample++;

        if (indexSample >= fpsSamplesCapacity) indexSample = 0;

        fpsSamples[indexSample] = ((int)currentFPS);

        if (fpsSamplesCount < fpsSamplesCapacity) fpsSamplesCount++;

        for (int i = 0; i < fpsSamplesCount; i++) averageAddedFps += fpsSamples[i];

        averageFPS = averageAddedFps / fpsSamplesCount;
        averageFpsText.text = Mathf.RoundToInt(averageFPS).ToString();

        // Update percent lows

        Array.Copy(fpsSamples, fpsSamplesSorted, fpsSamplesCount);
        Array.Sort(fpsSamplesSorted);

        int totalAddedFps = 0;

        int samplesToIterateThroughForOnePercent = Mathf.Min(fpsSamplesCount, onePercentSamples);
        int samplesToIterateThroughForZeroOnePercent = Mathf.Min(fpsSamplesCount, zeroOnePercentSamples);

        int sampleToStartIn = fpsSamplesCapacity - fpsSamplesCount;

        bool zeroOnePercentCalculated = false;

        for (int i = sampleToStartIn; i < sampleToStartIn + samplesToIterateThroughForOnePercent; i++)
        {
            totalAddedFps += fpsSamplesSorted[i];

            if (!zeroOnePercentCalculated && i >= samplesToIterateThroughForZeroOnePercent - 1)
            {
                zeroOnePercentCalculated = true;

                zeroOnePercentFPS = totalAddedFps / zeroOnePercentSamples;
            }
        }

        onePercentFPS = totalAddedFps / onePercentSamples;
        low01PercentFpsText.text = Mathf.RoundToInt(zeroOnePercentFPS).ToString();
        low1PercentFpsText.text = Mathf.RoundToInt(onePercentFPS).ToString();

    }

    private void Init()
    {
        fpsSamples = new int[fpsSamplesCapacity];
        fpsSamplesSorted = new int[fpsSamplesCapacity];

        UpdateParameters();
    }

    public void UpdateParameters()
    {
        onePercentSamples = fpsSamplesCapacity / 100;
        zeroOnePercentSamples = fpsSamplesCapacity / 1000;
    }
}
