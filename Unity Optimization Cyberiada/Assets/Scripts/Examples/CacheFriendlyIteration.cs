using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Profiling;

public class CacheFriendlyIteration : MonoBehaviour
{
	public int lengthY = 100;
	public int lengthX = 100;

	private int[,] array;
	private int[][] array_of_arrays;

	// Start is called before the first frame update
	void Start()
	{
		array = new int[lengthY, lengthX];
		array_of_arrays = new int[lengthY][];

		for (int y = 0; y < lengthY; y++)
		{
			array_of_arrays[y] = new int[lengthX];
			for (int x = 0; x < lengthX; x++)
			{
				array[y, x] = Random.Range(-10, 10);
				array_of_arrays[x][y] = array[y, x];
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		int sum;

		Profiler.BeginSample("Bad interation");

		sum = 0;
		for (int x = 0; x < lengthX; x++)
		{
			for (int y = 0; y < lengthY; y++)
				sum += array[y, x];
		}

		Profiler.EndSample();

		Debug.Log($"Sum bad iteration: {sum}");

		Profiler.BeginSample("Good interation");

		sum = 0;
		for (int y = 0; y < lengthY; y++)
		{
			for (int x = 0; x < lengthX; x++)
				sum += array[y, x];
		}

		Profiler.EndSample();

		Profiler.BeginSample("Good interation with parallelism");

		sum = 0;
		Parallel.For(0, lengthY, (y) =>
		{
			for (int x = 0; x < lengthX; x++)
				sum += array_of_arrays[y][x];
		});

		Profiler.EndSample();

		Debug.Log($"Sum good iteration with parallelism: {sum}");
	}
}
