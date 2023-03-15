using System.Text.RegularExpressions;
using System;
using utils;
using System.IO;
using XmlNodeX = System.Xml.XmlNode;

namespace xmlParser
{

	public class XmlParser
	{

		private static Regex DATA = new Regex (">(.+?)<");
		private static Regex START_TAG = new Regex ("<(.+?)>");
		private static Regex ATTR_NAME = new Regex ("(.+?)=");
		private static Regex ATTR_VAL = new Regex ("\"(.+?)\"");
		private static Regex CLOSED = new Regex ("(</|/>)");

		public static XmlNode loadXmlFile (MyFile file)
		{
			
			StreamReader reader = null;
			try {
				reader = file.getReader ();
			} catch (Exception e) {
				Console.WriteLine (e);
				Console.Error.WriteLine ("Can't find the XML file: " + file.getPath ());
				Environment.Exit (0);
				return null;
			}
			try {
				reader.ReadLine ();
				XmlNode node = loadXmlData (reader);
				reader.Close ();
				return node;
			} catch (Exception e) {
				Console.WriteLine (e);
				Console.Error.WriteLine ("Error with XML file format for: " + file.getPath ());
				Environment.Exit (0);
				return null;
			}
		}

		private static XmlNode loadXmlData (StreamReader reader)
		{
			System.Xml.XmlDocument xDocument = new System.Xml.XmlDocument ();
			xDocument.Load (reader);
			XmlNodeX xparant = xDocument.ChildNodes [0];
			XmlNode parent = loadNode (xparant);
			return parent;
		}

		private static XmlNode loadNode (XmlNodeX xNode)
		{
				XmlNode parent = new XmlNode (xNode.Name);

				addData (xNode, parent);
				addAttributes (xNode, parent);

				foreach (XmlNodeX xN in xNode.ChildNodes) {
					parent.addChild (loadNode (xN));
				}
			return parent;
		}

		private static void addData (XmlNodeX xNode, XmlNode node)
		{
			node.setData (xNode.InnerText.Replace('.',','));
		}

		private static void addAttributes (XmlNodeX xNode, XmlNode node)
		{
			if (xNode.Attributes != null) {
				foreach (System.Xml.XmlAttribute attrib in xNode.Attributes) {
					node.addAttribute (attrib.Name, attrib.InnerText);
				}
			}
		}

	}
}
