using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Screenshot{

    static string pathToScreenshot;

    public static void captureScreenshot()
    {
        ScreenCapture.CaptureScreenshot("screenshot");
        pathToScreenshot = Application.persistentDataPath + "/" + "screenshot";
    }

    public static void loadScreenshot()
    {

    }
}
