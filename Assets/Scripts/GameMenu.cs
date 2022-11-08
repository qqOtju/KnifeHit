using System.IO;
using UnityEditor;
using UnityEngine;

//EditorWindow - не попадет в билд
public class GameMenu : MonoBehaviour
{
    [MenuItem("Game/Take screenshot")]
    public static void TakeScreenshot()
    {
        string path = "Screenshots";

        Directory.CreateDirectory(path);

        int i = 0;
        while (File.Exists(path + "/" + i + ".png")) i++;

        ScreenCapture.CaptureScreenshot(path + "/" + i + ".png");
    }
}
