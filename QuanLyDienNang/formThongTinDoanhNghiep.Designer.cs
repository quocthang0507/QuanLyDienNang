namespace QuanLyDienNang
{
    partial class FormThongTinDoanhNghiep
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
            this.components = new System.ComponentModel.Container();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_luu_tt = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tb_chucvu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.thongtinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanlydien_sqlDataSet = new QuanLyDienNang.quanlydien_sqlDataSet();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tb_nguoidaidien = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tb_dkkd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tb_masothue = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tb_diachi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tb_Tendn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_xoa = new DevComponents.DotNetBar.ButtonX();
            this.btn_luu_tk = new DevComponents.DotNetBar.ButtonX();
            this.btn_them = new DevComponents.DotNetBar.ButtonX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cb_nganhang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tb_tk = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.tb_sodt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lienheBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thongtinTableAdapter = new QuanLyDienNang.quanlydien_sqlDataSetTableAdapters.thongtinTableAdapter();
            this.lienheTableAdapter = new QuanLyDienNang.quanlydien_sqlDataSetTableAdapters.lienheTableAdapter();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thongtinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlydien_sqlDataSet)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lienheBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btn_luu_tt);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.tb_chucvu);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.tb_nguoidaidien);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.tb_dkkd);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.tb_masothue);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.tb_diachi);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.tb_Tendn);
            this.groupPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(65, 27);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(471, 531);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 12;
            this.groupPanel1.Text = "Thông Tin Doanh Nghiệp";
            // 
            // btn_luu_tt
            // 
            this.btn_luu_tt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_luu_tt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_luu_tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luu_tt.Location = new System.Drawing.Point(45, 460);
            this.btn_luu_tt.Name = "btn_luu_tt";
            this.btn_luu_tt.Size = new System.Drawing.Size(128, 35);
            this.btn_luu_tt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_luu_tt.TabIndex = 24;
            this.btn_luu_tt.Text = "Lưu Lại";
            this.btn_luu_tt.Click += new System.EventHandler(this.btn_luu_tt_Click);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX6.Location = new System.Drawing.Point(45, 380);
            this.labelX6.Name = "labelX6";
            this.labelX6.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX6.Size = new System.Drawing.Size(398, 36);
            this.labelX6.TabIndex = 23;
            this.labelX6.Text = "Chức Vụ ";
            // 
            // tb_chucvu
            // 
            // 
            // 
            // 
            this.tb_chucvu.Border.Class = "TextBoxBorder";
            this.tb_chucvu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_chucvu.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.thongtinBindingSource, "chucvu", true));
            this.tb_chucvu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thongtinBindingSource, "chucvu", true));
            this.tb_chucvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_chucvu.Location = new System.Drawing.Point(45, 420);
            this.tb_chucvu.Name = "tb_chucvu";
            this.tb_chucvu.Size = new System.Drawing.Size(398, 31);
            this.tb_chucvu.TabIndex = 22;
            // 
            // thongtinBindingSource
            // 
            this.thongtinBindingSource.DataMember = "thongtin";
            this.thongtinBindingSource.DataSource = this.quanlydien_sqlDataSet;
            // 
            // quanlydien_sqlDataSet
            // 
            this.quanlydien_sqlDataSet.DataSetName = "quanlydien_sqlDataSet";
            this.quanlydien_sqlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX5.Location = new System.Drawing.Point(45, 307);
            this.labelX5.Name = "labelX5";
            this.labelX5.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX5.Size = new System.Drawing.Size(398, 36);
            this.labelX5.TabIndex = 21;
            this.labelX5.Text = "Người Đại Diện";
            // 
            // tb_nguoidaidien
            // 
            // 
            // 
            // 
            this.tb_nguoidaidien.Border.Class = "TextBoxBorder";
            this.tb_nguoidaidien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_nguoidaidien.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.thongtinBindingSource, "nguoi_dd", true));
            this.tb_nguoidaidien.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thongtinBindingSource, "nguoi_dd", true));
            this.tb_nguoidaidien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nguoidaidien.Location = new System.Drawing.Point(45, 346);
            this.tb_nguoidaidien.Name = "tb_nguoidaidien";
            this.tb_nguoidaidien.Size = new System.Drawing.Size(398, 31);
            this.tb_nguoidaidien.TabIndex = 20;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX4.Location = new System.Drawing.Point(45, 234);
            this.labelX4.Name = "labelX4";
            this.labelX4.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX4.Size = new System.Drawing.Size(398, 36);
            this.labelX4.TabIndex = 19;
            this.labelX4.Text = "Số Đăng Ký Kinh Doanh";
            // 
            // tb_dkkd
            // 
            // 
            // 
            // 
            this.tb_dkkd.Border.Class = "TextBoxBorder";
            this.tb_dkkd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_dkkd.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.thongtinBindingSource, "dangky_kd", true));
            this.tb_dkkd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thongtinBindingSource, "dangky_kd", true));
            this.tb_dkkd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_dkkd.Location = new System.Drawing.Point(45, 273);
            this.tb_dkkd.Name = "tb_dkkd";
            this.tb_dkkd.Size = new System.Drawing.Size(398, 31);
            this.tb_dkkd.TabIndex = 18;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX3.Location = new System.Drawing.Point(46, 163);
            this.labelX3.Name = "labelX3";
            this.labelX3.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX3.Size = new System.Drawing.Size(398, 36);
            this.labelX3.TabIndex = 17;
            this.labelX3.Text = "Mã Số Thuế";
            // 
            // tb_masothue
            // 
            // 
            // 
            // 
            this.tb_masothue.Border.Class = "TextBoxBorder";
            this.tb_masothue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_masothue.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.thongtinBindingSource, "masothue", true));
            this.tb_masothue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thongtinBindingSource, "masothue", true));
            this.tb_masothue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_masothue.Location = new System.Drawing.Point(45, 201);
            this.tb_masothue.Name = "tb_masothue";
            this.tb_masothue.Size = new System.Drawing.Size(398, 31);
            this.tb_masothue.TabIndex = 16;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX2.Location = new System.Drawing.Point(45, 91);
            this.labelX2.Name = "labelX2";
            this.labelX2.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX2.Size = new System.Drawing.Size(398, 36);
            this.labelX2.TabIndex = 15;
            this.labelX2.Text = "Địa Chỉ";
            // 
            // tb_diachi
            // 
            // 
            // 
            // 
            this.tb_diachi.Border.Class = "TextBoxBorder";
            this.tb_diachi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_diachi.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.thongtinBindingSource, "Diachi", true));
            this.tb_diachi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thongtinBindingSource, "Diachi", true));
            this.tb_diachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_diachi.Location = new System.Drawing.Point(45, 129);
            this.tb_diachi.Name = "tb_diachi";
            this.tb_diachi.Size = new System.Drawing.Size(398, 31);
            this.tb_diachi.TabIndex = 14;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Location = new System.Drawing.Point(45, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX1.Size = new System.Drawing.Size(398, 36);
            this.labelX1.TabIndex = 13;
            this.labelX1.Text = "Tên Doanh Nghiệp";
            // 
            // tb_Tendn
            // 
            // 
            // 
            // 
            this.tb_Tendn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_Tendn.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.thongtinBindingSource, "Tendoanhnghiep", true));
            this.tb_Tendn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thongtinBindingSource, "Tendoanhnghiep", true));
            this.tb_Tendn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Tendn.Location = new System.Drawing.Point(45, 57);
            this.tb_Tendn.Name = "tb_Tendn";
            this.tb_Tendn.Size = new System.Drawing.Size(398, 31);
            this.tb_Tendn.TabIndex = 12;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btn_xoa);
            this.groupPanel2.Controls.Add(this.btn_luu_tk);
            this.groupPanel2.Controls.Add(this.btn_them);
            this.groupPanel2.Controls.Add(this.labelX9);
            this.groupPanel2.Controls.Add(this.cb_nganhang);
            this.groupPanel2.Controls.Add(this.labelX8);
            this.groupPanel2.Controls.Add(this.tb_tk);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.tb_sodt);
            this.groupPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(1240, 109);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(344, 366);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 13;
            this.groupPanel2.Text = "Tài Khoản và Liên Hệ";
            // 
            // btn_xoa
            // 
            this.btn_xoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_xoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_xoa.Location = new System.Drawing.Point(219, 247);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(102, 31);
            this.btn_xoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_xoa.TabIndex = 22;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_luu_tk
            // 
            this.btn_luu_tk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_luu_tk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_luu_tk.Location = new System.Drawing.Point(111, 247);
            this.btn_luu_tk.Name = "btn_luu_tk";
            this.btn_luu_tk.Size = new System.Drawing.Size(102, 31);
            this.btn_luu_tk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_luu_tk.TabIndex = 21;
            this.btn_luu_tk.Text = "Lưu Lại";
            this.btn_luu_tk.Click += new System.EventHandler(this.btn_luu_tk_Click);
            // 
            // btn_them
            // 
            this.btn_them.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_them.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_them.Location = new System.Drawing.Point(3, 247);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(102, 31);
            this.btn_them.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_them.TabIndex = 20;
            this.btn_them.Text = "Thêm Mới";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX9.Location = new System.Drawing.Point(46, 47);
            this.labelX9.Name = "labelX9";
            this.labelX9.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX9.Size = new System.Drawing.Size(273, 31);
            this.labelX9.TabIndex = 19;
            this.labelX9.Text = "Ngân Hàng";
            // 
            // cb_nganhang
            // 
            this.cb_nganhang.DisplayMember = "Text";
            this.cb_nganhang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_nganhang.FormattingEnabled = true;
            this.cb_nganhang.ItemHeight = 25;
            this.cb_nganhang.Location = new System.Drawing.Point(46, 78);
            this.cb_nganhang.Name = "cb_nganhang";
            this.cb_nganhang.Size = new System.Drawing.Size(273, 31);
            this.cb_nganhang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_nganhang.TabIndex = 18;
            this.cb_nganhang.SelectedIndexChanged += new System.EventHandler(this.cb_nganhang_SelectedIndexChanged);
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX8.Location = new System.Drawing.Point(46, 111);
            this.labelX8.Name = "labelX8";
            this.labelX8.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX8.Size = new System.Drawing.Size(273, 31);
            this.labelX8.TabIndex = 17;
            this.labelX8.Text = "Số Tài Khoản Ngân Hàng";
            // 
            // tb_tk
            // 
            // 
            // 
            // 
            this.tb_tk.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_tk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_tk.Location = new System.Drawing.Point(46, 143);
            this.tb_tk.Name = "tb_tk";
            this.tb_tk.Size = new System.Drawing.Size(273, 25);
            this.tb_tk.TabIndex = 16;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX7.Location = new System.Drawing.Point(46, 171);
            this.labelX7.Name = "labelX7";
            this.labelX7.SingleLineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelX7.Size = new System.Drawing.Size(273, 31);
            this.labelX7.TabIndex = 15;
            this.labelX7.Text = "Số Điện Thoại";
            this.labelX7.Click += new System.EventHandler(this.labelX7_Click);
            // 
            // tb_sodt
            // 
            // 
            // 
            // 
            this.tb_sodt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_sodt.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.lienheBindingSource, "so_dt", true));
            this.tb_sodt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lienheBindingSource, "so_dt", true));
            this.tb_sodt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sodt.Location = new System.Drawing.Point(46, 205);
            this.tb_sodt.Name = "tb_sodt";
            this.tb_sodt.Size = new System.Drawing.Size(273, 25);
            this.tb_sodt.TabIndex = 14;
            // 
            // lienheBindingSource
            // 
            this.lienheBindingSource.DataMember = "lienhe";
            this.lienheBindingSource.DataSource = this.quanlydien_sqlDataSet;
            // 
            // thongtinTableAdapter
            // 
            this.thongtinTableAdapter.ClearBeforeFill = true;
            // 
            // lienheTableAdapter
            // 
            this.lienheTableAdapter.ClearBeforeFill = true;
            // 
            // Thongtin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyDienNang.Properties.Resources.anh_nen_3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1586, 882);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "Thongtin";
            this.Text = "Thongtin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Thongtin_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thongtinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlydien_sqlDataSet)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lienheBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btn_luu_tt;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_chucvu;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_nguoidaidien;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_dkkd;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_masothue;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_diachi;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_Tendn;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_sodt;
        private DevComponents.DotNetBar.ButtonX btn_xoa;
        private DevComponents.DotNetBar.ButtonX btn_luu_tk;
        private DevComponents.DotNetBar.ButtonX btn_them;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_nganhang;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX tb_tk;
        private quanlydien_sqlDataSet quanlydien_sqlDataSet;
        private System.Windows.Forms.BindingSource thongtinBindingSource;
        private quanlydien_sqlDataSetTableAdapters.thongtinTableAdapter thongtinTableAdapter;
        private System.Windows.Forms.BindingSource lienheBindingSource;
        private quanlydien_sqlDataSetTableAdapters.lienheTableAdapter lienheTableAdapter;
    }
}