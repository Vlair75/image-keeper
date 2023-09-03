using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecsInfoText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI operationSystemText;
    public TextMeshProUGUI windowScreenResolution;
    [SerializeField] private TextMeshProUGUI screenResolutionText;
    [SerializeField] private TextMeshProUGUI graphicApiText;
    [SerializeField] private TextMeshProUGUI maxTextureSizeText;
    [SerializeField] private TextMeshProUGUI shaderLevelText;
    [SerializeField] private TextMeshProUGUI graphicsText;
    [SerializeField] private TextMeshProUGUI vramText;
    [SerializeField] private TextMeshProUGUI processorText;
    [SerializeField] private TextMeshProUGUI ramText;

    private void Awake()
    {
        windowScreenResolution.text
            = "<b>Window:</b> "
            + Screen.width.ToString()
            + "x"
            + Screen.height.ToString()
            + "@"
            + Screen.currentResolution.refreshRate.ToString()
            + "Hz"
            + "["
            + ((int)Screen.dpi).ToString()
            + "dpi]";

        Resolution res = Screen.currentResolution;

        screenResolutionText.text
            = "<b>Screen:</b> "
            + res.width
            + "x"
            + res.height
            + "@"
            + res.refreshRate
            + "Hz";

        processorText.text
            = "<b>CPU:</b> "
            + SystemInfo.processorType
            + " ["
            + SystemInfo.processorCount
            + " cores]";

        ramText.text
            = "<b>RAM:</b> "
            + SystemInfo.systemMemorySize
            + " MB";

        graphicApiText.text
            = "<b>Graphics API:</b> "
            + SystemInfo.graphicsDeviceVersion;

        maxTextureSizeText.text
            = "<b>Max texture size:</b> "
            + SystemInfo.maxTextureSize + "px.";

        shaderLevelText.text
            = "<b>Shader level:</b> "
            + SystemInfo.graphicsShaderLevel;

        graphicsText.text
            = "<b>GPU:</b> "
            + SystemInfo.graphicsDeviceName;

        vramText.text
            = "<b>VRAM:</b> "
            + SystemInfo.graphicsMemorySize
            + " MB";

        operationSystemText.text
            = "<b>" + SystemInfo.operatingSystem
            + "</b> [" + SystemInfo.deviceType + ']';

    }
}
