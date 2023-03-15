using shaders;
using utils;

namespace renderer
{

	public class AnimatedModelShader : ShaderProgram
	{

		private static int MAX_JOINTS = 50;
// max number of joints in a skeleton
		private static int DIFFUSE_TEX_UNIT = 0;

		private static MyFile VERTEX_SHADER = new MyFile ("renderer", "animatedEntityVertex.glsl");
		private static MyFile FRAGMENT_SHADER = new MyFile ("renderer", "animatedEntityFragment.glsl");

		public UniformMatrix projectionViewMatrix = new UniformMatrix ("projectionViewMatrix");
		public UniformVec3 lightDirection = new UniformVec3 ("lightDirection");
		public UniformMat4Array jointTransforms = new UniformMat4Array ("jointTransforms", MAX_JOINTS);
		private UniformSampler diffuseMap = new UniformSampler ("diffuseMap");

		/**
	 * Creates the shader program for the {@link AnimatedModelRenderer} by
	 * loading up the vertex and fragment shader code files. It also gets the
	 * location of all the specified uniform variables, and also indicates that
	 * the diffuse texture will be sampled from texture unit 0.
	 */
		public AnimatedModelShader () : base (VERTEX_SHADER, FRAGMENT_SHADER, "in_position", "in_textureCoords", "in_normal", "in_jointIndices",
			                                   "in_weights")
		{
			base.storeAllUniformLocations (projectionViewMatrix, diffuseMap, lightDirection, jointTransforms);
			connectTextureUnits ();
		}

		/**
	 * Indicates which texture unit the diffuse texture should be sampled from.
	 */
		private void connectTextureUnits ()
		{
			base.start ();
			diffuseMap.loadTexUnit (DIFFUSE_TEX_UNIT);
			base.stop ();
		}
	}
}
