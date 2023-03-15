using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace lwcgl.drawing
{
	public class Texture
	{
		private int id;
		private int width;
		private int height;
		private string filename;
		private FilterMode mode;

		public Texture (string filename,FilterMode mode)
		{
			this.filename = filename.Substring(1);
			this.mode = mode;
			LoadTexture ();
		}

		private void LoadTexture(){

			if (!File.Exists (filename))
				throw new FileNotFoundException ();
			
			Bitmap image = new Bitmap (filename);

			this.width = image.Width;
			this.height = image.Height;

			if(mode == FilterMode.Point)
				this.id = loadPoint (image);
			else if(mode == FilterMode.Linear)
				this.id = loadLimear (image);
			else if(mode == FilterMode.Data)
				this.id = loadData (image);

			image.Dispose ();
		}

		private static int loadPoint(Bitmap bitmap)
		{
			int textureID = GL.GenTexture ();
			GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, textureID);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)All.ClampToEdge);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)All.ClampToEdge);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			OpenTK.Graphics.OpenGL.GL.TexImage2D(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
			bitmap.UnlockBits(bitmapData);
			GL.BindTexture (TextureTarget.Texture2D,0);
			return textureID;
		}

		public static int loadLimear(Bitmap bitmap)
		{
			int textureID = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, textureID);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			OpenTK.Graphics.OpenGL.GL.TexImage2D(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
			bitmap.UnlockBits(bitmapData);
			GL.BindTexture(TextureTarget.Texture2D, 0);
			return textureID;
		}

		public static int loadData(Bitmap bitmap)
		{
			int textureID = GL.GenTexture();
			GL.ActiveTexture(TextureUnit.Texture0);
			GL.BindTexture(TextureTarget.Texture2D, textureID);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
			OpenTK.Graphics.OpenGL.GL.TexImage2D(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
			bitmap.UnlockBits(bitmapData);
			GL.BindTexture(TextureTarget.Texture2D, 0);
			return textureID;
		}

		public int getID(){
			return id;
		}

		public int getWidth(){
			return width;
		}

		public int gethieght(){
			return height;
		}

		public void unbind(){
			GL.BindTexture (TextureTarget.Texture2D,0);
		}

		public void bind(){
			GL.ActiveTexture (TextureUnit.Texture0);
			GL.BindTexture (TextureTarget.Texture2D,id);
		}

		public void delete(){
			unbind ();
			GL.DeleteTexture (id);
		}
	}


}

