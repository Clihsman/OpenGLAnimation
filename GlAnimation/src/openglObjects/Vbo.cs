using OpenTK.Graphics.OpenGL;
using System;

namespace openglObjects
{
	public class Vbo
	{
		private int vboId;
		private BufferTarget type;

		private Vbo (int vboId, BufferTarget type)
		{
			this.vboId = vboId;
			this.type = type;
		}

		public static Vbo create (BufferTarget type)
		{
			int id = GL.GenBuffer ();
			return new Vbo (id, type);
		}

		public void bind ()
		{
			GL.BindBuffer (type, vboId);
		}

		public void unbind ()
		{
			GL.BindBuffer (type, 0);
		}

		public void storeData (float[] data)
		{
			int sizeInBytes = sizeof(float) * data.Length;
			storeData (data,sizeInBytes);
		}

		public void storeData (int[] data)
		{
			int sizeInBytes = sizeof(int) * data.Length;
			storeData (data,sizeInBytes);
		}

		public void storeData<T> (T[] data, int sizeInBytes) where T : struct
		{
			GL.BufferData (type, sizeInBytes, data, BufferUsageHint.StaticDraw);
		}

		public void delete ()
		{
			GL.DeleteBuffer (vboId);
		}

	}
}
