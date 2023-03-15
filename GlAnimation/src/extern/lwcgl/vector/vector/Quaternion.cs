using System;

namespace lwjgl.vector
{
	#if QUATERNION
	[Serializable]
	public class Quaternion : Vector
	{
		public float x;
		public float y;
		public float z;
		public float w;

		public Quaternion ()
		{
			setIdentity ();
		}

		public Quaternion (ReadableVector4f src)
		{
			set (src);
		}

		public Quaternion (float x, float y, float z, float w)
		{
			set (x, y, z, w);
		}

		public void set (float x, float y)
		{
			/*  81 */
			this.x = x;
			/*  82 */
			this.y = y;
			/*     */
		}

		public void set (float x, float y, float z)
		{
			/*  91 */
			this.x = x;
			/*  92 */
			this.y = y;
			/*  93 */
			this.z = z;
			/*     */
		}

		public void set (float x, float y, float z, float w)
		{
			/* 103 */
			this.x = x;
			/* 104 */
			this.y = y;
			/* 105 */
			this.z = z;
			/* 106 */
			this.w = w;
			/*     */
		}

		public Quaternion set (ReadableVector4f src)
		{
			/* 117 */
			this.x = src.getX ();
			/* 118 */
			this.y = src.getY ();
			/* 119 */
			this.z = src.getZ ();
			/* 120 */
			this.w = src.getW ();
			/* 121 */
			return this;
			/*     */
		}

		public Quaternion setIdentity ()
		{
			return setIdentity (this);
		}

		public static Quaternion setIdentity (Quaternion q)
		{
/* 138 */
			q.x = 0.0F;
/* 139 */
			q.y = 0.0F;
/* 140 */
			q.z = 0.0F;
/* 141 */
			q.w = 1.0F;
/* 142 */
			return q;
/*     */
		}

		public override float lengthSquared ()
		{
			return this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;
		}

		public static Quaternion normalise (Quaternion src, Quaternion dest)
		{
			/* 163 */
			float inv_l = 1.0F / src.length ();
			/*     */     
			/* 165 */
			if (dest == null) {
				/* 166 */
				dest = new Quaternion ();
				/*     */
			}
/* 168 */
			dest.set (src.x * inv_l, src.y * inv_l, src.z * inv_l, src.w * inv_l);
/*     */     
/* 170 */
			return dest;
/*     */
		}

		public Quaternion normalise (Quaternion dest)
		{
			return normalise (this, dest);
		}

		public static float dot (Quaternion left, Quaternion right)
		{
			return left.x * right.x + left.y * right.y + left.z * right.z + left.w * right.w;
		}

		public Quaternion negate (Quaternion dest)
		{
			return negate (this, dest);
		}

		public static Quaternion negate (Quaternion src, Quaternion dest)
		{
/* 220 */
			if (dest == null) {
				/* 221 */
				dest = new Quaternion ();
				/*     */
			}
/* 223 */
			dest.x = -src.x;
/* 224 */
			dest.y = -src.y;
/* 225 */
			dest.z = -src.z;
/* 226 */
			dest.w = src.w;
/*     */     
/* 228 */
			return dest;
/*     */
		}

		public override Vector negate ()
		{
			return negate (this, this);
		}

		public override Vector scale (float scale)
		{
			return Quaternion.scale (scale, this, this);
		}

		public static Quaternion scale (float scale, Quaternion src, Quaternion dest)
		{
/* 266 */
			if (dest == null)
	/* 267 */       dest = new Quaternion (); 
/* 268 */
			src.x *= scale;
/* 269 */
			src.y *= scale;
/* 270 */
			src.z *= scale;
/* 271 */
			src.w *= scale;
/* 272 */
			return dest;
/*     */
		}

		public float getX ()
		{
			return this.x;
		}

		public float getY ()
		{
			return this.y;
		}

		public void setX (float x)
		{
			this.x = x;
		}

		public void setY (float y)
		{
			this.y = y;
		}

		public void setZ (float z)
		{
			this.z = z;
		}

		public float getZ ()
		{
			return this.z;
		}

		public void setW (float w)
		{
			this.w = w;
		}

		public float getW ()
		{
			return this.w;
		}

		public String toString ()
		{
			return "Quaternion: " + this.x + " " + this.y + " " + this.z + " " + this.w;
		}

		public static Quaternion mul (Quaternion left, Quaternion right, Quaternion dest)
		{
/* 371 */
			if (dest == null)
	/* 372 */       dest = new Quaternion (); 
/* 373 */
			dest.set (left.x * right.w + left.w * right.x + left.y * right.z - left.z * right.y, left.y * right.w + left.w * right.y + left.z * right.x - left.x * right.z, left.z * right.w + left.w * right.z + left.x * right.y - left.y * right.x, left.w * right.w - left.x * right.x - left.y * right.y - left.z * right.z);
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */     
/* 379 */
			return dest;
/*     */
		}

		public static Quaternion mulInverse (Quaternion left, Quaternion right, Quaternion dest)
		{
/* 395 */
			float n = right.lengthSquared ();
/*     */     
/* 397 */
			n = (n == 0.0D) ? n : (1.0F / n);
/*     */     
/* 399 */
			if (dest == null)
/* 400 */       dest = new Quaternion (); 
/* 401 */
			dest.set ((left.x * right.w - left.w * right.x - left.y * right.z + left.z * right.y) * n, (left.y * right.w - left.w * right.y - left.z * right.x + left.x * right.z) * n, (left.z * right.w - left.w * right.z - left.x * right.y + left.y * right.x) * n, (left.w * right.w + left.x * right.x + left.y * right.y + left.z * right.z) * n);
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
/* 412 */
			return dest;
/*     */
		}

		public void setFromAxisAngle (Vector4f a1)
		{
			/* 423 */
			this.x = a1.x;
			/* 424 */
			this.y = a1.y;
			/* 425 */
			this.z = a1.z;
			/* 426 */
			float n = (float)Math.Sqrt ((this.x * this.x + this.y * this.y + this.z * this.z));
			/*     */     
			/* 428 */
			float s = (float)(Math.Sin (0.5D * a1.w) / n);
			/* 429 */
			this.x *= s;
			/* 430 */
			this.y *= s;
			/* 431 */
			this.z *= s;
			/* 432 */
			this.w = (float)Math.Cos (0.5D * a1.w);
			/*     */
		}

		public Quaternion setFromMatrix (Matrix4f m)
		{
			return setFromMatrix (m, this);
		}

		public static Quaternion setFromMatrix (Matrix4f m, Quaternion q)
		{
			return q.setFromMat (m.m00, m.m01, m.m02, m.m10, m.m11, m.m12, m.m20, m.m21, m.m22);
		}

		public Quaternion setFromMatrix (Matrix3f m)
		{
			return setFromMatrix (m, this);
		}

		public static Quaternion setFromMatrix (Matrix3f m, Quaternion q)
		{
			return q.setFromMat (m.m00, m.m01, m.m02, m.m10, m.m11, m.m12, m.m20, m.m21, m.m22);
		}

		private Quaternion setFromMat (float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
		{
/* 495 */
			float tr = m00 + m11 + m22;
/* 496 */
			if (tr >= 0.0D) {
				/* 497 */
				float s = (float)Math.Sqrt (tr + 1.0D);
				/* 498 */
				this.w = s * 0.5F;
				/* 499 */
				s = 0.5F / s;
				/* 500 */
				this.x = (m21 - m12) * s;
				/* 501 */
				this.y = (m02 - m20) * s;
				/* 502 */
				this.z = (m10 - m01) * s;
				/*     */
			} else {
				/* 504 */
				float max = Math.Max (Math.Max (m00, m11), m22);
				/* 505 */
				if (max == m00) {
					/* 506 */
					float s = (float)Math.Sqrt ((m00 - m11 + m22) + 1.0D);
					/* 507 */
					this.x = s * 0.5F;
					/* 508 */
					s = 0.5F / s;
					/* 509 */
					this.y = (m01 + m10) * s;
					/* 510 */
					this.z = (m20 + m02) * s;
					/* 511 */
					this.w = (m21 - m12) * s;
					/* 512 */
				} else if (max == m11) {
					/* 513 */
					float s = (float)Math.Sqrt ((m11 - m22 + m00) + 1.0D);
					/* 514 */
					this.y = s * 0.5F;
					/* 515 */
					s = 0.5F / s;
					/* 516 */
					this.z = (m12 + m21) * s;
					/* 517 */
					this.x = (m01 + m10) * s;
					/* 518 */
					this.w = (m02 - m20) * s;
					/*     */
				} else {
					/* 520 */
					float s = (float)Math.Sqrt ((m22 - m00 + m11) + 1.0D);
					/* 521 */
					this.z = s * 0.5F;
					/* 522 */
					s = 0.5F / s;
					/* 523 */
					this.x = (m20 + m02) * s;
					/* 524 */
					this.y = (m12 + m21) * s;
					/* 525 */
					this.w = (m10 - m01) * s;
					/*     */
				} 
				/*     */
			} 
/* 528 */
			return this;
/*     */
		}

		public static implicit operator OpenTK.Quaternion(Quaternion quaternion){
			return new OpenTK.Quaternion (quaternion.x,quaternion.y,quaternion.z,quaternion.w);
		}


	}
	#endif
}

