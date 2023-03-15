using System;
using OpenTK;

namespace GlAnimation
{
	public class GlWindow
	{
		private GameWindow native_window;
		private int ups;
		private int fps;
		private int width;
		private int height;

		public GlWindow(int width,int height,int fps,int ups)
		{
			this.width = width;
			this.height = height;
			this.fps = fps;
			this.ups = ups;
			native_window = new GameWindow (width,height);
		}

		public void Run()
		{
			native_window.Run (ups,fps);
		}

		public GameWindow getNativeWindow()
		{
			return native_window;
		}
	}
}

