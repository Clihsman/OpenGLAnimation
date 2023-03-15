using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System;

namespace openglObjects
{

	public class Vao {
	
	private static int BYTES_PER_FLOAT = 4;
	private static int BYTES_PER_INT = 4;
	public int id;
	private List<Vbo> dataVbos = new List<Vbo>();
	private Vbo indexVbo;
	private int indexCount;

	public static Vao create() {
			int id = GL.GenVertexArray();
		return new Vao(id);
	}

	private Vao(int id) {
		this.id = id;
	}
	
	public int getIndexCount(){
		return indexCount;
	}

		public void bind(params int[] attributes){
		bind();
		foreach (int i in attributes) {
			GL.EnableVertexAttribArray(i);
		}
	}

		public void unbind(params int[] attributes){
		foreach (int i in attributes) {
				GL.DisableVertexAttribArray(i);
		}
		unbind();
	}
	
	public void createIndexBuffer(int[] indices){
			this.indexVbo = Vbo.create(BufferTarget.ElementArrayBuffer);
		indexVbo.bind();
		indexVbo.storeData(indices);
			this.indexCount = indices.Length;
	}

	public void createAttribute(int attribute, float[] data, int attrSize){
			Vbo dataVbo = Vbo.create(BufferTarget.ArrayBuffer);
		dataVbo.bind();
		dataVbo.storeData(data);
			GL.VertexAttribPointer(attribute, attrSize,VertexAttribPointerType.Float, false, attrSize * BYTES_PER_FLOAT, 0);
		dataVbo.unbind();
		dataVbos.Add(dataVbo);
	}
	
	public void createIntAttribute(int attribute, int[] data, int attrSize){
			Vbo dataVbo = Vbo.create(BufferTarget.ArrayBuffer);
		dataVbo.bind();
		dataVbo.storeData(data);
			GL.VertexAttribIPointer(attribute, attrSize, VertexAttribIntegerType.Int, attrSize * BYTES_PER_INT, IntPtr.Zero);
		dataVbo.unbind();
		dataVbos.Add(dataVbo);
	}
	
	public void delete() {
			GL.DeleteVertexArray(id);
		foreach(Vbo vbo in dataVbos){
			vbo.delete();
		}
		indexVbo.delete();
	}

	private void bind() {
		GL.BindVertexArray(id);
	}

	private void unbind() {
		GL.BindVertexArray(0);
	}

}
}