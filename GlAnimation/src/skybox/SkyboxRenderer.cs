using utils;
using openglObjects;
using scene;
using OpenTK.Graphics.OpenGL;

namespace skybox
{
public class SkyboxRenderer {

	private static float SIZE = 200;

	private SkyboxShader shader;
	private Vao box;

	public SkyboxRenderer() {
		this.shader = new SkyboxShader();
		this.box = CubeGenerator.generateCube(SIZE);
	}

	/**
	 * Renders the skybox.
	 * 
	 * @param camera
	 *            - the scene's camera.
	 */
	public void render(ICamera camera) {
		prepare(camera);
		box.bind(0);
			GL.DrawElements(PrimitiveType.Triangles, box.getIndexCount(),DrawElementsType.UnsignedInt, 0);
		box.unbind(0);
		shader.stop();
	}

	/**
	 * Delete the shader when the game closes.
	 */
	public void cleanUp() {
		shader.cleanUp();
	}

	/**
	 * Starts the shader, loads the projection-view matrix to the uniform
	 * variable, and sets some OpenGL state which should be mostly
	 * self-explanatory.
	 * 
	 * @param camera
	 *            - the scene's camera.
	 */
	private void prepare(ICamera camera) {
		shader.start();
		shader.projectionViewMatrix.loadMatrix(camera.getProjectionViewMatrix());
		OpenGlUtils.disableBlending();
		OpenGlUtils.enableDepthTesting(true);
		OpenGlUtils.cullBackFaces(true);
		OpenGlUtils.antialias(false);
	}
	}
}
