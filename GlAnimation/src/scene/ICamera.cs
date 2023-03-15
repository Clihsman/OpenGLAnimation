using lwjgl.vector;

namespace scene
{
	public interface ICamera
	{
	
		Matrix4f getViewMatrix ();

		Matrix4f getProjectionMatrix ();

		Matrix4f getProjectionViewMatrix ();

		void move ();

	}
}
