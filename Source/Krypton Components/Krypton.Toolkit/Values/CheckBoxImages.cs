﻿#region BSD License
/*
 * 
 * Original BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
 *  © Component Factory Pty Ltd, 2006 - 2016, All rights reserved.
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2017 - 2021. All rights reserved. 
 *  
 *  Modified: Monday 12th April, 2021 @ 18:00 GMT
 *
 */
#endregion


namespace Krypton.Toolkit
{
    /// <summary>
    /// Storage for check box images.
    /// </summary>
    public class CheckBoxImages : Storage
    {
        #region Instance Fields
        private Image _common;
        private Image _uncheckedDisabled;
        private Image _uncheckedNormal;
        private Image _uncheckedTracking;
        private Image _uncheckedPressed;
        private Image _checkedDisabled;
        private Image _checkedNormal;
        private Image _checkedTracking;
        private Image _checkedPressed;
        private Image _indeterminateDisabled;
        private Image _indeterminateNormal;
        private Image _indeterminateTracking;
        private Image _indeterminatePressed;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the CheckBoxImages class.
        /// </summary>
        public CheckBoxImages()
            : this(null)
        {
        }

        /// <summary>
        /// Initialize a new instance of the CheckBoxImages class.
        /// </summary>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public CheckBoxImages(NeedPaintHandler needPaint) 
        {
            // Store the provided paint notification delegate
            NeedPaint = needPaint;

            // Create the storage
            _common = null;
            _uncheckedDisabled = null;
            _uncheckedNormal = null;
            _uncheckedTracking = null;
            _uncheckedPressed = null;
            _checkedDisabled = null;
            _checkedNormal = null;
            _checkedTracking = null;
            _checkedPressed = null;
            _indeterminateDisabled = null;
            _indeterminateNormal = null;
            _indeterminateTracking = null;
            _indeterminatePressed = null;
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        public override bool IsDefault => (_common == null) &&
                                          (_uncheckedDisabled == null) &&
                                          (_uncheckedNormal == null) &&
                                          (_uncheckedTracking == null) &&
                                          (_uncheckedPressed == null) &&
                                          (_checkedDisabled == null) &&
                                          (_checkedNormal == null) &&
                                          (_checkedTracking == null) &&
                                          (_checkedPressed == null) &&
                                          (_indeterminateDisabled == null) &&
                                          (_indeterminateNormal == null) &&
                                          (_indeterminateTracking == null) &&
                                          (_indeterminatePressed == null);

        #endregion

        #region Common
        /// <summary>
        /// Gets and sets the common image that other check box images inherit from.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Common image that other check box images inherit from.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image Common
        {
            get => _common;

            set
            {
                if (_common != value)
                {
                    _common = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the Common property to its default value.
        /// </summary>
        public void ResetCommon()
        {
            Common = null;
        }
        #endregion

        #region UncheckedDisabled
        /// <summary>
        /// Gets and sets the image for use when the check box is not checked and disabled.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is not checked and disabled.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image UncheckedDisabled
        {
            get => _uncheckedDisabled;

            set
            {
                if (_uncheckedDisabled != value)
                {
                    _uncheckedDisabled = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the UncheckedDisabled property to its default value.
        /// </summary>
        public void ResetUncheckedDisabled()
        {
            UncheckedDisabled = null;
        }
        #endregion

        #region UncheckedNormal
        /// <summary>
        /// Gets and sets the image for use when the check box is unchecked.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is unchecked.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image UncheckedNormal
        {
            get => _uncheckedNormal;

            set
            {
                if (_uncheckedNormal != value)
                {
                    _uncheckedNormal = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the UncheckedNormal property to its default value.
        /// </summary>
        public void ResetUncheckedNormal()
        {
            UncheckedNormal = null;
        }
        #endregion

        #region UncheckedTracking
        /// <summary>
        /// Gets and sets the image for use when the check box is unchecked and hot tracking.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is unchecked and hot tracking.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image UncheckedTracking
        {
            get => _uncheckedTracking;

            set
            {
                if (_uncheckedTracking != value)
                {
                    _uncheckedTracking = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the UncheckedTracking property to its default value.
        /// </summary>
        public void ResetUncheckedTracking()
        {
            UncheckedTracking = null;
        }
        #endregion

        #region UncheckedPressed
        /// <summary>
        /// Gets and sets the image for use when the check box is unchecked and pressed.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is unchecked and pressed.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image UncheckedPressed
        {
            get => _uncheckedPressed;

            set
            {
                if (_uncheckedPressed != value)
                {
                    _uncheckedPressed = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the UncheckedPressed property to its default value.
        /// </summary>
        public void ResetUncheckedPressed()
        {
            UncheckedPressed = null;
        }
        #endregion

        #region CheckedDisabled
        /// <summary>
        /// Gets and sets the image for use when the check box is checked but disabled.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is checked but disabled.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image CheckedDisabled
        {
            get => _checkedDisabled;

            set
            {
                if (_checkedDisabled != value)
                {
                    _checkedDisabled = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the CheckedDisabled property to its default value.
        /// </summary>
        public void ResetCheckedDisabled()
        {
            CheckedDisabled = null;
        }
        #endregion

        #region CheckedNormal
        /// <summary>
        /// Gets and sets the image for use when the check box is checked.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is checked.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image CheckedNormal
        {
            get => _checkedNormal;

            set
            {
                if (_checkedNormal != value)
                {
                    _checkedNormal = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the CheckedNormal property to its default value.
        /// </summary>
        public void ResetCheckedNormal()
        {
            CheckedNormal = null;
        }
        #endregion

        #region CheckedTracking
        /// <summary>
        /// Gets and sets the image for use when the check box is checked and hot tracking.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is checked and hot tracking.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image CheckedTracking
        {
            get => _checkedTracking;

            set
            {
                if (_checkedTracking != value)
                {
                    _checkedTracking = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the CheckedTracking property to its default value.
        /// </summary>
        public void ResetCheckedTracking()
        {
            CheckedTracking = null;
        }
        #endregion

        #region CheckedPressed
        /// <summary>
        /// Gets and sets the image for use when the check box is checked and pressed.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is checked and pressed.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image CheckedPressed
        {
            get => _checkedPressed;

            set
            {
                if (_checkedPressed != value)
                {
                    _checkedPressed = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the CheckedPressed property to its default value.
        /// </summary>
        public void ResetCheckedPressed()
        {
            CheckedPressed = null;
        }
        #endregion

        #region IndeterminateDisabled
        /// <summary>
        /// Gets and sets the image for use when the check box is indeterminate but disabled.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is indeterminate but disabled.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image IndeterminateDisabled
        {
            get => _indeterminateDisabled;

            set
            {
                if (_indeterminateDisabled != value)
                {
                    _indeterminateDisabled = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the IndeterminateDisabled property to its default value.
        /// </summary>
        public void ResetIndeterminateDisabled()
        {
            IndeterminateDisabled = null;
        }
        #endregion

        #region IndeterminateNormal
        /// <summary>
        /// Gets and sets the image for use when the check box is indeterminate.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is indeterminate.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image IndeterminateNormal
        {
            get => _indeterminateNormal;

            set
            {
                if (_indeterminateNormal != value)
                {
                    _indeterminateNormal = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the IndeterminateNormal property to its default value.
        /// </summary>
        public void ResetIndeterminateNormal()
        {
            IndeterminateNormal = null;
        }
        #endregion

        #region IndeterminateTracking
        /// <summary>
        /// Gets and sets the image for use when the check box is indeterminate and hot tracking.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is indeterminate and hot tracking.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image IndeterminateTracking
        {
            get => _indeterminateTracking;

            set
            {
                if (_indeterminateTracking != value)
                {
                    _indeterminateTracking = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the IndeterminateTracking property to its default value.
        /// </summary>
        public void ResetIndeterminateTracking()
        {
            IndeterminateTracking = null;
        }
        #endregion

        #region IndeterminatePressed
        /// <summary>
        /// Gets and sets the image for use when the check box is indeterminate and pressed.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for use when the check box is indeterminate and pressed.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public Image IndeterminatePressed
        {
            get => _indeterminatePressed;

            set
            {
                if (_indeterminatePressed != value)
                {
                    _indeterminatePressed = value;
                    PerformNeedPaint(true);
                }
            }
        }

        /// <summary>
        /// Resets the IndeterminatePressed property to its default value.
        /// </summary>
        public void ResetIndeterminatePressed()
        {
            IndeterminatePressed = null;
        }
        #endregion
    }
}
