using lwjgl.vector;
using System;
using utils;

namespace main
{
	public class GeneralSettings
	{
	
		public static readonly MyFile RES_FOLDER = new MyFile ("res");
		public static readonly String MODEL_FILE = "model.dae";
		public static readonly String ANIM_FILE = "model.dae";
		public static readonly String DIFFUSE_FILE = "diffuse.png";
	
		public static readonly int MAX_WEIGHTS = 3;
	
		public static readonly Vector3f LIGHT_DIR = new Vector3f (0.2f, -0.3f, -0.8f);
	
	}
}