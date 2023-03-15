using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace lwcgl.opengl
{
	public static class GLContext
	{
		private static List<string> capabilities = new List<string>();

		public static Capabilities getCapabilities()
		{
			if(capabilities.Count == 0)
			{
				string value = GL.GetString (StringName.Extensions);
				string[] currentValue = value.Split (' ');
				foreach (string vl in currentValue)
					capabilities.Add (vl);
			}
			return new Capabilities (capabilities);
		}
	}
}

