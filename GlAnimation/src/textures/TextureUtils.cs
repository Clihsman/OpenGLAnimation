using utils;
using OpenTK.Graphics.OpenGL;
using System;
using lwcgl.opengl;

namespace textures
{
	public class TextureUtils
	{
		public static int loadTextureToOpenGL (string filename, TextureBuilder builder)
		{
			lwcgl.drawing.Texture texture = new lwcgl.drawing.Texture (filename, lwcgl.drawing.FilterMode.Data);
			texture.bind ();
			int texID = texture.getID ();

			if (builder.isMipmap ()) {
				GL.GenerateMipmap (GenerateMipmapTarget.Texture2D);
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)All.Linear);
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)All.LinearMipmapLinear);
				if (builder.isAnisotropic () && GLContext.getCapabilities ().GL_EXT_texture_filter_anisotropic) {
					GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureLodBias, 0);
					GL.TexParameter (TextureTarget.Texture2D, (TextureParameterName)All.TextureMaxAnisotropyExt,
						4.0f);
				}
			} else if (builder.isNearest ()) {
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)All.Nearest);
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)All.Nearest);
			} else {
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)All.Linear);
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)All.Linear);
			}
			if (builder.isClampEdges ()) {
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)All.ClampToEdge);
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)All.ClampToEdge);
			} else {
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)All.Repeat);
				GL.TexParameter (TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)All.Repeat);
			}
		
			GL.BindTexture (TextureTarget.Texture2D, 0);
			return texID;
		}
	}
}
