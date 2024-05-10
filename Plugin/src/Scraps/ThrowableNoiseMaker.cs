using GameNetcodeStuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ImmersiveScrap.Misc
{
    public class ThrowableNoisemaker : NoisemakerProp
    {
        public bool throwWithRight = false;
        public bool beingThrown = false;

        public override void FallWithCurve()
        {
            float magnitude = (startFallingPosition - targetFloorPosition).magnitude;
            base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(itemProperties.restingRotation.x, base.transform.eulerAngles.y, itemProperties.restingRotation.z), 14f * Time.deltaTime / magnitude);
            base.transform.localPosition = Vector3.Lerp(startFallingPosition, targetFloorPosition, itemFallCurve.Evaluate(fallTime));
            if (magnitude > 5f)
            {
                base.transform.localPosition = Vector3.Lerp(new Vector3(base.transform.localPosition.x, startFallingPosition.y, base.transform.localPosition.z), new Vector3(base.transform.localPosition.x, targetFloorPosition.y, base.transform.localPosition.z), itemVerticalFallCurveNoBounce.Evaluate(fallTime));
            }
            else
            {
                base.transform.localPosition = Vector3.Lerp(new Vector3(base.transform.localPosition.x, startFallingPosition.y, base.transform.localPosition.z), new Vector3(base.transform.localPosition.x, targetFloorPosition.y, base.transform.localPosition.z), itemVerticalFallCurve.Evaluate(fallTime));
            }
            fallTime += Mathf.Abs(Time.deltaTime * 12f / magnitude);
        }
        public override void ItemActivate(bool used, bool buttonDown = true) {
        }
        public Vector3 GetItemThrowDestination()
        {
            Vector3 position = base.transform.position;
            //Debug.DrawRay(playerHeldBy.gameplayCamera.transform.position, playerHeldBy.gameplayCamera.transform.forward, Color.yellow, 15f);
            itemThrowRay = new Ray(playerHeldBy.gameplayCamera.transform.position, playerHeldBy.gameplayCamera.transform.forward);

            // Multiply the range by 3
            float maxThrowDistance = 30f;  // Original distance was 10f for no hit
            if (Physics.Raycast(itemThrowRay, out itemHit, maxThrowDistance, StartOfRound.Instance.collidersAndRoomMaskAndDefault, QueryTriggerInteraction.Ignore))
            {
                position = itemThrowRay.GetPoint(itemHit.distance - 0.05f);
            }
            else
            {
                position = itemThrowRay.GetPoint(maxThrowDistance);
            }
            //Debug.DrawRay(position, Vector3.down, Color.blue, 15f);
            itemThrowRay = new Ray(position, Vector3.down);

            // Keep the vertical raycast distance consistent to ensure it checks correctly to the ground
            if (Physics.Raycast(itemThrowRay, out itemHit, 30f, StartOfRound.Instance.collidersAndRoomMaskAndDefault, QueryTriggerInteraction.Ignore))
            {
                return itemHit.point + Vector3.up * 0.05f;
            }
            return itemThrowRay.GetPoint(30f);
        }

        public AnimationCurve itemFallCurve;

        public AnimationCurve itemVerticalFallCurve;

        public AnimationCurve itemVerticalFallCurveNoBounce;

        public RaycastHit itemHit;

        public Ray itemThrowRay;

    }
}