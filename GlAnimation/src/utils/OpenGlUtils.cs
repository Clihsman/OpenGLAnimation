using OpenTK.Graphics.OpenGL;

namespace utils
{
	public class OpenGlUtils
	{
		private static bool cullingBackFace = false;
		private static bool inWireframe = false;
		private static bool isAlphaBlending = false;
		private static bool additiveBlending = false;
		private static bool antialiasing = false;
		private static bool depthTesting = false;

		public static void antialias (bool enable)
		{
			if (enable && !antialiasing) {
				GL.Enable (EnableCap.Multisample);
				antialiasing = true;
			} else if (!enable && antialiasing) {
				GL.Disable (EnableCap.Multisample);
				antialiasing = false;
			}
		}

		public static void enableAlphaBlending ()
		{
			if (!isAlphaBlending) {
				GL.Enable (EnableCap.Blend);
				GL.BlendFunc (BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
				isAlphaBlending = true;
				additiveBlending = false;
			}
		}

		public static void enableAdditiveBlending ()
		{
			if (!additiveBlending) {
				GL.Enable (EnableCap.Blend);
				GL.BlendFunc (BlendingFactor.SrcAlpha, BlendingFactor.One);
				additiveBlending = true;
				isAlphaBlending = false;
			}
		}

		public static void disableBlending ()
		{
			if (isAlphaBlending || additiveBlending) {
				GL.Disable (EnableCap.Blend);
				isAlphaBlending = false;
				additiveBlending = false;
			}
		}

		public static void enableDepthTesting (bool enable)
		{
			if (enable && !depthTesting) {
				GL.Enable (EnableCap.DepthTest);
				depthTesting = true;
			} else if (!enable && depthTesting) {
				GL.Disable (EnableCap.DepthTest);
				depthTesting = false;
			}
		}

		public static void cullBackFaces (bool cull)
		{
			if (cull && !cullingBackFace) {
				GL.Enable (EnableCap.CullFace);
				GL.CullFace (CullFaceMode.Back);
				cullingBackFace = true;
			} else if (!cull && cullingBackFace) {
				GL.Disable (EnableCap.CullFace);
				cullingBackFace = false;
			}
		}

		public static void goWireframe (bool goWireframe)
		{
			if (goWireframe && !inWireframe) {
				GL.PolygonMode (MaterialFace.FrontAndBack, PolygonMode.Line);
				inWireframe = true;
			} else if (!goWireframe && inWireframe) {
				GL.PolygonMode (MaterialFace.FrontAndBack, PolygonMode.Fill);
				inWireframe = false;
			}
		}
	}
}
