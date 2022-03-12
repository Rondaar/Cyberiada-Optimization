using UnityEditor;
using UnityEngine;

public class ObjectsSpawner3D : ScriptableWizard
{
    private static Transform parent;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Vector3 spawnRange = Vector3.one;
    [SerializeField] private int numberOfObjects = 100;

    [MenuItem("GameObject/SpawnObjects3D")]
    static void CreateWizard(MenuCommand command)
    {
        parent = ((GameObject)command.context).transform;
        ScriptableWizard.DisplayWizard<ObjectsSpawner3D>("Spawn Objects", "Spawn");
    }
        
    private void OnWizardCreate()
    {
		for (int i = 0; i < numberOfObjects; i++)
		{
            var obj = Instantiate(objectToSpawn);
            obj.transform.SetParent(parent);
            obj.transform.localPosition = RandomPosition();
		}
    }

    private Vector3 RandomPosition()
	{
        return new Vector3(Random.Range(-spawnRange.x, spawnRange.x), Random.Range(-spawnRange.y, spawnRange.y), Random.Range(-spawnRange.z, spawnRange.z));
	}

	private void OnValidate()
	{
        spawnRange.x = Mathf.Max(0.0f, spawnRange.x);
        spawnRange.y = Mathf.Max(0.0f, spawnRange.y);
        spawnRange.z = Mathf.Max(0.0f, spawnRange.z);
    }
}
