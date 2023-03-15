using System;
using System.Collections.Generic;

namespace lwcgl.opengl
{
	public class Capabilities
	{
		private List<string> capabilities;

		public Capabilities (List<string> capabilities)
		{
			this.capabilities = capabilities;
		}

		public bool GL_EXT_texture_filter_anisotropic
		{
			get
			{ 
				return capabilities.Contains ("GL_EXT_texture_filter_anisotropic");
			}
		}
	}
}

