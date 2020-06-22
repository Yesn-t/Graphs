/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 23/08/2018
 * Time: 01:27 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Act_1
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonCALCULAR;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonCARGA;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TreeView treeViewGRAFO;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button InsertParticulabutton;
		private System.Windows.Forms.NumericUpDown presaNumericUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelRecorrido;
		private System.Windows.Forms.Label label9;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonCALCULAR = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonCARGA = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.treeViewGRAFO = new System.Windows.Forms.TreeView();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.depredadorNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.InsertParticulabutton = new System.Windows.Forms.Button();
			this.presaNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.labelRecorrido = new System.Windows.Forms.Label();
			this.inicioRecorrido = new System.Windows.Forms.NumericUpDown();
			this.recorridoProfundidadButton = new System.Windows.Forms.Button();
			this.recorridoAnchuraButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.KruskalListBox = new System.Windows.Forms.ListBox();
			this.PrimListBox = new System.Windows.Forms.ListBox();
			this.KruskalButton = new System.Windows.Forms.Button();
			this.PrimButton = new System.Windows.Forms.Button();
			this.PrimNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.KruskalPonderacionLabel = new System.Windows.Forms.Label();
			this.PrimPonderacionLabel = new System.Windows.Forms.Label();
			this.PrimLabel = new System.Windows.Forms.Label();
			this.KruskalLabel = new System.Windows.Forms.Label();
			this.groupBoxACT5 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.DepredadorDijnumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.AnimarDijButton = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DestinoDijNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.OrigenDijNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.groupBoxACT1 = new System.Windows.Forms.GroupBox();
			this.listBoxCENTROS = new System.Windows.Forms.ListBox();
			this.ACT1 = new System.Windows.Forms.Button();
			this.ACT2 = new System.Windows.Forms.Button();
			this.ACT3 = new System.Windows.Forms.Button();
			this.ACT4 = new System.Windows.Forms.Button();
			this.ACT5 = new System.Windows.Forms.Button();
			this.groupBoxACT2 = new System.Windows.Forms.GroupBox();
			this.Camino4VerticesButton = new System.Windows.Forms.Button();
			this.PuntosCercanosButton = new System.Windows.Forms.Button();
			this.groupBoxACT3 = new System.Windows.Forms.GroupBox();
			this.groupBoxACT4 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.depredadorNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.presaNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.inicioRecorrido)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PrimNumericUpDown)).BeginInit();
			this.groupBoxACT5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DepredadorDijnumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DestinoDijNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OrigenDijNumericUpDown)).BeginInit();
			this.groupBoxACT1.SuspendLayout();
			this.groupBoxACT2.SuspendLayout();
			this.groupBoxACT3.SuspendLayout();
			this.groupBoxACT4.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCALCULAR
			// 
			this.buttonCALCULAR.Location = new System.Drawing.Point(386, 12);
			this.buttonCALCULAR.Name = "buttonCALCULAR";
			this.buttonCALCULAR.Size = new System.Drawing.Size(131, 29);
			this.buttonCALCULAR.TabIndex = 0;
			this.buttonCALCULAR.Text = "Analizar";
			this.buttonCALCULAR.UseVisualStyleBackColor = true;
			this.buttonCALCULAR.Click += new System.EventHandler(this.ButtonCALCULARClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(12, 47);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(604, 452);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// buttonCARGA
			// 
			this.buttonCARGA.Location = new System.Drawing.Point(69, 12);
			this.buttonCARGA.Name = "buttonCARGA";
			this.buttonCARGA.Size = new System.Drawing.Size(123, 29);
			this.buttonCARGA.TabIndex = 2;
			this.buttonCARGA.Text = "Cargar Imagen";
			this.buttonCARGA.UseVisualStyleBackColor = true;
			this.buttonCARGA.Click += new System.EventHandler(this.ButtonCARGAClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// treeViewGRAFO
			// 
			this.treeViewGRAFO.Location = new System.Drawing.Point(6, 40);
			this.treeViewGRAFO.Name = "treeViewGRAFO";
			this.treeViewGRAFO.Size = new System.Drawing.Size(223, 120);
			this.treeViewGRAFO.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(183, 32);
			this.label2.TabIndex = 8;
			this.label2.Text = "Grafo";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.depredadorNumericUpDown);
			this.groupBox1.Controls.Add(this.InsertParticulabutton);
			this.groupBox1.Controls.Add(this.presaNumericUpDown);
			this.groupBox1.Location = new System.Drawing.Point(287, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(268, 112);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Particulas";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(143, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(102, 23);
			this.label6.TabIndex = 14;
			this.label6.Text = "Depredador";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Presa";
			// 
			// depredadorNumericUpDown
			// 
			this.depredadorNumericUpDown.Location = new System.Drawing.Point(143, 40);
			this.depredadorNumericUpDown.Name = "depredadorNumericUpDown";
			this.depredadorNumericUpDown.Size = new System.Drawing.Size(116, 26);
			this.depredadorNumericUpDown.TabIndex = 2;
			// 
			// InsertParticulabutton
			// 
			this.InsertParticulabutton.Location = new System.Drawing.Point(87, 72);
			this.InsertParticulabutton.Name = "InsertParticulabutton";
			this.InsertParticulabutton.Size = new System.Drawing.Size(84, 34);
			this.InsertParticulabutton.TabIndex = 1;
			this.InsertParticulabutton.Text = "Insertar";
			this.InsertParticulabutton.UseVisualStyleBackColor = true;
			this.InsertParticulabutton.Click += new System.EventHandler(this.InsertParticulabuttonClick);
			// 
			// presaNumericUpDown
			// 
			this.presaNumericUpDown.Location = new System.Drawing.Point(6, 40);
			this.presaNumericUpDown.Name = "presaNumericUpDown";
			this.presaNumericUpDown.Size = new System.Drawing.Size(116, 26);
			this.presaNumericUpDown.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(19, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 17);
			this.label3.TabIndex = 11;
			this.label3.Text = "Recorrido:";
			// 
			// labelRecorrido
			// 
			this.labelRecorrido.Location = new System.Drawing.Point(106, 22);
			this.labelRecorrido.Name = "labelRecorrido";
			this.labelRecorrido.Size = new System.Drawing.Size(449, 23);
			this.labelRecorrido.TabIndex = 12;
			// 
			// inicioRecorrido
			// 
			this.inicioRecorrido.Location = new System.Drawing.Point(68, 19);
			this.inicioRecorrido.Name = "inicioRecorrido";
			this.inicioRecorrido.Size = new System.Drawing.Size(116, 26);
			this.inicioRecorrido.TabIndex = 2;
			// 
			// recorridoProfundidadButton
			// 
			this.recorridoProfundidadButton.Location = new System.Drawing.Point(6, 51);
			this.recorridoProfundidadButton.Name = "recorridoProfundidadButton";
			this.recorridoProfundidadButton.Size = new System.Drawing.Size(116, 31);
			this.recorridoProfundidadButton.TabIndex = 3;
			this.recorridoProfundidadButton.Text = "Profundidad";
			this.recorridoProfundidadButton.UseVisualStyleBackColor = true;
			this.recorridoProfundidadButton.Click += new System.EventHandler(this.RecorridoProfundidadButtonClick);
			// 
			// recorridoAnchuraButton
			// 
			this.recorridoAnchuraButton.Location = new System.Drawing.Point(128, 51);
			this.recorridoAnchuraButton.Name = "recorridoAnchuraButton";
			this.recorridoAnchuraButton.Size = new System.Drawing.Size(116, 31);
			this.recorridoAnchuraButton.TabIndex = 4;
			this.recorridoAnchuraButton.Text = "Anchura";
			this.recorridoAnchuraButton.UseVisualStyleBackColor = true;
			this.recorridoAnchuraButton.Click += new System.EventHandler(this.RecorridoAnchuraButtonClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.recorridoAnchuraButton);
			this.groupBox2.Controls.Add(this.recorridoProfundidadButton);
			this.groupBox2.Controls.Add(this.inicioRecorrido);
			this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
			this.groupBox2.Location = new System.Drawing.Point(19, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(249, 112);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Recorrido";
			// 
			// KruskalListBox
			// 
			this.KruskalListBox.FormattingEnabled = true;
			this.KruskalListBox.ItemHeight = 20;
			this.KruskalListBox.Location = new System.Drawing.Point(6, 64);
			this.KruskalListBox.Name = "KruskalListBox";
			this.KruskalListBox.Size = new System.Drawing.Size(138, 144);
			this.KruskalListBox.TabIndex = 13;
			// 
			// PrimListBox
			// 
			this.PrimListBox.FormattingEnabled = true;
			this.PrimListBox.ItemHeight = 20;
			this.PrimListBox.Location = new System.Drawing.Point(6, 271);
			this.PrimListBox.Name = "PrimListBox";
			this.PrimListBox.Size = new System.Drawing.Size(138, 164);
			this.PrimListBox.TabIndex = 14;
			// 
			// KruskalButton
			// 
			this.KruskalButton.Location = new System.Drawing.Point(6, 32);
			this.KruskalButton.Name = "KruskalButton";
			this.KruskalButton.Size = new System.Drawing.Size(138, 29);
			this.KruskalButton.TabIndex = 15;
			this.KruskalButton.Text = "Kruskal";
			this.KruskalButton.UseVisualStyleBackColor = true;
			this.KruskalButton.Click += new System.EventHandler(this.KruskalButtonClick);
			// 
			// PrimButton
			// 
			this.PrimButton.Location = new System.Drawing.Point(6, 236);
			this.PrimButton.Name = "PrimButton";
			this.PrimButton.Size = new System.Drawing.Size(138, 29);
			this.PrimButton.TabIndex = 16;
			this.PrimButton.Text = "Prim";
			this.PrimButton.UseVisualStyleBackColor = true;
			this.PrimButton.Click += new System.EventHandler(this.PrimButtonClick);
			// 
			// PrimNumericUpDown
			// 
			this.PrimNumericUpDown.Location = new System.Drawing.Point(150, 238);
			this.PrimNumericUpDown.Name = "PrimNumericUpDown";
			this.PrimNumericUpDown.Size = new System.Drawing.Size(49, 26);
			this.PrimNumericUpDown.TabIndex = 15;
			// 
			// KruskalPonderacionLabel
			// 
			this.KruskalPonderacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KruskalPonderacionLabel.ForeColor = System.Drawing.Color.Red;
			this.KruskalPonderacionLabel.Location = new System.Drawing.Point(144, 64);
			this.KruskalPonderacionLabel.Name = "KruskalPonderacionLabel";
			this.KruskalPonderacionLabel.Size = new System.Drawing.Size(94, 20);
			this.KruskalPonderacionLabel.TabIndex = 17;
			this.KruskalPonderacionLabel.Text = "Ponderacion";
			// 
			// PrimPonderacionLabel
			// 
			this.PrimPonderacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrimPonderacionLabel.ForeColor = System.Drawing.Color.Red;
			this.PrimPonderacionLabel.Location = new System.Drawing.Point(144, 271);
			this.PrimPonderacionLabel.Name = "PrimPonderacionLabel";
			this.PrimPonderacionLabel.Size = new System.Drawing.Size(94, 17);
			this.PrimPonderacionLabel.TabIndex = 18;
			this.PrimPonderacionLabel.Text = "Ponderacion";
			// 
			// PrimLabel
			// 
			this.PrimLabel.Location = new System.Drawing.Point(150, 292);
			this.PrimLabel.Name = "PrimLabel";
			this.PrimLabel.Size = new System.Drawing.Size(88, 23);
			this.PrimLabel.TabIndex = 19;
			// 
			// KruskalLabel
			// 
			this.KruskalLabel.Location = new System.Drawing.Point(150, 98);
			this.KruskalLabel.Name = "KruskalLabel";
			this.KruskalLabel.Size = new System.Drawing.Size(88, 23);
			this.KruskalLabel.TabIndex = 20;
			// 
			// groupBoxACT5
			// 
			this.groupBoxACT5.Controls.Add(this.label9);
			this.groupBoxACT5.Controls.Add(this.label10);
			this.groupBoxACT5.Controls.Add(this.DepredadorDijnumericUpDown);
			this.groupBoxACT5.Controls.Add(this.label8);
			this.groupBoxACT5.Controls.Add(this.AnimarDijButton);
			this.groupBoxACT5.Controls.Add(this.label7);
			this.groupBoxACT5.Controls.Add(this.label1);
			this.groupBoxACT5.Controls.Add(this.DestinoDijNumericUpDown);
			this.groupBoxACT5.Controls.Add(this.OrigenDijNumericUpDown);
			this.groupBoxACT5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxACT5.Location = new System.Drawing.Point(598, 506);
			this.groupBoxACT5.Name = "groupBoxACT5";
			this.groupBoxACT5.Size = new System.Drawing.Size(268, 166);
			this.groupBoxACT5.TabIndex = 21;
			this.groupBoxACT5.TabStop = false;
			this.groupBoxACT5.Text = "ACT 5";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(152, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(108, 23);
			this.label9.TabIndex = 22;
			this.label9.Text = "Depredador";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(152, 61);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 23);
			this.label10.TabIndex = 20;
			this.label10.Text = "Num:";
			// 
			// DepredadorDijnumericUpDown
			// 
			this.DepredadorDijnumericUpDown.Location = new System.Drawing.Point(212, 58);
			this.DepredadorDijnumericUpDown.Name = "DepredadorDijnumericUpDown";
			this.DepredadorDijnumericUpDown.Size = new System.Drawing.Size(48, 26);
			this.DepredadorDijnumericUpDown.TabIndex = 21;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 30);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 23);
			this.label8.TabIndex = 19;
			this.label8.Text = "Presa";
			// 
			// AnimarDijButton
			// 
			this.AnimarDijButton.Location = new System.Drawing.Point(152, 109);
			this.AnimarDijButton.Name = "AnimarDijButton";
			this.AnimarDijButton.Size = new System.Drawing.Size(95, 30);
			this.AnimarDijButton.TabIndex = 18;
			this.AnimarDijButton.Text = "Animar";
			this.AnimarDijButton.UseVisualStyleBackColor = true;
			this.AnimarDijButton.Click += new System.EventHandler(this.AnimarDijButtonClick);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 94);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 23);
			this.label7.TabIndex = 17;
			this.label7.Text = "Destino:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 23);
			this.label1.TabIndex = 15;
			this.label1.Text = "Origen:";
			// 
			// DestinoDijNumericUpDown
			// 
			this.DestinoDijNumericUpDown.Location = new System.Drawing.Point(88, 92);
			this.DestinoDijNumericUpDown.Name = "DestinoDijNumericUpDown";
			this.DestinoDijNumericUpDown.Size = new System.Drawing.Size(48, 26);
			this.DestinoDijNumericUpDown.TabIndex = 16;
			// 
			// OrigenDijNumericUpDown
			// 
			this.OrigenDijNumericUpDown.Location = new System.Drawing.Point(88, 58);
			this.OrigenDijNumericUpDown.Name = "OrigenDijNumericUpDown";
			this.OrigenDijNumericUpDown.Size = new System.Drawing.Size(48, 26);
			this.OrigenDijNumericUpDown.TabIndex = 15;
			// 
			// groupBoxACT1
			// 
			this.groupBoxACT1.Controls.Add(this.listBoxCENTROS);
			this.groupBoxACT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxACT1.Location = new System.Drawing.Point(631, 51);
			this.groupBoxACT1.Name = "groupBoxACT1";
			this.groupBoxACT1.Size = new System.Drawing.Size(235, 166);
			this.groupBoxACT1.TabIndex = 22;
			this.groupBoxACT1.TabStop = false;
			this.groupBoxACT1.Text = "ACT 1";
			// 
			// listBoxCENTROS
			// 
			this.listBoxCENTROS.FormattingEnabled = true;
			this.listBoxCENTROS.ItemHeight = 20;
			this.listBoxCENTROS.Location = new System.Drawing.Point(6, 27);
			this.listBoxCENTROS.Name = "listBoxCENTROS";
			this.listBoxCENTROS.Size = new System.Drawing.Size(223, 124);
			this.listBoxCENTROS.TabIndex = 23;
			// 
			// ACT1
			// 
			this.ACT1.Location = new System.Drawing.Point(625, 12);
			this.ACT1.Name = "ACT1";
			this.ACT1.Size = new System.Drawing.Size(51, 29);
			this.ACT1.TabIndex = 23;
			this.ACT1.Text = "ACT 1";
			this.ACT1.UseVisualStyleBackColor = true;
			this.ACT1.Click += new System.EventHandler(this.ACT1Click);
			// 
			// ACT2
			// 
			this.ACT2.Location = new System.Drawing.Point(683, 12);
			this.ACT2.Name = "ACT2";
			this.ACT2.Size = new System.Drawing.Size(51, 29);
			this.ACT2.TabIndex = 24;
			this.ACT2.Text = "ACT 2";
			this.ACT2.UseVisualStyleBackColor = true;
			this.ACT2.Click += new System.EventHandler(this.ACT2Click);
			// 
			// ACT3
			// 
			this.ACT3.Location = new System.Drawing.Point(740, 12);
			this.ACT3.Name = "ACT3";
			this.ACT3.Size = new System.Drawing.Size(51, 29);
			this.ACT3.TabIndex = 25;
			this.ACT3.Text = "ACT 3";
			this.ACT3.UseVisualStyleBackColor = true;
			this.ACT3.Click += new System.EventHandler(this.ACT3Click);
			// 
			// ACT4
			// 
			this.ACT4.Location = new System.Drawing.Point(797, 12);
			this.ACT4.Name = "ACT4";
			this.ACT4.Size = new System.Drawing.Size(51, 29);
			this.ACT4.TabIndex = 26;
			this.ACT4.Text = "ACT 4";
			this.ACT4.UseVisualStyleBackColor = true;
			this.ACT4.Click += new System.EventHandler(this.ACT4Click);
			// 
			// ACT5
			// 
			this.ACT5.Location = new System.Drawing.Point(854, 12);
			this.ACT5.Name = "ACT5";
			this.ACT5.Size = new System.Drawing.Size(51, 29);
			this.ACT5.TabIndex = 27;
			this.ACT5.Text = "ACT 5";
			this.ACT5.UseVisualStyleBackColor = true;
			this.ACT5.Click += new System.EventHandler(this.ACT5Click);
			// 
			// groupBoxACT2
			// 
			this.groupBoxACT2.Controls.Add(this.Camino4VerticesButton);
			this.groupBoxACT2.Controls.Add(this.PuntosCercanosButton);
			this.groupBoxACT2.Controls.Add(this.treeViewGRAFO);
			this.groupBoxACT2.Controls.Add(this.label2);
			this.groupBoxACT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxACT2.Location = new System.Drawing.Point(631, 233);
			this.groupBoxACT2.Name = "groupBoxACT2";
			this.groupBoxACT2.Size = new System.Drawing.Size(235, 266);
			this.groupBoxACT2.TabIndex = 28;
			this.groupBoxACT2.TabStop = false;
			this.groupBoxACT2.Text = "ACT 2";
			// 
			// Camino4VerticesButton
			// 
			this.Camino4VerticesButton.Location = new System.Drawing.Point(6, 215);
			this.Camino4VerticesButton.Name = "Camino4VerticesButton";
			this.Camino4VerticesButton.Size = new System.Drawing.Size(221, 29);
			this.Camino4VerticesButton.TabIndex = 22;
			this.Camino4VerticesButton.Text = "Camino 4 Vertices";
			this.Camino4VerticesButton.UseVisualStyleBackColor = true;
			this.Camino4VerticesButton.Click += new System.EventHandler(this.Camino4VerticesButtonClick);
			// 
			// PuntosCercanosButton
			// 
			this.PuntosCercanosButton.Location = new System.Drawing.Point(6, 180);
			this.PuntosCercanosButton.Name = "PuntosCercanosButton";
			this.PuntosCercanosButton.Size = new System.Drawing.Size(221, 29);
			this.PuntosCercanosButton.TabIndex = 21;
			this.PuntosCercanosButton.Text = "2 Puntos Cercanos";
			this.PuntosCercanosButton.UseVisualStyleBackColor = true;
			this.PuntosCercanosButton.Click += new System.EventHandler(this.PuntosCercanosButtonClick);
			// 
			// groupBoxACT3
			// 
			this.groupBoxACT3.Controls.Add(this.labelRecorrido);
			this.groupBoxACT3.Controls.Add(this.groupBox1);
			this.groupBoxACT3.Controls.Add(this.groupBox2);
			this.groupBoxACT3.Controls.Add(this.label3);
			this.groupBoxACT3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxACT3.Location = new System.Drawing.Point(12, 506);
			this.groupBoxACT3.Name = "groupBoxACT3";
			this.groupBoxACT3.Size = new System.Drawing.Size(570, 166);
			this.groupBoxACT3.TabIndex = 29;
			this.groupBoxACT3.TabStop = false;
			this.groupBoxACT3.Text = "ACT 3";
			// 
			// groupBoxACT4
			// 
			this.groupBoxACT4.Controls.Add(this.KruskalButton);
			this.groupBoxACT4.Controls.Add(this.KruskalListBox);
			this.groupBoxACT4.Controls.Add(this.PrimListBox);
			this.groupBoxACT4.Controls.Add(this.PrimButton);
			this.groupBoxACT4.Controls.Add(this.PrimNumericUpDown);
			this.groupBoxACT4.Controls.Add(this.KruskalPonderacionLabel);
			this.groupBoxACT4.Controls.Add(this.PrimPonderacionLabel);
			this.groupBoxACT4.Controls.Add(this.PrimLabel);
			this.groupBoxACT4.Controls.Add(this.KruskalLabel);
			this.groupBoxACT4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBoxACT4.Location = new System.Drawing.Point(872, 51);
			this.groupBoxACT4.Name = "groupBoxACT4";
			this.groupBoxACT4.Size = new System.Drawing.Size(244, 448);
			this.groupBoxACT4.TabIndex = 30;
			this.groupBoxACT4.TabStop = false;
			this.groupBoxACT4.Text = "ACT 4";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1125, 681);
			this.Controls.Add(this.groupBoxACT4);
			this.Controls.Add(this.groupBoxACT3);
			this.Controls.Add(this.groupBoxACT2);
			this.Controls.Add(this.ACT5);
			this.Controls.Add(this.ACT4);
			this.Controls.Add(this.ACT3);
			this.Controls.Add(this.ACT2);
			this.Controls.Add(this.ACT1);
			this.Controls.Add(this.groupBoxACT1);
			this.Controls.Add(this.groupBoxACT5);
			this.Controls.Add(this.buttonCARGA);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.buttonCALCULAR);
			this.Name = "MainForm";
			this.Text = "Act 1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.depredadorNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.presaNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.inicioRecorrido)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PrimNumericUpDown)).EndInit();
			this.groupBoxACT5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DepredadorDijnumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DestinoDijNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OrigenDijNumericUpDown)).EndInit();
			this.groupBoxACT1.ResumeLayout(false);
			this.groupBoxACT2.ResumeLayout(false);
			this.groupBoxACT3.ResumeLayout(false);
			this.groupBoxACT4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        private System.Windows.Forms.NumericUpDown depredadorNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown inicioRecorrido;
        private System.Windows.Forms.Button recorridoProfundidadButton;
        private System.Windows.Forms.Button recorridoAnchuraButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox KruskalListBox;
        private System.Windows.Forms.ListBox PrimListBox;
        private System.Windows.Forms.Button KruskalButton;
        private System.Windows.Forms.Button PrimButton;
        private System.Windows.Forms.NumericUpDown PrimNumericUpDown;
        private System.Windows.Forms.Label KruskalPonderacionLabel;
        private System.Windows.Forms.Label PrimPonderacionLabel;
        private System.Windows.Forms.Label PrimLabel;
        private System.Windows.Forms.Label KruskalLabel;
        private System.Windows.Forms.GroupBox groupBoxACT5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button AnimarDijButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DestinoDijNumericUpDown;
        private System.Windows.Forms.NumericUpDown OrigenDijNumericUpDown;
        private System.Windows.Forms.NumericUpDown DepredadorDijnumericUpDown;
        private System.Windows.Forms.GroupBox groupBoxACT1;
        private System.Windows.Forms.ListBox listBoxCENTROS;
        private System.Windows.Forms.Button ACT1;
        private System.Windows.Forms.Button ACT2;
        private System.Windows.Forms.Button ACT3;
        private System.Windows.Forms.Button ACT4;
        private System.Windows.Forms.Button ACT5;
        private System.Windows.Forms.GroupBox groupBoxACT2;
        private System.Windows.Forms.GroupBox groupBoxACT3;
        private System.Windows.Forms.GroupBox groupBoxACT4;
        private System.Windows.Forms.Button Camino4VerticesButton;
        private System.Windows.Forms.Button PuntosCercanosButton;
    }
}
