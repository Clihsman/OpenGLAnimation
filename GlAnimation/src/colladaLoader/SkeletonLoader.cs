using lwjgl.vector;
using System.Collections.Generic;
using xmlParser;
using System;
using dataStructures;
using OpenTK;

namespace colladaLoader{

public class SkeletonLoader {

	private XmlNode armatureData;
	
	private List<String> boneOrder;
	
	private int jointCount = 0;
	
	private static Matrix4f CORRECTION = new Matrix4f().rotate((float) MathHelper.DegreesToRadians(-90), new Vector3f(1, 0, 0));

	public SkeletonLoader(XmlNode visualSceneNode, List<String> boneOrder) {
		this.armatureData = visualSceneNode.getChild("visual_scene").getChildWithAttribute("node", "id", "Armature");
		this.boneOrder = boneOrder;
	}
	
	public SkeletonData extractBoneData(){
		XmlNode headNode = armatureData.getChild("node");
		JointData headJoint = loadJointData(headNode, true);
		return new SkeletonData(jointCount, headJoint);
	}
	
		private JointData loadJointData(XmlNode jointNode, bool isRoot){
		JointData joint = extractMainJointData(jointNode, isRoot);
		foreach(XmlNode childNode in jointNode.getChildren("node")){
			joint.addChild(loadJointData(childNode, false));
		}
		return joint;
	}
	
		private JointData extractMainJointData(XmlNode jointNode, bool isRoot){
		String nameId = jointNode.getAttribute("id");
			int index = boneOrder.IndexOf(nameId);
			String[] matrixData = jointNode.getChild("matrix").getData().Split(' ');
		Matrix4f matrix = new Matrix4f();
		matrix.load(convertData(matrixData));
		matrix.transpose();	
		if(isRoot){
			//because in Blender z is up, but in our game y is up.
				 Matrix4f.mul(CORRECTION, matrix, matrix);
		}
		jointCount++;
		return new JointData(index, nameId, matrix);
	}
	
		private float[] convertData(String[] rawData)
		{
			float[] buffer = new float[16];
			for(int i=0;i<buffer.Length;i++)
			{
				buffer[i] = float.Parse(rawData[i]);
		    }
		return buffer;
	}

}
}
