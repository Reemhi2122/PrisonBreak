using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class NameGenerator
{
    private static List<string> names = new List<string>();

    public static string GetName()
    {
        if (names.Count == 0)
        {
            StreamReader sr = File.OpenText(Application.streamingAssetsPath + "/Names.txt");
            names = sr.ReadToEnd().Split("\n"[0]).ToList();
        }

        int randNum = Random.Range(1, names.Count);
        string curName = names[randNum];
        return curName;
    }
}
