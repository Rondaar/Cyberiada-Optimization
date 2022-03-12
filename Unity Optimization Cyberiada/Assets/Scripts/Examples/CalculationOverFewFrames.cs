using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class CalculationOverFewFrames : MonoBehaviour
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
	[SerializeField] private int calculationBatchSize;

	public List<ExampleClass> originalList = new List<ExampleClass>();
	public List<ExampleClass> operationalList = new List<ExampleClass>();
	public List<ExampleClass> operationalList_cache = new List<ExampleClass>();

	Coroutine calculateCoroutine = null;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < numberOfElements; i++)
		{
			originalList.Add(new ExampleClass());
		}
	}

	private void ResetOperationalList()
	{
		operationalList.Clear();
		operationalList.AddRange(originalList);
	}

	// Update is called once per frame
	void Update()
	{
		if (calculateCoroutine == null)
		{
			ResetOperationalList();
			calculateCoroutine = StartCoroutine(CalculateCoroutine());
		}
	}

	private IEnumerator CalculateCoroutine()
	{
		operationalList_cache.Clear();

		for (int i = 0; i < operationalList.Count; i++)
		{
			if (i % 10 == 0)
				operationalList_cache.Add(operationalList[i]);

			if (i % calculationBatchSize == 0)
				yield return null;
		}

		operationalList.Clear();
		operationalList.AddRange(operationalList_cache);

		calculateCoroutine = null;
	}
}
