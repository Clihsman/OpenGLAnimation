using System;
using System.Text;

namespace lwjgl.vector
{
	[Serializable]
	public class Matrix4f : Matrix
	{
		public float m00;
		public float m01;
		public float m02;
		public float m03;

		public float m10;
		public float m11;
		public float m12;
		public float m13;

		public float m20;
		public float m21;
		public float m22;
		public float m23;

		public float m30;
		public float m31;
		public float m32;
		public float m33;

		public Matrix4f ()
		{
			setIdentity ();
		}

		public Matrix4f (Matrix4f src)
		{
			load (src);
		}

		public String toString ()
		{
			/*  64 */
			StringBuilder buf = new StringBuilder ();
			/*  65 */
			buf.Append (this.m00).Append (' ').Append (this.m10).Append (' ').Append (this.m20).Append (' ').Append (this.m30).Append ('\n');
			/*  66 */
			buf.Append (this.m01).Append (' ').Append (this.m11).Append (' ').Append (this.m21).Append (' ').Append (this.m31).Append ('\n');
			/*  67 */
			buf.Append (this.m02).Append (' ').Append (this.m12).Append (' ').Append (this.m22).Append (' ').Append (this.m32).Append ('\n');
			/*  68 */
			buf.Append (this.m03).Append (' ').Append (this.m13).Append (' ').Append (this.m23).Append (' ').Append (this.m33).Append ('\n');
			/*  69 */
			return buf.ToString ();
			/*     */
		}

		public override Matrix setIdentity ()
		{
			return setIdentity (this);
		}

		public float[] toArray(){
			float[] data = new float[16];

			data [0] = m00;
			data [1] = m01;
			data [2] = m02;
			data [3] = m03;
		
			data [4] = m10;
			data [5] = m11;
			data [6] = m12;
			data [7] = m13;

			data [8] = m20;
			data [9] = m21;
			data [10] = m22;
			data [11] = m23;

			data [12] = m30;
			data [13] = m31;
			data [14] = m32;
			data [15] = m33;
			return data;
		}

		public static Matrix4f setIdentity (Matrix4f m)
		{
			/*  86 */
			m.m00 = 1.0F;
			/*  87 */
			m.m01 = 0.0F;
			/*  88 */
			m.m02 = 0.0F;
			/*  89 */
			m.m03 = 0.0F;
			/*  90 */
			m.m10 = 0.0F;
			/*  91 */
			m.m11 = 1.0F;
			/*  92 */
			m.m12 = 0.0F;
			/*  93 */
			m.m13 = 0.0F;
			/*  94 */
			m.m20 = 0.0F;
			/*  95 */
			m.m21 = 0.0F;
			/*  96 */
			m.m22 = 1.0F;
			/*  97 */
			m.m23 = 0.0F;
			/*  98 */
			m.m30 = 0.0F;
			/*  99 */
			m.m31 = 0.0F;
			/* 100 */
			m.m32 = 0.0F;
			/* 101 */
			m.m33 = 1.0F;
			/*     */     
			/* 103 */
			return m;
			/*     */
		}

		public override Matrix setZero ()
		{
			return setZero (this);
		}

		public static Matrix4f setZero (Matrix4f m)
		{
/* 120 */
			m.m00 = 0.0F;
/* 121 */
			m.m01 = 0.0F;
/* 122 */
			m.m02 = 0.0F;
/* 123 */
			m.m03 = 0.0F;
/* 124 */
			m.m10 = 0.0F;
/* 125 */
			m.m11 = 0.0F;
/* 126 */
			m.m12 = 0.0F;
/* 127 */
			m.m13 = 0.0F;
/* 128 */
			m.m20 = 0.0F;
/* 129 */
			m.m21 = 0.0F;
/* 130 */
			m.m22 = 0.0F;
/* 131 */
			m.m23 = 0.0F;
/* 132 */
			m.m30 = 0.0F;
/* 133 */
			m.m31 = 0.0F;
/* 134 */
			m.m32 = 0.0F;
/* 135 */
			m.m33 = 0.0F;
/*     */     
/* 137 */
			return m;
/*     */
		}

		public Matrix4f load (Matrix4f src)
		{
			return load (src, this);
		}

		public void load(float[] data)
		{
			this.m00 = data [0];
			this.m01 = data [1];
			this.m02 = data [2];
			this.m03 = data [3];

			this.m10 = data [4];
			this.m11 = data [5];
			this.m12 = data [6];
			this.m13 = data [7];

			this.m20 = data [8];
			this.m21 = data [9];
			this.m22 = data [10];
			this.m23 = data [11];

			this.m30 = data [12];
			this.m31 = data [13];
			this.m32 = data [14];
			this.m33 = data [15];
		}

		public static Matrix4f load (Matrix4f src, Matrix4f dest)
		{
			/* 156 */
			if (dest == null)
		/* 157 */       dest = new Matrix4f (); 
			/* 158 */
			dest.m00 = src.m00;
			/* 159 */
			dest.m01 = src.m01;
			/* 160 */
			dest.m02 = src.m02;
			/* 161 */
			dest.m03 = src.m03;
			/* 162 */
			dest.m10 = src.m10;
			/* 163 */
			dest.m11 = src.m11;
			/* 164 */
			dest.m12 = src.m12;
			/* 165 */
			dest.m13 = src.m13;
			/* 166 */
			dest.m20 = src.m20;
			/* 167 */
			dest.m21 = src.m21;
			/* 168 */
			dest.m22 = src.m22;
			/* 169 */
			dest.m23 = src.m23;
			/* 170 */
			dest.m30 = src.m30;
			/* 171 */
			dest.m31 = src.m31;
			/* 172 */
			dest.m32 = src.m32;
			/* 173 */
			dest.m33 = src.m33;
			/*     */     
			/* 175 */
			return dest;
			/*     */
		}

		public static Matrix4f add (Matrix4f left, Matrix4f right, Matrix4f dest)
		{
			/* 312 */
			if (dest == null) {
				/* 313 */
				dest = new Matrix4f ();
				/*     */
			}
			/* 315 */
			left.m00 += right.m00;
			/* 316 */
			left.m01 += right.m01;
			/* 317 */
			left.m02 += right.m02;
			/* 318 */
			left.m03 += right.m03;
			/* 319 */
			left.m10 += right.m10;
			/* 320 */
			left.m11 += right.m11;
			/* 321 */
			left.m12 += right.m12;
			/* 322 */
			left.m13 += right.m13;
			/* 323 */
			left.m20 += right.m20;
			/* 324 */
			left.m21 += right.m21;
			/* 325 */
			left.m22 += right.m22;
			/* 326 */
			left.m23 += right.m23;
			/* 327 */
			left.m30 += right.m30;
			/* 328 */
			left.m31 += right.m31;
			/* 329 */
			left.m32 += right.m32;
			/* 330 */
			left.m33 += right.m33;
			/*     */     
			/* 332 */
			return dest;
			/*     */
		}

		public static Matrix4f sub (Matrix4f left, Matrix4f right, Matrix4f dest)
		{
			/* 343 */
			if (dest == null) {
				/* 344 */
				dest = new Matrix4f ();
				/*     */
			}
			/* 346 */
			left.m00 -= right.m00;
			/* 347 */
			left.m01 -= right.m01;
			/* 348 */
			left.m02 -= right.m02;
			/* 349 */
			left.m03 -= right.m03;
			/* 350 */
			left.m10 -= right.m10;
			/* 351 */
			left.m11 -= right.m11;
			/* 352 */
			left.m12 -= right.m12;
			/* 353 */
			left.m13 -= right.m13;
			/* 354 */
			left.m20 -= right.m20;
			/* 355 */
			left.m21 -= right.m21;
			/* 356 */
			left.m22 -= right.m22;
			/* 357 */
			left.m23 -= right.m23;
			/* 358 */
			left.m30 -= right.m30;
			/* 359 */
			left.m31 -= right.m31;
			/* 360 */
			left.m32 -= right.m32;
			/* 361 */
			left.m33 -= right.m33;
			/*     */     
			/* 363 */
			return dest;
			/*     */
		}

		public static Matrix4f mul (Matrix4f left, Matrix4f right, Matrix4f dest)
		{
			/* 374 */
			if (dest == null) {
				/* 375 */
				dest = new Matrix4f ();
				/*     */
			}
			/* 377 */
			float m00 = left.m00 * right.m00 + left.m10 * right.m01 + left.m20 * right.m02 + left.m30 * right.m03;
			/* 378 */
			float m01 = left.m01 * right.m00 + left.m11 * right.m01 + left.m21 * right.m02 + left.m31 * right.m03;
			/* 379 */
			float m02 = left.m02 * right.m00 + left.m12 * right.m01 + left.m22 * right.m02 + left.m32 * right.m03;
			/* 380 */
			float m03 = left.m03 * right.m00 + left.m13 * right.m01 + left.m23 * right.m02 + left.m33 * right.m03;
			/* 381 */
			float m10 = left.m00 * right.m10 + left.m10 * right.m11 + left.m20 * right.m12 + left.m30 * right.m13;
			/* 382 */
			float m11 = left.m01 * right.m10 + left.m11 * right.m11 + left.m21 * right.m12 + left.m31 * right.m13;
			/* 383 */
			float m12 = left.m02 * right.m10 + left.m12 * right.m11 + left.m22 * right.m12 + left.m32 * right.m13;
			/* 384 */
			float m13 = left.m03 * right.m10 + left.m13 * right.m11 + left.m23 * right.m12 + left.m33 * right.m13;
			/* 385 */
			float m20 = left.m00 * right.m20 + left.m10 * right.m21 + left.m20 * right.m22 + left.m30 * right.m23;
			/* 386 */
			float m21 = left.m01 * right.m20 + left.m11 * right.m21 + left.m21 * right.m22 + left.m31 * right.m23;
			/* 387 */
			float m22 = left.m02 * right.m20 + left.m12 * right.m21 + left.m22 * right.m22 + left.m32 * right.m23;
			/* 388 */
			float m23 = left.m03 * right.m20 + left.m13 * right.m21 + left.m23 * right.m22 + left.m33 * right.m23;
			/* 389 */
			float m30 = left.m00 * right.m30 + left.m10 * right.m31 + left.m20 * right.m32 + left.m30 * right.m33;
			/* 390 */
			float m31 = left.m01 * right.m30 + left.m11 * right.m31 + left.m21 * right.m32 + left.m31 * right.m33;
			/* 391 */
			float m32 = left.m02 * right.m30 + left.m12 * right.m31 + left.m22 * right.m32 + left.m32 * right.m33;
			/* 392 */
			float m33 = left.m03 * right.m30 + left.m13 * right.m31 + left.m23 * right.m32 + left.m33 * right.m33;
			/*     */     
			/* 394 */
			dest.m00 = m00;
			/* 395 */
			dest.m01 = m01;
			/* 396 */
			dest.m02 = m02;
			/* 397 */
			dest.m03 = m03;
			/* 398 */
			dest.m10 = m10;
			/* 399 */
			dest.m11 = m11;
			/* 400 */
			dest.m12 = m12;
			/* 401 */
			dest.m13 = m13;
			/* 402 */
			dest.m20 = m20;
			/* 403 */
			dest.m21 = m21;
			/* 404 */
			dest.m22 = m22;
			/* 405 */
			dest.m23 = m23;
			/* 406 */
			dest.m30 = m30;
			/* 407 */
			dest.m31 = m31;
			/* 408 */
			dest.m32 = m32;
			/* 409 */
			dest.m33 = m33;
			/*     */     
			/* 411 */
			return dest;
			/*     */
		}

		public static Vector4f transform (Matrix4f left, Vector4f right, Vector4f dest)
		{
/* 423 */
			if (dest == null) {
				/* 424 */
				dest = new Vector4f ();
				/*     */
			}
/* 426 */
			float x = left.m00 * right.x + left.m10 * right.y + left.m20 * right.z + left.m30 * right.w;
/* 427 */
			float y = left.m01 * right.x + left.m11 * right.y + left.m21 * right.z + left.m31 * right.w;
/* 428 */
			float z = left.m02 * right.x + left.m12 * right.y + left.m22 * right.z + left.m32 * right.w;
/* 429 */
			float w = left.m03 * right.x + left.m13 * right.y + left.m23 * right.z + left.m33 * right.w;
/*     */     
/* 431 */
			dest.x = x;
/* 432 */
			dest.y = y;
/* 433 */
			dest.z = z;
/* 434 */
			dest.w = w;
/*     */     
/* 436 */
			return dest;
/*     */
		}

		public override Matrix transpose ()
		{
			return transpose (this);
		}

		public Matrix4f translate (Vector2f vec)
		{
			return translate (vec, this);
		}
	
		public Matrix4f translate (Vector3f vec)
		{
			return translate (vec, this);
		}

		public Matrix4f scale (Vector3f vec)
		{
			return scale (vec, this, this);
		}
	
		public static Matrix4f scale (Vector3f vec, Matrix4f src, Matrix4f dest)
		{
/* 482 */
			if (dest == null)
	/* 483 */       dest = new Matrix4f (); 
/* 484 */
			src.m00 *= vec.x;
/* 485 */
			src.m01 *= vec.x;
/* 486 */
			src.m02 *= vec.x;
/* 487 */
			src.m03 *= vec.x;
/* 488 */
			src.m10 *= vec.y;
/* 489 */
			src.m11 *= vec.y;
/* 490 */
			src.m12 *= vec.y;
/* 491 */
			src.m13 *= vec.y;
/* 492 */
			src.m20 *= vec.z;
/* 493 */
			src.m21 *= vec.z;
/* 494 */
			src.m22 *= vec.z;
/* 495 */
			src.m23 *= vec.z;
/* 496 */
			return dest;
/*     */
		}
	
		public Matrix4f rotate (float angle, Vector3f axis)
		{
			return rotate (angle, axis, this);
		}
	
		public Matrix4f rotate (float angle, Vector3f axis, Matrix4f dest)
		{
			return rotate (angle, axis, this, dest);
		}
	
		public static Matrix4f rotate (float angle, Vector3f axis, Matrix4f src, Matrix4f dest)
		{
/* 530 */
			if (dest == null)
	/* 531 */       dest = new Matrix4f (); 
/* 532 */
			float c = (float)Math.Cos (angle);
/* 533 */
			float s = (float)Math.Sin (angle);
/* 534 */
			float oneminusc = 1.0F - c;
/* 535 */
			float xy = axis.x * axis.y;
/* 536 */
			float yz = axis.y * axis.z;
/* 537 */
			float xz = axis.x * axis.z;
/* 538 */
			float xs = axis.x * s;
/* 539 */
			float ys = axis.y * s;
/* 540 */
			float zs = axis.z * s;
/*     */     
/* 542 */
			float f00 = axis.x * axis.x * oneminusc + c;
/* 543 */
			float f01 = xy * oneminusc + zs;
/* 544 */
			float f02 = xz * oneminusc - ys;
/*     */     
/* 546 */
			float f10 = xy * oneminusc - zs;
/* 547 */
			float f11 = axis.y * axis.y * oneminusc + c;
/* 548 */
			float f12 = yz * oneminusc + xs;
/*     */     
/* 550 */
			float f20 = xz * oneminusc + ys;
/* 551 */
			float f21 = yz * oneminusc - xs;
/* 552 */
			float f22 = axis.z * axis.z * oneminusc + c;
/*     */     
/* 554 */
			float t00 = src.m00 * f00 + src.m10 * f01 + src.m20 * f02;
/* 555 */
			float t01 = src.m01 * f00 + src.m11 * f01 + src.m21 * f02;
/* 556 */
			float t02 = src.m02 * f00 + src.m12 * f01 + src.m22 * f02;
/* 557 */
			float t03 = src.m03 * f00 + src.m13 * f01 + src.m23 * f02;
/* 558 */
			float t10 = src.m00 * f10 + src.m10 * f11 + src.m20 * f12;
/* 559 */
			float t11 = src.m01 * f10 + src.m11 * f11 + src.m21 * f12;
/* 560 */
			float t12 = src.m02 * f10 + src.m12 * f11 + src.m22 * f12;
/* 561 */
			float t13 = src.m03 * f10 + src.m13 * f11 + src.m23 * f12;
/* 562 */
			dest.m20 = src.m00 * f20 + src.m10 * f21 + src.m20 * f22;
/* 563 */
			dest.m21 = src.m01 * f20 + src.m11 * f21 + src.m21 * f22;
/* 564 */
			dest.m22 = src.m02 * f20 + src.m12 * f21 + src.m22 * f22;
/* 565 */
			dest.m23 = src.m03 * f20 + src.m13 * f21 + src.m23 * f22;
/* 566 */
			dest.m00 = t00;
/* 567 */
			dest.m01 = t01;
/* 568 */
			dest.m02 = t02;
/* 569 */
			dest.m03 = t03;
/* 570 */
			dest.m10 = t10;
/* 571 */
			dest.m11 = t11;
/* 572 */
			dest.m12 = t12;
/* 573 */
			dest.m13 = t13;
/* 574 */
			return dest;
/*     */
		}

		public Matrix4f translate (Vector3f vec, Matrix4f dest)
		{
			return translate (vec, this, dest);
		}
	
		public static Matrix4f translate (Vector3f vec, Matrix4f src, Matrix4f dest)
		{
/* 595 */
			if (dest == null) {
				/* 596 */
				dest = new Matrix4f ();
				/*     */
			}
/* 598 */
			dest.m30 += src.m00 * vec.x + src.m10 * vec.y + src.m20 * vec.z;
/* 599 */
			dest.m31 += src.m01 * vec.x + src.m11 * vec.y + src.m21 * vec.z;
/* 600 */
			dest.m32 += src.m02 * vec.x + src.m12 * vec.y + src.m22 * vec.z;
/* 601 */
			dest.m33 += src.m03 * vec.x + src.m13 * vec.y + src.m23 * vec.z;
/*     */     
/* 603 */
			return dest;
/*     */
		}

		public Matrix4f translate (Vector2f vec, Matrix4f dest)
		{
			return translate (vec, this, dest);
		}

		public static Matrix4f translate (Vector2f vec, Matrix4f src, Matrix4f dest)
		{
/* 624 */
			if (dest == null) {
				/* 625 */
				dest = new Matrix4f ();
				/*     */
			}
/* 627 */
			dest.m30 += src.m00 * vec.x + src.m10 * vec.y;
/* 628 */
			dest.m31 += src.m01 * vec.x + src.m11 * vec.y;
/* 629 */
			dest.m32 += src.m02 * vec.x + src.m12 * vec.y;
/* 630 */
			dest.m33 += src.m03 * vec.x + src.m13 * vec.y;
/*     */     
/* 632 */
			return dest;
/*     */
		}

		public Matrix4f transpose (Matrix4f dest)
		{
			return transpose (this, dest);
		}
	
		public static Matrix4f transpose (Matrix4f src, Matrix4f dest)
		{
			/* 651 */
			if (dest == null)
		/* 652 */       dest = new Matrix4f (); 
			/* 653 */
			float m00 = src.m00;
			/* 654 */
			float m01 = src.m10;
			/* 655 */
			float m02 = src.m20;
			/* 656 */
			float m03 = src.m30;
			/* 657 */
			float m10 = src.m01;
			/* 658 */
			float m11 = src.m11;
			/* 659 */
			float m12 = src.m21;
			/* 660 */
			float m13 = src.m31;
			/* 661 */
			float m20 = src.m02;
			/* 662 */
			float m21 = src.m12;
			/* 663 */
			float m22 = src.m22;
			/* 664 */
			float m23 = src.m32;
			/* 665 */
			float m30 = src.m03;
			/* 666 */
			float m31 = src.m13;
			/* 667 */
			float m32 = src.m23;
			/* 668 */
			float m33 = src.m33;
			/*     */     
			/* 670 */
			dest.m00 = m00;
			/* 671 */
			dest.m01 = m01;
			/* 672 */
			dest.m02 = m02;
			/* 673 */
			dest.m03 = m03;
			/* 674 */
			dest.m10 = m10;
			/* 675 */
			dest.m11 = m11;
			/* 676 */
			dest.m12 = m12;
			/* 677 */
			dest.m13 = m13;
			/* 678 */
			dest.m20 = m20;
			/* 679 */
			dest.m21 = m21;
			/* 680 */
			dest.m22 = m22;
			/* 681 */
			dest.m23 = m23;
			/* 682 */
			dest.m30 = m30;
			/* 683 */
			dest.m31 = m31;
			/* 684 */
			dest.m32 = m32;
			/* 685 */
			dest.m33 = m33;
			/*     */     
			/* 687 */
			return dest;
			/*     */
		}

		public override float determinant ()
		{
			/* 694 */
			float f = this.m00 * (this.m11 * this.m22 * this.m33 + this.m12 * this.m23 * this.m31 + this.m13 * this.m21 * this.m32 - this.m13 * this.m22 * this.m31 - this.m11 * this.m23 * this.m32 - this.m12 * this.m21 * this.m33);
			/*     */ 
			/*     */ 
			/*     */ 
			/*     */ 
			/*     */     
			/* 700 */
			f += this.m01 * (this.m10 * this.m22 * this.m33 + this.m12 * this.m23 * this.m30 + this.m13 * this.m20 * this.m32 - this.m13 * this.m22 * this.m30 - this.m10 * this.m23 * this.m32 - this.m12 * this.m20 * this.m33);
			/*     */ 
			/*     */ 
			/*     */ 
			/*     */     
			/* 705 */
			f += this.m02 * (this.m10 * this.m21 * this.m33 + this.m11 * this.m23 * this.m30 + this.m13 * this.m20 * this.m31 - this.m13 * this.m21 * this.m30 - this.m10 * this.m23 * this.m31 - this.m11 * this.m20 * this.m33);
			/*     */ 
			/*     */ 
			/*     */ 
			/*     */     
			/* 710 */

			f += this.m03 * (this.m10 * this.m21 * this.m32 + this.m11 * this.m22 * this.m30 + this.m12 * this.m20 * this.m31 - this.m12 * this.m21 * this.m30 - this.m10 * this.m22 * this.m31 - this.m11 * this.m20 * this.m32);
		//	Console.WriteLine (f);
		//	Console.WriteLine (this.m03 * (this.m10 * this.m21 * this.m32 + this.m11 * this.m22 * this.m30 + this.m12 * this.m20 * this.m31 - this.m12 * this.m21 * this.m30 - this.m10 * this.m22 * this.m31 - this.m11 * this.m20 * this.m32));
			return f;
			//return this.m03 * (this.m10 * this.m21 * this.m32 + this.m11 * this.m22 * this.m30 + this.m12 * this.m20 * this.m31 - this.m12 * this.m21 * this.m30 - this.m10 * this.m22 * this.m31 - this.m11 * this.m20 * this.m32);
			/*     */
		}

		private static float determinant3x3 (float t00, float t01, float t02, float t10, float t11, float t12, float t20, float t21, float t22)
		{
			return t00 * (t11 * t22 - t12 * t21) + t01 * (t12 * t20 - t10 * t22) + t02 * (t10 * t21 - t11 * t20);
		}

		public override Matrix invert ()
		{
			return invert (this, this);
		}

		public static Matrix4f invert (Matrix4f src, Matrix4f dest)
		{
			/* 747 */
			float determinant = src.determinant ();
			/*     */     
			/* 749 */
			if (determinant != 0.0F) {
				/*     */ 
				/*     */ 
				/*     */ 
				/*     */ 
				/*     */ 
				/*     */       
				/* 756 */
				if (dest == null)
		/* 757 */         dest = new Matrix4f (); 
				/* 758 */
				float determinant_inv = 1.0F / determinant;
				/*     */ 
				/*     */       
				/* 761 */
				float t00 = determinant3x3 (src.m11, src.m12, src.m13, src.m21, src.m22, src.m23, src.m31, src.m32, src.m33);
				/* 762 */
				float t01 = -determinant3x3 (src.m10, src.m12, src.m13, src.m20, src.m22, src.m23, src.m30, src.m32, src.m33);
				/* 763 */
				float t02 = determinant3x3 (src.m10, src.m11, src.m13, src.m20, src.m21, src.m23, src.m30, src.m31, src.m33);
				/* 764 */
				float t03 = -determinant3x3 (src.m10, src.m11, src.m12, src.m20, src.m21, src.m22, src.m30, src.m31, src.m32);
				/*     */       
				/* 766 */
				float t10 = -determinant3x3 (src.m01, src.m02, src.m03, src.m21, src.m22, src.m23, src.m31, src.m32, src.m33);
				/* 767 */
				float t11 = determinant3x3 (src.m00, src.m02, src.m03, src.m20, src.m22, src.m23, src.m30, src.m32, src.m33);
				/* 768 */
				float t12 = -determinant3x3 (src.m00, src.m01, src.m03, src.m20, src.m21, src.m23, src.m30, src.m31, src.m33);
				/* 769 */
				float t13 = determinant3x3 (src.m00, src.m01, src.m02, src.m20, src.m21, src.m22, src.m30, src.m31, src.m32);
				/*     */       
				/* 771 */
				float t20 = determinant3x3 (src.m01, src.m02, src.m03, src.m11, src.m12, src.m13, src.m31, src.m32, src.m33);
				/* 772 */
				float t21 = -determinant3x3 (src.m00, src.m02, src.m03, src.m10, src.m12, src.m13, src.m30, src.m32, src.m33);
				/* 773 */
				float t22 = determinant3x3 (src.m00, src.m01, src.m03, src.m10, src.m11, src.m13, src.m30, src.m31, src.m33);
				/* 774 */
				float t23 = -determinant3x3 (src.m00, src.m01, src.m02, src.m10, src.m11, src.m12, src.m30, src.m31, src.m32);
				/*     */       
				/* 776 */
				float t30 = -determinant3x3 (src.m01, src.m02, src.m03, src.m11, src.m12, src.m13, src.m21, src.m22, src.m23);
				/* 777 */
				float t31 = determinant3x3 (src.m00, src.m02, src.m03, src.m10, src.m12, src.m13, src.m20, src.m22, src.m23);
				/* 778 */
				float t32 = -determinant3x3 (src.m00, src.m01, src.m03, src.m10, src.m11, src.m13, src.m20, src.m21, src.m23);
				/* 779 */
				float t33 = determinant3x3 (src.m00, src.m01, src.m02, src.m10, src.m11, src.m12, src.m20, src.m21, src.m22);
				/*     */ 
				/*     */       
				/* 782 */
				dest.m00 = t00 * determinant_inv;
				/* 783 */
				dest.m11 = t11 * determinant_inv;
				/* 784 */
				dest.m22 = t22 * determinant_inv;
				/* 785 */
				dest.m33 = t33 * determinant_inv;
				/* 786 */
				dest.m01 = t10 * determinant_inv;
				/* 787 */
				dest.m10 = t01 * determinant_inv;
				/* 788 */
				dest.m20 = t02 * determinant_inv;
				/* 789 */
				dest.m02 = t20 * determinant_inv;
				/* 790 */
				dest.m12 = t21 * determinant_inv;
				/* 791 */
				dest.m21 = t12 * determinant_inv;
				/* 792 */
				dest.m03 = t30 * determinant_inv;
				/* 793 */
				dest.m30 = t03 * determinant_inv;
				/* 794 */
				dest.m13 = t31 * determinant_inv;
				/* 795 */
				dest.m31 = t13 * determinant_inv;
				/* 796 */
				dest.m32 = t23 * determinant_inv;
				/* 797 */
				dest.m23 = t32 * determinant_inv;
				/* 798 */
				return dest;
				/*     */
			} 
/* 800 */
			return null;
/*     */
		}

		public override Matrix negate ()
		{
			return negate (this);
		}

		public Matrix4f negate (Matrix4f dest)
		{
			return negate (this, dest);
		}

		public static Matrix4f negate (Matrix4f src, Matrix4f dest)
		{
			/* 827 */
			if (dest == null) {
				/* 828 */
				dest = new Matrix4f ();
				/*     */
			}
			/* 830 */
			dest.m00 = -src.m00;
			/* 831 */
			dest.m01 = -src.m01;
			/* 832 */
			dest.m02 = -src.m02;
			/* 833 */
			dest.m03 = -src.m03;
			/* 834 */
			dest.m10 = -src.m10;
			/* 835 */
			dest.m11 = -src.m11;
			/* 836 */
			dest.m12 = -src.m12;
			/* 837 */
			dest.m13 = -src.m13;
			/* 838 */
			dest.m20 = -src.m20;
			/* 839 */
			dest.m21 = -src.m21;
			/* 840 */
			dest.m22 = -src.m22;
			/* 841 */
			dest.m23 = -src.m23;
			/* 842 */
			dest.m30 = -src.m30;
			/* 843 */
			dest.m31 = -src.m31;
			/* 844 */
			dest.m32 = -src.m32;
			/* 845 */
			dest.m33 = -src.m33;
			/*     */     
			/* 847 */
			return dest;
			/*     */
		}

		public static implicit operator OpenTK.Matrix4(Matrix4f matrix){
			return new OpenTK.Matrix4 (
				matrix.m00,matrix.m01,matrix.m02,matrix.m03,
				matrix.m10,matrix.m11,matrix.m12,matrix.m13,
				matrix.m20,matrix.m21,matrix.m22,matrix.m23,
				matrix.m30,matrix.m31,matrix.m32,matrix.m33
			);
		}

	}
}

