using lwjgl.vector;
using animatedModel;

namespace scene
{

	/**
 * Represents all the stuff in the scene (just the camera, light, and model
 * really).
 * 
 * @author Karl
 *
 */
	public class Scene
	{

		private ICamera camera;

		private AnimatedModel animatedModel;

		private Vector3f lightDirection = new Vector3f (0, -1, 0);

		public Scene (AnimatedModel model, ICamera cam)
		{
			this.animatedModel = model;
			this.camera = cam;
		}

		/**
	 * @return The scene's camera.
	 */
		public ICamera getCamera ()
		{
			return camera;
		}

		public AnimatedModel getAnimatedModel ()
		{
			return animatedModel;
		}

		/**
	 * @return The direction of the light as a vector.
	 */
		public Vector3f getLightDirection ()
		{
			return lightDirection;
		}

		public void setLightDirection (Vector3f lightDir)
		{
			this.lightDirection.set (lightDir);
		}
	}
}
