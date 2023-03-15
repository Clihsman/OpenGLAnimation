using lwjgl.vector;
using OpenTK;
using xmlParser;
using System.Collections.Generic;
using dataStructures;
using System;

namespace colladaLoader
{

	/**
 * Loads the mesh data for a model from a collada XML file.
 * @author Karl
 *
 */
	public class GeometryLoader
	{

		private static Matrix4f CORRECTION = new Matrix4f ().rotate ((float)MathHelper.DegreesToRadians (-90), new Vector3f (1, 0, 0));
	
		private XmlNode meshData;

		private List<VertexSkinData> vertexWeights;
	
		private float[] verticesArray;
		private float[] normalsArray;
		private float[] texturesArray;
		private int[] indicesArray;
		private int[] jointIdsArray;
		private float[] weightsArray;

		List<Vertex> vertices = new List<Vertex> ();
		List<Vector2f> textures = new List<Vector2f> ();
		List<Vector3f> normals = new List<Vector3f> ();
		List<int> indices = new List<int> ();

		public GeometryLoader (XmlNode geometryNode, List<VertexSkinData> vertexWeights)
		{
			this.vertexWeights = vertexWeights;
			this.meshData = geometryNode.getChild ("geometry").getChild ("mesh");
		}

		public MeshData extractModelData ()
		{
			readRawData ();
			assembleVertices ();
			removeUnusedVertices ();
			initArrays ();
			convertDataToArrays ();
			convertIndicesListToArray ();
			return new MeshData (verticesArray, texturesArray, normalsArray, indicesArray, jointIdsArray, weightsArray);
		}

		private void readRawData ()
		{
			readPositions ();
			readNormals ();
			readTextureCoords ();
		}

		private void readPositions ()
		{
			String positionsId = meshData.getChild ("vertices").getChild ("input").getAttribute ("source").Substring (1);
			XmlNode positionsData = meshData.getChildWithAttribute ("source", "id", positionsId).getChild ("float_array");
			int count = int.Parse (positionsData.getAttribute ("count"));
			String[] posData = positionsData.getData ().Split (' ');
			for (int i = 0; i < count / 3; i++) {
				float x = float.Parse (posData [i * 3]);
				float y = float.Parse (posData [i * 3 + 1]);
				float z = float.Parse (posData [i * 3 + 2]);
				Vector4f position = new Vector4f (x, y, z, 1);
				Matrix4f.transform (CORRECTION, position, position);
				vertices.Add (new Vertex (vertices.Count, new Vector3f (position.x, position.y, position.z), vertexWeights [vertices.Count]));
			}
		}

		private void readNormals ()
		{
			String normalsId = meshData.getChild ("polylist").getChildWithAttribute ("input", "semantic", "NORMAL")
				.getAttribute ("source").Substring (1);
			XmlNode normalsData = meshData.getChildWithAttribute ("source", "id", normalsId).getChild ("float_array");
			int count = int.Parse (normalsData.getAttribute ("count"));
			String[] normData = normalsData.getData ().Split (' ');
			for (int i = 0; i < count / 3; i++) {
				float x = float.Parse (normData [i * 3]);
				float y = float.Parse (normData [i * 3 + 1]);
				float z = float.Parse (normData [i * 3 + 2]);
				Vector4f norm = new Vector4f (x, y, z, 0f);
				Matrix4f.transform (CORRECTION, norm, norm);
				normals.Add (new Vector3f (norm.x, norm.y, norm.z));
			}
		}

		private void readTextureCoords ()
		{
			String texCoordsId = meshData.getChild ("polylist").getChildWithAttribute ("input", "semantic", "TEXCOORD")
				.getAttribute ("source").Substring (1);
			XmlNode texCoordsData = meshData.getChildWithAttribute ("source", "id", texCoordsId).getChild ("float_array");
			int count = int.Parse (texCoordsData.getAttribute ("count"));
			String[] texData = texCoordsData.getData ().Split (' ');
			for (int i = 0; i < count / 2; i++) {
				float s = float.Parse (texData [i * 2]);
				float t = float.Parse (texData [i * 2 + 1]);
				textures.Add (new Vector2f (s, t));
			}
		}

		private void assembleVertices ()
		{
			XmlNode poly = meshData.getChild ("polylist");
			int typeCount = poly.getChildren ("input").Count;
			String[] indexData = poly.getChild ("p").getData ().Split (' ');
			for (int i = 0; i < indexData.Length / typeCount; i++) {
				int positionIndex = int.Parse (indexData [i * typeCount]);
				int normalIndex = int.Parse (indexData [i * typeCount + 1]);
				int texCoordIndex = int.Parse (indexData [i * typeCount + 2]);
				processVertex (positionIndex, normalIndex, texCoordIndex);
			}
		}


		private Vertex processVertex (int posIndex, int normIndex, int texIndex)
		{
			Vertex currentVertex = vertices [posIndex];
			if (!currentVertex.isSet ()) {
				currentVertex.setTextureIndex (texIndex);
				currentVertex.setNormalIndex (normIndex);
				indices.Add (posIndex);
				return currentVertex;
			} else {
				return dealWithAlreadyProcessedVertex (currentVertex, texIndex, normIndex);
			}
		}

		private int[] convertIndicesListToArray ()
		{
			this.indicesArray = new int[indices.Count];
			for (int i = 0; i < indicesArray.Length; i++) {
				indicesArray [i] = indices [i];
			}
			return indicesArray;
		}

		private float convertDataToArrays ()
		{
			float furthestPoint = 0;
			for (int i = 0; i < vertices.Count; i++) {
				Vertex currentVertex = vertices [i];
				if (currentVertex.getLength () > furthestPoint) {
					furthestPoint = currentVertex.getLength ();
				}
				Vector3f position = currentVertex.getPosition ();
				Vector2f textureCoord = textures [currentVertex.getTextureIndex ()];
				Vector3f normalVector = normals [currentVertex.getNormalIndex ()];
				verticesArray [i * 3] = position.x;
				verticesArray [i * 3 + 1] = position.y;
				verticesArray [i * 3 + 2] = position.z;
				texturesArray [i * 2] = textureCoord.x;
				texturesArray [i * 2 + 1] = 1 - textureCoord.y;
				normalsArray [i * 3] = normalVector.x;
				normalsArray [i * 3 + 1] = normalVector.y;
				normalsArray [i * 3 + 2] = normalVector.z;
				VertexSkinData weights = currentVertex.getWeightsData ();
				jointIdsArray [i * 3] = weights.jointIds [0];
				jointIdsArray [i * 3 + 1] = weights.jointIds [1];
				jointIdsArray [i * 3 + 2] = weights.jointIds [2];
				weightsArray [i * 3] = weights.weights [0];
				weightsArray [i * 3 + 1] = weights.weights [1];
				weightsArray [i * 3 + 2] = weights.weights [2];

			}
			return furthestPoint;
		}

		private Vertex dealWithAlreadyProcessedVertex (Vertex previousVertex, int newTextureIndex, int newNormalIndex)
		{
			if (previousVertex.hasSameTextureAndNormal (newTextureIndex, newNormalIndex)) {
				indices.Add (previousVertex.getIndex ());
				return previousVertex;
			} else {
				Vertex anotherVertex = previousVertex.getDuplicateVertex ();
				if (anotherVertex != null) {
					return dealWithAlreadyProcessedVertex (anotherVertex, newTextureIndex, newNormalIndex);
				} else {
					Vertex duplicateVertex = new Vertex (vertices.Count, previousVertex.getPosition (), previousVertex.getWeightsData ());
					duplicateVertex.setTextureIndex (newTextureIndex);
					duplicateVertex.setNormalIndex (newNormalIndex);
					previousVertex.setDuplicateVertex (duplicateVertex);
					vertices.Add (duplicateVertex);
					indices.Add (duplicateVertex.getIndex ());
					return duplicateVertex;
				}

			}
		}

		private void initArrays ()
		{
			this.verticesArray = new float[vertices.Count * 3];
			this.texturesArray = new float[vertices.Count * 2];
			this.normalsArray = new float[vertices.Count * 3];
			this.jointIdsArray = new int[vertices.Count * 3];
			this.weightsArray = new float[vertices.Count * 3];
		}

		private void removeUnusedVertices ()
		{
			foreach (Vertex vertex in vertices) {
				vertex.averageTangents ();
				if (!vertex.isSet ()) {
					vertex.setTextureIndex (0);
					vertex.setNormalIndex (0);
				}
			}
		}
	
	}
}