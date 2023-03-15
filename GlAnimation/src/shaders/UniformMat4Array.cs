using System;
using lwjgl.vector;

namespace shaders
{
	public class UniformMat4Array : Uniform
	{
	
		private UniformMatrix[] matrixUniforms;

		public UniformMat4Array (String name, int size) : base (name)
		{
			matrixUniforms = new UniformMatrix[size];
			for (int i = 0; i < size; i++) {
				matrixUniforms [i] = new UniformMatrix (name + "[" + i + "]");
			}
		}

		public override void storeUniformLocation (int programID)
		{
			foreach (UniformMatrix matrixUniform in matrixUniforms) {
				matrixUniform.storeUniformLocation (programID);
			}
		}

		public void loadMatrixArray (Matrix4f[] matrices)
		{
			for (int i = 0; i < matrices.Length; i++) {
				matrixUniforms [i].loadMatrix (matrices [i]);
			//	Console.WriteLine (matrices[i].toString());
			}
		//	Environment.Exit (0);
		}
	}
}
