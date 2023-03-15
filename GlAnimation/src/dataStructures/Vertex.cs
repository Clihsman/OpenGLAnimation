using lwjgl.vector;
using System.Collections.Generic;

namespace dataStructures
{

	public class Vertex
	{
	
		private static int NO_INDEX = -1;
	
		private Vector3f position;
		private int textureIndex = NO_INDEX;
		private int normalIndex = NO_INDEX;
		private Vertex duplicateVertex = null;
		private int index;
		private float length;
		private List<Vector3f> tangents = new List<Vector3f> ();
		private Vector3f averagedTangent = new Vector3f (0, 0, 0);
	
	
		private VertexSkinData weightsData;

		public Vertex (int index, Vector3f position, VertexSkinData weightsData)
		{
			this.index = index;
			this.weightsData = weightsData;
			this.position = position;
			this.length = position.length ();
		}

		public VertexSkinData getWeightsData ()
		{
			return weightsData;
		}

		public void addTangent (Vector3f tangent)
		{
			tangents.Add (tangent);
		}

		public void averageTangents ()
		{
			if (!(tangents.Count > 0)) {
				return;
			}
			foreach (Vector3f tangent in tangents) {
				Vector3f.add (averagedTangent, tangent, averagedTangent);
			}
			averagedTangent.normalise ();
		}

		public Vector3f getAverageTangent ()
		{
			return averagedTangent;
		}

		public int getIndex ()
		{
			return index;
		}

		public float getLength ()
		{
			return length;
		}

		public bool isSet ()
		{
			return textureIndex != NO_INDEX && normalIndex != NO_INDEX;
		}

		public bool hasSameTextureAndNormal (int textureIndexOther, int normalIndexOther)
		{
			return textureIndexOther == textureIndex && normalIndexOther == normalIndex;
		}

		public void setTextureIndex (int textureIndex)
		{
			this.textureIndex = textureIndex;
		}

		public void setNormalIndex (int normalIndex)
		{
			this.normalIndex = normalIndex;
		}

		public Vector3f getPosition ()
		{
			return position;
		}

		public int getTextureIndex ()
		{
			return textureIndex;
		}

		public int getNormalIndex ()
		{
			return normalIndex;
		}

		public Vertex getDuplicateVertex ()
		{
			return duplicateVertex;
		}

		public void setDuplicateVertex (Vertex duplicateVertex)
		{
			this.duplicateVertex = duplicateVertex;
		}
	}
}
