using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomWalkMapGen))]
public class MapGenEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        RandomWalkMapGen mapgen = (RandomWalkMapGen)target;
        if(GUILayout.Button("Generate Map") && EditorApplication.isPlaying) {
            mapgen.GenerateMap();
        }
    }
}
