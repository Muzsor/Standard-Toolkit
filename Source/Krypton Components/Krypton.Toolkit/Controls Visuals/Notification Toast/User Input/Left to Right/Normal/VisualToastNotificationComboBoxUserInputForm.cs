﻿#region BSD License
/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2024 - 2024. All rights reserved.
 *
 */
#endregion

using Timer = System.Windows.Forms.Timer;

namespace Krypton.Toolkit
{
    internal partial class VisualToastNotificationComboBoxUserInputForm : KryptonForm
    {
        #region Instance Fields

        private ArrayList _userInputItemList;

        private Color? _borderColorOne;

        private Color? _borderColorTwo;

        private ComboBoxStyle? _userInputBoxStyle;

        private int? _countdownSeconds;

        private int? _initialSelectedIndex;

        private int _time;

        private IWin32Window? _owner;

        private Timer _timer;

        private string _notificationMessage;

        private string? _notificationTitle;

        private readonly KryptonUserInputToastNotificationData _data;

        private KryptonToastNotificationIcon? _icon;

        #endregion

        #region Internal

        internal string UserResponse => kcmbUserInput.Text ?? string.Empty;

        #endregion

        #region Identity

        public VisualToastNotificationComboBoxUserInputForm(IWin32Window? owner,
                                                            string notificationMessage,
                                                            string? notificationTitle,
                                                            KryptonToastNotificationIcon? icon,
                                                            ArrayList userInputItemList,
                                                            int? initialSelectedIndex,
                                                            ComboBoxStyle? inputBoxStyle,
                                                            Color? borderColorOne,
                                                            Color? borderColorTwo,
                                                            int? countdownSeconds)
        {
            InitializeComponent();

            _owner = owner;

            _notificationMessage = notificationMessage;

            _notificationTitle = notificationTitle ?? GlobalStaticValues.DEFAULT_EMPTY_STRING;

            _icon = icon ?? KryptonToastNotificationIcon.None;

            _userInputItemList = userInputItemList;

            _initialSelectedIndex = initialSelectedIndex ?? 0;

            _userInputBoxStyle = inputBoxStyle ?? ComboBoxStyle.DropDown;

            _borderColorOne = borderColorOne ?? GlobalStaticValues.EMPTY_COLOR;

            _borderColorTwo = borderColorTwo ?? GlobalStaticValues.EMPTY_COLOR;

            _countdownSeconds = countdownSeconds ?? 60;

            UpdateBorderColors();

            UpdateComboBoxItems();

            UpdateInputBoxStyle();

            UpdateIcon();

            UpdateText();

            UpdateOwner(owner);

            GotFocus += (sender, args) => kcmbUserInput.Focus();
        }

        public VisualToastNotificationComboBoxUserInputForm(KryptonUserInputToastNotificationData data)
        {
            InitializeComponent();

            _data = data;

            GotFocus += (sender, args) => kcmbUserInput.Focus();

            UpdateBorderColors();
        }

        #endregion

        #region Implementation

        private void UpdateBorderColors()
        {
            StateCommon!.Border.Color1 = _data.BorderColor1 ?? GlobalStaticValues.EMPTY_COLOR;

            StateCommon.Border.Color2 = _data.BorderColor2 ?? GlobalStaticValues.EMPTY_COLOR;
        }

        private void UpdateText()
        {
            kwlNotificationTitle.Text = _data.NotificationTitle ?? GlobalStaticValues.DEFAULT_EMPTY_STRING;

            kwlNotificationMessage.Text = _data.NotificationContent ?? GlobalStaticValues.DEFAULT_EMPTY_STRING;
        }

        private void UpdateComboBoxItems()
        {
            if (_data.UserInputList.Count > 0)
            {
                foreach (var item in _data.UserInputList)
                {
                    kcmbUserInput.Items.Add(item);
                }

                kcmbUserInput.SelectedIndex = _data.SelectedIndex ?? 1;
            }

            kcmbUserInput.DropDownStyle = _userInputBoxStyle ?? ComboBoxStyle.DropDown;
        }

        private void SetIcon(Bitmap? image) => pictureBox1.Image = image;

        private void UpdateLocation()
        {
            //Once loaded, position the form, or position it to the bottom left of the screen with added padding
            Location = _data.NotificationLocation ?? new Point(Screen.PrimaryScreen!.WorkingArea.Width - Width - 5,
                Screen.PrimaryScreen.WorkingArea.Height - Height - 5);
        }

        private void UpdateIcon()
        {
            switch (_data.NotificationIcon)
            {
                case KryptonToastNotificationIcon.None:
                    SetIcon(null);
                    break;
                case KryptonToastNotificationIcon.Hand:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Hand_128_x_128);
                    break;
                case KryptonToastNotificationIcon.SystemHand:
                    SetIcon(GraphicsExtensions.ScaleImage(SystemIcons.Hand.ToBitmap(), 128, 128));
                    break;
                case KryptonToastNotificationIcon.Question:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Question_128_x_128);
                    break;
                case KryptonToastNotificationIcon.SystemQuestion:
                    SetIcon(GraphicsExtensions.ScaleImage(SystemIcons.Question.ToBitmap(), 128, 128));
                    break;
                case KryptonToastNotificationIcon.Exclamation:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Warning_128_x_115);
                    break;
                case KryptonToastNotificationIcon.SystemExclamation:
                    SetIcon(GraphicsExtensions.ScaleImage(SystemIcons.Exclamation.ToBitmap(), 128, 128));
                    break;
                case KryptonToastNotificationIcon.Asterisk:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Asterisk_128_x_128);
                    break;
                case KryptonToastNotificationIcon.SystemAsterisk:
                    SetIcon(GraphicsExtensions.ScaleImage(SystemIcons.Asterisk.ToBitmap(), 128, 128));
                    break;
                case KryptonToastNotificationIcon.Stop:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Stop_128_x_128);
                    break;
                case KryptonToastNotificationIcon.Error:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Critical_128_x_128);
                    break;
                case KryptonToastNotificationIcon.Warning:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Warning_128_x_115);
                    break;
                case KryptonToastNotificationIcon.Information:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Information_128_x_128);
                    break;
                case KryptonToastNotificationIcon.Shield:
                    if (OSUtilities.IsWindowsEleven)
                    {
                        SetIcon(ToastNotificationImageResources.Toast_Notification_UAC_Shield_Windows_11_128_x_128);
                    }
                    else if (OSUtilities.IsWindowsTen)
                    {
                        SetIcon(ToastNotificationImageResources.Toast_Notification_UAC_Shield_Windows_10_128_x_128);
                    }
                    else
                    {
                        SetIcon(ToastNotificationImageResources.Toast_Notification_UAC_Shield_Windows_7_and_8_128_x_128);
                    }
                    break;
                case KryptonToastNotificationIcon.WindowsLogo:
                    if (OSUtilities.IsWindowsEleven)
                    {
                        SetIcon(WindowsLogoImageResources.Windows_11_128_128);
                    }
                    else if (OSUtilities.IsWindowsEight || OSUtilities.IsWindowsEightPointOne || OSUtilities.IsWindowsTen)
                    {
                        SetIcon(WindowsLogoImageResources.Windows_8_81_10_128_128);
                    }
                    else
                    {
                        SetIcon(GraphicsExtensions.ScaleImage(SystemIcons.WinLogo.ToBitmap(), new Size(128, 128)));
                    }
                    break;
                case KryptonToastNotificationIcon.Application:
                    SetIcon(GraphicsExtensions.ScaleImage(_data.ApplicationIcon.ToBitmap(), new Size(128, 128)));
                    break;
                case KryptonToastNotificationIcon.SystemApplication:
                    SetIcon(GraphicsExtensions.ScaleImage(SystemIcons.Asterisk.ToBitmap(), 128, 128));
                    break;
                case KryptonToastNotificationIcon.Ok:
                    SetIcon(ToastNotificationImageResources.Toast_Notification_Ok_128_x_128);
                    break;
                case KryptonToastNotificationIcon.Custom:
                    SetIcon(_data.CustomImage != null
                        ? new Bitmap(_data.CustomImage)
                        : null);
                    break;
                case null:
                    SetIcon(null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ShowCloseButton()
        {
            CloseBox = _data.ShowCloseBox ?? false;

            FormBorderStyle = CloseBox ? FormBorderStyle.Fixed3D : FormBorderStyle.FixedSingle;

            ControlBox = _data.ShowCloseBox ?? false;
        }

        private void VisualToastNotificationComboBoxUserInputForm_Load(object sender, EventArgs e)
        {
            UpdateIcon();

            UpdateLocation();

            ShowCloseButton();

            _timer.Start();

            _data.DisplayDebugData(_data);
        }

        private void VisualToastNotificationComboBoxUserInputForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void UpdateInputBoxStyle() =>
            kcmbUserInput.DropDownStyle = _userInputBoxStyle ?? ComboBoxStyle.DropDown;

        private void UpdateOwner(IWin32Window? owner)
        {

        }

        public new DialogResult ShowDialog()
        {
            TopMost = _data.TopMost ?? true;

            UpdateText();

            UpdateIcon();

            UpdateComboBoxItems();

            UpdateLocation();

            if (_data.CountDownSeconds != 0)
            {
                kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_data.CountDownSeconds - _time})";

                _timer = new Timer();

                _timer.Interval = _data.CountDownTimerInterval ?? 1000;

                _timer.Tick += (sender, args) =>
                {
                    _time++;

                    kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_data.CountDownSeconds - _time})";

                    if (_time == _data.CountDownSeconds)
                    {
                        _timer.Stop();

                        Close();
                    }
                };
            }

            return base.ShowDialog();
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            TopMost = _data.TopMost ?? true;

            UpdateText();

            UpdateIcon();

            UpdateComboBoxItems();

            if (_data.CountDownSeconds != 0)
            {
                kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_data.CountDownSeconds - _time})";

                _timer = new Timer();

                _timer.Interval = _data.CountDownTimerInterval ?? 1000;

                _timer.Tick += (sender, args) =>
                {
                    _time++;

                    kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_data.CountDownSeconds - _time})";

                    if (_time == _data.CountDownSeconds)
                    {
                        _timer.Stop();

                        Close();
                    }
                };
            }

            return base.ShowDialog(owner);
        }

        internal static string ShowNotification(KryptonUserInputToastNotificationData data)
        {
            var owner = data.Owner ?? FromHandle(PI.GetActiveWindow());

            using var toast = new VisualToastNotificationComboBoxUserInputForm(data);

            if (owner != null)
            {
                toast.StartPosition = owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

                return toast.ShowDialog(owner!) == DialogResult.OK ? toast.UserResponse : string.Empty;
            }
            else
            {
                return toast.ShowDialog() == DialogResult.OK ? toast.UserResponse : string.Empty;
            }
        }

        /// <summary>Shows the notification.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="notificationMessage">The notification message.</param>
        /// <param name="notificationTitle">The notification title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="userInputItemList">The user input item list.</param>
        /// <param name="initialSelectedIndex">Initial index of the selected.</param>
        /// <param name="inputBoxStyle">The input box style.</param>
        /// <param name="borderColorOne">The border color one.</param>
        /// <param name="borderColorTwo">The border color two.</param>
        /// <returns></returns>
        internal static string ShowNotification(IWin32Window? owner,
                                         string notificationMessage,
                                         string? notificationTitle,
                                         KryptonToastNotificationIcon? icon,
                                         ArrayList userInputItemList,
                                         int? initialSelectedIndex,
                                         ComboBoxStyle? inputBoxStyle,
                                         Color? borderColorOne,
                                         Color? borderColorTwo,
                                         int? countDownSeconds)
        {
            var parent = owner ?? FromHandle(PI.GetActiveWindow());

            using var toast = new VisualToastNotificationComboBoxUserInputForm(parent,
                                                                               notificationMessage,
                                                                               notificationTitle,
                                                                               icon,
                                                                               userInputItemList,
                                                                               initialSelectedIndex,
                                                                               inputBoxStyle,
                                                                               borderColorOne,
                                                                               borderColorTwo,
                                                                               countDownSeconds);

            if (parent != null)
            {
                toast.StartPosition = parent == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

                return toast.ShowDialog(parent!) == DialogResult.OK ? toast.UserResponse : string.Empty;
            }
            else
            {
                return toast.ShowDialog() == DialogResult.OK ? toast.UserResponse : string.Empty;
            }
        }

        #endregion
    }
}
