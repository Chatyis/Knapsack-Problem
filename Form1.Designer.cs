
namespace ProblemPlecakowy
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.selectionProgressBar = new System.Windows.Forms.ProgressBar();
            this.uploadFileTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.crossingMixingParentsRadio = new System.Windows.Forms.RadioButton();
            this.crossingMakingChildsRadio = new System.Windows.Forms.RadioButton();
            this.selectionTournamentRadio = new System.Windows.Forms.RadioButton();
            this.selectionSteadyStateRadio = new System.Windows.Forms.RadioButton();
            this.setViewButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.startSelectionButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.selectionWayRadio = new System.Windows.Forms.GroupBox();
            this.crossingFactorRadio = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.populationNumeric = new System.Windows.Forms.NumericUpDown();
            this.mutationOfPopulationNumeric = new System.Windows.Forms.NumericUpDown();
            this.mutationOfAttributeNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.amountOfSelectionsNumeric = new System.Windows.Forms.NumericUpDown();
            this.selectionWayRadio.SuspendLayout();
            this.crossingFactorRadio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.populationNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationOfPopulationNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationOfAttributeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfSelectionsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Location = new System.Drawing.Point(687, 22);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(84, 26);
            this.uploadFileButton.TabIndex = 0;
            this.uploadFileButton.Text = "Dodaj plik...";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.uploadFileButton_Click);
            // 
            // selectionProgressBar
            // 
            this.selectionProgressBar.Location = new System.Drawing.Point(25, 448);
            this.selectionProgressBar.Name = "selectionProgressBar";
            this.selectionProgressBar.Size = new System.Drawing.Size(451, 22);
            this.selectionProgressBar.TabIndex = 1;
            // 
            // uploadFileTextbox
            // 
            this.uploadFileTextbox.Location = new System.Drawing.Point(498, 26);
            this.uploadFileTextbox.Name = "uploadFileTextbox";
            this.uploadFileTextbox.ReadOnly = true;
            this.uploadFileTextbox.Size = new System.Drawing.Size(172, 20);
            this.uploadFileTextbox.TabIndex = 2;
            this.uploadFileTextbox.TextChanged += new System.EventHandler(this.uploadFileTextbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Populacja";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(499, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Współczynnik mutacji max 50 (%)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(499, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Pojemność plecaka";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ilość selekcji";
            // 
            // crossingMixingParentsRadio
            // 
            this.crossingMixingParentsRadio.AutoSize = true;
            this.crossingMixingParentsRadio.Location = new System.Drawing.Point(6, 39);
            this.crossingMixingParentsRadio.Name = "crossingMixingParentsRadio";
            this.crossingMixingParentsRadio.Size = new System.Drawing.Size(177, 17);
            this.crossingMixingParentsRadio.TabIndex = 19;
            this.crossingMixingParentsRadio.Text = "Mieszanie osobników w nowych";
            this.crossingMixingParentsRadio.UseVisualStyleBackColor = true;
            // 
            // crossingMakingChildsRadio
            // 
            this.crossingMakingChildsRadio.AutoSize = true;
            this.crossingMakingChildsRadio.Checked = true;
            this.crossingMakingChildsRadio.Location = new System.Drawing.Point(6, 19);
            this.crossingMakingChildsRadio.Name = "crossingMakingChildsRadio";
            this.crossingMakingChildsRadio.Size = new System.Drawing.Size(208, 17);
            this.crossingMakingChildsRadio.TabIndex = 20;
            this.crossingMakingChildsRadio.TabStop = true;
            this.crossingMakingChildsRadio.Text = "Krzyżowanie osobników tworząc dzieci";
            this.crossingMakingChildsRadio.UseVisualStyleBackColor = true;
            // 
            // selectionTournamentRadio
            // 
            this.selectionTournamentRadio.AutoSize = true;
            this.selectionTournamentRadio.Checked = true;
            this.selectionTournamentRadio.Location = new System.Drawing.Point(6, 17);
            this.selectionTournamentRadio.Name = "selectionTournamentRadio";
            this.selectionTournamentRadio.Size = new System.Drawing.Size(117, 17);
            this.selectionTournamentRadio.TabIndex = 21;
            this.selectionTournamentRadio.TabStop = true;
            this.selectionTournamentRadio.Text = "Selekcja turniejowa";
            this.selectionTournamentRadio.UseVisualStyleBackColor = true;
            // 
            // selectionSteadyStateRadio
            // 
            this.selectionSteadyStateRadio.AutoSize = true;
            this.selectionSteadyStateRadio.Location = new System.Drawing.Point(6, 40);
            this.selectionSteadyStateRadio.Name = "selectionSteadyStateRadio";
            this.selectionSteadyStateRadio.Size = new System.Drawing.Size(133, 17);
            this.selectionSteadyStateRadio.TabIndex = 22;
            this.selectionSteadyStateRadio.Text = "Steady State Selection";
            this.selectionSteadyStateRadio.UseVisualStyleBackColor = true;
            // 
            // setViewButton
            // 
            this.setViewButton.Location = new System.Drawing.Point(498, 412);
            this.setViewButton.Name = "setViewButton";
            this.setViewButton.Size = new System.Drawing.Size(133, 26);
            this.setViewButton.TabIndex = 23;
            this.setViewButton.Text = "Porównaj Generacje";
            this.setViewButton.UseVisualStyleBackColor = true;
            this.setViewButton.Click += new System.EventHandler(this.setViewButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(638, 412);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(133, 26);
            this.saveAsButton.TabIndex = 24;
            this.saveAsButton.Text = "Zapisz jako...";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // startSelectionButton
            // 
            this.startSelectionButton.Enabled = false;
            this.startSelectionButton.Location = new System.Drawing.Point(638, 444);
            this.startSelectionButton.Name = "startSelectionButton";
            this.startSelectionButton.Size = new System.Drawing.Size(133, 26);
            this.startSelectionButton.TabIndex = 26;
            this.startSelectionButton.Text = "Generuj";
            this.startSelectionButton.UseVisualStyleBackColor = true;
            this.startSelectionButton.Click += new System.EventHandler(this.startSelectionButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(498, 444);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(133, 26);
            this.resetButton.TabIndex = 25;
            this.resetButton.Text = "Resetuj";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Ilość mutowanych cech max 50 (%)";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // selectionWayRadio
            // 
            this.selectionWayRadio.Controls.Add(this.selectionTournamentRadio);
            this.selectionWayRadio.Controls.Add(this.selectionSteadyStateRadio);
            this.selectionWayRadio.Location = new System.Drawing.Point(502, 131);
            this.selectionWayRadio.Name = "selectionWayRadio";
            this.selectionWayRadio.Size = new System.Drawing.Size(269, 63);
            this.selectionWayRadio.TabIndex = 29;
            this.selectionWayRadio.TabStop = false;
            this.selectionWayRadio.Text = "Sposób selekcji";
            // 
            // crossingFactorRadio
            // 
            this.crossingFactorRadio.Controls.Add(this.crossingMakingChildsRadio);
            this.crossingFactorRadio.Controls.Add(this.crossingMixingParentsRadio);
            this.crossingFactorRadio.Location = new System.Drawing.Point(502, 63);
            this.crossingFactorRadio.Name = "crossingFactorRadio";
            this.crossingFactorRadio.Size = new System.Drawing.Size(269, 62);
            this.crossingFactorRadio.TabIndex = 30;
            this.crossingFactorRadio.TabStop = false;
            this.crossingFactorRadio.Text = "Współczynnik krzyżowania";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(25, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(451, 416);
            this.tabControl1.TabIndex = 31;
            // 
            // populationNumeric
            // 
            this.populationNumeric.Location = new System.Drawing.Point(502, 210);
            this.populationNumeric.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.populationNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.populationNumeric.Name = "populationNumeric";
            this.populationNumeric.Size = new System.Drawing.Size(269, 20);
            this.populationNumeric.TabIndex = 32;
            this.populationNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // mutationOfPopulationNumeric
            // 
            this.mutationOfPopulationNumeric.Location = new System.Drawing.Point(502, 252);
            this.mutationOfPopulationNumeric.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.mutationOfPopulationNumeric.Name = "mutationOfPopulationNumeric";
            this.mutationOfPopulationNumeric.Size = new System.Drawing.Size(269, 20);
            this.mutationOfPopulationNumeric.TabIndex = 33;
            this.mutationOfPopulationNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // mutationOfAttributeNumeric
            // 
            this.mutationOfAttributeNumeric.Location = new System.Drawing.Point(502, 294);
            this.mutationOfAttributeNumeric.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.mutationOfAttributeNumeric.Name = "mutationOfAttributeNumeric";
            this.mutationOfAttributeNumeric.Size = new System.Drawing.Size(269, 20);
            this.mutationOfAttributeNumeric.TabIndex = 34;
            this.mutationOfAttributeNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // maximumWeightNumeric
            // 
            this.maximumWeightNumeric.DecimalPlaces = 4;
            this.maximumWeightNumeric.Location = new System.Drawing.Point(502, 337);
            this.maximumWeightNumeric.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.maximumWeightNumeric.Name = "maximumWeightNumeric";
            this.maximumWeightNumeric.Size = new System.Drawing.Size(269, 20);
            this.maximumWeightNumeric.TabIndex = 35;
            this.maximumWeightNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // amountOfSelectionsNumeric
            // 
            this.amountOfSelectionsNumeric.Location = new System.Drawing.Point(502, 376);
            this.amountOfSelectionsNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.amountOfSelectionsNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.amountOfSelectionsNumeric.Name = "amountOfSelectionsNumeric";
            this.amountOfSelectionsNumeric.Size = new System.Drawing.Size(269, 20);
            this.amountOfSelectionsNumeric.TabIndex = 36;
            this.amountOfSelectionsNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 482);
            this.Controls.Add(this.amountOfSelectionsNumeric);
            this.Controls.Add(this.maximumWeightNumeric);
            this.Controls.Add(this.mutationOfAttributeNumeric);
            this.Controls.Add(this.mutationOfPopulationNumeric);
            this.Controls.Add(this.populationNumeric);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.crossingFactorRadio);
            this.Controls.Add(this.selectionWayRadio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.startSelectionButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.setViewButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uploadFileTextbox);
            this.Controls.Add(this.selectionProgressBar);
            this.Controls.Add(this.uploadFileButton);
            this.Name = "Form1";
            this.Text = "Problem Plecakowy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.selectionWayRadio.ResumeLayout(false);
            this.selectionWayRadio.PerformLayout();
            this.crossingFactorRadio.ResumeLayout(false);
            this.crossingFactorRadio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.populationNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationOfPopulationNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationOfAttributeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumWeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfSelectionsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.ProgressBar selectionProgressBar;
        private System.Windows.Forms.TextBox uploadFileTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton crossingMakingChildsRadio;
        private System.Windows.Forms.RadioButton selectionTournamentRadio;
        private System.Windows.Forms.RadioButton selectionSteadyStateRadio;
        private System.Windows.Forms.Button setViewButton;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button startSelectionButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton crossingMixingParentsRadio;
        private System.Windows.Forms.GroupBox selectionWayRadio;
        private System.Windows.Forms.GroupBox crossingFactorRadio;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.NumericUpDown populationNumeric;
        private System.Windows.Forms.NumericUpDown mutationOfPopulationNumeric;
        private System.Windows.Forms.NumericUpDown mutationOfAttributeNumeric;
        private System.Windows.Forms.NumericUpDown maximumWeightNumeric;
        private System.Windows.Forms.NumericUpDown amountOfSelectionsNumeric;
    }
}

