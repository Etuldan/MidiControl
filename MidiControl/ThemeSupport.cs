using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidiControl {
	class ThemeSupport {
		public class DarkModeToolStripColors : ProfessionalColorTable {
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

		public class Office2007BlueColorTable : ProfessionalColorTable {
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

	}
}
