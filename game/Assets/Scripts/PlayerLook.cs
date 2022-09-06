using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class PlayerLook : MonoBehaviour
{
    public static Sprite sprite = null;
    private static string spriteName = "icon_1";
    public static Color color = Color.white;
    private static string colorName = "red**";

    const string templateForSkinLogFile = "icon_1|red**";

    public static void SetSkinSprite(int num)
    {
        //log skin to file
        spriteName = $"icon_{num}";
        sprite = Resources.Load<Sprite>(spriteName);
        var fstream = File.Open("skin_log.txt", FileMode.OpenOrCreate);
        fstream.Write(Encoding.ASCII.GetBytes(spriteName + '|' + colorName));
        fstream.Close();
    }

    public static void SetSkinColor(string color_name)
    {
        //log color to file
        colorName = color_name;
        color = GetColor(color_name);
        var fstream = File.Open("skin_log.txt", FileMode.OpenOrCreate);
        fstream.Write(Encoding.ASCII.GetBytes(spriteName + '|' + colorName));
        fstream.Close();
    }

    public static Sprite GetCurrentSprite()
    {
        var fstream = File.Open("skin_log.txt", FileMode.OpenOrCreate);
        byte[] buffer = new byte[12];
        fstream.Read(buffer, 0, buffer.Length);
        var skin_info = Encoding.ASCII.GetString(buffer).Split('|');
        try
        {
            sprite = Resources.Load<Sprite>(skin_info[0]);
            if (sprite == null) throw new Exception();
        }
        catch (Exception)
        {
            RewriteLogFile(fstream);
        }
        fstream.Close();
        return sprite;
    }

    public static Color GetCurrentColor()
    {
        var fstream = File.Open("skin_log.txt", FileMode.OpenOrCreate);
        byte[] buffer = new byte[12];
        fstream.Read(buffer, 0, buffer.Length);
        try
        {
            var color = Encoding.ASCII.GetString(buffer).Split('|')[1];
            if (GetColor(color) == Color.white)
            {
                throw new Exception();
            }
        }
        catch (Exception)
        {
            RewriteLogFile(fstream);
        }
        fstream.Close();
        return color = GetColor(colorName);
    }

    static Color GetColor(string color_name)
    {
        switch (color_name)
        {
            case "red**": return Color.red;
            case "blue*": return Color.blue;
            case "green": return Color.green;
            case "cyan*": return Color.cyan;
            case "yellw": return Color.yellow;
            case "pink*": return Color.magenta;
            default: return Color.white;
        }
    }

    static void RewriteLogFile(FileStream fstream)
    {
        var skin_info = templateForSkinLogFile.Split('|');
        sprite = Resources.Load<Sprite>(skin_info[0]);
        spriteName = skin_info[0];
        color = GetColor(skin_info[1]);
        colorName = skin_info[1];
        fstream.Position = 0;
        fstream.Write(Encoding.ASCII.GetBytes(templateForSkinLogFile));
    }
}
