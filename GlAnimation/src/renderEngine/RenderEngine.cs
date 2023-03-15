using scene;
using skybox;
using renderer;


namespace renderEngine{

public class RenderEngine {

	private MasterRenderer renderer;

	private RenderEngine(MasterRenderer renderer) {
		this.renderer = renderer;
	}

	public void update() {
			OpenTK.Graphics.GraphicsContext.CurrentContext.SwapBuffers ();
	}

	public void renderScene(Scene scene) {
		renderer.renderScene(scene);
	}

	public void close() {
		renderer.cleanUp();
	}

	public static RenderEngine init ()
		{
			SkyboxRenderer skyRenderer = new SkyboxRenderer ();
			AnimatedModelRenderer entityRenderer = new AnimatedModelRenderer ();
			MasterRenderer renderer = new MasterRenderer (entityRenderer, skyRenderer);
			return new RenderEngine (renderer);
		}

	}

}
