/* 
This is a VERY quick and dirty, but useful script for replacing the terrain splatmap with an imported one from World Machine.

This script is released into the public domain; you may do whatever you want with it!

To use:

1) Import the new Splat map as an asset
2) Change the type of it to Advanced, Readable/Writeable, ARGB32 and Nearest power of two.
3) Invoke the script from the Terrain menu

Two things of note:

 * Note that you will need to first create an original splatmap before being able to replace it. To do this, save your world and setup your textures, etc first. 
 * Note that World Machine by default considers the texture origin to be the bottom-left, not the top-left.

 Updated for C# on 2/12/2019 by Stephen Schmitt

*/ 

using UnityEditor;
using UnityEngine;

public class WizardReplaceSplatmap : ScriptableWizard
{
    public Texture2D splatmap;
    public Texture2D newsplat;
    public bool flipVertical;


    WizardReplaceSplatmap()
    {
        flipVertical = true;
        newsplat = null;
        splatmap = null;
    }

    [MenuItem("Terrain/Replace Splatmap (from WM)")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<WizardReplaceSplatmap>("Replace Splatmap", "Replace");
    }

    void OnWizardCreate()
    {
        if (newsplat.format != TextureFormat.RGBA32 && newsplat.format != TextureFormat.ARGB32 && newsplat.format != TextureFormat.RGB24)
        {
            EditorUtility.DisplayDialog("Wrong format", "Your new splatmap must be set to the RGBA 32 bit format in the Texture Inspector.\nMake sure the type is Advanced and set the format!", "Cancel");
            return;
        }
        int w = newsplat.width;

        if (Mathf.ClosestPowerOfTwo(w) != w)
        {
            EditorUtility.DisplayDialog("Wrong size", "Splatmap width and height must be a power of two!", "Cancel");
            return;
        }

        try
        {
            var pixels = newsplat.GetPixels();
            if (flipVertical)
            {
                var h = w; // always square in unity
                for (var y = 0; y < h / 2; y++)
                {
                    var otherY = h - y - 1;
                    for (var x = 0; x < w; x++)
                    {
                        var swapval = pixels[y * w + x];
                        pixels[y * w + x] = pixels[otherY * w + x];
                        pixels[otherY * w + x] = swapval;
                    }
                }
            }
            splatmap.Resize(newsplat.width, newsplat.height, newsplat.format, true);
            splatmap.SetPixels(pixels);
            splatmap.Apply();
        }
        catch (UnityException)
        {
            EditorUtility.DisplayDialog("Not readable", "The 'New' splatmap must be readable. Make sure the type is Advanced and enable read/write and try again!", "Cancel");
            return;
        }

    }

    void OnWizardUpdate()
    {
        helpString = "Replace the existing splatmap of your terrain with a new one.\n1) Drag the embedded splatmap texture of your terrain to the 'Splatmap box'.\n2) Then drag the replacement splatmap texture to the 'New' box\n3) Then hit 'Replace'.";
        isValid = (splatmap != null) && (newsplat != null);
    }
}