﻿/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using System.Collections.Generic;
using TouchScript.Gestures.Simple;
using UnityEngine;

namespace TouchScript.Gestures
{
    /// <summary>
    /// Recognizes dragging gesture.
    /// </summary>
    [AddComponentMenu("TouchScript/Gestures/Pan Gesture")]
    public class PanGesture : SimplePanGesture
    {
        #region Private variables

        private Clusters.Clusters clusters = new Clusters.Clusters();

        #endregion

        #region Public methods

        /// <inheritdoc />
        public override Vector2 ScreenPosition
        {
            get
            {
                if (touchPoints.Count == 0) return TouchManager.INVALID_POSITION;
                if (touchPoints.Count == 1) return touchPoints[0].Position;
                return (clusters.GetCenterPosition(Clusters.Clusters.CLUSTER1) + clusters.GetCenterPosition(Clusters.Clusters.CLUSTER2))*.5f;
            }
        }

        /// <inheritdoc />
        public override Vector2 PreviousScreenPosition
        {
            get
            {
                if (touchPoints.Count == 0) return TouchManager.INVALID_POSITION;
                if (touchPoints.Count == 1) return touchPoints[0].PreviousPosition;
                return (clusters.GetPreviousCenterPosition(Clusters.Clusters.CLUSTER1) + clusters.GetPreviousCenterPosition(Clusters.Clusters.CLUSTER2))*.5f;
            }
        }

        #endregion

        #region Unity methods

        #endregion

        #region Gesture callbacks

        /// <inheritdoc />
        protected override void touchesBegan(IList<ITouchPoint> touches)
        {
            clusters.AddPoints(touches);

            base.touchesBegan(touches);
        }

        /// <inheritdoc />
        protected override void touchesMoved(IList<ITouchPoint> touches)
        {
            clusters.Invalidate();

            base.touchesMoved(touches);
        }

        /// <inheritdoc />
        protected override void touchesEnded(IList<ITouchPoint> touches)
        {
            clusters.RemovePoints(touches);

            base.touchesEnded(touches);
        }

        /// <inheritdoc />
        protected override void reset()
        {
            base.reset();

            clusters.RemoveAllPoints();
        }

        #endregion
    }
}