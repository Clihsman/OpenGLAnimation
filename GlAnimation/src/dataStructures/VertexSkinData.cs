using System.Collections.Generic;
using System;

namespace dataStructures
{
	public class VertexSkinData
	{
		public List<int> jointIds = new List<int> ();
		public List<float> weights = new List<float> ();

		public void addJointEffect (int jointId, float weight)
		{
			for (int i = 0; i < weights.Count; i++) 
			{
				if (weight > weights [i]) {
					jointIds.Insert (i,jointId);
					weights.Insert (i,weight);
					return;
				}

			}

			jointIds.Add (jointId);
			weights.Add (weight);

		}

		public void limitJointNumber (int max)
		{
			if (jointIds.Count > max) 
			{
				float[] topWeights = new float[max];
				float total = saveTopWeights (topWeights);
				refillWeightList (topWeights, total);
				removeExcessJointIds (max);
			} else if (jointIds.Count < max) {
				fillEmptyWeights (max);
			}
		}

		private void fillEmptyWeights (int max)
		{
			while (jointIds.Count < max) {
				jointIds.Add (0);
				weights.Add (0f);
			}
		}

		private float saveTopWeights (float[] topWeightsArray)
		{
			float total = 0;
			for (int i = 0; i < topWeightsArray.Length; i++) {
				topWeightsArray [i] = weights [i];
				total += topWeightsArray [i];
			}
			return total;
		}

		private void refillWeightList (float[] topWeights, float total)
		{
			weights.Clear ();
			for (int i = 0; i < topWeights.Length; i++) {
				weights.Add (Math.Min (topWeights [i] / total, 1));
			}
		}

		private void removeExcessJointIds (int max)
		{
			while (jointIds.Count > max) {
				jointIds.RemoveAt (jointIds.Count - 1);
			}
		}
	
	}

}
