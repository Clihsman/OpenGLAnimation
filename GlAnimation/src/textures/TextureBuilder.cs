using utils;
using System;

namespace textures
{

	public class TextureBuilder
	{
	
		private bool m_clampEdges = false;
		private bool mipmap = false;
		private bool m_anisotropic = true;
		private bool nearest = false;
	
		private MyFile file;

		public TextureBuilder (MyFile textureFile)
		{
			this.file = textureFile;
		}

		public Texture create ()
		{
			int textureId = TextureUtils.loadTextureToOpenGL (file.getPath (), this);
			return new Texture (textureId, 1);
		}

		public TextureBuilder clampEdges ()
		{
			this.m_clampEdges = true;
			return this;
		}

		public TextureBuilder normalMipMap ()
		{
			this.mipmap = true;
			this.m_anisotropic = false;
			return this;
		}

		public TextureBuilder nearestFiltering ()
		{
			this.mipmap = false;
			this.m_anisotropic = false;
			this.nearest = true;
			return this;
		}

		public TextureBuilder anisotropic ()
		{
			this.mipmap = true;
			this.m_anisotropic = true;
			return this;
		}

		public bool isClampEdges ()
		{
			return m_clampEdges;
		}

		public bool isMipmap ()
		{
			return mipmap;
		}

		public bool isAnisotropic ()
		{
			return m_anisotropic;
		}

		public bool isNearest ()
		{
			return nearest;
		}
	}
}
