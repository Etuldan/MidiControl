using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidiControl {
	class ThemeSupport {
		public const int DEFAULT = 0;
		public const int DARKMODE = 1;
		public const int OFFICEBLUE = 2;

        // order of themes to list in the options menu
        // also determines what theme class is returned for a given index in GetThemeByIndex()
		public static string[] GetThemesList() {
			return new string[] { "Default (light)", "Dark", "Office 2007 Blue" };
		}

		public static MidiControlTheme GetThemeByIndex(int i) {
			switch(i) {
				case 1: return new DarkTheme2();
				case 2: return new Office2007BlueTheme();
				default: return new DefaultTheme();
			}
		}

        // ProfessionalColorTable + additional properties specific to this app
		public abstract class MidiControlTheme : ProfessionalColorTable {
			public virtual bool ShowStatusBarGrip => true;
			public virtual Color WindowBackColor => SystemColors.Control;
			public virtual Color MenuForeColor => SystemColors.ControlText;
			public virtual Color ToolbarForeColor => this.MenuForeColor;
			public virtual Color ListViewBackColor => SystemColors.Window;
			public virtual Color ListViewForeColor => SystemColors.WindowText;
			public virtual BorderStyle ListViewBorderStyle => BorderStyle.Fixed3D;

			public virtual Image SaveIcon => Properties.Resources.floppy_disk;
			public virtual Image DeleteIcon => Properties.Resources.rubbish;
			public virtual Image PlusIcon => Properties.Resources.plus;
			public virtual Image MinusIcon => Properties.Resources.minus;
			public virtual Image EditIcon => Properties.Resources.edit;
			public virtual Image MuteIcon => Properties.Resources.mute;
			public virtual Image OBSIcon => Properties.Resources.obs;
			public virtual Image TwitchIcon => Properties.Resources.twitch;
			public virtual Image MIDIIcon => Properties.Resources.MIDI;
			public virtual Image ControlKnobIcon => Properties.Resources.control_knob_icon;
			public virtual Image ControlButtonIcon => Properties.Resources.control_button_icon;
			public virtual Image SettingsIcon => Properties.Resources.settings;
		}

		public class DefaultTheme : MidiControlTheme { }

		public class DarkTheme : MidiControlTheme {
			public override bool ShowStatusBarGrip => false;
			public override Color WindowBackColor => Color.Black;
			public override Color MenuForeColor => Color.White;
			public override Color ToolbarForeColor => this.MenuForeColor;
			public override Color ListViewBackColor => Color.FromArgb(24, 24, 24);
			public override Color ListViewForeColor => Color.FromArgb(224, 224, 224);
			public override BorderStyle ListViewBorderStyle => BorderStyle.None;

			public override Color ToolStripGradientBegin => Color.Black;
			public override Color ToolStripGradientMiddle => Color.FromArgb(24, 24, 24);
			public override Color ToolStripGradientEnd => Color.Black;
			public override Color ToolStripBorder => Color.Black;
			public override Color GripLight => Color.DarkGray;
			public override Color GripDark => Color.DimGray;
			public override Color SeparatorLight => Color.DarkGray;
			public override Color SeparatorDark => Color.DimGray;

			public override Color ToolStripDropDownBackground => Color.FromArgb(24, 24, 24);
			public override Color ImageMarginGradientBegin => Color.FromArgb(48, 48, 48);
			public override Color ImageMarginGradientMiddle => Color.FromArgb(48, 48, 48);
			public override Color ImageMarginGradientEnd => Color.FromArgb(48, 48, 48);

			public override Color MenuItemSelected => Color.SteelBlue;
			public override Color MenuItemPressedGradientBegin => Color.SteelBlue;
			public override Color MenuItemPressedGradientMiddle => Color.SteelBlue;
			public override Color MenuItemPressedGradientEnd => Color.SteelBlue;

			public override Color ButtonSelectedHighlight => Color.SteelBlue;
			public override Color ButtonSelectedBorder => Color.Gray;
			public override Color ButtonSelectedGradientBegin => Color.SteelBlue;
			public override Color ButtonSelectedGradientMiddle => Color.SteelBlue;
			public override Color ButtonSelectedGradientEnd => Color.SteelBlue;
			public override Color ButtonPressedHighlight => Color.SteelBlue;
			public override Color ButtonCheckedHighlight => Color.SteelBlue;

			public override Color StatusStripGradientBegin => Color.Black;
			public override Color StatusStripGradientEnd => Color.Black;
		}

		public class DarkTheme2 : MidiControlTheme {
			public override bool ShowStatusBarGrip => false;
			public override Color WindowBackColor => Color.FromArgb(45, 45, 48);
			public override Color MenuForeColor => Color.White;
			public override Color ToolbarForeColor => this.MenuForeColor;
			public override Color ListViewBackColor => Color.FromArgb(30, 30, 30);
			public override Color ListViewForeColor => Color.FromArgb(224, 224, 224);
			public override BorderStyle ListViewBorderStyle => BorderStyle.None;

			public override Image SaveIcon => Properties.Resources.floppy_disk_light;
			public override Image DeleteIcon => Properties.Resources.rubbish_light;
			public override Image PlusIcon => Properties.Resources.plus_light;
			public override Image MinusIcon => Properties.Resources.minus_light;
			public override Image EditIcon => Properties.Resources.edit_light;
			public override Image MuteIcon => Properties.Resources.mute_light;
			public override Image OBSIcon => Properties.Resources.obs;
			public override Image TwitchIcon => Properties.Resources.twitch_light;
			public override Image MIDIIcon => Properties.Resources.MIDI_light;
			public override Image ControlKnobIcon => Properties.Resources.control_knob_icon_light;
			public override Image ControlButtonIcon => Properties.Resources.control_button_icon_light;
			public override Image SettingsIcon => Properties.Resources.settings_light;

			public override Color ToolStripGradientBegin => Color.FromArgb(45, 45, 48);
			public override Color ToolStripGradientMiddle => Color.FromArgb(45, 45, 48);
			public override Color ToolStripGradientEnd => Color.FromArgb(45, 45, 48);
			public override Color ToolStripBorder => Color.FromArgb(45, 45, 48);
			public override Color GripDark => Color.FromArgb(34, 34, 34);
			public override Color GripLight => Color.FromArgb(70, 70, 74);
			public override Color SeparatorDark => Color.FromArgb(34, 34, 34);
			public override Color SeparatorLight => Color.FromArgb(70, 70, 74);

			public override Color ToolStripDropDownBackground => Color.FromArgb(27, 27, 28);
			public override Color ImageMarginGradientBegin => Color.FromArgb(32, 32, 32);
			public override Color ImageMarginGradientMiddle => Color.FromArgb(32, 32, 32);
			public override Color ImageMarginGradientEnd => Color.FromArgb(32, 32, 32);

			public override Color MenuItemSelected => Color.FromArgb(51, 51, 52);
			public override Color MenuItemSelectedGradientBegin => Color.FromArgb(51, 51, 52);
			public override Color MenuItemSelectedGradientEnd => Color.FromArgb(51, 51, 52);

			public override Color MenuItemPressedGradientBegin => Color.FromArgb(27, 27, 28);
			public override Color MenuItemPressedGradientMiddle => Color.FromArgb(27, 27, 28);
			public override Color MenuItemPressedGradientEnd => Color.FromArgb(27, 27, 28);
			public override Color MenuBorder => Color.FromArgb(51, 51, 55);
			public override Color MenuItemBorder => Color.FromArgb(51, 51, 55);

			public override Color ButtonSelectedHighlight => Color.FromArgb(62, 62, 64);
			public override Color ButtonSelectedBorder => Color.FromArgb(62, 62, 64);
			public override Color ButtonSelectedGradientBegin => Color.FromArgb(62, 62, 64);
			public override Color ButtonSelectedGradientMiddle => Color.FromArgb(62, 62, 64);
			public override Color ButtonSelectedGradientEnd => Color.FromArgb(62, 62, 64);
			public override Color ButtonPressedHighlight => Color.FromArgb(62, 62, 64);

			public override Color ButtonCheckedHighlight => Color.FromArgb(51, 51, 52);
			public override Color ButtonCheckedGradientBegin => Color.FromArgb(51, 51, 52);
			public override Color ButtonCheckedGradientMiddle => Color.FromArgb(51, 51, 52);
			public override Color ButtonCheckedGradientEnd => Color.FromArgb(51, 51, 52);

			public override Color StatusStripGradientBegin => Color.Black;
			public override Color StatusStripGradientEnd => Color.Black;


            // copied from office 2007 blue to see what's missing
			public override Color ButtonSelectedHighlightBorder => Color.White;
			public override Color ButtonPressedHighlightBorder => Color.White;
			public override Color ButtonCheckedHighlightBorder => Color.White;
			public override Color ButtonPressedBorder => Color.FromArgb(251, 140, 60);
			public override Color ButtonPressedGradientBegin => Color.FromArgb(252, 151, 61);
			public override Color ButtonPressedGradientMiddle => Color.FromArgb(255, 171, 63);
			public override Color ButtonPressedGradientEnd => Color.FromArgb(255, 184, 94);
			public override Color CheckBackground => Color.FromArgb(255, 171, 63);
			public override Color CheckSelectedBackground => this.ButtonPressedGradientBegin;
			public override Color CheckPressedBackground => this.CheckSelectedBackground;
			public override Color ImageMarginRevealedGradientBegin => this.ImageMarginGradientBegin;
			public override Color ImageMarginRevealedGradientMiddle => this.ImageMarginRevealedGradientBegin;
			public override Color ImageMarginRevealedGradientEnd => ImageMarginRevealedGradientBegin;
			public override Color MenuStripGradientBegin => Color.FromArgb(45, 45, 48);
			public override Color MenuStripGradientEnd => this.MenuStripGradientBegin;
			
			public override Color RaftingContainerGradientBegin => Color.FromArgb(27, 27, 28);
			public override Color RaftingContainerGradientEnd => Color.FromArgb(27, 27, 28);
			public override Color ToolStripContentPanelGradientBegin => Color.FromArgb(215, 232, 255);
			public override Color ToolStripContentPanelGradientEnd => Color.FromArgb(111, 157, 217);
			public override Color ToolStripPanelGradientBegin => this.MenuStripGradientBegin;
			public override Color ToolStripPanelGradientEnd => this.MenuStripGradientEnd;
			public override Color OverflowButtonGradientBegin => Color.FromArgb(27, 27, 28);
			public override Color OverflowButtonGradientMiddle => Color.FromArgb(27, 27, 28);
			public override Color OverflowButtonGradientEnd => Color.FromArgb(27, 27, 28);
		}

		public class Office2007BlueTheme : MidiControlTheme {
			public override Color ButtonSelectedHighlight => Color.White;
			public override Color ButtonSelectedHighlightBorder => Color.White;
			public override Color ButtonPressedHighlight => Color.White;
			public override Color ButtonPressedHighlightBorder => Color.White;
			public override Color ButtonCheckedHighlight => Color.White;
			public override Color ButtonCheckedHighlightBorder => Color.White;
			public override Color ButtonPressedBorder => Color.FromArgb(251, 140, 60);
			public override Color ButtonSelectedBorder => Color.FromArgb(255, 189, 105);
			public override Color ButtonCheckedGradientBegin => Color.FromArgb(255, 207, 146);
			public override Color ButtonCheckedGradientMiddle => Color.FromArgb(255, 189, 105);
			public override Color ButtonCheckedGradientEnd => Color.FromArgb(255, 175, 73);
			public override Color ButtonSelectedGradientBegin => Color.FromArgb(255, 245, 204);
			public override Color ButtonSelectedGradientMiddle => Color.FromArgb(255, 230, 162);
			public override Color ButtonSelectedGradientEnd => Color.FromArgb(255, 218, 117);
			public override Color ButtonPressedGradientBegin => Color.FromArgb(252, 151, 61);
			public override Color ButtonPressedGradientMiddle => Color.FromArgb(255, 171, 63);
			public override Color ButtonPressedGradientEnd => Color.FromArgb(255, 184, 94);
			public override Color CheckBackground => Color.FromArgb(255, 171, 63);
			public override Color CheckSelectedBackground => this.ButtonPressedGradientBegin;
			public override Color CheckPressedBackground => this.CheckSelectedBackground;
			public override Color GripDark => Color.FromArgb(111, 157, 217);
			public override Color GripLight => Color.White;
			public override Color ImageMarginGradientBegin => Color.FromArgb(233, 238, 238);
			public override Color ImageMarginGradientMiddle => this.ImageMarginGradientBegin;
			public override Color ImageMarginGradientEnd => this.ImageMarginGradientBegin;
			public override Color ImageMarginRevealedGradientBegin => this.ImageMarginGradientBegin;
			public override Color ImageMarginRevealedGradientMiddle => this.ImageMarginRevealedGradientBegin;
			public override Color ImageMarginRevealedGradientEnd => ImageMarginRevealedGradientBegin;
			public override Color MenuStripGradientBegin => Color.FromArgb(191, 219, 255);
			public override Color MenuStripGradientEnd => this.MenuStripGradientBegin;
			public override Color MenuItemSelected => Color.FromArgb(255, 231, 162);
			public override Color MenuItemBorder => Color.FromArgb(255, 189, 105);
			public override Color MenuBorder => Color.FromArgb(101, 147, 207);
			public override Color MenuItemSelectedGradientBegin => this.ButtonSelectedGradientBegin;
			public override Color MenuItemSelectedGradientEnd => this.ButtonSelectedGradientEnd;
			public override Color MenuItemPressedGradientBegin => Color.FromArgb(226, 239, 255);
			public override Color MenuItemPressedGradientMiddle => Color.FromArgb(190, 215, 247);
			public override Color MenuItemPressedGradientEnd => Color.FromArgb(153, 191, 240);
			public override Color RaftingContainerGradientBegin => Color.White;
			public override Color RaftingContainerGradientEnd => Color.White;
			public override Color SeparatorDark => Color.FromArgb(154, 198, 255);
			public override Color SeparatorLight => Color.White;
			public override Color ToolStripBorder => Color.FromArgb(111, 157, 217);
			public override Color ToolStripDropDownBackground => Color.FromArgb(246, 246, 246);
			public override Color ToolStripGradientBegin => Color.FromArgb(227, 239, 255);
			public override Color ToolStripGradientMiddle => Color.FromArgb(218, 234, 255);
			public override Color ToolStripGradientEnd => Color.FromArgb(177, 211, 255);
			public override Color ToolStripContentPanelGradientBegin => Color.FromArgb(215, 232, 255);
			public override Color ToolStripContentPanelGradientEnd => Color.FromArgb(111, 157, 217);
			public override Color ToolStripPanelGradientBegin => this.MenuStripGradientBegin;
			public override Color ToolStripPanelGradientEnd => this.MenuStripGradientEnd;
			public override Color OverflowButtonGradientBegin => Color.FromArgb(215, 232, 255);
			public override Color OverflowButtonGradientMiddle => Color.FromArgb(167, 204, 251);
			public override Color OverflowButtonGradientEnd => Color.FromArgb(111, 157, 217);
		}

		public class Office2007BlackTheme : MidiControlTheme {
			public override Color ButtonSelectedHighlight => Color.FromArgb(223, 227, 213);
			public override Color ButtonSelectedHighlightBorder => Color.FromArgb(255, 189, 105);
			public override Color ButtonPressedHighlight => Color.FromArgb(200, 206, 182);
			public override Color ButtonPressedHighlightBorder => Color.FromArgb(147, 160, 112);
			public override Color ButtonCheckedHighlight => Color.FromArgb(223, 227, 213);
			public override Color ButtonCheckedHighlightBorder => Color.FromArgb(147, 160, 112);
			public override Color ButtonPressedBorder => Color.FromArgb(255, 189, 105);
			public override Color ButtonSelectedBorder => Color.FromArgb(255, 189, 105);
			public override Color ButtonCheckedGradientBegin => Color.FromArgb(255, 223, 154);
			public override Color ButtonCheckedGradientMiddle => Color.FromArgb(255, 195, 116);
			public override Color ButtonCheckedGradientEnd => Color.FromArgb(255, 166, 76);
			public override Color ButtonSelectedGradientBegin => Color.FromArgb(255, 245, 204);
			public override Color ButtonSelectedGradientMiddle => Color.FromArgb(255, 231, 162);
			public override Color ButtonSelectedGradientEnd => Color.FromArgb(255, 219, 117);
			public override Color ButtonPressedGradientBegin => Color.FromArgb(248, 181, 106);
			public override Color ButtonPressedGradientMiddle => Color.FromArgb(251, 140, 60);
			public override Color ButtonPressedGradientEnd => Color.FromArgb(255, 208, 134);
			public override Color CheckBackground => Color.FromArgb(255, 227, 149);
			public override Color CheckSelectedBackground => Color.FromArgb(254, 128, 62);
			public override Color CheckPressedBackground => Color.FromArgb(254, 128, 62);
			public override Color GripDark => Color.FromArgb(145, 153, 164);
			public override Color GripLight => Color.FromArgb(221, 224, 227);
			public override Color ImageMarginGradientBegin => Color.FromArgb(255, 223, 154);
			public override Color ImageMarginGradientMiddle => Color.FromArgb(255, 223, 154);
			public override Color ImageMarginGradientEnd => Color.FromArgb(255, 223, 154);
			public override Color ImageMarginRevealedGradientBegin => Color.FromArgb(230, 230, 209);
			public override Color ImageMarginRevealedGradientMiddle => Color.FromArgb(186, 201, 143);
			public override Color ImageMarginRevealedGradientEnd => Color.FromArgb(160, 177, 116);
			public override Color MenuStripGradientBegin => Color.FromArgb(83, 83, 83);
			public override Color MenuStripGradientEnd => Color.FromArgb(83, 83, 83);
			public override Color MenuItemSelected => Color.FromArgb(255, 238, 194);
			public override Color MenuItemBorder => Color.FromArgb(255, 189, 105);
			public override Color MenuBorder => Color.FromArgb(145, 153, 164);
			public override Color MenuItemSelectedGradientBegin => Color.FromArgb(255, 245, 204);
			public override Color MenuItemSelectedGradientEnd => Color.FromArgb(255, 223, 132);
			public override Color MenuItemPressedGradientBegin => Color.FromArgb(145, 153, 164);
			public override Color MenuItemPressedGradientMiddle => Color.FromArgb(126, 135, 146);
			public override Color MenuItemPressedGradientEnd => Color.FromArgb(108, 117, 128);
			public override Color RaftingContainerGradientBegin => Color.FromArgb(83, 83, 83);
			public override Color RaftingContainerGradientEnd => Color.FromArgb(83, 83, 83);
			public override Color SeparatorDark => Color.FromArgb(145, 153, 164);
			public override Color SeparatorLight => Color.FromArgb(221, 224, 227);
			public override Color StatusStripGradientBegin => Color.FromArgb(76, 83, 92);
			public override Color StatusStripGradientEnd => Color.FromArgb(35, 38, 42);
			public override Color ToolStripBorder => Color.FromArgb(76, 83, 92);
			public override Color ToolStripDropDownBackground => Color.FromArgb(250, 250, 250);
			public override Color ToolStripGradientBegin => Color.FromArgb(205, 208, 213);
			public override Color ToolStripGradientMiddle => Color.FromArgb(188, 193, 200);
			public override Color ToolStripGradientEnd => Color.FromArgb(148, 156, 166);
			public override Color ToolStripContentPanelGradientBegin => Color.FromArgb(82, 82, 82);
			public override Color ToolStripContentPanelGradientEnd => Color.FromArgb(10, 10, 10);
			public override Color ToolStripPanelGradientBegin => Color.FromArgb(83, 83, 83);
			public override Color ToolStripPanelGradientEnd => Color.FromArgb(83, 83, 83);
			public override Color OverflowButtonGradientBegin => Color.FromArgb(178, 183, 191);
			public override Color OverflowButtonGradientMiddle => Color.FromArgb(145, 153, 164);
			public override Color OverflowButtonGradientEnd => Color.FromArgb(81, 88, 98);
		}
	}
}
