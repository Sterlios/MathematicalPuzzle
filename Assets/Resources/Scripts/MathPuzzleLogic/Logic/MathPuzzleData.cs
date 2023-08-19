
namespace MathPuzzleLogic.Logic
{
	public class MathPuzzleData
	{
		public MathPuzzleData(int[,] numbers, int goal)
		{
			Numbers = numbers;
			Goal = goal;
		}

		public int [,] Numbers { get; set; }
		public int Goal { get; set; }
	}
}
