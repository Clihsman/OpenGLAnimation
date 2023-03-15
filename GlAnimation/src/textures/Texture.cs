using OpenTK.Graphics.OpenGL;
using utils;

namespace textures
{
	public class Texture
	{
		public int textureId;
		public int size;
		private TextureTarget type;

		public Texture (int textureId, int size)
		{
			this.textureId = textureId;
			this.size = size;
			this.type = TextureTarget.Texture2D;
		}

		public Texture (int textureId, TextureTarget type, int size)
		{
			this.textureId = textureId;
			this.size = size;
			this.type = type;
		}

		public void bindToUnit (int unit)
		{
			GL.ActiveTexture (TextureUnit.Texture0 + unit);
			GL.BindTexture (type, textureId);
		}

		public void delete ()
		{
			GL.DeleteTexture (textureId);
		}

		public static TextureBuilder newTexture (MyFile textureFile)
		{
			return new TextureBuilder (textureFile);
		}
	}
}
