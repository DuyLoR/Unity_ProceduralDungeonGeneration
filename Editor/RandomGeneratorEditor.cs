using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

//
// Summary:
//     Defines which object type the custom editor class can edit.
//
// Parameters:
//   inspectedType:
//     Type that this editor can edit.
//
//   editorForChildClasses:
//     If true, child classes of inspectedType will also show this editor. Defaults
//     to false.
[CustomEditor(typeof(AbstractDungeonGenerator), true)]
public class RandomGeneratorEditor : Editor
{
    AbstractDungeonGenerator generator;
    private void Awake()
    {
        generator = (AbstractDungeonGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate button"))
        {
            generator.GenerateDungeon();
        }
    }
}
