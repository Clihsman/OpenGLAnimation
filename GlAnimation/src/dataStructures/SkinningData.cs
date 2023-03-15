using System.Collections.Generic;
using System;

namespace dataStructures{

public class SkinningData {
	
	public List<String> jointOrder;
	public List<VertexSkinData> verticesSkinData;
	
	public SkinningData(List<String> jointOrder, List<VertexSkinData> verticesSkinData){
		this.jointOrder = jointOrder;
		this.verticesSkinData = verticesSkinData;
	}

	}
}
