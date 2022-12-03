namespace MidiControl
{
    partial class EntryGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("OBS");
			System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("SoundBoard");
			System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Media Keys");
			System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Twitch Chat");
			System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("MidiControl");
			System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Go XLR");
			System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("On Key Press", new System.Windows.Forms.TreeNode[] {
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53,
            treeNode54});
			System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("OBS");
			System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("SoundBoard");
			System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Media Keys");
			System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Twitch Chat");
			System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("MidiControl");
			System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("Go XLR");
			System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("On Key Release", new System.Windows.Forms.TreeNode[] {
            treeNode56,
            treeNode57,
            treeNode58,
            treeNode59,
            treeNode60,
            treeNode61});
			System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("OBS");
			System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("On Slider Change", new System.Windows.Forms.TreeNode[] {
            treeNode63});
			this.LblName = new System.Windows.Forms.Label();
			this.TxtBoxName = new System.Windows.Forms.TextBox();
			this.LblNote = new System.Windows.Forms.Label();
			this.TxtBoxNote = new System.Windows.Forms.TextBox();
			this.TxtBoxDevice = new System.Windows.Forms.TextBox();
			this.LblDevice = new System.Windows.Forms.Label();
			this.BtnAdd = new System.Windows.Forms.Button();
			this.TxtBoxChannel = new System.Windows.Forms.TextBox();
			this.LblChannel = new System.Windows.Forms.Label();
			this.ChkCboBoxHotkeyPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxHotkeyPress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMediaStopPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxMediaStopPress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMediaRestartPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxMediaRestartPress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMediaPlayPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxMediaPlayPress = new System.Windows.Forms.CheckBox();
			this.CboBoxPreviewScenePress = new System.Windows.Forms.ComboBox();
			this.ChkBoxPreviewScenePress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMiscPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxMiscPress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxToggleFilterPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxToggleFilterPress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxShowFilterPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxShowFilterPress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxHideFilterPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxHideFilterPress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxToggleSourcePress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxToggleSourcePress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxToggleMutePress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxTogglemutePress = new System.Windows.Forms.CheckBox();
			this.ChkBoxTransitionPress = new System.Windows.Forms.CheckBox();
			this.NumericTransitionPress = new System.Windows.Forms.NumericUpDown();
			this.CboBoxTransitionPress = new System.Windows.Forms.ComboBox();
			this.ChkCboBoxHidePress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxHideSourcePress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxShowPress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxShowSourcePress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxUnmutePress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxUnmutePress = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMutePress = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxMutePress = new System.Windows.Forms.CheckBox();
			this.CboBoxSwitchScenePress = new System.Windows.Forms.ComboBox();
			this.ChkBoxSwitchScenePress = new System.Windows.Forms.CheckBox();
			this.chkStopAllOthers = new System.Windows.Forms.CheckBox();
			this.LblVolume = new System.Windows.Forms.Label();
			this.volumeSlider = new NAudio.Gui.VolumeSlider();
			this.chkBoxLoop = new System.Windows.Forms.CheckBox();
			this.LblAudioFile = new System.Windows.Forms.Label();
			this.LblAudioDevice = new System.Windows.Forms.Label();
			this.ChkBoxEnableAudio = new System.Windows.Forms.CheckBox();
			this.CboBoxAudioDevice = new System.Windows.Forms.ComboBox();
			this.BtnAudioSelect = new System.Windows.Forms.Button();
			this.TxtBoxAudioFile = new System.Windows.Forms.TextBox();
			this.ChkBoxMediaKeyPreviousPress = new System.Windows.Forms.CheckBox();
			this.ChkBoxMediaKeyNextPress = new System.Windows.Forms.CheckBox();
			this.ChkBoxMediaKeyPlayPress = new System.Windows.Forms.CheckBox();
			this.LblTwitchMessagePress = new System.Windows.Forms.Label();
			this.TxtBoxTwitchMessagePress = new System.Windows.Forms.TextBox();
			this.TxtBoxTwitchChannelPress = new System.Windows.Forms.TextBox();
			this.LblChannelTwitchPress = new System.Windows.Forms.Label();
			this.CboBoxProfilePress = new System.Windows.Forms.ComboBox();
			this.ChkBoxSwitchToProfilePress = new System.Windows.Forms.CheckBox();
			this.ChkBoxStopAllSoundPress = new System.Windows.Forms.CheckBox();
			this.LblXLROutputPress = new System.Windows.Forms.Label();
			this.LblXLRInputPress = new System.Windows.Forms.Label();
			this.PanelXLRPress = new System.Windows.Forms.Panel();
			this.RadioButtonUnMuteXLRPress = new System.Windows.Forms.RadioButton();
			this.RadioButtonMuteXLRPress = new System.Windows.Forms.RadioButton();
			this.RadioButtonToggleXLRPress = new System.Windows.Forms.RadioButton();
			this.RadioButtonDisabledXLRPress = new System.Windows.Forms.RadioButton();
			this.CboBoxXLROutputPress = new System.Windows.Forms.ComboBox();
			this.CboBoxXLRInputPress = new System.Windows.Forms.ComboBox();
			this.ChkCboBoxHotkeyRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxHotkeyRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMediaStopRelease = new CheckComboBoxTest.CheckedComboBox();
			this.CboBoxPreviewSceneRelease = new System.Windows.Forms.ComboBox();
			this.ChkBoxMediaStopRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMediaRestartRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxPreviewSceneRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxMediaRestartRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMiscRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkCboBoxMediaPlayRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxMiscRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxMediaPlayRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxToggleFilterRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkCboBoxToggleSourceRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxToggleFilterRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxToggleSourceRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxShowFilterRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkCboBoxToggleMuteRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxShowFilterRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxHideFilterRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxTogglemuteRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxHideFilterRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxTransitionRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxHideRelease = new CheckComboBoxTest.CheckedComboBox();
			this.NumericTransitionRelease = new System.Windows.Forms.NumericUpDown();
			this.ChkBoxSwitchSceneRelease = new System.Windows.Forms.CheckBox();
			this.CboBoxTransitionRelease = new System.Windows.Forms.ComboBox();
			this.ChkBoxHideSourceRelease = new System.Windows.Forms.CheckBox();
			this.CboBoxSwitchSceneRelease = new System.Windows.Forms.ComboBox();
			this.ChkCboBoxShowRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxMuteRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxShowSourceRelease = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxMuteRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkCboBoxUnmuteRelease = new CheckComboBoxTest.CheckedComboBox();
			this.ChkBoxUnmuteRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxAudioStop = new System.Windows.Forms.CheckBox();
			this.ChkBoxMediaKeyPreviousRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxMediaKeyNextRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxMediaKeyPlayRelease = new System.Windows.Forms.CheckBox();
			this.LblTwitchMessageRelease = new System.Windows.Forms.Label();
			this.TxtBoxTwitchMessageRelease = new System.Windows.Forms.TextBox();
			this.TxtBoxTwitchChannelRelease = new System.Windows.Forms.TextBox();
			this.LblChannelTwitchRelease = new System.Windows.Forms.Label();
			this.CboBoxProfileRelease = new System.Windows.Forms.ComboBox();
			this.ChkBoxSwitchToProfileRelease = new System.Windows.Forms.CheckBox();
			this.ChkBoxStopAllSoundRelease = new System.Windows.Forms.CheckBox();
			this.LblXLROutputRelease = new System.Windows.Forms.Label();
			this.LblXLRInputRelease = new System.Windows.Forms.Label();
			this.PanelXLRRelease = new System.Windows.Forms.Panel();
			this.RadioButtonUnMuteXLRRelease = new System.Windows.Forms.RadioButton();
			this.RadioButtonMuteXLRRelease = new System.Windows.Forms.RadioButton();
			this.RadioButtonToggleXLRRelease = new System.Windows.Forms.RadioButton();
			this.RadioButtonDisabledXLRRelease = new System.Windows.Forms.RadioButton();
			this.CboBoxXLROutputRelease = new System.Windows.Forms.ComboBox();
			this.CboBoxXLRInputRelease = new System.Windows.Forms.ComboBox();
			this.CboBoxFilterSettingSlider = new System.Windows.Forms.ComboBox();
			this.CboBoxFilterNameSlider = new System.Windows.Forms.ComboBox();
			this.ChkBoxAdjustFilter = new System.Windows.Forms.CheckBox();
			this.ChkBoxSlideTransition = new System.Windows.Forms.CheckBox();
			this.ChkBoxAdjustTransitionDuration = new System.Windows.Forms.CheckBox();
			this.ChkBoxAdjustVolume = new System.Windows.Forms.CheckBox();
			this.ChkCboBoxVolumeSlider = new CheckComboBoxTest.CheckedComboBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.pnlOBSPress = new System.Windows.Forms.Panel();
			this.pnlSoundBoardPress = new System.Windows.Forms.Panel();
			this.pnlMediaKeysPress = new System.Windows.Forms.Panel();
			this.pnlGoXLRPress = new System.Windows.Forms.Panel();
			this.pnlTwitchPress = new System.Windows.Forms.Panel();
			this.pnlMidiControlPress = new System.Windows.Forms.Panel();
			this.pnlOBSRelease = new System.Windows.Forms.Panel();
			this.pnlSoundBoardRelease = new System.Windows.Forms.Panel();
			this.pnlMediaKeysRelease = new System.Windows.Forms.Panel();
			this.pnlMidiControlRelease = new System.Windows.Forms.Panel();
			this.pnlTwitchRelease = new System.Windows.Forms.Panel();
			this.pnlGoXLRRelease = new System.Windows.Forms.Panel();
			this.pnlOBSSlider = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblPanelLabel = new System.Windows.Forms.Label();
			this.pnlRoot = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblHideMe = new System.Windows.Forms.Label();
			this.txtKeybindSummary = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.NumericTransitionPress)).BeginInit();
			this.PanelXLRPress.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericTransitionRelease)).BeginInit();
			this.PanelXLRRelease.SuspendLayout();
			this.pnlOBSPress.SuspendLayout();
			this.pnlSoundBoardPress.SuspendLayout();
			this.pnlMediaKeysPress.SuspendLayout();
			this.pnlGoXLRPress.SuspendLayout();
			this.pnlTwitchPress.SuspendLayout();
			this.pnlMidiControlPress.SuspendLayout();
			this.pnlOBSRelease.SuspendLayout();
			this.pnlSoundBoardRelease.SuspendLayout();
			this.pnlMediaKeysRelease.SuspendLayout();
			this.pnlMidiControlRelease.SuspendLayout();
			this.pnlTwitchRelease.SuspendLayout();
			this.pnlGoXLRRelease.SuspendLayout();
			this.pnlOBSSlider.SuspendLayout();
			this.pnlRoot.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblName
			// 
			this.LblName.AutoSize = true;
			this.LblName.Location = new System.Drawing.Point(13, 13);
			this.LblName.Name = "LblName";
			this.LblName.Size = new System.Drawing.Size(35, 13);
			this.LblName.TabIndex = 0;
			this.LblName.Text = "Name";
			// 
			// TxtBoxName
			// 
			this.TxtBoxName.Location = new System.Drawing.Point(54, 10);
			this.TxtBoxName.Name = "TxtBoxName";
			this.TxtBoxName.Size = new System.Drawing.Size(176, 20);
			this.TxtBoxName.TabIndex = 1;
			// 
			// LblNote
			// 
			this.LblNote.AutoSize = true;
			this.LblNote.Location = new System.Drawing.Point(534, 13);
			this.LblNote.Name = "LblNote";
			this.LblNote.Size = new System.Drawing.Size(30, 13);
			this.LblNote.TabIndex = 2;
			this.LblNote.Text = "Note";
			// 
			// TxtBoxNote
			// 
			this.TxtBoxNote.Enabled = false;
			this.TxtBoxNote.Location = new System.Drawing.Point(570, 10);
			this.TxtBoxNote.Name = "TxtBoxNote";
			this.TxtBoxNote.Size = new System.Drawing.Size(33, 20);
			this.TxtBoxNote.TabIndex = 3;
			// 
			// TxtBoxDevice
			// 
			this.TxtBoxDevice.Enabled = false;
			this.TxtBoxDevice.Location = new System.Drawing.Point(309, 10);
			this.TxtBoxDevice.Name = "TxtBoxDevice";
			this.TxtBoxDevice.Size = new System.Drawing.Size(132, 20);
			this.TxtBoxDevice.TabIndex = 7;
			// 
			// LblDevice
			// 
			this.LblDevice.AutoSize = true;
			this.LblDevice.Location = new System.Drawing.Point(236, 13);
			this.LblDevice.Name = "LblDevice";
			this.LblDevice.Size = new System.Drawing.Size(67, 13);
			this.LblDevice.TabIndex = 6;
			this.LblDevice.Text = "MIDI Device";
			// 
			// BtnAdd
			// 
			this.BtnAdd.Location = new System.Drawing.Point(447, 372);
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.Size = new System.Drawing.Size(75, 23);
			this.BtnAdd.TabIndex = 8;
			this.BtnAdd.Text = "Add";
			this.BtnAdd.UseVisualStyleBackColor = true;
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// TxtBoxChannel
			// 
			this.TxtBoxChannel.Enabled = false;
			this.TxtBoxChannel.Location = new System.Drawing.Point(499, 10);
			this.TxtBoxChannel.Name = "TxtBoxChannel";
			this.TxtBoxChannel.Size = new System.Drawing.Size(29, 20);
			this.TxtBoxChannel.TabIndex = 10;
			// 
			// LblChannel
			// 
			this.LblChannel.AutoSize = true;
			this.LblChannel.Location = new System.Drawing.Point(447, 13);
			this.LblChannel.Name = "LblChannel";
			this.LblChannel.Size = new System.Drawing.Size(46, 13);
			this.LblChannel.TabIndex = 9;
			this.LblChannel.Text = "Channel";
			// 
			// ChkCboBoxHotkeyPress
			// 
			this.ChkCboBoxHotkeyPress.CheckOnClick = true;
			this.ChkCboBoxHotkeyPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxHotkeyPress.DropDownHeight = 1;
			this.ChkCboBoxHotkeyPress.Enabled = false;
			this.ChkCboBoxHotkeyPress.FormattingEnabled = true;
			this.ChkCboBoxHotkeyPress.IntegralHeight = false;
			this.ChkCboBoxHotkeyPress.Location = new System.Drawing.Point(112, 442);
			this.ChkCboBoxHotkeyPress.Name = "ChkCboBoxHotkeyPress";
			this.ChkCboBoxHotkeyPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxHotkeyPress.TabIndex = 35;
			this.ChkCboBoxHotkeyPress.ValueSeparator = ", ";
			// 
			// ChkBoxHotkeyPress
			// 
			this.ChkBoxHotkeyPress.AutoSize = true;
			this.ChkBoxHotkeyPress.Location = new System.Drawing.Point(12, 444);
			this.ChkBoxHotkeyPress.Name = "ChkBoxHotkeyPress";
			this.ChkBoxHotkeyPress.Size = new System.Drawing.Size(60, 17);
			this.ChkBoxHotkeyPress.TabIndex = 34;
			this.ChkBoxHotkeyPress.Text = "Hotkey";
			this.ChkBoxHotkeyPress.UseVisualStyleBackColor = true;
			this.ChkBoxHotkeyPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMediaStopPress
			// 
			this.ChkCboBoxMediaStopPress.CheckOnClick = true;
			this.ChkCboBoxMediaStopPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMediaStopPress.DropDownHeight = 1;
			this.ChkCboBoxMediaStopPress.Enabled = false;
			this.ChkCboBoxMediaStopPress.FormattingEnabled = true;
			this.ChkCboBoxMediaStopPress.IntegralHeight = false;
			this.ChkCboBoxMediaStopPress.Location = new System.Drawing.Point(112, 361);
			this.ChkCboBoxMediaStopPress.Name = "ChkCboBoxMediaStopPress";
			this.ChkCboBoxMediaStopPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMediaStopPress.TabIndex = 33;
			this.ChkCboBoxMediaStopPress.ValueSeparator = ", ";
			// 
			// ChkBoxMediaStopPress
			// 
			this.ChkBoxMediaStopPress.AutoSize = true;
			this.ChkBoxMediaStopPress.Location = new System.Drawing.Point(12, 363);
			this.ChkBoxMediaStopPress.Name = "ChkBoxMediaStopPress";
			this.ChkBoxMediaStopPress.Size = new System.Drawing.Size(80, 17);
			this.ChkBoxMediaStopPress.TabIndex = 32;
			this.ChkBoxMediaStopPress.Text = "Media Stop";
			this.ChkBoxMediaStopPress.UseVisualStyleBackColor = true;
			this.ChkBoxMediaStopPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMediaRestartPress
			// 
			this.ChkCboBoxMediaRestartPress.CheckOnClick = true;
			this.ChkCboBoxMediaRestartPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMediaRestartPress.DropDownHeight = 1;
			this.ChkCboBoxMediaRestartPress.Enabled = false;
			this.ChkCboBoxMediaRestartPress.FormattingEnabled = true;
			this.ChkCboBoxMediaRestartPress.IntegralHeight = false;
			this.ChkCboBoxMediaRestartPress.Location = new System.Drawing.Point(112, 388);
			this.ChkCboBoxMediaRestartPress.Name = "ChkCboBoxMediaRestartPress";
			this.ChkCboBoxMediaRestartPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMediaRestartPress.TabIndex = 31;
			this.ChkCboBoxMediaRestartPress.ValueSeparator = ", ";
			// 
			// ChkBoxMediaRestartPress
			// 
			this.ChkBoxMediaRestartPress.AutoSize = true;
			this.ChkBoxMediaRestartPress.Location = new System.Drawing.Point(12, 390);
			this.ChkBoxMediaRestartPress.Name = "ChkBoxMediaRestartPress";
			this.ChkBoxMediaRestartPress.Size = new System.Drawing.Size(92, 17);
			this.ChkBoxMediaRestartPress.TabIndex = 30;
			this.ChkBoxMediaRestartPress.Text = "Media Restart";
			this.ChkBoxMediaRestartPress.UseVisualStyleBackColor = true;
			this.ChkBoxMediaRestartPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMediaPlayPress
			// 
			this.ChkCboBoxMediaPlayPress.CheckOnClick = true;
			this.ChkCboBoxMediaPlayPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMediaPlayPress.DropDownHeight = 1;
			this.ChkCboBoxMediaPlayPress.Enabled = false;
			this.ChkCboBoxMediaPlayPress.FormattingEnabled = true;
			this.ChkCboBoxMediaPlayPress.IntegralHeight = false;
			this.ChkCboBoxMediaPlayPress.Location = new System.Drawing.Point(112, 334);
			this.ChkCboBoxMediaPlayPress.Name = "ChkCboBoxMediaPlayPress";
			this.ChkCboBoxMediaPlayPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMediaPlayPress.TabIndex = 29;
			this.ChkCboBoxMediaPlayPress.ValueSeparator = ", ";
			// 
			// ChkBoxMediaPlayPress
			// 
			this.ChkBoxMediaPlayPress.AutoSize = true;
			this.ChkBoxMediaPlayPress.Location = new System.Drawing.Point(12, 336);
			this.ChkBoxMediaPlayPress.Name = "ChkBoxMediaPlayPress";
			this.ChkBoxMediaPlayPress.Size = new System.Drawing.Size(78, 17);
			this.ChkBoxMediaPlayPress.TabIndex = 28;
			this.ChkBoxMediaPlayPress.Text = "Media Play";
			this.ChkBoxMediaPlayPress.UseVisualStyleBackColor = true;
			this.ChkBoxMediaPlayPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// CboBoxPreviewScenePress
			// 
			this.CboBoxPreviewScenePress.Enabled = false;
			this.CboBoxPreviewScenePress.FormattingEnabled = true;
			this.CboBoxPreviewScenePress.Location = new System.Drawing.Point(112, 37);
			this.CboBoxPreviewScenePress.Name = "CboBoxPreviewScenePress";
			this.CboBoxPreviewScenePress.Size = new System.Drawing.Size(191, 21);
			this.CboBoxPreviewScenePress.TabIndex = 27;
			// 
			// ChkBoxPreviewScenePress
			// 
			this.ChkBoxPreviewScenePress.AutoSize = true;
			this.ChkBoxPreviewScenePress.Location = new System.Drawing.Point(12, 39);
			this.ChkBoxPreviewScenePress.Name = "ChkBoxPreviewScenePress";
			this.ChkBoxPreviewScenePress.Size = new System.Drawing.Size(98, 17);
			this.ChkBoxPreviewScenePress.TabIndex = 26;
			this.ChkBoxPreviewScenePress.Text = "Preview Scene";
			this.ChkBoxPreviewScenePress.UseVisualStyleBackColor = true;
			this.ChkBoxPreviewScenePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMiscPress
			// 
			this.ChkCboBoxMiscPress.CheckOnClick = true;
			this.ChkCboBoxMiscPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMiscPress.DropDownHeight = 1;
			this.ChkCboBoxMiscPress.Enabled = false;
			this.ChkCboBoxMiscPress.FormattingEnabled = true;
			this.ChkCboBoxMiscPress.IntegralHeight = false;
			this.ChkCboBoxMiscPress.Location = new System.Drawing.Point(112, 415);
			this.ChkCboBoxMiscPress.Name = "ChkCboBoxMiscPress";
			this.ChkCboBoxMiscPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMiscPress.TabIndex = 25;
			this.ChkCboBoxMiscPress.ValueSeparator = ", ";
			// 
			// ChkBoxMiscPress
			// 
			this.ChkBoxMiscPress.AutoSize = true;
			this.ChkBoxMiscPress.Location = new System.Drawing.Point(12, 417);
			this.ChkBoxMiscPress.Name = "ChkBoxMiscPress";
			this.ChkBoxMiscPress.Size = new System.Drawing.Size(48, 17);
			this.ChkBoxMiscPress.TabIndex = 24;
			this.ChkBoxMiscPress.Text = "Misc";
			this.ChkBoxMiscPress.UseVisualStyleBackColor = true;
			this.ChkBoxMiscPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxToggleFilterPress
			// 
			this.ChkCboBoxToggleFilterPress.CheckOnClick = true;
			this.ChkCboBoxToggleFilterPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxToggleFilterPress.DropDownHeight = 1;
			this.ChkCboBoxToggleFilterPress.Enabled = false;
			this.ChkCboBoxToggleFilterPress.FormattingEnabled = true;
			this.ChkCboBoxToggleFilterPress.IntegralHeight = false;
			this.ChkCboBoxToggleFilterPress.Location = new System.Drawing.Point(112, 199);
			this.ChkCboBoxToggleFilterPress.Name = "ChkCboBoxToggleFilterPress";
			this.ChkCboBoxToggleFilterPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxToggleFilterPress.TabIndex = 23;
			this.ChkCboBoxToggleFilterPress.ValueSeparator = ", ";
			// 
			// ChkBoxToggleFilterPress
			// 
			this.ChkBoxToggleFilterPress.AutoSize = true;
			this.ChkBoxToggleFilterPress.Location = new System.Drawing.Point(12, 201);
			this.ChkBoxToggleFilterPress.Name = "ChkBoxToggleFilterPress";
			this.ChkBoxToggleFilterPress.Size = new System.Drawing.Size(84, 17);
			this.ChkBoxToggleFilterPress.TabIndex = 22;
			this.ChkBoxToggleFilterPress.Text = "Toggle Filter";
			this.ChkBoxToggleFilterPress.UseVisualStyleBackColor = true;
			this.ChkBoxToggleFilterPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxShowFilterPress
			// 
			this.ChkCboBoxShowFilterPress.CheckOnClick = true;
			this.ChkCboBoxShowFilterPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxShowFilterPress.DropDownHeight = 1;
			this.ChkCboBoxShowFilterPress.Enabled = false;
			this.ChkCboBoxShowFilterPress.FormattingEnabled = true;
			this.ChkCboBoxShowFilterPress.IntegralHeight = false;
			this.ChkCboBoxShowFilterPress.Location = new System.Drawing.Point(112, 145);
			this.ChkCboBoxShowFilterPress.Name = "ChkCboBoxShowFilterPress";
			this.ChkCboBoxShowFilterPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxShowFilterPress.TabIndex = 21;
			this.ChkCboBoxShowFilterPress.ValueSeparator = ", ";
			// 
			// ChkBoxShowFilterPress
			// 
			this.ChkBoxShowFilterPress.AutoSize = true;
			this.ChkBoxShowFilterPress.Location = new System.Drawing.Point(12, 147);
			this.ChkBoxShowFilterPress.Name = "ChkBoxShowFilterPress";
			this.ChkBoxShowFilterPress.Size = new System.Drawing.Size(78, 17);
			this.ChkBoxShowFilterPress.TabIndex = 20;
			this.ChkBoxShowFilterPress.Text = "Show Filter";
			this.ChkBoxShowFilterPress.UseVisualStyleBackColor = true;
			this.ChkBoxShowFilterPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxHideFilterPress
			// 
			this.ChkCboBoxHideFilterPress.CheckOnClick = true;
			this.ChkCboBoxHideFilterPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxHideFilterPress.DropDownHeight = 1;
			this.ChkCboBoxHideFilterPress.Enabled = false;
			this.ChkCboBoxHideFilterPress.FormattingEnabled = true;
			this.ChkCboBoxHideFilterPress.IntegralHeight = false;
			this.ChkCboBoxHideFilterPress.Location = new System.Drawing.Point(112, 172);
			this.ChkCboBoxHideFilterPress.Name = "ChkCboBoxHideFilterPress";
			this.ChkCboBoxHideFilterPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxHideFilterPress.TabIndex = 19;
			this.ChkCboBoxHideFilterPress.ValueSeparator = ", ";
			// 
			// ChkBoxHideFilterPress
			// 
			this.ChkBoxHideFilterPress.AutoSize = true;
			this.ChkBoxHideFilterPress.Location = new System.Drawing.Point(12, 174);
			this.ChkBoxHideFilterPress.Name = "ChkBoxHideFilterPress";
			this.ChkBoxHideFilterPress.Size = new System.Drawing.Size(73, 17);
			this.ChkBoxHideFilterPress.TabIndex = 18;
			this.ChkBoxHideFilterPress.Text = "Hide Filter";
			this.ChkBoxHideFilterPress.UseVisualStyleBackColor = true;
			this.ChkBoxHideFilterPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxToggleSourcePress
			// 
			this.ChkCboBoxToggleSourcePress.CheckOnClick = true;
			this.ChkCboBoxToggleSourcePress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxToggleSourcePress.DropDownHeight = 1;
			this.ChkCboBoxToggleSourcePress.Enabled = false;
			this.ChkCboBoxToggleSourcePress.FormattingEnabled = true;
			this.ChkCboBoxToggleSourcePress.IntegralHeight = false;
			this.ChkCboBoxToggleSourcePress.Location = new System.Drawing.Point(112, 118);
			this.ChkCboBoxToggleSourcePress.Name = "ChkCboBoxToggleSourcePress";
			this.ChkCboBoxToggleSourcePress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxToggleSourcePress.TabIndex = 17;
			this.ChkCboBoxToggleSourcePress.ValueSeparator = ", ";
			// 
			// ChkBoxToggleSourcePress
			// 
			this.ChkBoxToggleSourcePress.AutoSize = true;
			this.ChkBoxToggleSourcePress.Location = new System.Drawing.Point(12, 120);
			this.ChkBoxToggleSourcePress.Name = "ChkBoxToggleSourcePress";
			this.ChkBoxToggleSourcePress.Size = new System.Drawing.Size(96, 17);
			this.ChkBoxToggleSourcePress.TabIndex = 16;
			this.ChkBoxToggleSourcePress.Text = "Toggle Source";
			this.ChkBoxToggleSourcePress.UseVisualStyleBackColor = true;
			this.ChkBoxToggleSourcePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxToggleMutePress
			// 
			this.ChkCboBoxToggleMutePress.CheckOnClick = true;
			this.ChkCboBoxToggleMutePress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxToggleMutePress.DropDownHeight = 1;
			this.ChkCboBoxToggleMutePress.Enabled = false;
			this.ChkCboBoxToggleMutePress.FormattingEnabled = true;
			this.ChkCboBoxToggleMutePress.IntegralHeight = false;
			this.ChkCboBoxToggleMutePress.Location = new System.Drawing.Point(112, 307);
			this.ChkCboBoxToggleMutePress.Name = "ChkCboBoxToggleMutePress";
			this.ChkCboBoxToggleMutePress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxToggleMutePress.TabIndex = 15;
			this.ChkCboBoxToggleMutePress.ValueSeparator = ", ";
			// 
			// ChkBoxTogglemutePress
			// 
			this.ChkBoxTogglemutePress.AutoSize = true;
			this.ChkBoxTogglemutePress.Location = new System.Drawing.Point(12, 309);
			this.ChkBoxTogglemutePress.Name = "ChkBoxTogglemutePress";
			this.ChkBoxTogglemutePress.Size = new System.Drawing.Size(86, 17);
			this.ChkBoxTogglemutePress.TabIndex = 14;
			this.ChkBoxTogglemutePress.Text = "Toggle Mute";
			this.ChkBoxTogglemutePress.UseVisualStyleBackColor = true;
			this.ChkBoxTogglemutePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxTransitionPress
			// 
			this.ChkBoxTransitionPress.AutoSize = true;
			this.ChkBoxTransitionPress.Location = new System.Drawing.Point(12, 228);
			this.ChkBoxTransitionPress.Name = "ChkBoxTransitionPress";
			this.ChkBoxTransitionPress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkBoxTransitionPress.Size = new System.Drawing.Size(72, 17);
			this.ChkBoxTransitionPress.TabIndex = 13;
			this.ChkBoxTransitionPress.Text = "Transition";
			this.ChkBoxTransitionPress.UseVisualStyleBackColor = true;
			this.ChkBoxTransitionPress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// NumericTransitionPress
			// 
			this.NumericTransitionPress.Enabled = false;
			this.NumericTransitionPress.Location = new System.Drawing.Point(251, 227);
			this.NumericTransitionPress.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.NumericTransitionPress.Name = "NumericTransitionPress";
			this.NumericTransitionPress.Size = new System.Drawing.Size(52, 20);
			this.NumericTransitionPress.TabIndex = 12;
			// 
			// CboBoxTransitionPress
			// 
			this.CboBoxTransitionPress.Enabled = false;
			this.CboBoxTransitionPress.FormattingEnabled = true;
			this.CboBoxTransitionPress.Location = new System.Drawing.Point(112, 226);
			this.CboBoxTransitionPress.Name = "CboBoxTransitionPress";
			this.CboBoxTransitionPress.Size = new System.Drawing.Size(133, 21);
			this.CboBoxTransitionPress.TabIndex = 10;
			// 
			// ChkCboBoxHidePress
			// 
			this.ChkCboBoxHidePress.CheckOnClick = true;
			this.ChkCboBoxHidePress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxHidePress.DropDownHeight = 1;
			this.ChkCboBoxHidePress.Enabled = false;
			this.ChkCboBoxHidePress.FormattingEnabled = true;
			this.ChkCboBoxHidePress.IntegralHeight = false;
			this.ChkCboBoxHidePress.Location = new System.Drawing.Point(112, 91);
			this.ChkCboBoxHidePress.Name = "ChkCboBoxHidePress";
			this.ChkCboBoxHidePress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxHidePress.TabIndex = 9;
			this.ChkCboBoxHidePress.ValueSeparator = ", ";
			// 
			// ChkBoxHideSourcePress
			// 
			this.ChkBoxHideSourcePress.AutoSize = true;
			this.ChkBoxHideSourcePress.Location = new System.Drawing.Point(12, 93);
			this.ChkBoxHideSourcePress.Name = "ChkBoxHideSourcePress";
			this.ChkBoxHideSourcePress.Size = new System.Drawing.Size(85, 17);
			this.ChkBoxHideSourcePress.TabIndex = 8;
			this.ChkBoxHideSourcePress.Text = "Hide Source";
			this.ChkBoxHideSourcePress.UseVisualStyleBackColor = true;
			this.ChkBoxHideSourcePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxShowPress
			// 
			this.ChkCboBoxShowPress.CheckOnClick = true;
			this.ChkCboBoxShowPress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxShowPress.DropDownHeight = 1;
			this.ChkCboBoxShowPress.Enabled = false;
			this.ChkCboBoxShowPress.FormattingEnabled = true;
			this.ChkCboBoxShowPress.IntegralHeight = false;
			this.ChkCboBoxShowPress.Location = new System.Drawing.Point(112, 64);
			this.ChkCboBoxShowPress.Name = "ChkCboBoxShowPress";
			this.ChkCboBoxShowPress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxShowPress.TabIndex = 7;
			this.ChkCboBoxShowPress.ValueSeparator = ", ";
			// 
			// ChkBoxShowSourcePress
			// 
			this.ChkBoxShowSourcePress.AutoSize = true;
			this.ChkBoxShowSourcePress.Location = new System.Drawing.Point(12, 66);
			this.ChkBoxShowSourcePress.Name = "ChkBoxShowSourcePress";
			this.ChkBoxShowSourcePress.Size = new System.Drawing.Size(90, 17);
			this.ChkBoxShowSourcePress.TabIndex = 6;
			this.ChkBoxShowSourcePress.Text = "Show Source";
			this.ChkBoxShowSourcePress.UseVisualStyleBackColor = true;
			this.ChkBoxShowSourcePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxUnmutePress
			// 
			this.ChkCboBoxUnmutePress.CheckOnClick = true;
			this.ChkCboBoxUnmutePress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxUnmutePress.DropDownHeight = 1;
			this.ChkCboBoxUnmutePress.Enabled = false;
			this.ChkCboBoxUnmutePress.FormattingEnabled = true;
			this.ChkCboBoxUnmutePress.IntegralHeight = false;
			this.ChkCboBoxUnmutePress.Location = new System.Drawing.Point(112, 280);
			this.ChkCboBoxUnmutePress.Name = "ChkCboBoxUnmutePress";
			this.ChkCboBoxUnmutePress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxUnmutePress.TabIndex = 5;
			this.ChkCboBoxUnmutePress.ValueSeparator = ", ";
			// 
			// ChkBoxUnmutePress
			// 
			this.ChkBoxUnmutePress.AutoSize = true;
			this.ChkBoxUnmutePress.Location = new System.Drawing.Point(12, 282);
			this.ChkBoxUnmutePress.Name = "ChkBoxUnmutePress";
			this.ChkBoxUnmutePress.Size = new System.Drawing.Size(64, 17);
			this.ChkBoxUnmutePress.TabIndex = 4;
			this.ChkBoxUnmutePress.Text = "UnMute";
			this.ChkBoxUnmutePress.UseVisualStyleBackColor = true;
			this.ChkBoxUnmutePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMutePress
			// 
			this.ChkCboBoxMutePress.CheckOnClick = true;
			this.ChkCboBoxMutePress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMutePress.DropDownHeight = 1;
			this.ChkCboBoxMutePress.Enabled = false;
			this.ChkCboBoxMutePress.FormattingEnabled = true;
			this.ChkCboBoxMutePress.IntegralHeight = false;
			this.ChkCboBoxMutePress.Location = new System.Drawing.Point(112, 253);
			this.ChkCboBoxMutePress.Name = "ChkCboBoxMutePress";
			this.ChkCboBoxMutePress.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMutePress.TabIndex = 3;
			this.ChkCboBoxMutePress.ValueSeparator = ", ";
			// 
			// ChkBoxMutePress
			// 
			this.ChkBoxMutePress.AutoSize = true;
			this.ChkBoxMutePress.Location = new System.Drawing.Point(12, 255);
			this.ChkBoxMutePress.Name = "ChkBoxMutePress";
			this.ChkBoxMutePress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkBoxMutePress.Size = new System.Drawing.Size(50, 17);
			this.ChkBoxMutePress.TabIndex = 2;
			this.ChkBoxMutePress.Text = "Mute";
			this.ChkBoxMutePress.UseVisualStyleBackColor = true;
			this.ChkBoxMutePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// CboBoxSwitchScenePress
			// 
			this.CboBoxSwitchScenePress.Enabled = false;
			this.CboBoxSwitchScenePress.FormattingEnabled = true;
			this.CboBoxSwitchScenePress.Location = new System.Drawing.Point(112, 10);
			this.CboBoxSwitchScenePress.Name = "CboBoxSwitchScenePress";
			this.CboBoxSwitchScenePress.Size = new System.Drawing.Size(191, 21);
			this.CboBoxSwitchScenePress.TabIndex = 1;
			// 
			// ChkBoxSwitchScenePress
			// 
			this.ChkBoxSwitchScenePress.AutoSize = true;
			this.ChkBoxSwitchScenePress.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxSwitchScenePress.Name = "ChkBoxSwitchScenePress";
			this.ChkBoxSwitchScenePress.Size = new System.Drawing.Size(92, 17);
			this.ChkBoxSwitchScenePress.TabIndex = 0;
			this.ChkBoxSwitchScenePress.Text = "Switch Scene";
			this.ChkBoxSwitchScenePress.UseVisualStyleBackColor = true;
			this.ChkBoxSwitchScenePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// chkStopAllOthers
			// 
			this.chkStopAllOthers.AutoSize = true;
			this.chkStopAllOthers.Location = new System.Drawing.Point(12, 168);
			this.chkStopAllOthers.Name = "chkStopAllOthers";
			this.chkStopAllOthers.Size = new System.Drawing.Size(201, 17);
			this.chkStopAllOthers.TabIndex = 9;
			this.chkStopAllOthers.Text = "Stop all other sounds when activated";
			this.chkStopAllOthers.UseVisualStyleBackColor = true;
			// 
			// LblVolume
			// 
			this.LblVolume.AutoSize = true;
			this.LblVolume.Location = new System.Drawing.Point(9, 104);
			this.LblVolume.Name = "LblVolume";
			this.LblVolume.Size = new System.Drawing.Size(42, 13);
			this.LblVolume.TabIndex = 8;
			this.LblVolume.Text = "Volume";
			// 
			// volumeSlider
			// 
			this.volumeSlider.Location = new System.Drawing.Point(12, 120);
			this.volumeSlider.Name = "volumeSlider";
			this.volumeSlider.Size = new System.Drawing.Size(96, 19);
			this.volumeSlider.TabIndex = 7;
			// 
			// chkBoxLoop
			// 
			this.chkBoxLoop.AutoSize = true;
			this.chkBoxLoop.Location = new System.Drawing.Point(12, 145);
			this.chkBoxLoop.Name = "chkBoxLoop";
			this.chkBoxLoop.Size = new System.Drawing.Size(50, 17);
			this.chkBoxLoop.TabIndex = 6;
			this.chkBoxLoop.Text = "Loop";
			this.chkBoxLoop.UseVisualStyleBackColor = true;
			// 
			// LblAudioFile
			// 
			this.LblAudioFile.AutoSize = true;
			this.LblAudioFile.Location = new System.Drawing.Point(9, 36);
			this.LblAudioFile.Name = "LblAudioFile";
			this.LblAudioFile.Size = new System.Drawing.Size(52, 13);
			this.LblAudioFile.TabIndex = 5;
			this.LblAudioFile.Text = "Filename:";
			// 
			// LblAudioDevice
			// 
			this.LblAudioDevice.AutoSize = true;
			this.LblAudioDevice.Location = new System.Drawing.Point(178, 104);
			this.LblAudioDevice.Name = "LblAudioDevice";
			this.LblAudioDevice.Size = new System.Drawing.Size(71, 13);
			this.LblAudioDevice.TabIndex = 4;
			this.LblAudioDevice.Text = "Audio Device";
			// 
			// ChkBoxEnableAudio
			// 
			this.ChkBoxEnableAudio.AutoSize = true;
			this.ChkBoxEnableAudio.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxEnableAudio.Name = "ChkBoxEnableAudio";
			this.ChkBoxEnableAudio.Size = new System.Drawing.Size(59, 17);
			this.ChkBoxEnableAudio.TabIndex = 3;
			this.ChkBoxEnableAudio.Text = "Enable";
			this.ChkBoxEnableAudio.UseVisualStyleBackColor = true;
			this.ChkBoxEnableAudio.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// CboBoxAudioDevice
			// 
			this.CboBoxAudioDevice.Enabled = false;
			this.CboBoxAudioDevice.FormattingEnabled = true;
			this.CboBoxAudioDevice.Location = new System.Drawing.Point(181, 120);
			this.CboBoxAudioDevice.Name = "CboBoxAudioDevice";
			this.CboBoxAudioDevice.Size = new System.Drawing.Size(188, 21);
			this.CboBoxAudioDevice.TabIndex = 2;
			// 
			// BtnAudioSelect
			// 
			this.BtnAudioSelect.Enabled = false;
			this.BtnAudioSelect.Location = new System.Drawing.Point(294, 73);
			this.BtnAudioSelect.Name = "BtnAudioSelect";
			this.BtnAudioSelect.Size = new System.Drawing.Size(75, 23);
			this.BtnAudioSelect.TabIndex = 1;
			this.BtnAudioSelect.Text = "Browse ...";
			this.BtnAudioSelect.UseVisualStyleBackColor = true;
			this.BtnAudioSelect.Click += new System.EventHandler(this.BtnAudioSelect_Click);
			// 
			// TxtBoxAudioFile
			// 
			this.TxtBoxAudioFile.Enabled = false;
			this.TxtBoxAudioFile.Location = new System.Drawing.Point(12, 52);
			this.TxtBoxAudioFile.Name = "TxtBoxAudioFile";
			this.TxtBoxAudioFile.Size = new System.Drawing.Size(357, 20);
			this.TxtBoxAudioFile.TabIndex = 0;
			// 
			// ChkBoxMediaKeyPreviousPress
			// 
			this.ChkBoxMediaKeyPreviousPress.AutoSize = true;
			this.ChkBoxMediaKeyPreviousPress.Location = new System.Drawing.Point(12, 58);
			this.ChkBoxMediaKeyPreviousPress.Name = "ChkBoxMediaKeyPreviousPress";
			this.ChkBoxMediaKeyPreviousPress.Size = new System.Drawing.Size(120, 17);
			this.ChkBoxMediaKeyPreviousPress.TabIndex = 6;
			this.ChkBoxMediaKeyPreviousPress.Text = "Previous Media Key";
			this.ChkBoxMediaKeyPreviousPress.UseVisualStyleBackColor = true;
			// 
			// ChkBoxMediaKeyNextPress
			// 
			this.ChkBoxMediaKeyNextPress.AutoSize = true;
			this.ChkBoxMediaKeyNextPress.Location = new System.Drawing.Point(12, 35);
			this.ChkBoxMediaKeyNextPress.Name = "ChkBoxMediaKeyNextPress";
			this.ChkBoxMediaKeyNextPress.Size = new System.Drawing.Size(101, 17);
			this.ChkBoxMediaKeyNextPress.TabIndex = 5;
			this.ChkBoxMediaKeyNextPress.Text = "Next Media Key";
			this.ChkBoxMediaKeyNextPress.UseVisualStyleBackColor = true;
			// 
			// ChkBoxMediaKeyPlayPress
			// 
			this.ChkBoxMediaKeyPlayPress.AutoSize = true;
			this.ChkBoxMediaKeyPlayPress.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxMediaKeyPlayPress.Name = "ChkBoxMediaKeyPlayPress";
			this.ChkBoxMediaKeyPlayPress.Size = new System.Drawing.Size(140, 17);
			this.ChkBoxMediaKeyPlayPress.TabIndex = 4;
			this.ChkBoxMediaKeyPlayPress.Text = "Play / Pause Media Key";
			this.ChkBoxMediaKeyPlayPress.UseVisualStyleBackColor = true;
			// 
			// LblTwitchMessagePress
			// 
			this.LblTwitchMessagePress.AutoSize = true;
			this.LblTwitchMessagePress.Location = new System.Drawing.Point(13, 44);
			this.LblTwitchMessagePress.Name = "LblTwitchMessagePress";
			this.LblTwitchMessagePress.Size = new System.Drawing.Size(50, 13);
			this.LblTwitchMessagePress.TabIndex = 3;
			this.LblTwitchMessagePress.Text = "Message";
			// 
			// TxtBoxTwitchMessagePress
			// 
			this.TxtBoxTwitchMessagePress.Location = new System.Drawing.Point(16, 60);
			this.TxtBoxTwitchMessagePress.Multiline = true;
			this.TxtBoxTwitchMessagePress.Name = "TxtBoxTwitchMessagePress";
			this.TxtBoxTwitchMessagePress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtBoxTwitchMessagePress.Size = new System.Drawing.Size(356, 180);
			this.TxtBoxTwitchMessagePress.TabIndex = 2;
			// 
			// TxtBoxTwitchChannelPress
			// 
			this.TxtBoxTwitchChannelPress.Location = new System.Drawing.Point(100, 10);
			this.TxtBoxTwitchChannelPress.Name = "TxtBoxTwitchChannelPress";
			this.TxtBoxTwitchChannelPress.Size = new System.Drawing.Size(143, 20);
			this.TxtBoxTwitchChannelPress.TabIndex = 1;
			// 
			// LblChannelTwitchPress
			// 
			this.LblChannelTwitchPress.AutoSize = true;
			this.LblChannelTwitchPress.Location = new System.Drawing.Point(13, 13);
			this.LblChannelTwitchPress.Name = "LblChannelTwitchPress";
			this.LblChannelTwitchPress.Size = new System.Drawing.Size(81, 13);
			this.LblChannelTwitchPress.TabIndex = 0;
			this.LblChannelTwitchPress.Text = "Twitch Channel";
			// 
			// CboBoxProfilePress
			// 
			this.CboBoxProfilePress.Enabled = false;
			this.CboBoxProfilePress.FormattingEnabled = true;
			this.CboBoxProfilePress.Location = new System.Drawing.Point(124, 36);
			this.CboBoxProfilePress.Name = "CboBoxProfilePress";
			this.CboBoxProfilePress.Size = new System.Drawing.Size(166, 21);
			this.CboBoxProfilePress.TabIndex = 6;
			// 
			// ChkBoxSwitchToProfilePress
			// 
			this.ChkBoxSwitchToProfilePress.AutoSize = true;
			this.ChkBoxSwitchToProfilePress.Location = new System.Drawing.Point(12, 38);
			this.ChkBoxSwitchToProfilePress.Name = "ChkBoxSwitchToProfilePress";
			this.ChkBoxSwitchToProfilePress.Size = new System.Drawing.Size(106, 17);
			this.ChkBoxSwitchToProfilePress.TabIndex = 5;
			this.ChkBoxSwitchToProfilePress.Text = "Switch To Profile";
			this.ChkBoxSwitchToProfilePress.UseVisualStyleBackColor = true;
			this.ChkBoxSwitchToProfilePress.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxStopAllSoundPress
			// 
			this.ChkBoxStopAllSoundPress.AutoSize = true;
			this.ChkBoxStopAllSoundPress.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxStopAllSoundPress.Name = "ChkBoxStopAllSoundPress";
			this.ChkBoxStopAllSoundPress.Size = new System.Drawing.Size(101, 17);
			this.ChkBoxStopAllSoundPress.TabIndex = 4;
			this.ChkBoxStopAllSoundPress.Text = "Stop All Sounds";
			this.ChkBoxStopAllSoundPress.UseVisualStyleBackColor = true;
			// 
			// LblXLROutputPress
			// 
			this.LblXLROutputPress.AutoSize = true;
			this.LblXLROutputPress.Location = new System.Drawing.Point(93, 56);
			this.LblXLROutputPress.Name = "LblXLROutputPress";
			this.LblXLROutputPress.Size = new System.Drawing.Size(39, 13);
			this.LblXLROutputPress.TabIndex = 10;
			this.LblXLROutputPress.Text = "Output";
			// 
			// LblXLRInputPress
			// 
			this.LblXLRInputPress.AutoSize = true;
			this.LblXLRInputPress.Location = new System.Drawing.Point(101, 17);
			this.LblXLRInputPress.Name = "LblXLRInputPress";
			this.LblXLRInputPress.Size = new System.Drawing.Size(31, 13);
			this.LblXLRInputPress.TabIndex = 9;
			this.LblXLRInputPress.Text = "Input";
			// 
			// PanelXLRPress
			// 
			this.PanelXLRPress.Controls.Add(this.RadioButtonUnMuteXLRPress);
			this.PanelXLRPress.Controls.Add(this.RadioButtonMuteXLRPress);
			this.PanelXLRPress.Controls.Add(this.RadioButtonToggleXLRPress);
			this.PanelXLRPress.Controls.Add(this.RadioButtonDisabledXLRPress);
			this.PanelXLRPress.Location = new System.Drawing.Point(12, 12);
			this.PanelXLRPress.Name = "PanelXLRPress";
			this.PanelXLRPress.Size = new System.Drawing.Size(71, 97);
			this.PanelXLRPress.TabIndex = 8;
			// 
			// RadioButtonUnMuteXLRPress
			// 
			this.RadioButtonUnMuteXLRPress.AutoSize = true;
			this.RadioButtonUnMuteXLRPress.Location = new System.Drawing.Point(3, 72);
			this.RadioButtonUnMuteXLRPress.Name = "RadioButtonUnMuteXLRPress";
			this.RadioButtonUnMuteXLRPress.Size = new System.Drawing.Size(63, 17);
			this.RadioButtonUnMuteXLRPress.TabIndex = 10;
			this.RadioButtonUnMuteXLRPress.Text = "UnMute";
			this.RadioButtonUnMuteXLRPress.UseVisualStyleBackColor = true;
			// 
			// RadioButtonMuteXLRPress
			// 
			this.RadioButtonMuteXLRPress.AutoSize = true;
			this.RadioButtonMuteXLRPress.Location = new System.Drawing.Point(3, 49);
			this.RadioButtonMuteXLRPress.Name = "RadioButtonMuteXLRPress";
			this.RadioButtonMuteXLRPress.Size = new System.Drawing.Size(49, 17);
			this.RadioButtonMuteXLRPress.TabIndex = 9;
			this.RadioButtonMuteXLRPress.Text = "Mute";
			this.RadioButtonMuteXLRPress.UseVisualStyleBackColor = true;
			// 
			// RadioButtonToggleXLRPress
			// 
			this.RadioButtonToggleXLRPress.AutoSize = true;
			this.RadioButtonToggleXLRPress.Location = new System.Drawing.Point(3, 26);
			this.RadioButtonToggleXLRPress.Name = "RadioButtonToggleXLRPress";
			this.RadioButtonToggleXLRPress.Size = new System.Drawing.Size(58, 17);
			this.RadioButtonToggleXLRPress.TabIndex = 8;
			this.RadioButtonToggleXLRPress.Text = "Toggle";
			this.RadioButtonToggleXLRPress.UseVisualStyleBackColor = true;
			// 
			// RadioButtonDisabledXLRPress
			// 
			this.RadioButtonDisabledXLRPress.AutoSize = true;
			this.RadioButtonDisabledXLRPress.Checked = true;
			this.RadioButtonDisabledXLRPress.Location = new System.Drawing.Point(3, 3);
			this.RadioButtonDisabledXLRPress.Name = "RadioButtonDisabledXLRPress";
			this.RadioButtonDisabledXLRPress.Size = new System.Drawing.Size(66, 17);
			this.RadioButtonDisabledXLRPress.TabIndex = 7;
			this.RadioButtonDisabledXLRPress.TabStop = true;
			this.RadioButtonDisabledXLRPress.Text = "Disabled";
			this.RadioButtonDisabledXLRPress.UseVisualStyleBackColor = true;
			// 
			// CboBoxXLROutputPress
			// 
			this.CboBoxXLROutputPress.FormattingEnabled = true;
			this.CboBoxXLROutputPress.Location = new System.Drawing.Point(138, 53);
			this.CboBoxXLROutputPress.Name = "CboBoxXLROutputPress";
			this.CboBoxXLROutputPress.Size = new System.Drawing.Size(121, 21);
			this.CboBoxXLROutputPress.TabIndex = 2;
			// 
			// CboBoxXLRInputPress
			// 
			this.CboBoxXLRInputPress.FormattingEnabled = true;
			this.CboBoxXLRInputPress.Location = new System.Drawing.Point(138, 14);
			this.CboBoxXLRInputPress.Name = "CboBoxXLRInputPress";
			this.CboBoxXLRInputPress.Size = new System.Drawing.Size(121, 21);
			this.CboBoxXLRInputPress.TabIndex = 1;
			// 
			// ChkCboBoxHotkeyRelease
			// 
			this.ChkCboBoxHotkeyRelease.CheckOnClick = true;
			this.ChkCboBoxHotkeyRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxHotkeyRelease.DropDownHeight = 1;
			this.ChkCboBoxHotkeyRelease.Enabled = false;
			this.ChkCboBoxHotkeyRelease.FormattingEnabled = true;
			this.ChkCboBoxHotkeyRelease.IntegralHeight = false;
			this.ChkCboBoxHotkeyRelease.Location = new System.Drawing.Point(112, 442);
			this.ChkCboBoxHotkeyRelease.Name = "ChkCboBoxHotkeyRelease";
			this.ChkCboBoxHotkeyRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxHotkeyRelease.TabIndex = 41;
			this.ChkCboBoxHotkeyRelease.ValueSeparator = ", ";
			// 
			// ChkBoxHotkeyRelease
			// 
			this.ChkBoxHotkeyRelease.AutoSize = true;
			this.ChkBoxHotkeyRelease.Location = new System.Drawing.Point(12, 444);
			this.ChkBoxHotkeyRelease.Name = "ChkBoxHotkeyRelease";
			this.ChkBoxHotkeyRelease.Size = new System.Drawing.Size(60, 17);
			this.ChkBoxHotkeyRelease.TabIndex = 40;
			this.ChkBoxHotkeyRelease.Text = "Hotkey";
			this.ChkBoxHotkeyRelease.UseVisualStyleBackColor = true;
			this.ChkBoxHotkeyRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMediaStopRelease
			// 
			this.ChkCboBoxMediaStopRelease.CheckOnClick = true;
			this.ChkCboBoxMediaStopRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMediaStopRelease.DropDownHeight = 1;
			this.ChkCboBoxMediaStopRelease.Enabled = false;
			this.ChkCboBoxMediaStopRelease.FormattingEnabled = true;
			this.ChkCboBoxMediaStopRelease.IntegralHeight = false;
			this.ChkCboBoxMediaStopRelease.Location = new System.Drawing.Point(112, 361);
			this.ChkCboBoxMediaStopRelease.Name = "ChkCboBoxMediaStopRelease";
			this.ChkCboBoxMediaStopRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMediaStopRelease.TabIndex = 39;
			this.ChkCboBoxMediaStopRelease.ValueSeparator = ", ";
			// 
			// CboBoxPreviewSceneRelease
			// 
			this.CboBoxPreviewSceneRelease.Enabled = false;
			this.CboBoxPreviewSceneRelease.FormattingEnabled = true;
			this.CboBoxPreviewSceneRelease.Location = new System.Drawing.Point(112, 37);
			this.CboBoxPreviewSceneRelease.Name = "CboBoxPreviewSceneRelease";
			this.CboBoxPreviewSceneRelease.Size = new System.Drawing.Size(190, 21);
			this.CboBoxPreviewSceneRelease.TabIndex = 31;
			// 
			// ChkBoxMediaStopRelease
			// 
			this.ChkBoxMediaStopRelease.AutoSize = true;
			this.ChkBoxMediaStopRelease.Location = new System.Drawing.Point(12, 363);
			this.ChkBoxMediaStopRelease.Name = "ChkBoxMediaStopRelease";
			this.ChkBoxMediaStopRelease.Size = new System.Drawing.Size(80, 17);
			this.ChkBoxMediaStopRelease.TabIndex = 38;
			this.ChkBoxMediaStopRelease.Text = "Media Stop";
			this.ChkBoxMediaStopRelease.UseVisualStyleBackColor = true;
			this.ChkBoxMediaStopRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMediaRestartRelease
			// 
			this.ChkCboBoxMediaRestartRelease.CheckOnClick = true;
			this.ChkCboBoxMediaRestartRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMediaRestartRelease.DropDownHeight = 1;
			this.ChkCboBoxMediaRestartRelease.Enabled = false;
			this.ChkCboBoxMediaRestartRelease.FormattingEnabled = true;
			this.ChkCboBoxMediaRestartRelease.IntegralHeight = false;
			this.ChkCboBoxMediaRestartRelease.Location = new System.Drawing.Point(112, 388);
			this.ChkCboBoxMediaRestartRelease.Name = "ChkCboBoxMediaRestartRelease";
			this.ChkCboBoxMediaRestartRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMediaRestartRelease.TabIndex = 37;
			this.ChkCboBoxMediaRestartRelease.ValueSeparator = ", ";
			// 
			// ChkBoxPreviewSceneRelease
			// 
			this.ChkBoxPreviewSceneRelease.AutoSize = true;
			this.ChkBoxPreviewSceneRelease.Location = new System.Drawing.Point(12, 39);
			this.ChkBoxPreviewSceneRelease.Name = "ChkBoxPreviewSceneRelease";
			this.ChkBoxPreviewSceneRelease.Size = new System.Drawing.Size(98, 17);
			this.ChkBoxPreviewSceneRelease.TabIndex = 30;
			this.ChkBoxPreviewSceneRelease.Text = "Preview Scene";
			this.ChkBoxPreviewSceneRelease.UseVisualStyleBackColor = true;
			this.ChkBoxPreviewSceneRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxMediaRestartRelease
			// 
			this.ChkBoxMediaRestartRelease.AutoSize = true;
			this.ChkBoxMediaRestartRelease.Location = new System.Drawing.Point(12, 390);
			this.ChkBoxMediaRestartRelease.Name = "ChkBoxMediaRestartRelease";
			this.ChkBoxMediaRestartRelease.Size = new System.Drawing.Size(92, 17);
			this.ChkBoxMediaRestartRelease.TabIndex = 36;
			this.ChkBoxMediaRestartRelease.Text = "Media Restart";
			this.ChkBoxMediaRestartRelease.UseVisualStyleBackColor = true;
			this.ChkBoxMediaRestartRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMiscRelease
			// 
			this.ChkCboBoxMiscRelease.CheckOnClick = true;
			this.ChkCboBoxMiscRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMiscRelease.DropDownHeight = 1;
			this.ChkCboBoxMiscRelease.Enabled = false;
			this.ChkCboBoxMiscRelease.FormattingEnabled = true;
			this.ChkCboBoxMiscRelease.IntegralHeight = false;
			this.ChkCboBoxMiscRelease.Location = new System.Drawing.Point(112, 415);
			this.ChkCboBoxMiscRelease.Name = "ChkCboBoxMiscRelease";
			this.ChkCboBoxMiscRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMiscRelease.TabIndex = 27;
			this.ChkCboBoxMiscRelease.ValueSeparator = ", ";
			// 
			// ChkCboBoxMediaPlayRelease
			// 
			this.ChkCboBoxMediaPlayRelease.CheckOnClick = true;
			this.ChkCboBoxMediaPlayRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMediaPlayRelease.DropDownHeight = 1;
			this.ChkCboBoxMediaPlayRelease.Enabled = false;
			this.ChkCboBoxMediaPlayRelease.FormattingEnabled = true;
			this.ChkCboBoxMediaPlayRelease.IntegralHeight = false;
			this.ChkCboBoxMediaPlayRelease.Location = new System.Drawing.Point(112, 334);
			this.ChkCboBoxMediaPlayRelease.Name = "ChkCboBoxMediaPlayRelease";
			this.ChkCboBoxMediaPlayRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMediaPlayRelease.TabIndex = 35;
			this.ChkCboBoxMediaPlayRelease.ValueSeparator = ", ";
			// 
			// ChkBoxMiscRelease
			// 
			this.ChkBoxMiscRelease.AutoSize = true;
			this.ChkBoxMiscRelease.Location = new System.Drawing.Point(12, 417);
			this.ChkBoxMiscRelease.Name = "ChkBoxMiscRelease";
			this.ChkBoxMiscRelease.Size = new System.Drawing.Size(48, 17);
			this.ChkBoxMiscRelease.TabIndex = 26;
			this.ChkBoxMiscRelease.Text = "Misc";
			this.ChkBoxMiscRelease.UseVisualStyleBackColor = true;
			this.ChkBoxMiscRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxMediaPlayRelease
			// 
			this.ChkBoxMediaPlayRelease.AutoSize = true;
			this.ChkBoxMediaPlayRelease.Location = new System.Drawing.Point(12, 336);
			this.ChkBoxMediaPlayRelease.Name = "ChkBoxMediaPlayRelease";
			this.ChkBoxMediaPlayRelease.Size = new System.Drawing.Size(78, 17);
			this.ChkBoxMediaPlayRelease.TabIndex = 34;
			this.ChkBoxMediaPlayRelease.Text = "Media Play";
			this.ChkBoxMediaPlayRelease.UseVisualStyleBackColor = true;
			this.ChkBoxMediaPlayRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxToggleFilterRelease
			// 
			this.ChkCboBoxToggleFilterRelease.CheckOnClick = true;
			this.ChkCboBoxToggleFilterRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxToggleFilterRelease.DropDownHeight = 1;
			this.ChkCboBoxToggleFilterRelease.Enabled = false;
			this.ChkCboBoxToggleFilterRelease.FormattingEnabled = true;
			this.ChkCboBoxToggleFilterRelease.IntegralHeight = false;
			this.ChkCboBoxToggleFilterRelease.Location = new System.Drawing.Point(112, 199);
			this.ChkCboBoxToggleFilterRelease.Name = "ChkCboBoxToggleFilterRelease";
			this.ChkCboBoxToggleFilterRelease.Size = new System.Drawing.Size(190, 21);
			this.ChkCboBoxToggleFilterRelease.TabIndex = 29;
			this.ChkCboBoxToggleFilterRelease.ValueSeparator = ", ";
			// 
			// ChkCboBoxToggleSourceRelease
			// 
			this.ChkCboBoxToggleSourceRelease.CheckOnClick = true;
			this.ChkCboBoxToggleSourceRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxToggleSourceRelease.DropDownHeight = 1;
			this.ChkCboBoxToggleSourceRelease.Enabled = false;
			this.ChkCboBoxToggleSourceRelease.FormattingEnabled = true;
			this.ChkCboBoxToggleSourceRelease.IntegralHeight = false;
			this.ChkCboBoxToggleSourceRelease.Location = new System.Drawing.Point(112, 118);
			this.ChkCboBoxToggleSourceRelease.Name = "ChkCboBoxToggleSourceRelease";
			this.ChkCboBoxToggleSourceRelease.Size = new System.Drawing.Size(190, 21);
			this.ChkCboBoxToggleSourceRelease.TabIndex = 23;
			this.ChkCboBoxToggleSourceRelease.ValueSeparator = ", ";
			// 
			// ChkBoxToggleFilterRelease
			// 
			this.ChkBoxToggleFilterRelease.AutoSize = true;
			this.ChkBoxToggleFilterRelease.Location = new System.Drawing.Point(12, 201);
			this.ChkBoxToggleFilterRelease.Name = "ChkBoxToggleFilterRelease";
			this.ChkBoxToggleFilterRelease.Size = new System.Drawing.Size(84, 17);
			this.ChkBoxToggleFilterRelease.TabIndex = 28;
			this.ChkBoxToggleFilterRelease.Text = "Toggle Filter";
			this.ChkBoxToggleFilterRelease.UseVisualStyleBackColor = true;
			this.ChkBoxToggleFilterRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxToggleSourceRelease
			// 
			this.ChkBoxToggleSourceRelease.AutoSize = true;
			this.ChkBoxToggleSourceRelease.Location = new System.Drawing.Point(12, 120);
			this.ChkBoxToggleSourceRelease.Name = "ChkBoxToggleSourceRelease";
			this.ChkBoxToggleSourceRelease.Size = new System.Drawing.Size(96, 17);
			this.ChkBoxToggleSourceRelease.TabIndex = 22;
			this.ChkBoxToggleSourceRelease.Text = "Toggle Source";
			this.ChkBoxToggleSourceRelease.UseVisualStyleBackColor = true;
			this.ChkBoxToggleSourceRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxShowFilterRelease
			// 
			this.ChkCboBoxShowFilterRelease.CheckOnClick = true;
			this.ChkCboBoxShowFilterRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxShowFilterRelease.DropDownHeight = 1;
			this.ChkCboBoxShowFilterRelease.Enabled = false;
			this.ChkCboBoxShowFilterRelease.FormattingEnabled = true;
			this.ChkCboBoxShowFilterRelease.IntegralHeight = false;
			this.ChkCboBoxShowFilterRelease.Location = new System.Drawing.Point(112, 145);
			this.ChkCboBoxShowFilterRelease.Name = "ChkCboBoxShowFilterRelease";
			this.ChkCboBoxShowFilterRelease.Size = new System.Drawing.Size(190, 21);
			this.ChkCboBoxShowFilterRelease.TabIndex = 27;
			this.ChkCboBoxShowFilterRelease.ValueSeparator = ", ";
			// 
			// ChkCboBoxToggleMuteRelease
			// 
			this.ChkCboBoxToggleMuteRelease.CheckOnClick = true;
			this.ChkCboBoxToggleMuteRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxToggleMuteRelease.DropDownHeight = 1;
			this.ChkCboBoxToggleMuteRelease.Enabled = false;
			this.ChkCboBoxToggleMuteRelease.FormattingEnabled = true;
			this.ChkCboBoxToggleMuteRelease.IntegralHeight = false;
			this.ChkCboBoxToggleMuteRelease.Location = new System.Drawing.Point(112, 307);
			this.ChkCboBoxToggleMuteRelease.Name = "ChkCboBoxToggleMuteRelease";
			this.ChkCboBoxToggleMuteRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxToggleMuteRelease.TabIndex = 21;
			this.ChkCboBoxToggleMuteRelease.ValueSeparator = ", ";
			// 
			// ChkBoxShowFilterRelease
			// 
			this.ChkBoxShowFilterRelease.AutoSize = true;
			this.ChkBoxShowFilterRelease.Location = new System.Drawing.Point(12, 147);
			this.ChkBoxShowFilterRelease.Name = "ChkBoxShowFilterRelease";
			this.ChkBoxShowFilterRelease.Size = new System.Drawing.Size(78, 17);
			this.ChkBoxShowFilterRelease.TabIndex = 26;
			this.ChkBoxShowFilterRelease.Text = "Show Filter";
			this.ChkBoxShowFilterRelease.UseVisualStyleBackColor = true;
			this.ChkBoxShowFilterRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxHideFilterRelease
			// 
			this.ChkCboBoxHideFilterRelease.CheckOnClick = true;
			this.ChkCboBoxHideFilterRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxHideFilterRelease.DropDownHeight = 1;
			this.ChkCboBoxHideFilterRelease.Enabled = false;
			this.ChkCboBoxHideFilterRelease.FormattingEnabled = true;
			this.ChkCboBoxHideFilterRelease.IntegralHeight = false;
			this.ChkCboBoxHideFilterRelease.Location = new System.Drawing.Point(112, 172);
			this.ChkCboBoxHideFilterRelease.Name = "ChkCboBoxHideFilterRelease";
			this.ChkCboBoxHideFilterRelease.Size = new System.Drawing.Size(190, 21);
			this.ChkCboBoxHideFilterRelease.TabIndex = 25;
			this.ChkCboBoxHideFilterRelease.ValueSeparator = ", ";
			// 
			// ChkBoxTogglemuteRelease
			// 
			this.ChkBoxTogglemuteRelease.AutoSize = true;
			this.ChkBoxTogglemuteRelease.Location = new System.Drawing.Point(12, 309);
			this.ChkBoxTogglemuteRelease.Name = "ChkBoxTogglemuteRelease";
			this.ChkBoxTogglemuteRelease.Size = new System.Drawing.Size(86, 17);
			this.ChkBoxTogglemuteRelease.TabIndex = 20;
			this.ChkBoxTogglemuteRelease.Text = "Toggle Mute";
			this.ChkBoxTogglemuteRelease.UseVisualStyleBackColor = true;
			this.ChkBoxTogglemuteRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxHideFilterRelease
			// 
			this.ChkBoxHideFilterRelease.AutoSize = true;
			this.ChkBoxHideFilterRelease.Location = new System.Drawing.Point(12, 174);
			this.ChkBoxHideFilterRelease.Name = "ChkBoxHideFilterRelease";
			this.ChkBoxHideFilterRelease.Size = new System.Drawing.Size(73, 17);
			this.ChkBoxHideFilterRelease.TabIndex = 24;
			this.ChkBoxHideFilterRelease.Text = "Hide Filter";
			this.ChkBoxHideFilterRelease.UseVisualStyleBackColor = true;
			this.ChkBoxHideFilterRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxTransitionRelease
			// 
			this.ChkBoxTransitionRelease.AutoSize = true;
			this.ChkBoxTransitionRelease.Location = new System.Drawing.Point(12, 228);
			this.ChkBoxTransitionRelease.Name = "ChkBoxTransitionRelease";
			this.ChkBoxTransitionRelease.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkBoxTransitionRelease.Size = new System.Drawing.Size(72, 17);
			this.ChkBoxTransitionRelease.TabIndex = 16;
			this.ChkBoxTransitionRelease.Text = "Transition";
			this.ChkBoxTransitionRelease.UseVisualStyleBackColor = true;
			this.ChkBoxTransitionRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxHideRelease
			// 
			this.ChkCboBoxHideRelease.CheckOnClick = true;
			this.ChkCboBoxHideRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxHideRelease.DropDownHeight = 1;
			this.ChkCboBoxHideRelease.Enabled = false;
			this.ChkCboBoxHideRelease.FormattingEnabled = true;
			this.ChkCboBoxHideRelease.IntegralHeight = false;
			this.ChkCboBoxHideRelease.Location = new System.Drawing.Point(112, 91);
			this.ChkCboBoxHideRelease.Name = "ChkCboBoxHideRelease";
			this.ChkCboBoxHideRelease.Size = new System.Drawing.Size(190, 21);
			this.ChkCboBoxHideRelease.TabIndex = 19;
			this.ChkCboBoxHideRelease.ValueSeparator = ", ";
			// 
			// NumericTransitionRelease
			// 
			this.NumericTransitionRelease.Enabled = false;
			this.NumericTransitionRelease.Location = new System.Drawing.Point(250, 227);
			this.NumericTransitionRelease.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.NumericTransitionRelease.Name = "NumericTransitionRelease";
			this.NumericTransitionRelease.Size = new System.Drawing.Size(52, 20);
			this.NumericTransitionRelease.TabIndex = 15;
			// 
			// ChkBoxSwitchSceneRelease
			// 
			this.ChkBoxSwitchSceneRelease.AutoSize = true;
			this.ChkBoxSwitchSceneRelease.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxSwitchSceneRelease.Name = "ChkBoxSwitchSceneRelease";
			this.ChkBoxSwitchSceneRelease.Size = new System.Drawing.Size(92, 17);
			this.ChkBoxSwitchSceneRelease.TabIndex = 10;
			this.ChkBoxSwitchSceneRelease.Text = "Switch Scene";
			this.ChkBoxSwitchSceneRelease.UseVisualStyleBackColor = true;
			this.ChkBoxSwitchSceneRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// CboBoxTransitionRelease
			// 
			this.CboBoxTransitionRelease.Enabled = false;
			this.CboBoxTransitionRelease.FormattingEnabled = true;
			this.CboBoxTransitionRelease.Location = new System.Drawing.Point(112, 226);
			this.CboBoxTransitionRelease.Name = "CboBoxTransitionRelease";
			this.CboBoxTransitionRelease.Size = new System.Drawing.Size(133, 21);
			this.CboBoxTransitionRelease.TabIndex = 14;
			// 
			// ChkBoxHideSourceRelease
			// 
			this.ChkBoxHideSourceRelease.AutoSize = true;
			this.ChkBoxHideSourceRelease.Location = new System.Drawing.Point(12, 93);
			this.ChkBoxHideSourceRelease.Name = "ChkBoxHideSourceRelease";
			this.ChkBoxHideSourceRelease.Size = new System.Drawing.Size(85, 17);
			this.ChkBoxHideSourceRelease.TabIndex = 18;
			this.ChkBoxHideSourceRelease.Text = "Hide Source";
			this.ChkBoxHideSourceRelease.UseVisualStyleBackColor = true;
			this.ChkBoxHideSourceRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// CboBoxSwitchSceneRelease
			// 
			this.CboBoxSwitchSceneRelease.Enabled = false;
			this.CboBoxSwitchSceneRelease.FormattingEnabled = true;
			this.CboBoxSwitchSceneRelease.Location = new System.Drawing.Point(112, 10);
			this.CboBoxSwitchSceneRelease.Name = "CboBoxSwitchSceneRelease";
			this.CboBoxSwitchSceneRelease.Size = new System.Drawing.Size(190, 21);
			this.CboBoxSwitchSceneRelease.TabIndex = 11;
			// 
			// ChkCboBoxShowRelease
			// 
			this.ChkCboBoxShowRelease.CheckOnClick = true;
			this.ChkCboBoxShowRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxShowRelease.DropDownHeight = 1;
			this.ChkCboBoxShowRelease.Enabled = false;
			this.ChkCboBoxShowRelease.FormattingEnabled = true;
			this.ChkCboBoxShowRelease.IntegralHeight = false;
			this.ChkCboBoxShowRelease.Location = new System.Drawing.Point(112, 64);
			this.ChkCboBoxShowRelease.Name = "ChkCboBoxShowRelease";
			this.ChkCboBoxShowRelease.Size = new System.Drawing.Size(190, 21);
			this.ChkCboBoxShowRelease.TabIndex = 17;
			this.ChkCboBoxShowRelease.ValueSeparator = ", ";
			// 
			// ChkBoxMuteRelease
			// 
			this.ChkBoxMuteRelease.AutoSize = true;
			this.ChkBoxMuteRelease.Location = new System.Drawing.Point(12, 255);
			this.ChkBoxMuteRelease.Name = "ChkBoxMuteRelease";
			this.ChkBoxMuteRelease.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ChkBoxMuteRelease.Size = new System.Drawing.Size(50, 17);
			this.ChkBoxMuteRelease.TabIndex = 12;
			this.ChkBoxMuteRelease.Text = "Mute";
			this.ChkBoxMuteRelease.UseVisualStyleBackColor = true;
			this.ChkBoxMuteRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxShowSourceRelease
			// 
			this.ChkBoxShowSourceRelease.AutoSize = true;
			this.ChkBoxShowSourceRelease.Location = new System.Drawing.Point(12, 66);
			this.ChkBoxShowSourceRelease.Name = "ChkBoxShowSourceRelease";
			this.ChkBoxShowSourceRelease.Size = new System.Drawing.Size(90, 17);
			this.ChkBoxShowSourceRelease.TabIndex = 16;
			this.ChkBoxShowSourceRelease.Text = "Show Source";
			this.ChkBoxShowSourceRelease.UseVisualStyleBackColor = true;
			this.ChkBoxShowSourceRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxMuteRelease
			// 
			this.ChkCboBoxMuteRelease.CheckOnClick = true;
			this.ChkCboBoxMuteRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxMuteRelease.DropDownHeight = 1;
			this.ChkCboBoxMuteRelease.Enabled = false;
			this.ChkCboBoxMuteRelease.FormattingEnabled = true;
			this.ChkCboBoxMuteRelease.IntegralHeight = false;
			this.ChkCboBoxMuteRelease.Location = new System.Drawing.Point(112, 253);
			this.ChkCboBoxMuteRelease.Name = "ChkCboBoxMuteRelease";
			this.ChkCboBoxMuteRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxMuteRelease.TabIndex = 13;
			this.ChkCboBoxMuteRelease.ValueSeparator = ", ";
			// 
			// ChkCboBoxUnmuteRelease
			// 
			this.ChkCboBoxUnmuteRelease.CheckOnClick = true;
			this.ChkCboBoxUnmuteRelease.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxUnmuteRelease.DropDownHeight = 1;
			this.ChkCboBoxUnmuteRelease.Enabled = false;
			this.ChkCboBoxUnmuteRelease.FormattingEnabled = true;
			this.ChkCboBoxUnmuteRelease.IntegralHeight = false;
			this.ChkCboBoxUnmuteRelease.Location = new System.Drawing.Point(112, 280);
			this.ChkCboBoxUnmuteRelease.Name = "ChkCboBoxUnmuteRelease";
			this.ChkCboBoxUnmuteRelease.Size = new System.Drawing.Size(191, 21);
			this.ChkCboBoxUnmuteRelease.TabIndex = 15;
			this.ChkCboBoxUnmuteRelease.ValueSeparator = ", ";
			// 
			// ChkBoxUnmuteRelease
			// 
			this.ChkBoxUnmuteRelease.AutoSize = true;
			this.ChkBoxUnmuteRelease.Location = new System.Drawing.Point(12, 282);
			this.ChkBoxUnmuteRelease.Name = "ChkBoxUnmuteRelease";
			this.ChkBoxUnmuteRelease.Size = new System.Drawing.Size(64, 17);
			this.ChkBoxUnmuteRelease.TabIndex = 14;
			this.ChkBoxUnmuteRelease.Text = "UnMute";
			this.ChkBoxUnmuteRelease.UseVisualStyleBackColor = true;
			this.ChkBoxUnmuteRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxAudioStop
			// 
			this.ChkBoxAudioStop.AutoSize = true;
			this.ChkBoxAudioStop.Enabled = false;
			this.ChkBoxAudioStop.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxAudioStop.Name = "ChkBoxAudioStop";
			this.ChkBoxAudioStop.Size = new System.Drawing.Size(159, 17);
			this.ChkBoxAudioStop.TabIndex = 0;
			this.ChkBoxAudioStop.Text = "Stop Sound when Released";
			this.ChkBoxAudioStop.UseVisualStyleBackColor = true;
			// 
			// ChkBoxMediaKeyPreviousRelease
			// 
			this.ChkBoxMediaKeyPreviousRelease.AutoSize = true;
			this.ChkBoxMediaKeyPreviousRelease.Location = new System.Drawing.Point(12, 58);
			this.ChkBoxMediaKeyPreviousRelease.Name = "ChkBoxMediaKeyPreviousRelease";
			this.ChkBoxMediaKeyPreviousRelease.Size = new System.Drawing.Size(120, 17);
			this.ChkBoxMediaKeyPreviousRelease.TabIndex = 6;
			this.ChkBoxMediaKeyPreviousRelease.Text = "Previous Media Key";
			this.ChkBoxMediaKeyPreviousRelease.UseVisualStyleBackColor = true;
			// 
			// ChkBoxMediaKeyNextRelease
			// 
			this.ChkBoxMediaKeyNextRelease.AutoSize = true;
			this.ChkBoxMediaKeyNextRelease.Location = new System.Drawing.Point(12, 35);
			this.ChkBoxMediaKeyNextRelease.Name = "ChkBoxMediaKeyNextRelease";
			this.ChkBoxMediaKeyNextRelease.Size = new System.Drawing.Size(101, 17);
			this.ChkBoxMediaKeyNextRelease.TabIndex = 5;
			this.ChkBoxMediaKeyNextRelease.Text = "Next Media Key";
			this.ChkBoxMediaKeyNextRelease.UseVisualStyleBackColor = true;
			// 
			// ChkBoxMediaKeyPlayRelease
			// 
			this.ChkBoxMediaKeyPlayRelease.AutoSize = true;
			this.ChkBoxMediaKeyPlayRelease.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxMediaKeyPlayRelease.Name = "ChkBoxMediaKeyPlayRelease";
			this.ChkBoxMediaKeyPlayRelease.Size = new System.Drawing.Size(140, 17);
			this.ChkBoxMediaKeyPlayRelease.TabIndex = 4;
			this.ChkBoxMediaKeyPlayRelease.Text = "Play / Pause Media Key";
			this.ChkBoxMediaKeyPlayRelease.UseVisualStyleBackColor = true;
			// 
			// LblTwitchMessageRelease
			// 
			this.LblTwitchMessageRelease.AutoSize = true;
			this.LblTwitchMessageRelease.Location = new System.Drawing.Point(13, 44);
			this.LblTwitchMessageRelease.Name = "LblTwitchMessageRelease";
			this.LblTwitchMessageRelease.Size = new System.Drawing.Size(50, 13);
			this.LblTwitchMessageRelease.TabIndex = 7;
			this.LblTwitchMessageRelease.Text = "Message";
			// 
			// TxtBoxTwitchMessageRelease
			// 
			this.TxtBoxTwitchMessageRelease.Location = new System.Drawing.Point(16, 60);
			this.TxtBoxTwitchMessageRelease.Multiline = true;
			this.TxtBoxTwitchMessageRelease.Name = "TxtBoxTwitchMessageRelease";
			this.TxtBoxTwitchMessageRelease.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtBoxTwitchMessageRelease.Size = new System.Drawing.Size(356, 180);
			this.TxtBoxTwitchMessageRelease.TabIndex = 6;
			// 
			// TxtBoxTwitchChannelRelease
			// 
			this.TxtBoxTwitchChannelRelease.Location = new System.Drawing.Point(100, 10);
			this.TxtBoxTwitchChannelRelease.Name = "TxtBoxTwitchChannelRelease";
			this.TxtBoxTwitchChannelRelease.Size = new System.Drawing.Size(143, 20);
			this.TxtBoxTwitchChannelRelease.TabIndex = 5;
			// 
			// LblChannelTwitchRelease
			// 
			this.LblChannelTwitchRelease.AutoSize = true;
			this.LblChannelTwitchRelease.Location = new System.Drawing.Point(13, 13);
			this.LblChannelTwitchRelease.Name = "LblChannelTwitchRelease";
			this.LblChannelTwitchRelease.Size = new System.Drawing.Size(81, 13);
			this.LblChannelTwitchRelease.TabIndex = 4;
			this.LblChannelTwitchRelease.Text = "Twitch Channel";
			// 
			// CboBoxProfileRelease
			// 
			this.CboBoxProfileRelease.Enabled = false;
			this.CboBoxProfileRelease.FormattingEnabled = true;
			this.CboBoxProfileRelease.Location = new System.Drawing.Point(124, 36);
			this.CboBoxProfileRelease.Name = "CboBoxProfileRelease";
			this.CboBoxProfileRelease.Size = new System.Drawing.Size(166, 21);
			this.CboBoxProfileRelease.TabIndex = 7;
			// 
			// ChkBoxSwitchToProfileRelease
			// 
			this.ChkBoxSwitchToProfileRelease.AutoSize = true;
			this.ChkBoxSwitchToProfileRelease.Location = new System.Drawing.Point(12, 38);
			this.ChkBoxSwitchToProfileRelease.Name = "ChkBoxSwitchToProfileRelease";
			this.ChkBoxSwitchToProfileRelease.Size = new System.Drawing.Size(106, 17);
			this.ChkBoxSwitchToProfileRelease.TabIndex = 6;
			this.ChkBoxSwitchToProfileRelease.Text = "Switch To Profile";
			this.ChkBoxSwitchToProfileRelease.UseVisualStyleBackColor = true;
			this.ChkBoxSwitchToProfileRelease.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxStopAllSoundRelease
			// 
			this.ChkBoxStopAllSoundRelease.AutoSize = true;
			this.ChkBoxStopAllSoundRelease.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxStopAllSoundRelease.Name = "ChkBoxStopAllSoundRelease";
			this.ChkBoxStopAllSoundRelease.Size = new System.Drawing.Size(101, 17);
			this.ChkBoxStopAllSoundRelease.TabIndex = 4;
			this.ChkBoxStopAllSoundRelease.Text = "Stop All Sounds";
			this.ChkBoxStopAllSoundRelease.UseVisualStyleBackColor = true;
			// 
			// LblXLROutputRelease
			// 
			this.LblXLROutputRelease.AutoSize = true;
			this.LblXLROutputRelease.Location = new System.Drawing.Point(93, 56);
			this.LblXLROutputRelease.Name = "LblXLROutputRelease";
			this.LblXLROutputRelease.Size = new System.Drawing.Size(39, 13);
			this.LblXLROutputRelease.TabIndex = 18;
			this.LblXLROutputRelease.Text = "Output";
			// 
			// LblXLRInputRelease
			// 
			this.LblXLRInputRelease.AutoSize = true;
			this.LblXLRInputRelease.Location = new System.Drawing.Point(101, 17);
			this.LblXLRInputRelease.Name = "LblXLRInputRelease";
			this.LblXLRInputRelease.Size = new System.Drawing.Size(31, 13);
			this.LblXLRInputRelease.TabIndex = 17;
			this.LblXLRInputRelease.Text = "Input";
			// 
			// PanelXLRRelease
			// 
			this.PanelXLRRelease.Controls.Add(this.RadioButtonUnMuteXLRRelease);
			this.PanelXLRRelease.Controls.Add(this.RadioButtonMuteXLRRelease);
			this.PanelXLRRelease.Controls.Add(this.RadioButtonToggleXLRRelease);
			this.PanelXLRRelease.Controls.Add(this.RadioButtonDisabledXLRRelease);
			this.PanelXLRRelease.Location = new System.Drawing.Point(12, 12);
			this.PanelXLRRelease.Name = "PanelXLRRelease";
			this.PanelXLRRelease.Size = new System.Drawing.Size(71, 97);
			this.PanelXLRRelease.TabIndex = 16;
			// 
			// RadioButtonUnMuteXLRRelease
			// 
			this.RadioButtonUnMuteXLRRelease.AutoSize = true;
			this.RadioButtonUnMuteXLRRelease.Location = new System.Drawing.Point(3, 72);
			this.RadioButtonUnMuteXLRRelease.Name = "RadioButtonUnMuteXLRRelease";
			this.RadioButtonUnMuteXLRRelease.Size = new System.Drawing.Size(63, 17);
			this.RadioButtonUnMuteXLRRelease.TabIndex = 10;
			this.RadioButtonUnMuteXLRRelease.Text = "UnMute";
			this.RadioButtonUnMuteXLRRelease.UseVisualStyleBackColor = true;
			// 
			// RadioButtonMuteXLRRelease
			// 
			this.RadioButtonMuteXLRRelease.AutoSize = true;
			this.RadioButtonMuteXLRRelease.Location = new System.Drawing.Point(3, 49);
			this.RadioButtonMuteXLRRelease.Name = "RadioButtonMuteXLRRelease";
			this.RadioButtonMuteXLRRelease.Size = new System.Drawing.Size(49, 17);
			this.RadioButtonMuteXLRRelease.TabIndex = 9;
			this.RadioButtonMuteXLRRelease.Text = "Mute";
			this.RadioButtonMuteXLRRelease.UseVisualStyleBackColor = true;
			// 
			// RadioButtonToggleXLRRelease
			// 
			this.RadioButtonToggleXLRRelease.AutoSize = true;
			this.RadioButtonToggleXLRRelease.Location = new System.Drawing.Point(3, 26);
			this.RadioButtonToggleXLRRelease.Name = "RadioButtonToggleXLRRelease";
			this.RadioButtonToggleXLRRelease.Size = new System.Drawing.Size(58, 17);
			this.RadioButtonToggleXLRRelease.TabIndex = 8;
			this.RadioButtonToggleXLRRelease.Text = "Toggle";
			this.RadioButtonToggleXLRRelease.UseVisualStyleBackColor = true;
			// 
			// RadioButtonDisabledXLRRelease
			// 
			this.RadioButtonDisabledXLRRelease.AutoSize = true;
			this.RadioButtonDisabledXLRRelease.Checked = true;
			this.RadioButtonDisabledXLRRelease.Location = new System.Drawing.Point(3, 3);
			this.RadioButtonDisabledXLRRelease.Name = "RadioButtonDisabledXLRRelease";
			this.RadioButtonDisabledXLRRelease.Size = new System.Drawing.Size(66, 17);
			this.RadioButtonDisabledXLRRelease.TabIndex = 7;
			this.RadioButtonDisabledXLRRelease.TabStop = true;
			this.RadioButtonDisabledXLRRelease.Text = "Disabled";
			this.RadioButtonDisabledXLRRelease.UseVisualStyleBackColor = true;
			// 
			// CboBoxXLROutputRelease
			// 
			this.CboBoxXLROutputRelease.FormattingEnabled = true;
			this.CboBoxXLROutputRelease.Location = new System.Drawing.Point(138, 53);
			this.CboBoxXLROutputRelease.Name = "CboBoxXLROutputRelease";
			this.CboBoxXLROutputRelease.Size = new System.Drawing.Size(121, 21);
			this.CboBoxXLROutputRelease.TabIndex = 11;
			// 
			// CboBoxXLRInputRelease
			// 
			this.CboBoxXLRInputRelease.FormattingEnabled = true;
			this.CboBoxXLRInputRelease.Location = new System.Drawing.Point(138, 14);
			this.CboBoxXLRInputRelease.Name = "CboBoxXLRInputRelease";
			this.CboBoxXLRInputRelease.Size = new System.Drawing.Size(121, 21);
			this.CboBoxXLRInputRelease.TabIndex = 10;
			// 
			// CboBoxFilterSettingSlider
			// 
			this.CboBoxFilterSettingSlider.Enabled = false;
			this.CboBoxFilterSettingSlider.FormattingEnabled = true;
			this.CboBoxFilterSettingSlider.IntegralHeight = false;
			this.CboBoxFilterSettingSlider.Location = new System.Drawing.Point(111, 64);
			this.CboBoxFilterSettingSlider.Name = "CboBoxFilterSettingSlider";
			this.CboBoxFilterSettingSlider.Size = new System.Drawing.Size(186, 21);
			this.CboBoxFilterSettingSlider.TabIndex = 41;
			// 
			// CboBoxFilterNameSlider
			// 
			this.CboBoxFilterNameSlider.Enabled = false;
			this.CboBoxFilterNameSlider.FormattingEnabled = true;
			this.CboBoxFilterNameSlider.Location = new System.Drawing.Point(111, 37);
			this.CboBoxFilterNameSlider.Name = "CboBoxFilterNameSlider";
			this.CboBoxFilterNameSlider.Size = new System.Drawing.Size(186, 21);
			this.CboBoxFilterNameSlider.TabIndex = 40;
			this.CboBoxFilterNameSlider.SelectionChangeCommitted += new System.EventHandler(this.CboBoxFilterNameSlider_SelectionChangeCommitted);
			// 
			// ChkBoxAdjustFilter
			// 
			this.ChkBoxAdjustFilter.AutoSize = true;
			this.ChkBoxAdjustFilter.Location = new System.Drawing.Point(12, 39);
			this.ChkBoxAdjustFilter.Name = "ChkBoxAdjustFilter";
			this.ChkBoxAdjustFilter.Size = new System.Drawing.Size(80, 17);
			this.ChkBoxAdjustFilter.TabIndex = 4;
			this.ChkBoxAdjustFilter.Text = "Adjust Filter";
			this.ChkBoxAdjustFilter.UseVisualStyleBackColor = true;
			this.ChkBoxAdjustFilter.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxSlideTransition
			// 
			this.ChkBoxSlideTransition.AutoSize = true;
			this.ChkBoxSlideTransition.Location = new System.Drawing.Point(12, 118);
			this.ChkBoxSlideTransition.Name = "ChkBoxSlideTransition";
			this.ChkBoxSlideTransition.Size = new System.Drawing.Size(135, 17);
			this.ChkBoxSlideTransition.TabIndex = 3;
			this.ChkBoxSlideTransition.Text = "Slide Current Transition";
			this.ChkBoxSlideTransition.UseVisualStyleBackColor = true;
			this.ChkBoxSlideTransition.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkBoxAdjustTransitionDuration
			// 
			this.ChkBoxAdjustTransitionDuration.AutoSize = true;
			this.ChkBoxAdjustTransitionDuration.Location = new System.Drawing.Point(12, 91);
			this.ChkBoxAdjustTransitionDuration.Name = "ChkBoxAdjustTransitionDuration";
			this.ChkBoxAdjustTransitionDuration.Size = new System.Drawing.Size(147, 17);
			this.ChkBoxAdjustTransitionDuration.TabIndex = 2;
			this.ChkBoxAdjustTransitionDuration.Text = "Adjust Transition Duration";
			this.ChkBoxAdjustTransitionDuration.UseVisualStyleBackColor = true;
			// 
			// ChkBoxAdjustVolume
			// 
			this.ChkBoxAdjustVolume.AutoSize = true;
			this.ChkBoxAdjustVolume.Location = new System.Drawing.Point(12, 12);
			this.ChkBoxAdjustVolume.Name = "ChkBoxAdjustVolume";
			this.ChkBoxAdjustVolume.Size = new System.Drawing.Size(93, 17);
			this.ChkBoxAdjustVolume.TabIndex = 0;
			this.ChkBoxAdjustVolume.Text = "Adjust Volume";
			this.ChkBoxAdjustVolume.UseVisualStyleBackColor = true;
			this.ChkBoxAdjustVolume.CheckedChanged += new System.EventHandler(this.ChkBox_State);
			// 
			// ChkCboBoxVolumeSlider
			// 
			this.ChkCboBoxVolumeSlider.CheckOnClick = true;
			this.ChkCboBoxVolumeSlider.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCboBoxVolumeSlider.DropDownHeight = 1;
			this.ChkCboBoxVolumeSlider.Enabled = false;
			this.ChkCboBoxVolumeSlider.FormattingEnabled = true;
			this.ChkCboBoxVolumeSlider.IntegralHeight = false;
			this.ChkCboBoxVolumeSlider.Location = new System.Drawing.Point(111, 10);
			this.ChkCboBoxVolumeSlider.Name = "ChkCboBoxVolumeSlider";
			this.ChkCboBoxVolumeSlider.Size = new System.Drawing.Size(186, 21);
			this.ChkCboBoxVolumeSlider.TabIndex = 1;
			this.ChkCboBoxVolumeSlider.ValueSeparator = ", ";
			// 
			// treeView1
			// 
			this.treeView1.HotTracking = true;
			this.treeView1.Location = new System.Drawing.Point(16, 60);
			this.treeView1.Name = "treeView1";
			treeNode49.Name = "obs_on";
			treeNode49.Text = "OBS";
			treeNode50.Name = "soundboard_on";
			treeNode50.Text = "SoundBoard";
			treeNode51.Name = "mediakeys_on";
			treeNode51.Text = "Media Keys";
			treeNode52.Name = "twitch_on";
			treeNode52.Text = "Twitch Chat";
			treeNode53.Name = "midicontrol_on";
			treeNode53.Text = "MidiControl";
			treeNode54.Name = "goxlr_on";
			treeNode54.Text = "Go XLR";
			treeNode55.Name = "onkeypress_root";
			treeNode55.Text = "On Key Press";
			treeNode56.Name = "obs_off";
			treeNode56.Text = "OBS";
			treeNode57.Name = "soundboard_off";
			treeNode57.Text = "SoundBoard";
			treeNode58.Name = "mediakeys_off";
			treeNode58.Text = "Media Keys";
			treeNode59.Name = "twitch_off";
			treeNode59.Text = "Twitch Chat";
			treeNode60.Name = "midicontrol_off";
			treeNode60.Text = "MidiControl";
			treeNode61.Name = "goxlr_off";
			treeNode61.Text = "Go XLR";
			treeNode62.Name = "onkeyrelease_root";
			treeNode62.Text = "On Key Release";
			treeNode63.Name = "obs_slider";
			treeNode63.Text = "OBS";
			treeNode64.Name = "onsliderchange_root";
			treeNode64.Text = "On Slider Change";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode55,
            treeNode62,
            treeNode64});
			this.treeView1.PathSeparator = " > ";
			this.treeView1.ShowNodeToolTips = true;
			this.treeView1.Size = new System.Drawing.Size(191, 301);
			this.treeView1.TabIndex = 14;
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ActionCategoryChanged);
			// 
			// pnlOBSPress
			// 
			this.pnlOBSPress.AutoScroll = true;
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxHotkeyPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxSwitchScenePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxHotkeyPress);
			this.pnlOBSPress.Controls.Add(this.CboBoxSwitchScenePress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxMediaStopPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxMutePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxMediaStopPress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxMutePress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxMediaRestartPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxUnmutePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxMediaRestartPress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxUnmutePress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxMediaPlayPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxShowSourcePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxMediaPlayPress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxShowPress);
			this.pnlOBSPress.Controls.Add(this.CboBoxPreviewScenePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxHideSourcePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxPreviewScenePress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxHidePress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxMiscPress);
			this.pnlOBSPress.Controls.Add(this.CboBoxTransitionPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxMiscPress);
			this.pnlOBSPress.Controls.Add(this.NumericTransitionPress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxToggleFilterPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxTransitionPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxToggleFilterPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxTogglemutePress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxShowFilterPress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxToggleMutePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxShowFilterPress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxToggleSourcePress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxHideFilterPress);
			this.pnlOBSPress.Controls.Add(this.ChkCboBoxToggleSourcePress);
			this.pnlOBSPress.Controls.Add(this.ChkBoxHideFilterPress);
			this.pnlOBSPress.Location = new System.Drawing.Point(856, 25);
			this.pnlOBSPress.Name = "pnlOBSPress";
			this.pnlOBSPress.Size = new System.Drawing.Size(147, 110);
			this.pnlOBSPress.TabIndex = 15;
			this.pnlOBSPress.Tag = "obs_on";
			// 
			// pnlSoundBoardPress
			// 
			this.pnlSoundBoardPress.AutoScroll = true;
			this.pnlSoundBoardPress.Controls.Add(this.chkStopAllOthers);
			this.pnlSoundBoardPress.Controls.Add(this.ChkBoxEnableAudio);
			this.pnlSoundBoardPress.Controls.Add(this.LblAudioDevice);
			this.pnlSoundBoardPress.Controls.Add(this.LblVolume);
			this.pnlSoundBoardPress.Controls.Add(this.CboBoxAudioDevice);
			this.pnlSoundBoardPress.Controls.Add(this.LblAudioFile);
			this.pnlSoundBoardPress.Controls.Add(this.volumeSlider);
			this.pnlSoundBoardPress.Controls.Add(this.TxtBoxAudioFile);
			this.pnlSoundBoardPress.Controls.Add(this.chkBoxLoop);
			this.pnlSoundBoardPress.Controls.Add(this.BtnAudioSelect);
			this.pnlSoundBoardPress.Location = new System.Drawing.Point(298, 473);
			this.pnlSoundBoardPress.Name = "pnlSoundBoardPress";
			this.pnlSoundBoardPress.Size = new System.Drawing.Size(392, 259);
			this.pnlSoundBoardPress.TabIndex = 16;
			this.pnlSoundBoardPress.Tag = "soundboard_on";
			// 
			// pnlMediaKeysPress
			// 
			this.pnlMediaKeysPress.AutoScroll = true;
			this.pnlMediaKeysPress.Controls.Add(this.ChkBoxMediaKeyPreviousPress);
			this.pnlMediaKeysPress.Controls.Add(this.ChkBoxMediaKeyPlayPress);
			this.pnlMediaKeysPress.Controls.Add(this.ChkBoxMediaKeyNextPress);
			this.pnlMediaKeysPress.Location = new System.Drawing.Point(1033, 34);
			this.pnlMediaKeysPress.Name = "pnlMediaKeysPress";
			this.pnlMediaKeysPress.Size = new System.Drawing.Size(133, 94);
			this.pnlMediaKeysPress.TabIndex = 17;
			this.pnlMediaKeysPress.Tag = "mediakeys_on";
			// 
			// pnlGoXLRPress
			// 
			this.pnlGoXLRPress.AutoScroll = true;
			this.pnlGoXLRPress.Controls.Add(this.LblXLROutputPress);
			this.pnlGoXLRPress.Controls.Add(this.PanelXLRPress);
			this.pnlGoXLRPress.Controls.Add(this.LblXLRInputPress);
			this.pnlGoXLRPress.Controls.Add(this.CboBoxXLRInputPress);
			this.pnlGoXLRPress.Controls.Add(this.CboBoxXLROutputPress);
			this.pnlGoXLRPress.Location = new System.Drawing.Point(1211, 158);
			this.pnlGoXLRPress.Name = "pnlGoXLRPress";
			this.pnlGoXLRPress.Size = new System.Drawing.Size(99, 98);
			this.pnlGoXLRPress.TabIndex = 18;
			this.pnlGoXLRPress.Tag = "goxlr_on";
			// 
			// pnlTwitchPress
			// 
			this.pnlTwitchPress.AutoScroll = true;
			this.pnlTwitchPress.Controls.Add(this.LblTwitchMessagePress);
			this.pnlTwitchPress.Controls.Add(this.TxtBoxTwitchMessagePress);
			this.pnlTwitchPress.Controls.Add(this.LblChannelTwitchPress);
			this.pnlTwitchPress.Controls.Add(this.TxtBoxTwitchChannelPress);
			this.pnlTwitchPress.Location = new System.Drawing.Point(1039, 165);
			this.pnlTwitchPress.Name = "pnlTwitchPress";
			this.pnlTwitchPress.Size = new System.Drawing.Size(108, 91);
			this.pnlTwitchPress.TabIndex = 18;
			this.pnlTwitchPress.Tag = "twitch_on";
			// 
			// pnlMidiControlPress
			// 
			this.pnlMidiControlPress.AutoScroll = true;
			this.pnlMidiControlPress.Controls.Add(this.CboBoxProfilePress);
			this.pnlMidiControlPress.Controls.Add(this.ChkBoxStopAllSoundPress);
			this.pnlMidiControlPress.Controls.Add(this.ChkBoxSwitchToProfilePress);
			this.pnlMidiControlPress.Location = new System.Drawing.Point(1200, 45);
			this.pnlMidiControlPress.Name = "pnlMidiControlPress";
			this.pnlMidiControlPress.Size = new System.Drawing.Size(128, 83);
			this.pnlMidiControlPress.TabIndex = 18;
			this.pnlMidiControlPress.Tag = "midicontrol_on";
			// 
			// pnlOBSRelease
			// 
			this.pnlOBSRelease.AutoScroll = true;
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxHotkeyRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxSwitchSceneRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxHotkeyRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxUnmuteRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxMediaStopRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxUnmuteRelease);
			this.pnlOBSRelease.Controls.Add(this.CboBoxPreviewSceneRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxMuteRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxMediaStopRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxShowSourceRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxMediaRestartRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxMuteRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxPreviewSceneRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxShowRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxMediaRestartRelease);
			this.pnlOBSRelease.Controls.Add(this.CboBoxSwitchSceneRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxMiscRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxHideSourceRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxMediaPlayRelease);
			this.pnlOBSRelease.Controls.Add(this.CboBoxTransitionRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxMiscRelease);
			this.pnlOBSRelease.Controls.Add(this.NumericTransitionRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxMediaPlayRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxHideRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxToggleFilterRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxTransitionRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxToggleSourceRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxHideFilterRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxToggleFilterRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxTogglemuteRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxToggleSourceRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxHideFilterRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxShowFilterRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkBoxShowFilterRelease);
			this.pnlOBSRelease.Controls.Add(this.ChkCboBoxToggleMuteRelease);
			this.pnlOBSRelease.Location = new System.Drawing.Point(868, 361);
			this.pnlOBSRelease.Name = "pnlOBSRelease";
			this.pnlOBSRelease.Size = new System.Drawing.Size(114, 71);
			this.pnlOBSRelease.TabIndex = 19;
			this.pnlOBSRelease.Tag = "obs_off";
			// 
			// pnlSoundBoardRelease
			// 
			this.pnlSoundBoardRelease.AutoScroll = true;
			this.pnlSoundBoardRelease.Controls.Add(this.ChkBoxAudioStop);
			this.pnlSoundBoardRelease.Location = new System.Drawing.Point(868, 461);
			this.pnlSoundBoardRelease.Name = "pnlSoundBoardRelease";
			this.pnlSoundBoardRelease.Size = new System.Drawing.Size(114, 81);
			this.pnlSoundBoardRelease.TabIndex = 20;
			this.pnlSoundBoardRelease.Tag = "soundboard_off";
			// 
			// pnlMediaKeysRelease
			// 
			this.pnlMediaKeysRelease.AutoScroll = true;
			this.pnlMediaKeysRelease.Controls.Add(this.ChkBoxMediaKeyPreviousRelease);
			this.pnlMediaKeysRelease.Controls.Add(this.ChkBoxMediaKeyPlayRelease);
			this.pnlMediaKeysRelease.Controls.Add(this.ChkBoxMediaKeyNextRelease);
			this.pnlMediaKeysRelease.Location = new System.Drawing.Point(1022, 359);
			this.pnlMediaKeysRelease.Name = "pnlMediaKeysRelease";
			this.pnlMediaKeysRelease.Size = new System.Drawing.Size(96, 85);
			this.pnlMediaKeysRelease.TabIndex = 21;
			this.pnlMediaKeysRelease.Tag = "mediakeys_off";
			// 
			// pnlMidiControlRelease
			// 
			this.pnlMidiControlRelease.AutoScroll = true;
			this.pnlMidiControlRelease.Controls.Add(this.CboBoxProfileRelease);
			this.pnlMidiControlRelease.Controls.Add(this.ChkBoxStopAllSoundRelease);
			this.pnlMidiControlRelease.Controls.Add(this.ChkBoxSwitchToProfileRelease);
			this.pnlMidiControlRelease.Location = new System.Drawing.Point(1176, 359);
			this.pnlMidiControlRelease.Name = "pnlMidiControlRelease";
			this.pnlMidiControlRelease.Size = new System.Drawing.Size(122, 87);
			this.pnlMidiControlRelease.TabIndex = 22;
			this.pnlMidiControlRelease.Tag = "midicontrol_off";
			// 
			// pnlTwitchRelease
			// 
			this.pnlTwitchRelease.AutoScroll = true;
			this.pnlTwitchRelease.Controls.Add(this.LblTwitchMessageRelease);
			this.pnlTwitchRelease.Controls.Add(this.LblChannelTwitchRelease);
			this.pnlTwitchRelease.Controls.Add(this.TxtBoxTwitchMessageRelease);
			this.pnlTwitchRelease.Controls.Add(this.TxtBoxTwitchChannelRelease);
			this.pnlTwitchRelease.Location = new System.Drawing.Point(1034, 473);
			this.pnlTwitchRelease.Name = "pnlTwitchRelease";
			this.pnlTwitchRelease.Size = new System.Drawing.Size(115, 79);
			this.pnlTwitchRelease.TabIndex = 22;
			this.pnlTwitchRelease.Tag = "twitch_off";
			// 
			// pnlGoXLRRelease
			// 
			this.pnlGoXLRRelease.AutoScroll = true;
			this.pnlGoXLRRelease.Controls.Add(this.LblXLROutputRelease);
			this.pnlGoXLRRelease.Controls.Add(this.CboBoxXLRInputRelease);
			this.pnlGoXLRRelease.Controls.Add(this.LblXLRInputRelease);
			this.pnlGoXLRRelease.Controls.Add(this.CboBoxXLROutputRelease);
			this.pnlGoXLRRelease.Controls.Add(this.PanelXLRRelease);
			this.pnlGoXLRRelease.Location = new System.Drawing.Point(1188, 473);
			this.pnlGoXLRRelease.Name = "pnlGoXLRRelease";
			this.pnlGoXLRRelease.Size = new System.Drawing.Size(138, 92);
			this.pnlGoXLRRelease.TabIndex = 22;
			this.pnlGoXLRRelease.Tag = "goxlr_off";
			// 
			// pnlOBSSlider
			// 
			this.pnlOBSSlider.AutoScroll = true;
			this.pnlOBSSlider.Controls.Add(this.ChkBoxSlideTransition);
			this.pnlOBSSlider.Controls.Add(this.CboBoxFilterSettingSlider);
			this.pnlOBSSlider.Controls.Add(this.ChkBoxAdjustTransitionDuration);
			this.pnlOBSSlider.Controls.Add(this.ChkBoxAdjustVolume);
			this.pnlOBSSlider.Controls.Add(this.CboBoxFilterNameSlider);
			this.pnlOBSSlider.Controls.Add(this.ChkCboBoxVolumeSlider);
			this.pnlOBSSlider.Controls.Add(this.ChkBoxAdjustFilter);
			this.pnlOBSSlider.Location = new System.Drawing.Point(864, 596);
			this.pnlOBSSlider.Name = "pnlOBSSlider";
			this.pnlOBSSlider.Size = new System.Drawing.Size(200, 123);
			this.pnlOBSSlider.TabIndex = 23;
			this.pnlOBSSlider.Tag = "obs_slider";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Select action:";
			// 
			// lblPanelLabel
			// 
			this.lblPanelLabel.AutoSize = true;
			this.lblPanelLabel.Location = new System.Drawing.Point(215, 43);
			this.lblPanelLabel.Name = "lblPanelLabel";
			this.lblPanelLabel.Size = new System.Drawing.Size(79, 13);
			this.lblPanelLabel.TabIndex = 26;
			this.lblPanelLabel.Text = "[category label]";
			// 
			// pnlRoot
			// 
			this.pnlRoot.AutoScroll = true;
			this.pnlRoot.Controls.Add(this.txtKeybindSummary);
			this.pnlRoot.Controls.Add(this.label3);
			this.pnlRoot.Location = new System.Drawing.Point(218, 60);
			this.pnlRoot.Name = "pnlRoot";
			this.pnlRoot.Size = new System.Drawing.Size(385, 301);
			this.pnlRoot.TabIndex = 27;
			this.pnlRoot.Tag = "root";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(206, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Select a subcategory to configure options.";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(528, 372);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 28;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.CancelPressed);
			// 
			// lblHideMe
			// 
			this.lblHideMe.AutoSize = true;
			this.lblHideMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHideMe.Location = new System.Drawing.Point(13, 365);
			this.lblHideMe.Name = "lblHideMe";
			this.lblHideMe.Size = new System.Drawing.Size(272, 26);
			this.lblHideMe.TabIndex = 29;
			this.lblHideMe.Text = "original window size (632, 446)\r\nexpand window to view and edit the subpanels\r\n";
			this.lblHideMe.Visible = false;
			// 
			// txtKeybindSummary
			// 
			this.txtKeybindSummary.Location = new System.Drawing.Point(15, 32);
			this.txtKeybindSummary.Multiline = true;
			this.txtKeybindSummary.Name = "txtKeybindSummary";
			this.txtKeybindSummary.ReadOnly = true;
			this.txtKeybindSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtKeybindSummary.Size = new System.Drawing.Size(356, 259);
			this.txtKeybindSummary.TabIndex = 1;
			// 
			// EntryGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(616, 407);
			this.Controls.Add(this.lblHideMe);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.pnlRoot);
			this.Controls.Add(this.lblPanelLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pnlOBSSlider);
			this.Controls.Add(this.pnlMidiControlRelease);
			this.Controls.Add(this.pnlTwitchRelease);
			this.Controls.Add(this.pnlGoXLRRelease);
			this.Controls.Add(this.pnlMediaKeysRelease);
			this.Controls.Add(this.pnlSoundBoardRelease);
			this.Controls.Add(this.pnlOBSRelease);
			this.Controls.Add(this.pnlGoXLRPress);
			this.Controls.Add(this.pnlTwitchPress);
			this.Controls.Add(this.pnlMidiControlPress);
			this.Controls.Add(this.pnlMediaKeysPress);
			this.Controls.Add(this.pnlSoundBoardPress);
			this.Controls.Add(this.pnlOBSPress);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.TxtBoxChannel);
			this.Controls.Add(this.LblChannel);
			this.Controls.Add(this.BtnAdd);
			this.Controls.Add(this.TxtBoxDevice);
			this.Controls.Add(this.LblDevice);
			this.Controls.Add(this.TxtBoxNote);
			this.Controls.Add(this.LblNote);
			this.Controls.Add(this.TxtBoxName);
			this.Controls.Add(this.LblName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EntryGUI";
			this.Text = "Add MIDI Keybind";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntryGUI_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.NumericTransitionPress)).EndInit();
			this.PanelXLRPress.ResumeLayout(false);
			this.PanelXLRPress.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericTransitionRelease)).EndInit();
			this.PanelXLRRelease.ResumeLayout(false);
			this.PanelXLRRelease.PerformLayout();
			this.pnlOBSPress.ResumeLayout(false);
			this.pnlOBSPress.PerformLayout();
			this.pnlSoundBoardPress.ResumeLayout(false);
			this.pnlSoundBoardPress.PerformLayout();
			this.pnlMediaKeysPress.ResumeLayout(false);
			this.pnlMediaKeysPress.PerformLayout();
			this.pnlGoXLRPress.ResumeLayout(false);
			this.pnlGoXLRPress.PerformLayout();
			this.pnlTwitchPress.ResumeLayout(false);
			this.pnlTwitchPress.PerformLayout();
			this.pnlMidiControlPress.ResumeLayout(false);
			this.pnlMidiControlPress.PerformLayout();
			this.pnlOBSRelease.ResumeLayout(false);
			this.pnlOBSRelease.PerformLayout();
			this.pnlSoundBoardRelease.ResumeLayout(false);
			this.pnlSoundBoardRelease.PerformLayout();
			this.pnlMediaKeysRelease.ResumeLayout(false);
			this.pnlMediaKeysRelease.PerformLayout();
			this.pnlMidiControlRelease.ResumeLayout(false);
			this.pnlMidiControlRelease.PerformLayout();
			this.pnlTwitchRelease.ResumeLayout(false);
			this.pnlTwitchRelease.PerformLayout();
			this.pnlGoXLRRelease.ResumeLayout(false);
			this.pnlGoXLRRelease.PerformLayout();
			this.pnlOBSSlider.ResumeLayout(false);
			this.pnlOBSSlider.PerformLayout();
			this.pnlRoot.ResumeLayout(false);
			this.pnlRoot.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtBoxName;
        private System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.TextBox TxtBoxNote;
        public System.Windows.Forms.TextBox TxtBoxDevice;
        private System.Windows.Forms.Label LblDevice;
        private System.Windows.Forms.Button BtnAdd;
        public System.Windows.Forms.TextBox TxtBoxChannel;
        private System.Windows.Forms.Label LblChannel;
        private System.Windows.Forms.CheckBox ChkBoxSwitchScenePress;
        private System.Windows.Forms.ComboBox CboBoxSwitchScenePress;
        private System.Windows.Forms.CheckBox ChkBoxMutePress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMutePress;
        private System.Windows.Forms.CheckBox ChkBoxUnmutePress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxUnmutePress;
        private System.Windows.Forms.CheckBox ChkBoxHideSourcePress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxHidePress;
        private System.Windows.Forms.CheckBox ChkBoxShowSourcePress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxShowPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxHideRelease;
        private System.Windows.Forms.CheckBox ChkBoxSwitchSceneRelease;
        private System.Windows.Forms.CheckBox ChkBoxHideSourceRelease;
        private System.Windows.Forms.ComboBox CboBoxSwitchSceneRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxShowRelease;
        private System.Windows.Forms.CheckBox ChkBoxMuteRelease;
        private System.Windows.Forms.CheckBox ChkBoxShowSourceRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMuteRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxUnmuteRelease;
        private System.Windows.Forms.CheckBox ChkBoxUnmuteRelease;
        private System.Windows.Forms.Button BtnAudioSelect;
        private System.Windows.Forms.TextBox TxtBoxAudioFile;
        private System.Windows.Forms.CheckBox ChkBoxAudioStop;
        private System.Windows.Forms.CheckBox ChkBoxEnableAudio;
        private System.Windows.Forms.ComboBox CboBoxAudioDevice;
        private System.Windows.Forms.Label LblAudioDevice;
        private System.Windows.Forms.Label LblAudioFile;
        private System.Windows.Forms.CheckBox chkBoxLoop;
        private NAudio.Gui.VolumeSlider volumeSlider;
        private System.Windows.Forms.Label LblVolume;
        private System.Windows.Forms.NumericUpDown NumericTransitionPress;
        private System.Windows.Forms.ComboBox CboBoxTransitionPress;
        private System.Windows.Forms.CheckBox ChkBoxTransitionPress;
        private System.Windows.Forms.CheckBox ChkBoxTransitionRelease;
        private System.Windows.Forms.NumericUpDown NumericTransitionRelease;
        private System.Windows.Forms.ComboBox CboBoxTransitionRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxToggleSourcePress;
        private System.Windows.Forms.CheckBox ChkBoxToggleSourcePress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxToggleMutePress;
        private System.Windows.Forms.CheckBox ChkBoxTogglemutePress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxToggleSourceRelease;
        private System.Windows.Forms.CheckBox ChkBoxToggleSourceRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxToggleMuteRelease;
        private System.Windows.Forms.CheckBox ChkBoxTogglemuteRelease;
        private System.Windows.Forms.CheckBox ChkBoxAdjustVolume;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxVolumeSlider;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxToggleFilterPress;
        private System.Windows.Forms.CheckBox ChkBoxToggleFilterPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxShowFilterPress;
        private System.Windows.Forms.CheckBox ChkBoxShowFilterPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxHideFilterPress;
        private System.Windows.Forms.CheckBox ChkBoxHideFilterPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxToggleFilterRelease;
        private System.Windows.Forms.CheckBox ChkBoxToggleFilterRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxShowFilterRelease;
        private System.Windows.Forms.CheckBox ChkBoxShowFilterRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxHideFilterRelease;
        private System.Windows.Forms.CheckBox ChkBoxHideFilterRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMiscPress;
        private System.Windows.Forms.CheckBox ChkBoxMiscPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMiscRelease;
        private System.Windows.Forms.CheckBox ChkBoxMiscRelease;
        private System.Windows.Forms.CheckBox ChkBoxAdjustTransitionDuration;
        private System.Windows.Forms.CheckBox ChkBoxSlideTransition;
        private System.Windows.Forms.ComboBox CboBoxPreviewScenePress;
        private System.Windows.Forms.CheckBox ChkBoxPreviewScenePress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMediaStopPress;
        private System.Windows.Forms.CheckBox ChkBoxMediaStopPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMediaRestartPress;
        private System.Windows.Forms.CheckBox ChkBoxMediaRestartPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMediaPlayPress;
        private System.Windows.Forms.CheckBox ChkBoxMediaPlayPress;
        private System.Windows.Forms.ComboBox CboBoxPreviewSceneRelease;
        private System.Windows.Forms.CheckBox ChkBoxPreviewSceneRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMediaStopRelease;
        private System.Windows.Forms.CheckBox ChkBoxMediaStopRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMediaRestartRelease;
        private System.Windows.Forms.CheckBox ChkBoxMediaRestartRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxMediaPlayRelease;
        private System.Windows.Forms.CheckBox ChkBoxMediaPlayRelease;
        private System.Windows.Forms.CheckBox ChkBoxMediaKeyPlayPress;
        private System.Windows.Forms.CheckBox ChkBoxMediaKeyPreviousPress;
        private System.Windows.Forms.CheckBox ChkBoxMediaKeyNextPress;
        private System.Windows.Forms.CheckBox ChkBoxAdjustFilter;
        private System.Windows.Forms.ComboBox CboBoxFilterSettingSlider;
        private System.Windows.Forms.ComboBox CboBoxFilterNameSlider;
        private System.Windows.Forms.CheckBox ChkBoxMediaKeyPreviousRelease;
        private System.Windows.Forms.CheckBox ChkBoxMediaKeyNextRelease;
        private System.Windows.Forms.CheckBox ChkBoxMediaKeyPlayRelease;
        private System.Windows.Forms.TextBox TxtBoxTwitchChannelPress;
        private System.Windows.Forms.Label LblChannelTwitchPress;
        private System.Windows.Forms.Label LblTwitchMessagePress;
        private System.Windows.Forms.TextBox TxtBoxTwitchMessagePress;
        private System.Windows.Forms.Label LblTwitchMessageRelease;
        private System.Windows.Forms.TextBox TxtBoxTwitchMessageRelease;
        private System.Windows.Forms.TextBox TxtBoxTwitchChannelRelease;
        private System.Windows.Forms.Label LblChannelTwitchRelease;
        private System.Windows.Forms.CheckBox ChkBoxStopAllSoundPress;
        private System.Windows.Forms.CheckBox ChkBoxStopAllSoundRelease;
        private System.Windows.Forms.CheckBox ChkBoxSwitchToProfilePress;
        private System.Windows.Forms.CheckBox ChkBoxSwitchToProfileRelease;
        private System.Windows.Forms.ComboBox CboBoxProfilePress;
        private System.Windows.Forms.ComboBox CboBoxProfileRelease;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxHotkeyPress;
        private System.Windows.Forms.CheckBox ChkBoxHotkeyPress;
        private CheckComboBoxTest.CheckedComboBox ChkCboBoxHotkeyRelease;
        private System.Windows.Forms.CheckBox ChkBoxHotkeyRelease;
        private System.Windows.Forms.ComboBox CboBoxXLROutputPress;
        private System.Windows.Forms.ComboBox CboBoxXLRInputPress;
        private System.Windows.Forms.ComboBox CboBoxXLROutputRelease;
        private System.Windows.Forms.ComboBox CboBoxXLRInputRelease;
        private System.Windows.Forms.Panel PanelXLRPress;
        private System.Windows.Forms.RadioButton RadioButtonDisabledXLRPress;
        private System.Windows.Forms.RadioButton RadioButtonUnMuteXLRPress;
        private System.Windows.Forms.RadioButton RadioButtonMuteXLRPress;
        private System.Windows.Forms.RadioButton RadioButtonToggleXLRPress;
        private System.Windows.Forms.Panel PanelXLRRelease;
        private System.Windows.Forms.RadioButton RadioButtonUnMuteXLRRelease;
        private System.Windows.Forms.RadioButton RadioButtonMuteXLRRelease;
        private System.Windows.Forms.RadioButton RadioButtonToggleXLRRelease;
        private System.Windows.Forms.RadioButton RadioButtonDisabledXLRRelease;
        private System.Windows.Forms.Label LblXLROutputPress;
        private System.Windows.Forms.Label LblXLRInputPress;
        private System.Windows.Forms.Label LblXLROutputRelease;
        private System.Windows.Forms.Label LblXLRInputRelease;
		private System.Windows.Forms.CheckBox chkStopAllOthers;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Panel pnlOBSPress;
		private System.Windows.Forms.Panel pnlSoundBoardPress;
		private System.Windows.Forms.Panel pnlMediaKeysPress;
		private System.Windows.Forms.Panel pnlGoXLRPress;
		private System.Windows.Forms.Panel pnlTwitchPress;
		private System.Windows.Forms.Panel pnlMidiControlPress;
		private System.Windows.Forms.Panel pnlOBSRelease;
		private System.Windows.Forms.Panel pnlSoundBoardRelease;
		private System.Windows.Forms.Panel pnlMediaKeysRelease;
		private System.Windows.Forms.Panel pnlMidiControlRelease;
		private System.Windows.Forms.Panel pnlTwitchRelease;
		private System.Windows.Forms.Panel pnlGoXLRRelease;
		private System.Windows.Forms.Panel pnlOBSSlider;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblPanelLabel;
		private System.Windows.Forms.Panel pnlRoot;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblHideMe;
		private System.Windows.Forms.TextBox txtKeybindSummary;
	}
}