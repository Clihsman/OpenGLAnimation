using System;
using renderEngine;
using scene;
using OpenTK;
using App;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace main
{

	public class AnimationApp
	{

		public static float time = 0;
		public static float dx = 0;
		public static float dy = 0;

		public static void Main (String[] args)
		{
			
			RenderEngine engine = null;

			Scene scene = null;
			GraphicsMode grapMode = new GraphicsMode (ColorFormat.Empty, 24, 16, 4, ColorFormat.Empty, 2, false);

			GameWindow window = new GameWindow (Display.getWidth(),Display.getHeight(),new GraphicsMode(ColorFormat.Empty,24,0,4));       

			engine = RenderEngine.init ();
			scene = SceneLoader.loadScene (GeneralSettings.RES_FOLDER);
			GL.Enable(EnableCap.Multisample);

			window.Load += delegate {
				
			};

			window.RenderFrame += delegate(object o,FrameEventArgs e) {
				time = (float)e.Time;
				if(window.Focused)
					scene.getCamera ().move ();
				scene.getAnimatedModel ().update ();
				engine.renderScene (scene);
				engine.update ();
			};

			window.MouseMove += delegate(object sender, OpenTK.Input.MouseMoveEventArgs e) {
				dx = e.XDelta;
				dy = e.YDelta;
			};

			window.Closed += delegate {
				engine.close ();
			};
			window.Run (120);
      
        
		}
	}
}
