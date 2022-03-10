using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectsSpawner : ScriptableWizard
{
    private static Transform parent;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int rows = 100;
    [SerializeField] private int columns = 100;
    [SerializeField] private float positionOffset = 1.5f;

    [MenuItem("GameObject/SpawnObjects")]
    static void CreateWizard(MenuCommand command)
    {
        parent = ((GameObject)command.context).transform;
        ScriptableWizard.DisplayWizard<ObjectsSpawner>("Spawn Objects", "Spawn");
    }
        
    private void OnWizardCreate()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Transform newObjTransform = (PrefabUtility.InstantiatePrefab(objectToSpawn, parent) as GameObject).transform;
                newObjTransform.position = new Vector3(i * positionOffset, 0, j* positionOffset);
            }
        }
    }
}
