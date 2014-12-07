using RadiUX.Unity.Sphere;
using RadiUX.Model.Sphere.Components;
using RadiUX.Unity.Util;
using System;
using UnityEngine;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public class ActionLayoutRotation : ActionAnimBase<Quaternion> {

		public Vector3 Rotation;
		
		private ISphereLayout vLayout;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void HandleActiveEvent() {
			vLayout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			
			if ( vLayout == null ) {
				throw new Exception("No parent "+typeof(ISphereLayout).Name+" was found.");
			}

			if ( !vLayout.Data.State.Still ) {
				return;
			}

			base.HandleActiveEvent();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void UpdateWithAnimValue(Quaternion pValue) {
			(vLayout as MonoBehaviour).gameObject.transform.localRotation = pValue;
			
			State state = vLayout.Data.State;
			state.Still = !vAnim.Active;
			vLayout.Data.UpdateState(state);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Quaternion CalcProgressValue(Quaternion pFrom, Quaternion pTo, float pProgress) {
			return Quaternion.Slerp(pFrom, pTo, pProgress);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Quaternion GetAnimFromValue() {
			return (vLayout as MonoBehaviour).gameObject.transform.localRotation;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Quaternion GetAnimToValue(Quaternion pFromValue) {
			return Quaternion.Euler(Rotation)*(IsRelativeChange ? pFromValue : Quaternion.identity);
		}


	}

}
