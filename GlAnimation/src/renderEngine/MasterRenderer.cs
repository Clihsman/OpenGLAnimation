using skybox;
using renderer;
using scene;
using OpenTK.Graphics.OpenGL;

namespace renderEngine
{
	public class MasterRenderer
	{

		private SkyboxRenderer skyRenderer;
		private AnimatedModelRenderer entityRenderer;

		public MasterRenderer (AnimatedModelRenderer renderer, SkyboxRenderer skyRenderer)
		{
			this.skyRenderer = skyRenderer;
			this.entityRenderer = renderer;
		}

		public void renderScene (Scene scene)
		{
			prepare ();
			entityRenderer.render (scene.getAnimatedModel (), scene.getCamera (), scene.getLightDirection ());
			skyRenderer.render (scene.getCamera ());
		}

		public void cleanUp ()
		{
			skyRenderer.cleanUp ();
			entityRenderer.cleanUp ();
		}

		private void prepare ()
		{
			GL.ClearColor (1, 1, 1, 1);
			GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
		}

	}
}
