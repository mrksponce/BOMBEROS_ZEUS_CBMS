using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MapWinGIS;

namespace Forms
{
    public struct Label
    {
        public int handle;
        public MapWinGIS.tkHJustification alignment;
        public Font font;
        public int field;
        public int field2;
        public bool UseMinExtents;
        public MapWinGIS.Extents extents;
        public System.Drawing.Color color;
        public System.Drawing.Color shadowColor;
        public System.Collections.ArrayList points;
        public bool CalculatePos;
        public bool Modified;
        public bool LabelExtentsChanged;
        public bool Scaled;
        public bool UseShadows;
        public int Offset;
        public double StandardViewWidth;
        public bool UseLabelCollision;
        public bool RemoveDuplicates;
        public System.Collections.ArrayList labelShape;
        public String xml_LblFile;
        public bool updateHeaderOnly;
        public string AppendLine1;
        public string AppendLine2;
        public string PrependLine1;
        public string PrependLine2;
        public string RotationField;
    }

    public struct Point
    {
        public Point(double xVal, double yVal) { x = xVal; y = yVal; rotation = 0; }
        public double x;
        public double y;
        public double rotation;
    }

    public class frmLabeler : System.Windows.Forms.Form
    {
        //memeber variable
        private mwLabeler.mwLabeler m_parent;
        private System.Collections.Hashtable m_Layers;
        private MapWinGIS.tkCursor m_PreviousCursor;
        private Cursor m_Cursor;
        private bool m_Modifed;
        private string m_MapWinVersion;
        private mwLabeler.frmProgress ProgressBar;
        public int currentHandle = -1;
        private bool PopulatingFields = false;
        private MapWindow.Interfaces.IMapWin m_MapWin;

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.TextBox txtFont;
        private System.Windows.Forms.ComboBox cbAlign;
        private System.Windows.Forms.ComboBox cbField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbEnableMinExtents;
        private System.Windows.Forms.Button btnSaveMinExtents;
        private System.Windows.Forms.CheckBox LabelsShadowCheckBox;
        private System.Windows.Forms.CheckBox LabelsScaleCheckBox;
        private System.Windows.Forms.TextBox txtShadowColor;
        private System.Windows.Forms.Button btnShadowColor;
        private System.Windows.Forms.ColorDialog shadowColorDialog;
        private System.Windows.Forms.Button btnSetScaleSize;
        private System.Windows.Forms.CheckBox UseLabelCollisionCheckBox;
        private System.Windows.Forms.CheckBox RemoveDuplicatesCheckBox;
        private Button btnRelabel;
        private ComboBox cbField2;
        private System.Windows.Forms.Label label5;
        private GroupBox groupBox3;
        private TextBox txtSecondLineAppend;
        private System.Windows.Forms.Label label9;
        private TextBox txtSecondLinePrepend;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private TextBox txtFirstLineAppend;
        private System.Windows.Forms.Label label8;
        private TextBox txtFirstLinePrepend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private GroupBox groupBox4;
        private ComboBox cmbRotateField;
        private CheckBox chbRotate;
        private System.ComponentModel.Container components = null;

        public frmLabeler(mwLabeler.mwLabeler p, int LayerHandle, MapWindow.Interfaces.IMapWin MapWin)
        {
            //MapWinUtility.Logger.Message("frmLabeler Constructor");
            try
            {
                //
                // Required for Windows Form Designer support
                //
                InitializeComponent();

                currentHandle = LayerHandle;
                m_Layers = new Hashtable();
                m_parent = p;

                //set the pointing cursor
                m_Cursor = new Cursor(m_parent.GetType(), "pointing.cur");

                ProgressBar = new mwLabeler.frmProgress();
                ProgressBar.Owner = this;

                //set the parent form
                System.IntPtr tempPtr = (System.IntPtr)m_parent.m_ParentHandle;
                Form mapFrm = (Form)System.Windows.Forms.Control.FromHandle(tempPtr);
                mapFrm.AddOwnedForm(this);

                //get the mapwindow version
                m_MapWinVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(mapFrm.GetType().Assembly.Location).FileVersion.ToString();

                btnColor.BackColor = colorDialog.Color;
                txtColor.Text = colorDialog.Color.ToString();
                shadowColorDialog.Color = Color.White;
                btnShadowColor.BackColor = shadowColorDialog.Color;
                txtShadowColor.Text = shadowColorDialog.Color.ToString();

                m_MapWin = MapWin;
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("frmLabeler()", ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabeler));
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbAlign = new System.Windows.Forms.ComboBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UseLabelCollisionCheckBox = new System.Windows.Forms.CheckBox();
            this.btnSetScaleSize = new System.Windows.Forms.Button();
            this.btnShadowColor = new System.Windows.Forms.Button();
            this.txtShadowColor = new System.Windows.Forms.TextBox();
            this.LabelsScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.LabelsShadowCheckBox = new System.Windows.Forms.CheckBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.RemoveDuplicatesCheckBox = new System.Windows.Forms.CheckBox();
            this.cbField = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbEnableMinExtents = new System.Windows.Forms.CheckBox();
            this.btnSaveMinExtents = new System.Windows.Forms.Button();
            this.shadowColorDialog = new System.Windows.Forms.ColorDialog();
            this.btnRelabel = new System.Windows.Forms.Button();
            this.cbField2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSecondLineAppend = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSecondLinePrepend = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFirstLineAppend = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFirstLinePrepend = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbRotateField = new System.Windows.Forms.ComboBox();
            this.chbRotate = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(441, 327);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(54, 24);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(381, 356);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 24);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(441, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Close";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbAlign
            // 
            this.cbAlign.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
            this.cbAlign.Location = new System.Drawing.Point(48, 75);
            this.cbAlign.Name = "cbAlign";
            this.cbAlign.Size = new System.Drawing.Size(176, 21);
            this.cbAlign.TabIndex = 6;
            this.cbAlign.SelectedIndexChanged += new System.EventHandler(this.cbAlign_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Align:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Font:";
            // 
            // txtFont
            // 
            this.txtFont.BackColor = System.Drawing.SystemColors.Window;
            this.txtFont.Location = new System.Drawing.Point(48, 24);
            this.txtFont.Name = "txtFont";
            this.txtFont.ReadOnly = true;
            this.txtFont.Size = new System.Drawing.Size(144, 20);
            this.txtFont.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UseLabelCollisionCheckBox);
            this.groupBox1.Controls.Add(this.btnSetScaleSize);
            this.groupBox1.Controls.Add(this.btnShadowColor);
            this.groupBox1.Controls.Add(this.txtShadowColor);
            this.groupBox1.Controls.Add(this.LabelsScaleCheckBox);
            this.groupBox1.Controls.Add(this.LabelsShadowCheckBox);
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnFont);
            this.groupBox1.Controls.Add(this.txtFont);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbAlign);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RemoveDuplicatesCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 252);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label Properties";
            // 
            // UseLabelCollisionCheckBox
            // 
            this.UseLabelCollisionCheckBox.Location = new System.Drawing.Point(16, 204);
            this.UseLabelCollisionCheckBox.Name = "UseLabelCollisionCheckBox";
            this.UseLabelCollisionCheckBox.Size = new System.Drawing.Size(208, 24);
            this.UseLabelCollisionCheckBox.TabIndex = 19;
            this.UseLabelCollisionCheckBox.Text = "Use Label Collision Avoidance";
            this.UseLabelCollisionCheckBox.CheckedChanged += new System.EventHandler(this.UseLabelCollisionCheckBox_CheckedChanged);
            // 
            // btnSetScaleSize
            // 
            this.btnSetScaleSize.Location = new System.Drawing.Point(32, 176);
            this.btnSetScaleSize.Name = "btnSetScaleSize";
            this.btnSetScaleSize.Size = new System.Drawing.Size(192, 24);
            this.btnSetScaleSize.TabIndex = 18;
            this.btnSetScaleSize.Text = "Reset Font Scale";
            this.btnSetScaleSize.Click += new System.EventHandler(this.btnSetScaleSize_Click);
            // 
            // btnShadowColor
            // 
            this.btnShadowColor.Location = new System.Drawing.Point(194, 125);
            this.btnShadowColor.Name = "btnShadowColor";
            this.btnShadowColor.Size = new System.Drawing.Size(30, 20);
            this.btnShadowColor.TabIndex = 17;
            this.btnShadowColor.Text = "...";
            this.btnShadowColor.Click += new System.EventHandler(this.btnShadowColor_Click);
            // 
            // txtShadowColor
            // 
            this.txtShadowColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtShadowColor.Location = new System.Drawing.Point(48, 126);
            this.txtShadowColor.Name = "txtShadowColor";
            this.txtShadowColor.ReadOnly = true;
            this.txtShadowColor.Size = new System.Drawing.Size(144, 20);
            this.txtShadowColor.TabIndex = 16;
            // 
            // LabelsScaleCheckBox
            // 
            this.LabelsScaleCheckBox.Location = new System.Drawing.Point(16, 152);
            this.LabelsScaleCheckBox.Name = "LabelsScaleCheckBox";
            this.LabelsScaleCheckBox.Size = new System.Drawing.Size(184, 24);
            this.LabelsScaleCheckBox.TabIndex = 15;
            this.LabelsScaleCheckBox.Text = "Scale Labels";
            this.LabelsScaleCheckBox.CheckedChanged += new System.EventHandler(this.LabelScaleCheckBox_CheckedChanged);
            // 
            // LabelsShadowCheckBox
            // 
            this.LabelsShadowCheckBox.Location = new System.Drawing.Point(16, 102);
            this.LabelsShadowCheckBox.Name = "LabelsShadowCheckBox";
            this.LabelsShadowCheckBox.Size = new System.Drawing.Size(184, 24);
            this.LabelsShadowCheckBox.TabIndex = 14;
            this.LabelsShadowCheckBox.Text = "Use Label Shadow";
            this.LabelsShadowCheckBox.CheckedChanged += new System.EventHandler(this.LabelsShadowCheckBox_CheckedChanged);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(194, 49);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(30, 20);
            this.btnColor.TabIndex = 13;
            this.btnColor.Text = "...";
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtColor.Location = new System.Drawing.Point(48, 50);
            this.txtColor.Name = "txtColor";
            this.txtColor.ReadOnly = true;
            this.txtColor.Size = new System.Drawing.Size(144, 20);
            this.txtColor.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Color:";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(194, 23);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(30, 20);
            this.btnFont.TabIndex = 10;
            this.btnFont.Text = "...";
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // RemoveDuplicatesCheckBox
            // 
            this.RemoveDuplicatesCheckBox.Location = new System.Drawing.Point(16, 227);
            this.RemoveDuplicatesCheckBox.Name = "RemoveDuplicatesCheckBox";
            this.RemoveDuplicatesCheckBox.Size = new System.Drawing.Size(168, 16);
            this.RemoveDuplicatesCheckBox.TabIndex = 14;
            this.RemoveDuplicatesCheckBox.Text = "Remove Duplicate Labels";
            this.RemoveDuplicatesCheckBox.CheckedChanged += new System.EventHandler(this.RemoveDuplicatesCheckBox_CheckedChanged);
            // 
            // cbField
            // 
            this.cbField.Items.AddRange(new object[] {
            "None"});
            this.cbField.Location = new System.Drawing.Point(212, 6);
            this.cbField.Name = "cbField";
            this.cbField.Size = new System.Drawing.Size(235, 21);
            this.cbField.TabIndex = 0;
            this.cbField.SelectedIndexChanged += new System.EventHandler(this.cbField_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Label Field for First Line:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbEnableMinExtents);
            this.groupBox2.Controls.Add(this.btnSaveMinExtents);
            this.groupBox2.Location = new System.Drawing.Point(258, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 83);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Label zoom extents";
            // 
            // cbEnableMinExtents
            // 
            this.cbEnableMinExtents.Location = new System.Drawing.Point(16, 24);
            this.cbEnableMinExtents.Name = "cbEnableMinExtents";
            this.cbEnableMinExtents.Size = new System.Drawing.Size(184, 16);
            this.cbEnableMinExtents.TabIndex = 0;
            this.cbEnableMinExtents.Text = "Enable label extents";
            this.cbEnableMinExtents.CheckedChanged += new System.EventHandler(this.cbEnableMinExtents_CheckedChanged);
            // 
            // btnSaveMinExtents
            // 
            this.btnSaveMinExtents.Location = new System.Drawing.Point(36, 46);
            this.btnSaveMinExtents.Name = "btnSaveMinExtents";
            this.btnSaveMinExtents.Size = new System.Drawing.Size(177, 24);
            this.btnSaveMinExtents.TabIndex = 1;
            this.btnSaveMinExtents.Text = "Use Current Map Zoom Level";
            this.btnSaveMinExtents.Click += new System.EventHandler(this.btnSaveMinExtents_Click);
            // 
            // btnRelabel
            // 
            this.btnRelabel.Location = new System.Drawing.Point(350, 327);
            this.btnRelabel.Name = "btnRelabel";
            this.btnRelabel.Size = new System.Drawing.Size(85, 23);
            this.btnRelabel.TabIndex = 4;
            this.btnRelabel.Text = "Force Reapply";
            this.btnRelabel.Click += new System.EventHandler(this.btnRelabel_Click);
            // 
            // cbField2
            // 
            this.cbField2.Items.AddRange(new object[] {
            "None"});
            this.cbField2.Location = new System.Drawing.Point(212, 33);
            this.cbField2.Name = "cbField2";
            this.cbField2.Size = new System.Drawing.Size(235, 21);
            this.cbField2.TabIndex = 1;
            this.cbField2.SelectedIndexChanged += new System.EventHandler(this.cbField2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Label Field for Second Line (optional):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSecondLineAppend);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtSecondLinePrepend);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtFirstLineAppend);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtFirstLinePrepend);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(258, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 164);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Optionally Prepend / Append Text";
            // 
            // txtSecondLineAppend
            // 
            this.txtSecondLineAppend.BackColor = System.Drawing.SystemColors.Window;
            this.txtSecondLineAppend.Location = new System.Drawing.Point(87, 132);
            this.txtSecondLineAppend.Name = "txtSecondLineAppend";
            this.txtSecondLineAppend.Size = new System.Drawing.Size(144, 20);
            this.txtSecondLineAppend.TabIndex = 22;
            this.txtSecondLineAppend.TextChanged += new System.EventHandler(this.txtAppendPrepend_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Append Text:";
            // 
            // txtSecondLinePrepend
            // 
            this.txtSecondLinePrepend.BackColor = System.Drawing.SystemColors.Window;
            this.txtSecondLinePrepend.Location = new System.Drawing.Point(87, 109);
            this.txtSecondLinePrepend.Name = "txtSecondLinePrepend";
            this.txtSecondLinePrepend.Size = new System.Drawing.Size(144, 20);
            this.txtSecondLinePrepend.TabIndex = 20;
            this.txtSecondLinePrepend.TextChanged += new System.EventHandler(this.txtAppendPrepend_TextChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Prepend Text:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(12, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 18);
            this.label11.TabIndex = 18;
            this.label11.Text = "Second Line:";
            // 
            // txtFirstLineAppend
            // 
            this.txtFirstLineAppend.BackColor = System.Drawing.SystemColors.Window;
            this.txtFirstLineAppend.Location = new System.Drawing.Point(87, 62);
            this.txtFirstLineAppend.Name = "txtFirstLineAppend";
            this.txtFirstLineAppend.Size = new System.Drawing.Size(144, 20);
            this.txtFirstLineAppend.TabIndex = 17;
            this.txtFirstLineAppend.TextChanged += new System.EventHandler(this.txtAppendPrepend_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Append Text:";
            // 
            // txtFirstLinePrepend
            // 
            this.txtFirstLinePrepend.BackColor = System.Drawing.SystemColors.Window;
            this.txtFirstLinePrepend.Location = new System.Drawing.Point(87, 39);
            this.txtFirstLinePrepend.Name = "txtFirstLinePrepend";
            this.txtFirstLinePrepend.Size = new System.Drawing.Size(144, 20);
            this.txtFirstLinePrepend.TabIndex = 15;
            this.txtFirstLinePrepend.TextChanged += new System.EventHandler(this.txtAppendPrepend_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Prepend Text:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "First Line:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbRotateField);
            this.groupBox4.Controls.Add(this.chbRotate);
            this.groupBox4.Location = new System.Drawing.Point(12, 318);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 66);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Label Rotation";
            // 
            // cmbRotateField
            // 
            this.cmbRotateField.Items.AddRange(new object[] {
            "None"});
            this.cmbRotateField.Location = new System.Drawing.Point(26, 38);
            this.cmbRotateField.Name = "cmbRotateField";
            this.cmbRotateField.Size = new System.Drawing.Size(185, 21);
            this.cmbRotateField.TabIndex = 2;
            this.cmbRotateField.SelectedIndexChanged += new System.EventHandler(this.cmbRotateField_SelectedIndexChanged);
            // 
            // chbRotate
            // 
            this.chbRotate.Location = new System.Drawing.Point(16, 19);
            this.chbRotate.Name = "chbRotate";
            this.chbRotate.Size = new System.Drawing.Size(184, 19);
            this.chbRotate.TabIndex = 0;
            this.chbRotate.Text = "Rotate Label by Field Value?";
            this.chbRotate.CheckedChanged += new System.EventHandler(this.chbRotate_CheckedChanged);
            // 
            // frmLabeler
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(505, 390);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cbField2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRelabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLabeler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shapefile Labeler";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLabeler_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private Hashtable FindFieldCache = new Hashtable();
        private int FindField(string Name, ref MapWinGIS.Shapefile sf)
        {
            if (!FindFieldCache.Contains(sf.Filename)) FindFieldCache.Add(sf.Filename, new Hashtable());
            if (((Hashtable)FindFieldCache[sf.Filename]).Contains(Name)) return (int)((Hashtable)FindFieldCache[sf.Filename])[Name];

            for (int i = 0; i < sf.NumFields; i++)
                if (sf.get_Field(i).Name.ToLower().Trim() == Name.ToLower().Trim())
                {
                    ((Hashtable)FindFieldCache[sf.Filename]).Add(Name, i);
                    return i;
                }

            return -1;
        }

        public void SetCurrentLayer(int handle)
        {
            currentHandle = handle;
            Initialize();
        }

        private void btnFont_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    System.Windows.Forms.DialogResult result;
                    result = fontDialog.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //save changes
                    Label label = (Label)m_Layers[currentHandle];
                    label.font = fontDialog.Font;
                    label.Modified = true;

                    txtFont.Text = fontDialog.Font.Name + ", " + fontDialog.Font.Size.ToString();

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified
                    if (!PopulatingFields)
                        this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("btnFont_Click()", ex.Message);
            }
        }

        private void btnColor_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    System.Windows.Forms.DialogResult result;
                    result = colorDialog.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //save changes

                    Label label = (Label)m_Layers[currentHandle];
                    label.color = colorDialog.Color;
                    label.Modified = true;

                    txtColor.Text = colorDialog.Color.ToString();
                    btnColor.BackColor = colorDialog.Color;

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified
                    if (!PopulatingFields)
                        this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("btnColor_Click()", ex.Message);
            }
        }

        private void cbField_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    //save changes

                    Label label = (Label)m_Layers[currentHandle];

                    if (label.field == 0 && cbField.SelectedIndex != 0)
                        label.CalculatePos = true;

                    label.field = cbField.SelectedIndex;
                    label.Modified = true;
                    label.updateHeaderOnly = false;

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified
                    if (!PopulatingFields)
                        this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("cbField_SelectedIndexChanged()", ex.Message);
            }

        }

        private void cbField2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    //save changes

                    Label label = (Label)m_Layers[currentHandle];

                    if (label.field2 == 0 && cbField2.SelectedIndex != 0)
                        label.CalculatePos = true;

                    label.field2 = cbField2.SelectedIndex;
                    label.Modified = true;
                    label.updateHeaderOnly = false;

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified
                    if (!PopulatingFields)
                        this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("cbField_SelectedIndexChanged()", ex.Message);
            }

        }

        private void cbAlign_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    //save changes

                    Label label = (Label)m_Layers[currentHandle];
                    label.alignment = (MapWinGIS.tkHJustification)cbAlign.SelectedIndex;
                    label.Modified = true;

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified
                    if (!PopulatingFields)
                        this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("cbField_SelectedIndexChanged()", ex.Message);
            }

        }

        private void LoadShapeFileLayers()
        {
            MapWindow.Interfaces.eLayerType layerType;
            Label label;

            layerType = m_parent.m_MapWin.Layers[currentHandle].LayerType;

            //check to make sure it is a shapefile
            if (layerType == MapWindow.Interfaces.eLayerType.LineShapefile
                || layerType == MapWindow.Interfaces.eLayerType.PointShapefile
                || layerType == MapWindow.Interfaces.eLayerType.PolygonShapefile)
            {
                if (m_Layers.Contains(currentHandle) == false && !m_parent.m_MapWin.Layers[currentHandle].HideFromLegend)
                {
                    label = new Label();
                    label.points = new System.Collections.ArrayList();
                    label.handle = currentHandle;
                    label.alignment = MapWinGIS.tkHJustification.hjCenter;
                    label.field = 0;
                    label.field2 = 0;
                    label.font = txtFont.Font;
                    label.color = System.Drawing.Color.Black;
                    label.shadowColor = System.Drawing.Color.White;
                    label.UseShadows = false;
                    label.Scaled = false;
                    label.UseLabelCollision = false;
                    label.RemoveDuplicates = false;
                    label.labelShape = new System.Collections.ArrayList();
                    label.xml_LblFile = "";
                    label.updateHeaderOnly = false;

                    //load all the layers into the hashtable
                    m_Layers.Add(currentHandle, label);
                }
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            if (this.m_Modifed == true)
            {
                // Add the Cancel button to enable user to go back to Labeler window.
                // Enhancement Added: 04/15/2008 Earljon Hidalgo
                //result = MapWinUtility.Logger.Message("Do you wish to save your changes?","Labeler",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question, DialogResult.Yes);
                result = MapWinUtility.Logger.Message("Do you wish to save your changes?", "Labeler", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question, DialogResult.Yes);

                // Return to Labeler window if Cancel is clicked.
                if (result == System.Windows.Forms.DialogResult.Cancel) return;
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!ValidateRotationField()) return;

                    //Apply the lableing
                    ApplyChanges();
                    SaveAllLabelingInfo();
                }

            }
            this.Hide();
            this.m_parent.m_MapWindowForm.Focus();
        }

        private void frmLabeler_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MapWinUtility.Logger.Message("frmLabeler_Closing");
            e.Cancel = true;
            this.Hide();
            this.m_parent.m_MapWindowForm.Focus();
        }

        private void btnApply_Click(object sender, System.EventArgs e)
        {
            if (!ValidateRotationField()) return;
            //Apply the labeling
            if (this.m_Modifed == true)
            {
                ApplyChanges();
                SaveAllLabelingInfo();
            }

            this.ProgressBar.Hide();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!ValidateRotationField()) return;

            //Apply the labeling
            if (this.m_Modifed == true)
            {
                ApplyChanges();
                SaveAllLabelingInfo();
            }

            this.ProgressBar.Hide();
            this.Hide();
            this.m_parent.m_MapWindowForm.Focus();
        }

        private void ApplyChanges()
        {
            try
            {
                m_parent.m_MapWin.View.LockMap();
                int numShapes = 0;
                int prg = 0;
                int lprg = 0;
                double x = 0, y = 0, rotation = 0;
                string shapeValue = "";
                Shapefile shpFile = null;
                Hashtable labelPoints = new Hashtable();

                //change the cursor to a wait cursor
                m_PreviousCursor = m_parent.m_MapWin.View.MapCursor;
                m_parent.m_MapWin.View.MapCursor = MapWinGIS.tkCursor.crsrWait;

                //set the progress bar
                ProgressBar.SetProgress("", 0);

                Label label = (Label)m_Layers[currentHandle];
                shpFile = (Shapefile)m_parent.m_MapWin.Layers[label.handle].GetObject();

                shpFile.BeginPointInShapefile();

                //if the label field is not None then do the following
                if (label.field != 0 && label.Modified == true && label.updateHeaderOnly == false)
                {
                    ProgressBar.Show();
                    //set the progress bar
                    ProgressBar.SetProgress("Calculating label positions", 0);

                    //set the font
                    m_parent.m_MapWin.Layers[currentHandle].Font(label.font.Name, (int)label.font.Size);

                    //find out the number of shapes in the shapefile
                    numShapes = shpFile.NumShapes;

                    label.points = new System.Collections.ArrayList();
                    label.labelShape = new System.Collections.ArrayList();
                    label.CalculatePos = true;

                    //add labels to every shape
                    for (int j = 0; j < numShapes; j++)
                    {
                        if (label.CalculatePos == true)
                        {
                            FindXYValues(shpFile, j, ref x, ref y);

                            if (label.field2 != 0 || label.PrependLine2 != "" || label.AppendLine2 != "")
                            {
                                double disregardX = 0, adjustY0 = 0, adjustY1 = 0;
                                m_MapWin.View.PixelToProj(0, CreateGraphics().MeasureString("ZZZ", label.font).Height / 2, ref disregardX, ref adjustY0);
                                m_MapWin.View.PixelToProj(0, 0, ref disregardX, ref adjustY1);
                                y += Math.Abs(adjustY1 - adjustY0);
                            }

                            //set the x and y values
                            Point p = new Point();
                            p.x = x; p.y = y;
                            if (chbRotate.Checked)
                            {
                                object fldVal = shpFile.get_CellValue(FindField(cmbRotateField.Text, ref shpFile), j);
                                if (fldVal == null)
                                {
                                    rotation = 0;
                                }
                                else
                                {
                                    double.TryParse(fldVal.ToString(), out rotation);
                                }
                                p.rotation = rotation;
                            }
                            else
                            {
                                p.rotation = 0;
                                rotation = 0;
                            }
                            label.points.Add(p);
                        }
                        else
                        {
                            x = ((Point)label.points[j]).x;
                            y = ((Point)label.points[j]).y;
                            if (chbRotate.Checked)
                            {
                                object fldVal = shpFile.get_CellValue(FindField(cmbRotateField.Text, ref shpFile), j);
                                if (fldVal == null)
                                {
                                    rotation = 0;
                                }
                                else
                                {
                                    double.TryParse(fldVal.ToString(), out rotation);
                                }
                            }
                            else
                            {
                                rotation = 0;
                            }
                        }

                        shapeValue = txtFirstLinePrepend.Text + shpFile.get_CellValue(label.field - 1, j).ToString() + txtFirstLineAppend.Text;

                        if (label.field2 != 0)
                        {
                            shapeValue += Environment.NewLine;
                            shapeValue += txtSecondLinePrepend.Text + shpFile.get_CellValue(label.field2 - 1, j).ToString() + txtSecondLineAppend.Text;
                        }

                        label.labelShape.Add(1);
                        m_parent.m_MapWin.Layers[currentHandle].AddLabelEx(shapeValue, label.color, x, y, label.alignment, rotation);

                        label.AppendLine1 = txtFirstLineAppend.Text;
                        label.AppendLine2 = txtSecondLineAppend.Text;
                        label.PrependLine1 = txtFirstLinePrepend.Text;
                        label.PrependLine2 = txtSecondLinePrepend.Text;

                        //set the progress bar
                        prg = (int)(j / (double)numShapes * 100);
                        if (prg > lprg)
                        {
                            lprg = prg;
                            ProgressBar.SetProgress("Calculating label positions.", prg);
                        }
                    }
                    //} Needed when duplicate removal code is uncommented

                    m_parent.m_MapWin.Layers[currentHandle].LabelsScale = label.Scaled;
                    m_parent.m_MapWin.Layers[currentHandle].LabelsShadow = label.UseShadows;
                    m_parent.m_MapWin.Layers[currentHandle].LabelsShadowColor = label.shadowColor;
                    m_parent.m_MapWin.Layers[currentHandle].UseLabelCollision = label.UseLabelCollision;
                    m_parent.m_MapWin.Layers[currentHandle].StandardViewWidth = label.StandardViewWidth;
                    // Force labels visible after applying (during editing):
                    m_parent.m_MapWin.Layers[currentHandle].LabelsVisible = true;

                    //save the label info for this layer
                    m_Layers[currentHandle] = label;
                }
                else
                {
                    if (label.field == 0)
                        m_parent.m_MapWin.Layers[currentHandle].ClearLabels();
                }

                shpFile.EndPointInShapefile();


                //ProgressBar.Hide();
            }
            catch (System.Exception ex)
            {
                //ProgressBar.Hide();
                ShowErrorBox("ApplyChanges()", ex.Message);
            }
            finally
            {
                m_parent.m_MapWin.View.UnlockMap();
            }

            //change the cursor back to it's default
            m_parent.m_MapWin.View.MapCursor = m_PreviousCursor;

            ProgressBar.Hide();
        }

        public void OpenLabelingInfo()
        {
            if (currentHandle == -1) return;

            Label label = new Label();
            mwLabeler.Classes.XMLLabelFile xmlLabel = new mwLabeler.Classes.XMLLabelFile(this.m_parent.m_MapWin, this.m_MapWinVersion);

            //clear all previous labels
            m_Layers.Clear();

            //load all labeling info

            if (xmlLabel.LoadLabelInfo(m_parent.m_MapWin, m_parent.m_MapWin.Layers[currentHandle], ref label, this))
                m_Layers.Add(currentHandle, label);
        }

        private void SaveAllLabelingInfo()
        {
            try
            {
                Shapefile shpFile = null;

                Label label = (Label)m_Layers[currentHandle];
                shpFile = (Shapefile)m_parent.m_MapWin.Layers[currentHandle].GetObject();

                if (label.Modified || label.LabelExtentsChanged)
                {
                    //save the changes to the .lbl file
                    SaveLBLFile(ref label, shpFile.Filename);
                    //SaveLBLFile((Forms.Label)m_Layers[currentHandle],shpFile.Filename);

                    //force mapwindow to update it labeling info for this layer
                    m_parent.m_MapWin.Layers[label.handle].UpdateLabelInfo();

                    label.Modified = false;
                    label.updateHeaderOnly = true;
                    label.CalculatePos = false;
                    label.LabelExtentsChanged = false;
                    m_Layers[currentHandle] = label;
                }

                //set modified 
                this.SetModified(false);
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("SaveAllLabelingInfo()", ex.Message);
            }
        }

        private void SaveLBLFile(ref Label labels, string shpFileName)
        {
            string fileName1 = System.IO.Path.ChangeExtension(shpFileName, ".lbl");
            string fileName2 = "";
            string projectDirName = "";

            if (m_parent.m_MapWin.View.LabelsUseProjectLevel)
            {
                if (m_parent.m_MapWin.Project.FileName != null && m_parent.m_MapWin.Project.FileName.Trim() != "")
                {
                    projectDirName = System.IO.Path.GetFileNameWithoutExtension(m_parent.m_MapWin.Project.FileName);
                    fileName2 = projectDirName + @"\" + System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(shpFileName), ".lbl");
                }
            }

            //if the field = 0 (none) then delete the file if it exists
            if (labels.field == 0)
            {
                if (System.IO.File.Exists(fileName1))
                    System.IO.File.Delete(fileName1);
                if (fileName2 != "" && System.IO.File.Exists(fileName2))
                    System.IO.File.Delete(fileName2);
            }
            else
            {
                mwLabeler.Classes.XMLLabelFile xmlLabel = new mwLabeler.Classes.XMLLabelFile(this.m_parent.m_MapWin, this.m_MapWinVersion);
                if (labels.updateHeaderOnly && labels.xml_LblFile != "")
                {
                    xmlLabel.ReplaceHeader(ref labels, fileName1);
                }
                else
                {
                    xmlLabel.SaveLabelInfo(ref labels, fileName1);
                }

                try
                {
                    if (fileName2 != "")
                    {
                        if (System.IO.File.Exists(fileName2))
                            System.IO.File.Delete(fileName2);

                        if (!System.IO.Directory.Exists(projectDirName))
                            System.IO.Directory.CreateDirectory(projectDirName);

                        System.IO.File.Copy(fileName1, fileName2);
                    }
                }
                catch
                {
                }
            }
        }

        private void FindXYValues(MapWinGIS.Shapefile shpFile, int shapeIndex, ref double x, ref double y)
        {
            try
            {
                double dist = 0;
                double area = 0;
                double cX = 0, cY = 0;

                MapWinGIS.Point p1, p2;

                MapWinGIS.Shape shape = shpFile.get_Shape(shapeIndex);

                if (shape.ShapeType == MapWinGIS.ShpfileType.SHP_POLYGON | shape.ShapeType == MapWinGIS.ShpfileType.SHP_POLYGONM | shape.ShapeType == MapWinGIS.ShpfileType.SHP_POLYGONZ) //modified: Z and M types added by Cornelius Mende
                {

                    //calculate the area of the shape
                    int count = shape.numPoints;

                    //if 
                    if (count <= 4)
                    {
                        //find the x value
                        dist = Math.Sqrt(Math.Pow(shape.Extents.xMin - shape.Extents.xMax, 2) + Math.Pow((shape.Extents.yMin - shape.Extents.yMin), 2)) / 2;
                        cX = shape.Extents.xMax - dist;

                        //find the y value
                        dist = Math.Sqrt(Math.Pow(shape.Extents.xMin - shape.Extents.xMin, 2) + Math.Pow((shape.Extents.yMin - shape.Extents.yMax), 2)) / 2;
                        cY = shape.Extents.yMax - dist;

                        x = cX;
                        y = cY;
                        return;
                    }
                    else
                    {
                        //calculate the area of the poly
                        for (int i = 0; i < count; i++)
                        {
                            p1 = shape.get_Point(i);

                            if (i == count - 1)
                                p2 = shape.get_Point(0);
                            else
                                p2 = shape.get_Point(i + 1);

                            area += (p1.x * p2.y - p2.x * p1.y);
                        }
                        area *= .5;

                        //calculate the centroid
                        for (int i = 0; i < count; i++)
                        {
                            p1 = shape.get_Point(i);

                            if (i == count - 1)
                                p2 = shape.get_Point(0);
                            else
                                p2 = shape.get_Point(i + 1);

                            cX += (p1.x + p2.x) * (p1.x * p2.y - p2.x * p1.y);
                            cY += (p1.y + p2.y) * (p1.x * p2.y - p2.x * p1.y);
                        }
                        cX *= 1 / (6 * area);
                        cY *= 1 / (6 * area);

                        shpFile.BeginPointInShapefile();

                        //test to make sure the centroid is the poly
                        if (shpFile.PointInShape(shapeIndex, cX, cY) == false)
                        {
                            FindXY(shpFile, shapeIndex, ref cX, ref cY);
                        }

                        x = cX;
                        y = cY;

                        if (x == -1 || y == -1 || x == 0 || y == 0)
                        {
                            MapWinGIS.Shape s = shpFile.get_Shape(shapeIndex);
                            // Detection failed... simple center?
                            x = ((s.Extents.xMax - s.Extents.xMin) / 2) + s.Extents.xMin;
                            y = ((s.Extents.yMax - s.Extents.yMin) / 2) + s.Extents.yMin;
                        }

                        return;
                    }
                }
                else if (shape.ShapeType == MapWinGIS.ShpfileType.SHP_POINT | shape.ShapeType == MapWinGIS.ShpfileType.SHP_POINTM | shape.ShapeType == MapWinGIS.ShpfileType.SHP_POINTZ) //modified: Z and M types added by Cornelius Mende
                {
                    x = shape.Extents.xMax;
                    y = shape.Extents.yMax;
                    return;
                }
                else if (shape.ShapeType == MapWinGIS.ShpfileType.SHP_MULTIPOINT | shape.ShapeType == MapWinGIS.ShpfileType.SHP_MULTIPOINTM | shape.ShapeType == MapWinGIS.ShpfileType.SHP_MULTIPOINTZ) //modified: Z and M types added by Cornelius Mende
                {
                    x = (shape.Extents.xMin + shape.Extents.xMax) / 2;
                    y = (shape.Extents.yMin + shape.Extents.yMax) / 2;
                    return;
                }
                else if (shape.ShapeType == MapWinGIS.ShpfileType.SHP_POLYLINE || shape.ShapeType == MapWinGIS.ShpfileType.SHP_POLYLINEM || shape.ShapeType == MapWinGIS.ShpfileType.SHP_POLYLINEZ)
                {
                    int count = shape.numPoints, index1 = 0, index2 = 0;
                    double max_length = -1.0;
                    for (int i = 1; i < count; i++)
                    {
                        double length = GetLineLength(shape.get_Point(i - 1), shape.get_Point(i));
                        if (length > max_length)
                        {
                            index1 = i - 1;
                            index2 = i;
                            max_length = length;
                        }
                    }

                    double opposite = shape.get_Point(index2).y - shape.get_Point(index1).y;
                    double adjacent = shape.get_Point(index2).x - shape.get_Point(index1).x;
                    //					double opposite = shape.get_Point(count/2).y-shape.get_Point(0).y;
                    //					double adjacent = shape.get_Point(count/2).x-shape.get_Point(0).x;

                    //rotation = Math.Atan(opposite/adjacent) * (180 / Math.PI);
                    double temp_x1 = shape.get_Point(index1).x, temp_x2 = shape.get_Point(index2).x, temp_y1 = shape.get_Point(index1).y, temp_y2 = shape.get_Point(index2).y;
                    x = temp_x1 + ((temp_x2 - temp_x1) / 2);
                    y = temp_y1 + ((temp_y2 - temp_y1) / 2);
                    //					x = shape.get_Point(count/2).x;
                    //					y = shape.get_Point(count/2).y;
                    return;
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("FindXYValues()", ex.Message);
            }
        }

        private double GetLineLength(MapWinGIS.Point p1, MapWinGIS.Point p2)
        {
            double x_length = Math.Abs(p1.x - p2.x);
            double y_length = Math.Abs(p1.y - p2.y);
            return Math.Sqrt(x_length * x_length + y_length * y_length);
        }

        private void FindXY(MapWinGIS.Shapefile shpFile, int shapeIndex, ref double cX, ref double cY)
        {
            MapWinGIS.Shape shape = shpFile.get_Shape(shapeIndex);

            double xFirst = -1, xLast = -1;
            double tolx1 = 0, toly1 = 0, tolx2 = 0, toly2 = 0, stepSize = 0;

            //caluculate step size
            m_parent.m_MapWin.View.PixelToProj(0, 0, ref tolx1, ref toly1);
            m_parent.m_MapWin.View.PixelToProj(1, 0, ref tolx2, ref toly2);
            stepSize = System.Math.Pow((tolx1 - tolx2), 2) + System.Math.Pow((toly1 - toly2), 2);

            double xMin = shape.Extents.xMin;
            double xMax = shape.Extents.xMax;

            for (double i = xMin; i <= xMax; i += stepSize)
            {
                if (shpFile.PointInShape(shapeIndex, i, cY))
                {
                    //if the x value is in the boundary and it's the first time found then save
                    if (xFirst == -1)
                    {
                        xFirst = i;
                    }
                    //if the end x value is in the shape then set that to the last point
                    else if (i + stepSize >= xMax)
                    {
                        xLast = i;
                    }
                }
                else
                {
                    //if the first x value was already found then save the last x value
                    if (xFirst != -1)
                    {
                        xLast = i;

                        //exit from the for loop
                        break;
                    }
                }

            }

            //return the x value that lies between the two poly boundary
            cX = xFirst + (xLast - xFirst) / 2;

        }

        private void Initialize()
        {
            try
            {
                OpenLabelingInfo();
                LoadShapeFileLayers();

                //clear all fields
                cbField.Text = "";
                cbField2.Text = "";
                txtFont.Text = "";
                txtColor.Text = "";
                cbAlign.Text = "";
                txtShadowColor.Text = "";
                cbEnableMinExtents.Checked = false;
                btnSaveMinExtents.Enabled = false;
                btnApply.Enabled = false;
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("Initialize() 1", ex.Message);
                MessageBox.Show(ex.ToString());
            }
            try
            {
                Label label;


                label = (Label)m_Layers[currentHandle];

                //populate the fields
                if (LoadShapeFileFields(label.handle) == false)
                {
                    return;
                }

                txtFont.Text = label.font.Name + ", " + label.font.Size.ToString();
                txtColor.Text = label.color.ToString();
                txtShadowColor.Text = label.shadowColor.ToString();

                if (label.field < cbField.Items.Count)
                    cbField.SelectedIndex = label.field;
                if (label.field2 < cbField2.Items.Count)
                    cbField2.SelectedIndex = label.field2;
                for (int i = 0; i < cmbRotateField.Items.Count; i++)
                    if (label.RotationField == cmbRotateField.Items[i].ToString())
                    {
                        cmbRotateField.SelectedIndex = i;
                        break;
                    }
                chbRotate.Checked = (label.RotationField != "");

                if (label.alignment == MapWinGIS.tkHJustification.hjCenter)
                    cbAlign.Text = "Center";
                else if (label.alignment == MapWinGIS.tkHJustification.hjLeft)
                    cbAlign.Text = "Left";
                else if (label.alignment == MapWinGIS.tkHJustification.hjRight)
                    cbAlign.Text = "Right";

                LabelsShadowCheckBox.Checked = label.UseShadows;
                LabelsScaleCheckBox.Checked = label.Scaled;
                UseLabelCollisionCheckBox.Checked = label.UseLabelCollision;
                RemoveDuplicatesCheckBox.Checked = label.RemoveDuplicates;

                btnColor.BackColor = label.color;
                btnShadowColor.BackColor = label.shadowColor;

                colorDialog.Color = label.color;
                shadowColorDialog.Color = label.shadowColor;

                cbEnableMinExtents.Checked = label.UseMinExtents;
                btnSaveMinExtents.Enabled = cbEnableMinExtents.Checked;

                txtFirstLineAppend.Text = label.AppendLine1;
                txtSecondLineAppend.Text = label.AppendLine2;
                txtFirstLinePrepend.Text = label.PrependLine1;
                txtSecondLinePrepend.Text = label.PrependLine2;
                // Make sure there's no changes made upon loading.
                // This makes the Apply button disabled and bypass
                // the question on the Close() method.
                // Added 04/15/2008 Earljon Hidalgo
                SetModified(false);
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("Initialize() 2", ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private bool LoadShapeFileFields(int handle)
        {
            try
            {
                //clear all the fields
                cbField.Items.Clear();
                cbField.Items.Add("None");
                cbField2.Items.Clear();
                cbField2.Items.Add("None");
                cmbRotateField.Items.Clear();
                cmbRotateField.Items.Add("None");

                //check to see if that layer exiss
                if (m_parent.m_MapWin.Layers.IsValidHandle(handle) == false)
                    return false;

                Shapefile shpfile = (Shapefile)m_parent.m_MapWin.Layers[handle].GetObject();

                if (shpfile == null)
                    return false;

                int numFields = shpfile.NumFields;
                for (int i = 0; i < numFields; i++)
                {
                    cbField.Items.Add(shpfile.get_Field(i).Name);
                    cbField2.Items.Add(shpfile.get_Field(i).Name);
                    cmbRotateField.Items.Add(shpfile.get_Field(i).Name);
                }

                return true;

            }
            catch (System.Exception ex)
            {
                ShowErrorBox("LoadShapeFileFields()", ex.Message);
            }
            return false;
        }

        private void ShowErrorBox(string functionName, string errorMsg)
        {
            MapWinUtility.Logger.Message("Error in " + functionName + ", Message: " + errorMsg, "Label Editor", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, DialogResult.OK);
        }

        private int RGB(int r, int g, int b)
        {
            if (b > 255 || b < 0)
                return -1;
            if (r > 255 || r < 0)
                return -1;
            if (g > 255 || g < 0)
                return -1;

            int retval = b;

            retval = retval << 8;

            retval += g;

            retval = retval << 8;

            retval += r;

            return retval;
        }

        private void cbEnableMinExtents_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    //Enable the use of of min extents on the lables

                    Label label = (Label)m_Layers[currentHandle];

                    //if null then set extents to the current view extents
                    if (label.extents == null)
                    {
                        label.extents = this.m_parent.m_MapWin.View.Extents;
                    }

                    if (cbEnableMinExtents.Checked)
                    {
                        btnSaveMinExtents.Enabled = true;
                        label.UseMinExtents = true;
                    }
                    else
                    {
                        btnSaveMinExtents.Enabled = false;
                        label.UseMinExtents = false;
                    }

                    label.LabelExtentsChanged = true;

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified
                    if (!PopulatingFields)
                        this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("btnSaveMinExtents_Click()", ex.Message);
            }
        }

        private void btnSaveMinExtents_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    //save the current view extents

                    Label label = (Label)m_Layers[currentHandle];
                    label.extents = this.m_parent.m_MapWin.View.Extents;

                    //allow them to see the labels
                    //this.m_parent.m_MapWin.Layers[label.handle].LabelsVisible = true;
                    label.LabelExtentsChanged = true;
                    label.Modified = true;

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified 
                    this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("btnSaveMinExtents_Click()", ex.Message);
            }
        }

        private int RGB(System.Drawing.Color c)
        {
            return RGB(c.R, c.G, c.B);
        }

        public void CheckZoomLevelProp()
        {
            Label lb;
            System.Collections.DictionaryEntry dict;
            System.Collections.IEnumerator enumerator = m_Layers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                dict = (System.Collections.DictionaryEntry)enumerator.Current;
                lb = (Label)dict.Value;

                if (lb.UseMinExtents == false) return;

                Point p1 = new Point(lb.extents.xMin, lb.extents.yMin);
                Point p2 = new Point(lb.extents.xMax, lb.extents.yMax);

                double dist1 = Math.Sqrt(Math.Pow((p1.y - p2.y), 2) + Math.Pow((p1.x - p2.x), 2));

                Point p3 = new Point(this.m_parent.m_MapWin.View.Extents.xMin, this.m_parent.m_MapWin.View.Extents.yMin);
                Point p4 = new Point(this.m_parent.m_MapWin.View.Extents.xMax, this.m_parent.m_MapWin.View.Extents.yMax);

                double dist2 = Math.Sqrt(Math.Pow((p3.y - p4.y), 2.0) + Math.Pow((p3.x - p4.x), 2.0));

                if (dist1 >= dist2)
                {
                    this.m_parent.m_MapWin.Layers[(int)dict.Key].LabelsVisible = true;
                }
                else
                {
                    this.m_parent.m_MapWin.Layers[(int)dict.Key].LabelsVisible = false;
                }
            }
        }

        private void SetModified(bool modified)
        {
            this.m_Modifed = modified;
            this.btnApply.Enabled = modified;
        }

        private void LabelsShadowCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateLabelsShadow();
            //set modified
            if (!PopulatingFields)
                this.SetModified(true);
        }

        private void UpdateLabelsShadow()
        {
            if (currentHandle != -1)
            {

                Label label = (Label)m_Layers[currentHandle];

                if (LabelsShadowCheckBox.Checked == true)
                {
                    label.UseShadows = true;
                    //this.m_parent.m_MapWin.Layers[handle].LabelsShadow = true;
                }
                else
                {
                    label.UseShadows = false;
                    //this.m_parent.m_MapWin.Layers[handle].LabelsShadow = false;
                }
                label.Modified = true;
                m_Layers[currentHandle] = label;
            }
        }

        private void LabelScaleCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateLabelsScale();
            //set modified
            if (!PopulatingFields)
                this.SetModified(true);
        }

        private void UpdateLabelsScale()
        {
            if (currentHandle != -1)
            {

                Label label = (Label)m_Layers[currentHandle];

                if (LabelsScaleCheckBox.Checked == true)
                {
                    //Set view width right away
                    //this.m_parent.m_MapWin.Layers[handle].StandardViewWidth = 8*(this.m_parent.m_MapWin.View.Extents.xMax - this.m_parent.m_MapWin.View.Extents.xMin);
                    label.StandardViewWidth = 8 * (this.m_parent.m_MapWin.View.Extents.xMax - this.m_parent.m_MapWin.View.Extents.xMin);
                    label.Scaled = true;
                    //this.m_parent.m_MapWin.Layers[handle].LabelsScale = true;
                }
                else
                {
                    label.Scaled = false;
                    //this.m_parent.m_MapWin.Layers[handle].LabelsScale = false;
                }
                label.Modified = true;
                m_Layers[currentHandle] = label;
            }
        }

        private void btnShadowColor_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    System.Windows.Forms.DialogResult result;
                    result = shadowColorDialog.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //save changes

                    Label label = (Label)m_Layers[currentHandle];

                    txtShadowColor.Text = shadowColorDialog.Color.ToString();
                    btnShadowColor.BackColor = shadowColorDialog.Color;

                    label.shadowColor = shadowColorDialog.Color;
                    label.Modified = true;

                    //reset the label
                    m_Layers[currentHandle] = label;

                    //set modified
                    if (!PopulatingFields)
                        this.SetModified(true);
                }
            }
            catch (System.Exception ex)
            {
                ShowErrorBox("btnColor_Click()", ex.Message);
            }
        }

        private void btnSetScaleSize_Click(object sender, System.EventArgs e)
        {
            if (currentHandle != -1)
            {

                Label label = (Label)m_Layers[currentHandle];
                //When the current view width is multiplied by 8, you get the correct standardViewWidth to display the scaled labels at the correct font size for the current view.
                //this.m_parent.m_MapWin.Layers[handle].StandardViewWidth = 8*(this.m_parent.m_MapWin.View.Extents.xMax - this.m_parent.m_MapWin.View.Extents.xMin);
                label.StandardViewWidth = 8 * (this.m_parent.m_MapWin.View.Extents.xMax - this.m_parent.m_MapWin.View.Extents.xMin);
                label.Modified = true;
                m_Layers[currentHandle] = label;

                //set modified
                if (!PopulatingFields)
                    this.SetModified(true);
            }
        }

        private void UseLabelCollisionCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateLabelsCollision();
            //set modified
            if (!PopulatingFields)
                this.SetModified(true);
        }

        private void UpdateLabelsCollision()
        {
            if (currentHandle == -1) return;
            Label label = (Label)m_Layers[currentHandle];
            if (UseLabelCollisionCheckBox.Checked == true)
            {
                label.UseLabelCollision = true;
                this.m_parent.m_MapWin.Layers[currentHandle].UseLabelCollision = true;
            }
            else
            {
                label.UseLabelCollision = false;
                this.m_parent.m_MapWin.Layers[currentHandle].UseLabelCollision = false;
            }
            label.Modified = true;
            m_Layers[currentHandle] = label;
        }

        private void RemoveDuplicatesCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateRemoveDuplicates();
            //set modified
            if (!PopulatingFields)
                this.SetModified(true);
        }

        private void UpdateRemoveDuplicates()
        {
            if (currentHandle == -1) return;

            Label label = (Label)m_Layers[currentHandle];
            if (RemoveDuplicatesCheckBox.Checked == true)
            {
                label.RemoveDuplicates = true;
            }
            else
            {
                label.RemoveDuplicates = false;

            }
            label.Modified = true;
            label.updateHeaderOnly = false;
            m_Layers[currentHandle] = label;
        }

        public void btnRelabel_Click(object sender, EventArgs e)
        {
            if (!ValidateRotationField()) return;

            if (currentHandle == -1) return;
            Label label = (Label)m_Layers[currentHandle];

            if (label.field == 0 && cbField.SelectedIndex != 0)
                label.CalculatePos = true;

            if (label.field2 == 0 && cbField2.SelectedIndex != 0)
                label.CalculatePos = true;

            label.field = cbField.SelectedIndex;
            label.field2 = cbField2.SelectedIndex;
            label.Modified = true;
            label.updateHeaderOnly = false;

            //reset the label
            m_Layers[currentHandle] = label;

            //set modified
            if (!PopulatingFields)
                this.SetModified(true);

            ApplyChanges();
            SaveAllLabelingInfo();
        }

        private void txtAppendPrepend_TextChanged(object sender, EventArgs e)
        {
            m_Modifed = true;
        }

        private void cmbRotateField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!PopulatingFields && ValidateRotationField())
            {
                if (currentHandle != -1)
                {
                    Label label = (Label)m_Layers[currentHandle];
                    label.RotationField = cmbRotateField.Text;
                    m_Layers[currentHandle] = label;
                }
                this.SetModified(true);
            }
        }

        private bool ValidateRotationField()
        {
            if (cmbRotateField.Text == "None" || cmbRotateField.Text == "" || !chbRotate.Checked)
            {
                chbRotate.Checked = false;
                if (currentHandle != -1 && this.PopulatingFields == false)
                {
                    Label label = (Label)m_Layers[currentHandle];
                    label.RotationField = "";
                }
                return true; // OK
            }

            Shapefile shpfile = (Shapefile)m_parent.m_MapWin.Layers[m_MapWin.Layers.CurrentLayer].GetObject();

            if (shpfile == null)
                return false;

            double unused = 0;
            for (int i = 0; i < shpfile.NumFields; i++)
            {
                if (shpfile.get_Field(i).Name.ToLower().Trim() == cmbRotateField.Text.ToLower().Trim())
                {
                    for (int j = 0; j < shpfile.NumShapes; j++)
                    {
                        if (!double.TryParse(shpfile.get_CellValue(i, j).ToString(), out unused))
                        {
                            MessageBox.Show("One or more of the values in the selected rotation field are not numeric. Please select a different field, or uncheck the option to rotate labels by field." + Environment.NewLine + Environment.NewLine + "This option is used to rotate the label by the number of degrees specified in a field.", "Non-numeric Value Found");
                            return false;
                        }
                    }
                    break;
                }
            }

            if (currentHandle != -1 && this.PopulatingFields == false)
            {
                Label label = (Label)m_Layers[currentHandle];
                label.RotationField = cmbRotateField.Text;
            }

            return true;
        }

        private void chbRotate_CheckedChanged(object sender, EventArgs e)
        {
            if (!PopulatingFields && currentHandle != -1)
            {
                Label label = (Label)m_Layers[currentHandle];
                label.RotationField = cmbRotateField.Text;
                m_Layers[currentHandle] = label;
                this.SetModified(true);
            }
        }

        public class LabelPoints
        {
            public LabelPoints() { labels = new ArrayList(); endPoints = new ArrayList(); }
            public LabelPoints(Point l, Point end, Point end2) { labels = new ArrayList(); endPoints = new ArrayList(); labels.Add(l); endPoints.Add(end); endPoints.Add(end2); }
            public ArrayList labels;
            public ArrayList endPoints;
        }

        public class Cluster
        {
            public Cluster() { shapeIndex = new ArrayList(); endPoints = new ArrayList(); }
            public ArrayList shapeIndex;
            public ArrayList endPoints;
        }
    }
}
