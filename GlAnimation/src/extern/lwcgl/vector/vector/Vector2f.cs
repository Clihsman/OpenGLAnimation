using System;
using System.Text;

namespace lwjgl.vector
{
	[Serializable]
	public class Vector2f : Vector, ReadableVector2f, WritableVector2f
	{
		public float x;
		/*     */
		public float y;
		/*     */
		/*     */
		public Vector2f ()
		{
		}
		/*     */
		/*  65 */
		public Vector2f (ReadableVector2f src)
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
		public Vector2f (float x, float y)
		{
			set (x, y);
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
		/*     */
		/*     */
		public Vector2f set (ReadableVector2f src)
		{
			/*  89 */
			this.x = src.getX ();
			/*  90 */
			this.y = src.getY ();
			/*  91 */
			return this;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*  98 */
		public override float lengthSquared ()
		{
			return this.x * this.x + this.y * this.y;
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
		public Vector2f translate (float x, float y)
		{
			/* 108 */
			this.x += x;
			/* 109 */
			this.y += y;
			/* 110 */
			return this;
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public override Vector negate ()
		{
			/* 118 */
			this.x = -this.x;
			/* 119 */
			this.y = -this.y;
			/* 120 */
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
		public Vector2f negate (Vector2f dest)
		{
			/* 129 */
			if (dest == null)
		/* 130 */       dest = new Vector2f (); 
			/* 131 */
			dest.x = -this.x;
			/* 132 */
			dest.y = -this.y;
			/* 133 */
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
		public Vector2f normalise (Vector2f dest)
		{
/* 143 */
			float l = length ();
/*     */     
/* 145 */
			if (dest == null) {
/* 146 */
				dest = new Vector2f (this.x / l, this.y / l);
/*     */
			} else {
				/* 148 */
				dest.set (this.x / l, this.y / l);
				/*     */
			} 
/* 150 */
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
		/* 161 */
		public static float dot (Vector2f left, Vector2f right)
		{
			return left.x * right.x + left.y * right.y;
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
		public static float angle (Vector2f a, Vector2f b)
		{
			/* 173 */
			float dls = dot (a, b) / a.length () * b.length ();
			/* 174 */
			if (dls < -1.0F) {
				/* 175 */
				dls = -1.0F;
				/* 176 */
			} else if (dls > 1.0F) {
				/* 177 */
				dls = 1.0F;
				/* 178 */
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
		/*     */
		public static Vector2f add (Vector2f left, Vector2f right, Vector2f dest)
		{
/* 190 */
			if (dest == null) {
				/* 191 */
				return new Vector2f (left.x + right.x, left.y + right.y);
				/*     */
			}
/* 193 */
			dest.set (left.x + right.x, left.y + right.y);
/* 194 */
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
		public static Vector2f sub (Vector2f left, Vector2f right, Vector2f dest)
		{
			/* 207 */
			if (dest == null) {
				/* 208 */
				return new Vector2f (left.x - right.x, left.y - right.y);
				/*     */
			}
			/* 210 */
			dest.set (left.x - right.x, left.y - right.y);
			/* 211 */
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
		public override Vector scale (float scale)
		{
/* 242 */
			this.x *= scale;
/* 243 */
			this.y *= scale;
/*     */     
/* 245 */
			return this;
/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		public override String ToString ()
		{
			/* 252 */
			StringBuilder sb = new StringBuilder (64);
			/*     */     
			/* 254 */
			sb.Append ("Vector2f[");
			/* 255 */
			sb.Append (this.x);
			/* 256 */
			sb.Append (", ");
			/* 257 */
			sb.Append (this.y);
			/* 258 */
			sb.Append (']');
			/* 259 */
			return sb.ToString ();
			/*     */
		}
		/*     */
		/*     */
		/*     */
		/*     */
		/*     */
		/* 266 */
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
		/* 273 */
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
		/* 281 */
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
		/* 289 */
		public void setY (float y)
		{
			this.y = y;
		}
		/*     */
		/*     */
		/*     */
		public override bool Equals (Object obj)
		{
			/* 293 */
			if (this == obj)
				return true; 
			/* 294 */
			if (obj == null)
				return false; 
			/* 295 */
			if (GetType () != obj.GetType ())
				return false; 
			/* 296 */
			Vector2f other = (Vector2f)obj;
			/*     */     
			/* 298 */
			if (this.x == other.x && this.y == other.y)
				return true;
			/*     */     
			/* 300 */
			return false;
			/*     */
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public static implicit operator OpenTK.Vector2(Vector2f vector){
			return new OpenTK.Vector2 (vector.x,vector.y);
		}

	}
}

