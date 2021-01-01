using System;
using System.Collections.Generic;
using System.Text;

namespace PdfiumViewerFile
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printMultiplePagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ConvertAndexitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.renderToBitmapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutMarginsWhenPrintingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shrinkToMarginsWhenPrintingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateCurrentPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate270ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showRangeOfPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._page = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this._zoom = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this._pageToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this._coordinatesToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this._fitWidth = new System.Windows.Forms.ToolStripButton();
            this._fitHeight = new System.Windows.Forms.ToolStripButton();
            this._fitBest = new System.Windows.Forms.ToolStripButton();
            this._rotateLeft = new System.Windows.Forms.ToolStripButton();
            this._rotateRight = new System.Windows.Forms.ToolStripButton();
            this._showToolbar = new System.Windows.Forms.ToolStripButton();
            this._showBookmarks = new System.Windows.Forms.ToolStripButton();
            this._getTextFromPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConvert = new System.Windows.Forms.ToolStripButton();

            this.pdfViewer1 = new PdfiumViewer.PdfViewer();

            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1128, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printPreviewToolStripMenuItem,
            this.printMultiplePagesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.ConvertAndexitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "فایل";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "بازکردن";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.printPreviewToolStripMenuItem.Text = "پیش نمایش چاپ";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // printMultiplePagesToolStripMenuItem
            // 
            this.printMultiplePagesToolStripMenuItem.Name = "printMultiplePagesToolStripMenuItem";
            this.printMultiplePagesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.printMultiplePagesToolStripMenuItem.Text = "چاپ چند صفحه";
            this.printMultiplePagesToolStripMenuItem.Click += new System.EventHandler(this.printMultiplePagesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 6);
            // 
            // ConvertAndexitToolStripMenuItem
            // 
            this.ConvertAndexitToolStripMenuItem.Name = "ConvertAndexitToolStripMenuItem";
            this.ConvertAndexitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ConvertAndexitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ConvertAndexitToolStripMenuItem.Text = "تبدیل به عکس";
            this.ConvertAndexitToolStripMenuItem.Click += new System.EventHandler(this.ConvertAndexitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.toolStripMenuItem7,
            this.renderToBitmapsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cutMarginsWhenPrintingToolStripMenuItem,
            this.shrinkToMarginsWhenPrintingToolStripMenuItem,
            this.toolStripMenuItem4,
            this.deleteCurrentPageToolStripMenuItem,
            this.rotateCurrentPageToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showRangeOfPagesToolStripMenuItem,
            this.toolStripMenuItem6,
            this.informationToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.toolsToolStripMenuItem.Text = "ابزار";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.findToolStripMenuItem.Text = "پیدا کردن";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(241, 6);
            // 
            // renderToBitmapsToolStripMenuItem
            // 
            this.renderToBitmapsToolStripMenuItem.Name = "renderToBitmapsToolStripMenuItem";
            this.renderToBitmapsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.renderToBitmapsToolStripMenuItem.Text = "رندر به بیت مپ";
            this.renderToBitmapsToolStripMenuItem.Click += new System.EventHandler(this.renderToBitmapsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
            // 
            // cutMarginsWhenPrintingToolStripMenuItem
            // 
            this.cutMarginsWhenPrintingToolStripMenuItem.Name = "cutMarginsWhenPrintingToolStripMenuItem";
            this.cutMarginsWhenPrintingToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.cutMarginsWhenPrintingToolStripMenuItem.Text = "Cut margins when printing";
            this.cutMarginsWhenPrintingToolStripMenuItem.Click += new System.EventHandler(this.cutMarginsWhenPrintingToolStripMenuItem_Click);
            // 
            // shrinkToMarginsWhenPrintingToolStripMenuItem
            // 
            this.shrinkToMarginsWhenPrintingToolStripMenuItem.Name = "shrinkToMarginsWhenPrintingToolStripMenuItem";
            this.shrinkToMarginsWhenPrintingToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.shrinkToMarginsWhenPrintingToolStripMenuItem.Text = "Shrink to margins when printing";
            this.shrinkToMarginsWhenPrintingToolStripMenuItem.Click += new System.EventHandler(this.shrinkToMarginsWhenPrintingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(241, 6);
            // 
            // deleteCurrentPageToolStripMenuItem
            // 
            this.deleteCurrentPageToolStripMenuItem.Name = "deleteCurrentPageToolStripMenuItem";
            this.deleteCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.deleteCurrentPageToolStripMenuItem.Text = "حذف صفحه جاری";
            this.deleteCurrentPageToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentPageToolStripMenuItem_Click);
            // 
            // rotateCurrentPageToolStripMenuItem
            // 
            this.rotateCurrentPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotate0ToolStripMenuItem,
            this.rotate90ToolStripMenuItem,
            this.rotate180ToolStripMenuItem,
            this.rotate270ToolStripMenuItem});
            this.rotateCurrentPageToolStripMenuItem.Name = "rotateCurrentPageToolStripMenuItem";
            this.rotateCurrentPageToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.rotateCurrentPageToolStripMenuItem.Text = "چرخش صفحه";
            // 
            // rotate0ToolStripMenuItem
            // 
            this.rotate0ToolStripMenuItem.Name = "rotate0ToolStripMenuItem";
            this.rotate0ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rotate0ToolStripMenuItem.Text = "گردش 0";
            this.rotate0ToolStripMenuItem.Click += new System.EventHandler(this.rotate0ToolStripMenuItem_Click);
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            this.rotate90ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rotate90ToolStripMenuItem.Text = "گردش 90";
            this.rotate90ToolStripMenuItem.Click += new System.EventHandler(this.rotate90ToolStripMenuItem_Click);
            // 
            // rotate180ToolStripMenuItem
            // 
            this.rotate180ToolStripMenuItem.Name = "rotate180ToolStripMenuItem";
            this.rotate180ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rotate180ToolStripMenuItem.Text = "گردش 180";
            this.rotate180ToolStripMenuItem.Click += new System.EventHandler(this.rotate180ToolStripMenuItem_Click);
            // 
            // rotate270ToolStripMenuItem
            // 
            this.rotate270ToolStripMenuItem.Name = "rotate270ToolStripMenuItem";
            this.rotate270ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rotate270ToolStripMenuItem.Text = "گردش 270";
            this.rotate270ToolStripMenuItem.Click += new System.EventHandler(this.rotate270ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(241, 6);
            // 
            // showRangeOfPagesToolStripMenuItem
            // 
            this.showRangeOfPagesToolStripMenuItem.Name = "showRangeOfPagesToolStripMenuItem";
            this.showRangeOfPagesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.showRangeOfPagesToolStripMenuItem.Text = "نمایش گروهی صفحه";
            this.showRangeOfPagesToolStripMenuItem.Click += new System.EventHandler(this.showRangeOfPagesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(241, 6);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.informationToolStripMenuItem.Text = "سایر اطلاعات";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this._page,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this._zoom,
            this.toolStripSeparator7,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this._fitWidth,
            this._fitHeight,
            this._fitBest,
            this.toolStripSeparator5,
            this._rotateLeft,
            this._rotateRight,
            this.toolStripSeparator6,
            this._showToolbar,
            this._showBookmarks,
            this._getTextFromPage,
            this.toolStripButtonConvert});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1128, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _page
            // 
            this._page.Name = "_page";
            this._page.Size = new System.Drawing.Size(100, 25);
            this._page.KeyDown += new System.Windows.Forms.KeyEventHandler(this._page_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel2.Text = "بزرگنمایی";
            // 
            // _zoom
            // 
            this._zoom.Name = "_zoom";
            this._zoom.Size = new System.Drawing.Size(100, 25);
            this._zoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this._zoom_KeyDown);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this._pageToolStripLabel,
            this.toolStripStatusLabel2,
            this._coordinatesToolStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1128, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel1.Text = "Page:";
            // 
            // _pageToolStripLabel
            // 
            this._pageToolStripLabel.Name = "_pageToolStripLabel";
            this._pageToolStripLabel.Size = new System.Drawing.Size(41, 17);
            this._pageToolStripLabel.Text = "(page)";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusLabel2.Text = "Coordinates:";
            // 
            // _coordinatesToolStripLabel
            // 
            this._coordinatesToolStripLabel.Name = "_coordinatesToolStripLabel";
            this._coordinatesToolStripLabel.Size = new System.Drawing.Size(77, 17);
            this._coordinatesToolStripLabel.Text = "(coordinates)";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = global::PdfiumViewerFile.Properties.Resources.Icons8_Pages_1;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel1.Text = "صفحه:";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "<";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = ">";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::PdfiumViewerFile.Properties.Resources.Zoom_In;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "+";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::PdfiumViewerFile.Properties.Resources.Zoom_Out;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "-";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // _fitWidth
            // 
            this._fitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._fitWidth.Image = global::PdfiumViewerFile.Properties.Resources.FitWidth;
            this._fitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._fitWidth.Name = "_fitWidth";
            this._fitWidth.Size = new System.Drawing.Size(23, 22);
            this._fitWidth.Text = "بهترین عرض";
            this._fitWidth.Click += new System.EventHandler(this._fitWidth_Click);
            // 
            // _fitHeight
            // 
            this._fitHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._fitHeight.Image = global::PdfiumViewerFile.Properties.Resources.HightFit;
            this._fitHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._fitHeight.Name = "_fitHeight";
            this._fitHeight.Size = new System.Drawing.Size(23, 22);
            this._fitHeight.Text = "بهترین ارتفاع";
            this._fitHeight.Click += new System.EventHandler(this._fitHeight_Click);
            // 
            // _fitBest
            // 
            this._fitBest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._fitBest.Image = global::PdfiumViewerFile.Properties.Resources.FitToWidth;
            this._fitBest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._fitBest.Name = "_fitBest";
            this._fitBest.Size = new System.Drawing.Size(23, 22);
            this._fitBest.Text = "بهترین اندازه";
            this._fitBest.Click += new System.EventHandler(this._fitBest_Click);
            // 
            // _rotateLeft
            // 
            this._rotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rotateLeft.Image = global::PdfiumViewerFile.Properties.Resources.Rotate_To_Landscape;
            this._rotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rotateLeft.Name = "_rotateLeft";
            this._rotateLeft.Size = new System.Drawing.Size(23, 22);
            this._rotateLeft.Text = "گردش چپ";
            this._rotateLeft.Click += new System.EventHandler(this._rotateLeft_Click);
            // 
            // _rotateRight
            // 
            this._rotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rotateRight.Image = global::PdfiumViewerFile.Properties.Resources.Rotate_To_Portrait;
            this._rotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rotateRight.Name = "_rotateRight";
            this._rotateRight.Size = new System.Drawing.Size(23, 22);
            this._rotateRight.Text = "گردش راست";
            this._rotateRight.Click += new System.EventHandler(this._rotateRight_Click);
            // 
            // _showToolbar
            // 
            this._showToolbar.CheckOnClick = true;
            this._showToolbar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._showToolbar.Image = global::PdfiumViewerFile.Properties.Resources.showToolbar;
            this._showToolbar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._showToolbar.Name = "_showToolbar";
            this._showToolbar.Size = new System.Drawing.Size(23, 22);
            this._showToolbar.Text = "نمایش نوار ابزار";
            this._showToolbar.Click += new System.EventHandler(this._hideToolbar_Click);
            // 
            // _showBookmarks
            // 
            this._showBookmarks.CheckOnClick = true;
            this._showBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._showBookmarks.Image = global::PdfiumViewerFile.Properties.Resources.ShowBookMark;
            this._showBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._showBookmarks.Name = "_showBookmarks";
            this._showBookmarks.Size = new System.Drawing.Size(23, 22);
            this._showBookmarks.Text = "نمایش نشانگر صفحه";
            this._showBookmarks.Click += new System.EventHandler(this._hideBookmarks_Click);
            // 
            // _getTextFromPage
            // 
            this._getTextFromPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._getTextFromPage.Image = global::PdfiumViewerFile.Properties.Resources.GetText;
            this._getTextFromPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._getTextFromPage.Name = "_getTextFromPage";
            this._getTextFromPage.Size = new System.Drawing.Size(23, 22);
            this._getTextFromPage.Text = "استخراج متن";
            this._getTextFromPage.ToolTipText = "Get Text From Current Page";
            this._getTextFromPage.Click += new System.EventHandler(this._getTextFromPage_Click);
            // 
            // toolStripButtonConvert
            // 
            this.toolStripButtonConvert.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripButtonConvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConvert.Image = global::PdfiumViewerFile.Properties.Resources.ConvertCamera_2;
            this.toolStripButtonConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConvert.Name = "toolStripButtonConvert";
            this.toolStripButtonConvert.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonConvert.Text = "تبدیل به عکس";
            this.toolStripButtonConvert.Click += new System.EventHandler(this.toolStripButtonConvert_Click);
            // 

            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 49);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(1128, 524);
            this.pdfViewer1.TabIndex = 0;

            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(4F, 8F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 295);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pdfViewer1);

            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "نمایش و تبدیل آکروبات به عکس";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            this.pdfViewer1.PerformLayout();

        }

        #endregion

        ///private PdfiumViewer.PdfViewer pdfViewer1 = new PdfiumViewer.PdfViewer();
        private global::PdfiumViewer.PdfViewer pdfViewer1;
        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ConvertAndexitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderToBitmapsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox _page;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cutMarginsWhenPrintingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shrinkToMarginsWhenPrintingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _fitWidth;
        private System.Windows.Forms.ToolStripButton _fitHeight;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox _zoom;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton _rotateLeft;
        private System.Windows.Forms.ToolStripButton _rotateRight;
        private System.Windows.Forms.ToolStripButton _fitBest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton _showToolbar;
        private System.Windows.Forms.ToolStripButton _showBookmarks;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateCurrentPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate180ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate270ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel _pageToolStripLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel _coordinatesToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showRangeOfPagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _getTextFromPage;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem printMultiplePagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonConvert;
    }
}

