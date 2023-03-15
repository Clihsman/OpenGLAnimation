using System;

namespace lwjgl.vector
{
	[Serializable]
	public class Vector4f : Vector,ReadableVector4f,WritableVector4f
	{
		public float x;
		/*     */
		public float y;
		/*     */
		public float z;
		/*     */
		public float w;
		/*     */
		/*     */
		public Vector4f ()
		{
		}
		/*     */
		/*  65 */
		public Vector4f (ReadableVector4f src)
		{
			set (src);
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*  72 */
		public Vector4f (float x, float y, float z, float w)
		{
			set (x, y, z, w);
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public void set (float x, float y)
		{
			/*  79 */
			this.x = x;
			/*  80 */
			this.y = y;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public void set (float x, float y, float z)
		{
			/*  87 */
			this.x = x;
			/*  88 */
			this.y = y;
			/*  89 */
			this.z = z;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public void set (float x, float y, float z, float w)
		{
			/*  96 */
			this.x = x;
			/*  97 */
			this.y = y;
			/*  98 */
			this.z = z;
			/*  99 */
			this.w = w;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public Vector4f set (ReadableVector4f src)
		{
			/* 108 */
			this.x = src.getX ();
			/* 109 */
			this.y = src.getY ();
			/* 110 */
			this.z = src.getZ ();
			/* 111 */
			this.w = src.getW ();
			/* 112 */
			return this;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 119 */
		public override float lengthSquared ()
		{
			return this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public Vector4f translate (float x, float y, float z, float w)
		{
			/* 129 */
			this.x += x;
			/* 130 */
			this.y += y;
			/* 131 */
			this.z += z;
			/* 132 */
			this.w += w;
			/* 133 */
			return this;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public static Vector4f add (Vector4f left, Vector4f right, Vector4f dest)
		{
			/* 145 */
			if (dest == null) {
				/* 146 */
				return new Vector4f (left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
				/*     */
			}
			/* 148 */
			dest.set (left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
			/* 149 */
			return dest;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public static Vector4f sub (Vector4f left, Vector4f right, Vector4f dest)
		{
			/* 162 */
			if (dest == null) {
				/* 163 */
				return new Vector4f (left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
				/*     */
			}
			/* 165 */
			dest.set (left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
			/* 166 */
			return dest;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public override Vector negate ()
		{
/* 176 */
			this.x = -this.x;
/* 177 */
			this.y = -this.y;
/* 178 */
			this.z = -this.z;
/* 179 */
			this.w = -this.w;
/* 180 */
			return this;
/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public Vector4f negate (Vector4f dest)
		{
			/* 189 */
			if (dest == null)
		/* 190 */       dest = new Vector4f (); 
			/* 191 */
			dest.x = -this.x;
			/* 192 */
			dest.y = -this.y;
			/* 193 */
			dest.z = -this.z;
			/* 194 */
			dest.w = -this.w;
			/* 195 */
			return dest;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public Vector4f normalise (Vector4f dest)
		{
/* 205 */
			float l = length ();
/*     */     
/* 207 */
			if (dest == null) {
/* 208 */
				dest = new Vector4f (this.x / l, this.y / l, this.z / l, this.w / l);
/*     */
			} else {
				/* 210 */
				dest.set (this.x / l, this.y / l, this.z / l, this.w / l);
				/*     */
			} 
/* 212 */
			return dest;
/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 223 */
		public static float dot (Vector4f left, Vector4f right)
		{
			return left.x * right.x + left.y * right.y + left.z * right.z + left.w * right.w;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public static float angle (Vector4f a, Vector4f b)
		{
			/* 233 */
			float dls = dot (a, b) / a.length () * b.length ();
			/* 234 */
			if (dls < -1.0F) {
				/* 235 */
				dls = -1.0F;
				/* 236 */
			} else if (dls > 1.0F) {
				/* 237 */
				dls = 1.0F;
				/* 238 */
			}
			return (float)Math.Acos (dls);
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public override Vector scale (float scale)
		{
			/* 256 */
			this.x *= scale;
			/* 257 */
			this.y *= scale;
			/* 258 */
			this.z *= scale;
			/* 259 */
			this.w *= scale;
			/* 260 */
			return this;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/* 277 */
		public override String ToString ()
		{
			return "Vector4f: " + this.x + " " + this.y + " " + this.z + " " + this.w;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 284 */
		public float getX ()
		{
			return this.x;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 291 */
		public float getY ()
		{
			return this.y;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 299 */
		public void setX (float x)
		{
			this.x = x;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 307 */
		public void setY (float y)
		{
			this.y = y;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 315 */
		public void setZ (float z)
		{
			this.z = z;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 323 */
		public float getZ ()
		{
			return this.z;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 331 */
		public void setW (float w)
		{
			this.w = w;
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 338 */
		public float getW ()
		{
			return this.w;
		}
		/*     */
		/*     */
		/*     */
		public override bool Equals (Object obj)
		{
			/* 342 */
			if (this == obj)
				return true; 
			/* 343 */
			if (obj == null)
				return false; 
			/* 344 */
			if (GetType () != obj.GetType ())
				return false; 
			/* 345 */
			Vector4f other = (Vector4f)obj;
			/*     */     
			/* 347 */
			if (this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w)
				return true;
			/*     */     
			/* 349 */
			return false;
			/*     */
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public static implicit operator OpenTK.Vector4(Vector4f vector){
			return new OpenTK.Vector4 (vector.x,vector.y,vector.z,vector.w);
		}

	}
}

