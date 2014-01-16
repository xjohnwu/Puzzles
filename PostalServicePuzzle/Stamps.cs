using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServicePuzzle
{
	class Stamps
	{
		private int[] _numOfStamps = new int[10000];


		public Stamps(IEnumerable<double> stamps)
		{
			InitialiseAvailableStamps(stamps);
		}

		private void InitialiseAvailableStamps(IEnumerable<double> stamps)
		{
			foreach (var stamp in stamps)
			{
				_numOfStamps[GetIndex(stamp)] = 1;
			}
		}

		private static int GetIndex(double postage)
		{
			int index = -1;
			if (postage >= 0.01D)
			{
				index = Convert.ToInt32(postage * 100) - 1;
			}
			return index;
		}

		/// <summary>
		/// Assuming that all the index below that postage is already calculated
		/// </summary>
		/// <param name="postage"></param>
		public int CalculateMinNumOfStampsNeeded(double postage)
		{
			int index = GetIndex(postage);
			int num = 0;
			if (index >= 0)
			{
				for (int i = index / 2; i >= 0; i--)
				{
					int subStepA = _numOfStamps[i];
					int subStepB = _numOfStamps[index - i - 1];

					int totalStep = subStepA + subStepB;

					if (_numOfStamps[index] == 0)
					{
						_numOfStamps[index] = totalStep;
					}
					else
					{
						_numOfStamps[index] = Math.Min(_numOfStamps[index], totalStep);
					}
				}

				num = _numOfStamps[index];
			}
			
			return num;
		}
	}
}
