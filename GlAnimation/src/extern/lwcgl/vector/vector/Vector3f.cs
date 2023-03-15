using System;
using System.Text;

namespace lwjgl.vector
{
	public class Vector3f : Vector,ReadableVector3f,WritableVector3f
	{
		public float x;
		/*     */
		public float y;
		/*     */
		public float z;
		/*     */
		/*     */
		public Vector3f ()
		{
		}
		/*     */
		/*  65 */
		public Vector3f (ReadableVector3f src)
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
		public Vector3f (float x, float y, float z)
		{
			set (x, y, z);
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
		/*     */
		/*     */
		public Vector3f set (ReadableVector3f src)
		{
			/*  98 */
			this.x = src.getX ();
			/*  99 */
			this.y = src.getY ();
			/* 100 */
			this.z = src.getZ ();
			/* 101 */
			return this;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 108 */
		public override float lengthSquared ()
		{
			return this.x * this.x + this.y * this.y + this.z * this.z;
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
		public Vector3f translate (float x, float y, float z)
		{
			/* 118 */
			this.x += x;
			/* 119 */
			this.y += y;
			/* 120 */
			this.z += z;
			/* 121 */
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
		public static Vector3f add (Vector3f left, Vector3f right, Vector3f dest)
		{
			/* 133 */
			if (dest == null) {
				/* 134 */
				return new Vector3f (left.x + right.x, left.y + right.y, left.z + right.z);
				/*     */
			}
			/* 136 */
			dest.set (left.x + right.x, left.y + right.y, left.z + right.z);
			/* 137 */
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
		public static Vector3f sub (Vector3f left, Vector3f right, Vector3f dest)
		{
			/* 150 */
			if (dest == null) {
				/* 151 */
				return new Vector3f (left.x - right.x, left.y - right.y, left.z - right.z);
				/*     */
			}
			/* 153 */
			dest.set (left.x - right.x, left.y - right.y, left.z - right.z);
			/* 154 */
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
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public static Vector3f cross (Vector3f left, Vector3f right, Vector3f dest)
		{
/* 172 */
			if (dest == null) {
				/* 173 */
				dest = new Vector3f ();
				/*     */
			}
/* 175 */
			dest.set (left.y * right.z - left.z * right.y, right.x * left.z - right.z * left.x, left.x * right.y - left.y * right.x);
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */     
/* 181 */
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
/* 191 */
			this.x = -this.x;
/* 192 */
			this.y = -this.y;
/* 193 */
			this.z = -this.z;
/* 194 */
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
		public Vector3f negate (Vector3f dest)
		{
			/* 203 */
			if (dest == null)
		/* 204 */       dest = new Vector3f (); 
			/* 205 */
			dest.x = -this.x;
			/* 206 */
			dest.y = -this.y;
			/* 207 */
			dest.z = -this.z;
			/* 208 */
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
		public Vector3f normalise (Vector3f dest)
		{
/* 218 */
			float l = length ();
/*     */     
/* 220 */
			if (dest == null) {
/* 221 */
				dest = new Vector3f (this.x / l, this.y / l, this.z / l);
/*     */
			} else {
				/* 223 */
				dest.set (this.x / l, this.y / l, this.z / l);
				/*     */
			} 
/* 225 */
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
		/* 236 */
		public static float dot (Vector3f left, Vector3f right)
		{
			return left.x * right.x + left.y * right.y + left.z * right.z;
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
		public static float angle (Vector3f a, Vector3f b)
		{
			/* 246 */
			float dls = dot (a, b) / a.length () * b.length ();
			/* 247 */
			if (dls < -1.0F) {
				/* 248 */
				dls = -1.0F;
				/* 249 */
			} else if (dls > 1.0F) {
				/* 250 */
				dls = 1.0F;
				/* 251 */
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
		/*     */
		public override Vector scale (float scale)
		{
/* 269 */
			this.x *= scale;
/* 270 */
			this.y *= scale;
/* 271 */
			this.z *= scale;
/*     */     
/* 273 */
			return this;
/*     */
		}
		/*     */
		/*     */
		/*     */
		/*  
/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public override String ToString ()
		{
			/* 293 */
			StringBuilder sb = new StringBuilder (64);
			/*     */     
			/* 295 */
			sb.Append ("Vector3f[");
			/* 296 */
			sb.Append (this.x);
			/* 297 */
			sb.Append (", ");
			/* 298 */
			sb.Append (this.y);
			/* 299 */
			sb.Append (", ");
			/* 300 */
			sb.Append (this.z);
			/* 301 */
			sb.Append (']');
			/* 302 */
			return sb.ToString ();
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 309 */
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
		/* 316 */
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
		/* 324 */
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
		/* 332 */
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
		/* 340 */
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
		/* 347 */
		public float getZ ()
		{
			return this.z;
		}
		/*     */
		/*     */
		/*     */
		public override bool Equals (Object obj)
		{
			/* 351 */
			if (this == obj)
				return true; 
			/* 352 */
			if (obj == null)
				return false; 
			/* 353 */
			if (GetType () != obj.GetType ())
				return false; 
			/* 354 */
			Vector3f other = (Vector3f)obj;
			/*     */     
			/* 356 */
			if (this.x == other.x && this.y == other.y && this.z == other.z)
				return true;
			/*     */     
			/* 358 */
			return false;
			/*     */
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public static implicit operator OpenTK.Vector3(Vector3f vector){
			return new OpenTK.Vector3 (vector.x,vector.y,vector.z);
		}

	}
}

