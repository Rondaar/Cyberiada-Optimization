using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class AlgorithmPerformance : MonoBehaviour
{
    public class ExampleClass
	{
        public string str;
        public int integer;
        public float someNumber;

		public ExampleClass()
		{
			this.str = Random.Range(10000, 1000000).ToString();
			this.integer = Random.Range(10000, 1000000);
			this.someNumber = Random.Range(10000, 1000000);
		}
	}

    [SerializeField] private int numberOfElements = 10000;

    public List<ExampleClass> originalList = new List<ExampleClass>();
    public List<ExampleClass> operationalList = new List<ExampleClass>();
	public List<ExampleClass> operationalList_cache = new List<ExampleClass>();

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < numberOfElements; i++)
		{
            originalList.Add(new ExampleClass());
		}
    }

    // Update is called once per frame
    void Update()
	{
		ResetOperationalList();

		Profiler.BeginSample("Remove 1/10 elements");

		for (int i = 0; i < operationalList.Count; i++)
		{
			if (i % 10 == 0)
			{
				operationalList.RemoveAt(i);
				i--;
			}
		}

		Profiler.EndSample();

		ResetOperationalList();

		Profiler.BeginSample("Remove 1/10 elements - optimized");

		for (int i = operationalList.Count - 1; i >= 0; i--)
		{
			if (i % 10 == 0)
				operationalList.RemoveAt(i);
		}

		Profiler.EndSample();

		ResetOperationalList();

		Profiler.BeginSample("Remove 1/10 elements - optimized - cache friendly");

		operationalList_cache.Clear();

		for (int i = 0; i < operationalList.Count; i++)
		{
			if (i % 10 == 0)
				operationalList_cache.Add(operationalList[i]);
		}

		operationalList.Clear();
		operationalList.AddRange(operationalList_cache);

		Profiler.EndSample();
	}

	private void ResetOperationalList()
	{
		operationalList.Clear();
		operationalList.AddRange(originalList);
	}
}
