using System;
using System.Collections.Generic;

namespace GlAnimation
{
	public static class ColladaUtils
	{
		public static int[] toInts(string input){
			string[] currentInput = input.Split (' ');
			List<int> data = new List<int> ();

			for (int i = 0; i < currentInput.Length; i++) {
				if (!string.IsNullOrWhiteSpace (currentInput [i])) {
					data.Add (int.Parse (currentInput[i]));
				}
			}
			return data.ToArray();
		}

		public static float[] toFloats(string input){
			string[] currentInput = input.Split (' ');
			float[] data = new float[currentInput.Length];
			for (int i = 0; i < currentInput.Length; i++) {
				data[i] = float.Parse (currentInput[i].Replace('.',','));
			}
			return data;
		}
	}
}

