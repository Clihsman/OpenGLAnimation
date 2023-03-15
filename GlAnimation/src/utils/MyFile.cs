using System;
using System.IO;

namespace utils
{
	public class MyFile
	{
		private static readonly char FILE_SEPARATOR = '/';

		private String path;
		private String name;

		public MyFile (String path)
		{
			this.path = FILE_SEPARATOR + path;
			String[] dirs = path.Split (FILE_SEPARATOR);
			this.name = dirs [dirs.Length - 1];
		}

		public MyFile (params String[] paths)
		{
			this.path = "";
			foreach (String part in paths) {
				this.path += (FILE_SEPARATOR + part);
			}
			String[] dirs = path.Split (FILE_SEPARATOR);
			this.name = dirs [dirs.Length - 1];
		}

		public MyFile (MyFile file, String subFile)
		{
			this.path = file.path + FILE_SEPARATOR + subFile;
			this.name = subFile;
		}

		public MyFile (MyFile file, params String[] subFiles)
		{
			this.path = file.path;
			foreach (String part in subFiles) {
				this.path += (FILE_SEPARATOR + part);
			}
			String[] dirs = path.Split (FILE_SEPARATOR);
			this.name = dirs [dirs.Length - 1];
		}

		public String getPath ()
		{
			return path;
		}

		public override String ToString ()
		{
			return getPath ();
		}

		public Stream getInputStream ()
		{
			return File.Open (path.Substring(1), FileMode.Open, FileAccess.Read);
		}

		public StreamReader getReader ()
		{
			try {
				StreamReader reader = new StreamReader (getInputStream ());
				return reader;
			} catch(Exception ex)
			{
				Console.WriteLine (ex);
				Console.Error.WriteLine ("Couldn't get reader for " + path);
			}
			return null;
		}

		public String getName ()
		{
			return name;
		}

	}
}
