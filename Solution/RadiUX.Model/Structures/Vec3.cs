﻿namespace RadiUX.Model.Structures {

	/*================================================================================================*/
	public class Vec3 : Vec2 {

		public float Z { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vec3() {
		}

		/*--------------------------------------------------------------------------------------------*/
		public Vec3(float pX, float pY, float pZ) : base(pX, pY) {
			Z = pZ;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vec3 Clone() {
			return new Vec3(X, Y, Z);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Vec3 operator +(Vec3 pA, Vec3 pB) {
			return new Vec3(pA.X+pB.X, pA.Y+pB.Y, pA.Z+pB.Z);
		}

	}

}
