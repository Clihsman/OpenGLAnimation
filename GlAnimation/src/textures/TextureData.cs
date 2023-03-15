namespace textures
{
	public class TextureData
	{	
		private int width;
		private int height;
		private byte[] buffer;

		public TextureData (byte[] buffer, int width, int height)
		{
			this.buffer = buffer;
			this.width = width;
			this.height = height;
		}

		public int getWidth ()
		{
			return width;
		}

		public int getHeight ()
		{
			return height;
		}

		public byte[] getBuffer ()
		{
			return buffer;
		}
	}
}
