using loaders;
using utils;
using animation;
using animatedModel;
using scene;

namespace main
{
	public class SceneLoader
	{
		public static Scene loadScene (MyFile resFolder)
		{
			ICamera camera = new Camera ();
			AnimatedModel entity = AnimatedModelLoader.loadEntity (new MyFile (resFolder, GeneralSettings.MODEL_FILE),
				                      new MyFile (resFolder, GeneralSettings.DIFFUSE_FILE));
			Animation animation = AnimationLoader.loadAnimation (new MyFile (resFolder, GeneralSettings.ANIM_FILE));
			entity.doAnimation (animation);
			Scene scene = new Scene (entity, camera);
			scene.setLightDirection (GeneralSettings.LIGHT_DIR);
			return scene;
		}
	}
}
