﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator))]
public class MapEdiort : Editor
{

    public override void OnInspectorGUI()
    {
        MapGenerator map = target as MapGenerator;
        if (DrawDefaultInspector()) {
            map.GenerateMap();
        }

        if (GUILayout.Button("generate map"))
        {
            map.GenerateMap();
        }

    }
}
