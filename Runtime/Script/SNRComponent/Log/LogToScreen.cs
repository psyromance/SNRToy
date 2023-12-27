using System.Collections.Generic;
using UnityEngine;

public class LogToScreen : MonoBehaviour
{
    public float screenWidth = 750;
    public float screenHeight = 1624;

    public int fontSize = 33;

    public int maxLines = 50;
    public int maxLineLength = 120;

    private string _logStr = "";

    private readonly List<string> _lines = new List<string>();



    void OnEnable() { Application.logMessageReceived += Log; }
    void OnDisable() { Application.logMessageReceived -= Log; }

    public void Log(string logString, string stackTrace, LogType type)
    {
        foreach (var line in logString.Split('\n'))
        {
            if (line.Length <= maxLineLength)
            {
                _lines.Add(line);
                continue;
            }
            var lineCount = line.Length / maxLineLength + 1;
            for (int i = 0; i < lineCount; i++)
            {
                if ((i + 1) * maxLineLength <= line.Length)
                {
                    _lines.Add(line.Substring(i * maxLineLength, maxLineLength));
                }
                else
                {
                    _lines.Add(line.Substring(i * maxLineLength, line.Length - i * maxLineLength));
                }
            }
        }
        if (_lines.Count > maxLines)
        {
            _lines.RemoveRange(0, _lines.Count - maxLines);
        }
        _logStr = string.Join("\n", _lines);
    }

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
           new Vector3(Screen.width / screenWidth, Screen.height / screenHeight, 1.0f));

        GUIStyle lbStyle = new GUIStyle();
        lbStyle.fontSize = fontSize;
        lbStyle.normal.textColor = new Color(255f / 256f, 255f / 256f, 256f / 256f, 256f / 256f);
        GUI.Label(new Rect(10, 10, 800, 370), _logStr, lbStyle);

    }
}
