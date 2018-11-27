namespace db1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grid3 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.grid2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.grid4 = new System.Windows.Forms.DataGridView();
            this.dset1xsd = new db1.dset1xsd();
            this.nIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIDDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSpendconeAutomationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sClockworkLeggingsDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tEnglishTableAdapter = new db1.dset1xsdTableAdapters.tEnglishTableAdapter();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tIndianTableAdapter = new db1.dset1xsdTableAdapters.tIndianTableAdapter();
            this.tKoreanTableAdapter = new db1.dset1xsdTableAdapters.tKoreanTableAdapter();
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.tMalayTableAdapter = new db1.dset1xsdTableAdapters.tMalayTableAdapter();
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset1xsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "tEnglish";
            this.bindingSource1.DataSource = this.dset1xsd;
            // 
            // grid1
            // 
            this.grid1.AutoGenerateColumns = false;
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIDDataGridViewTextBoxColumn3,
            this.nSpendconeAutomationDataGridViewTextBoxColumn1,
            this.sClockworkLeggingsDataGridViewTextBoxColumn1});
            this.grid1.DataMember = "tEnglish";
            this.grid1.DataSource = this.bindingSource1;
            this.grid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid1.Location = new System.Drawing.Point(26, 77);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(403, 198);
            this.grid1.TabIndex = 0;
            this.grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "English";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(23, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Korean";
            // 
            // grid3
            // 
            this.grid3.AutoGenerateColumns = false;
            this.grid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIDDataGridViewTextBoxColumn1});
            this.grid3.DataMember = "tKorean_tProgram1";
            this.grid3.DataSource = this.bindingSource3;
            this.grid3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid3.Location = new System.Drawing.Point(26, 329);
            this.grid3.Name = "grid3";
            this.grid3.Size = new System.Drawing.Size(403, 198);
            this.grid3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(481, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Indian";
            // 
            // grid2
            // 
            this.grid2.AutoGenerateColumns = false;
            this.grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIDDataGridViewTextBoxColumn});
            this.grid2.DataMember = "tIndian_tProgram1";
            this.grid2.DataSource = this.bindingSource2;
            this.grid2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid2.Location = new System.Drawing.Point(484, 77);
            this.grid2.Name = "grid2";
            this.grid2.Size = new System.Drawing.Size(403, 198);
            this.grid2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(478, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Malay";
            // 
            // btnFill
            // 
            this.btnFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFill.Location = new System.Drawing.Point(130, 22);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(112, 35);
            this.btnFill.TabIndex = 8;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = false;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.Location = new System.Drawing.Point(248, 22);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 35);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(510, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 10;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFind.Location = new System.Drawing.Point(616, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(112, 35);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // grid4
            // 
            this.grid4.AutoGenerateColumns = false;
            this.grid4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIDDataGridViewTextBoxColumn2});
            this.grid4.DataMember = "tMalay_tProgram1";
            this.grid4.DataSource = this.bindingSource4;
            this.grid4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid4.Location = new System.Drawing.Point(478, 329);
            this.grid4.Name = "grid4";
            this.grid4.Size = new System.Drawing.Size(403, 198);
            this.grid4.TabIndex = 12;
            // 
            // dset1xsd
            // 
            this.dset1xsd.DataSetName = "dset1xsd";
            this.dset1xsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nIDDataGridViewTextBoxColumn
            // 
            this.nIDDataGridViewTextBoxColumn.DataPropertyName = "nID";
            this.nIDDataGridViewTextBoxColumn.HeaderText = "nID";
            this.nIDDataGridViewTextBoxColumn.Name = "nIDDataGridViewTextBoxColumn";
            // 
            // nIDDataGridViewTextBoxColumn1
            // 
            this.nIDDataGridViewTextBoxColumn1.DataPropertyName = "nID";
            this.nIDDataGridViewTextBoxColumn1.HeaderText = "nID";
            this.nIDDataGridViewTextBoxColumn1.Name = "nIDDataGridViewTextBoxColumn1";
            // 
            // nIDDataGridViewTextBoxColumn2
            // 
            this.nIDDataGridViewTextBoxColumn2.DataPropertyName = "nID";
            this.nIDDataGridViewTextBoxColumn2.HeaderText = "nID";
            this.nIDDataGridViewTextBoxColumn2.Name = "nIDDataGridViewTextBoxColumn2";
            // 
            // nIDDataGridViewTextBoxColumn3
            // 
            this.nIDDataGridViewTextBoxColumn3.DataPropertyName = "nID";
            this.nIDDataGridViewTextBoxColumn3.HeaderText = "nID";
            this.nIDDataGridViewTextBoxColumn3.Name = "nIDDataGridViewTextBoxColumn3";
            // 
            // nSpendconeAutomationDataGridViewTextBoxColumn1
            // 
            this.nSpendconeAutomationDataGridViewTextBoxColumn1.DataPropertyName = "nSpendconeAutomation";
            this.nSpendconeAutomationDataGridViewTextBoxColumn1.HeaderText = "nSpendconeAutomation";
            this.nSpendconeAutomationDataGridViewTextBoxColumn1.Name = "nSpendconeAutomationDataGridViewTextBoxColumn1";
            // 
            // sClockworkLeggingsDataGridViewTextBoxColumn1
            // 
            this.sClockworkLeggingsDataGridViewTextBoxColumn1.DataPropertyName = "sClockworkLeggings";
            this.sClockworkLeggingsDataGridViewTextBoxColumn1.HeaderText = "sClockworkLeggings";
            this.sClockworkLeggingsDataGridViewTextBoxColumn1.Name = "sClockworkLeggingsDataGridViewTextBoxColumn1";
            // 
            // tEnglishTableAdapter
            // 
            this.tEnglishTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "tIndian";
            this.bindingSource2.DataSource = this.dset1xsd;
            // 
            // tIndianTableAdapter
            // 
            this.tIndianTableAdapter.ClearBeforeFill = true;
            // 
            // tKoreanTableAdapter
            // 
            this.tKoreanTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource3
            // 
            this.bindingSource3.DataMember = "tKorean";
            this.bindingSource3.DataSource = this.dset1xsd;
            // 
            // tMalayTableAdapter
            // 
            this.tMalayTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource4
            // 
            this.bindingSource4.DataMember = "tMalay";
            this.bindingSource4.DataSource = this.dset1xsd;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1015, 595);
            this.Controls.Add(this.grid4);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grid3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid1);
            this.Name = "Form1";
            this.Text = "db1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dset1xsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
           private System.Windows.Forms.DataGridView grid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grid3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grid2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView grid4;
        private dset1xsd dset1xsd;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIDDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSpendconeAutomationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sClockworkLeggingsDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIDDataGridViewTextBoxColumn2;
        private dset1xsdTableAdapters.tEnglishTableAdapter tEnglishTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource2;
        private dset1xsdTableAdapters.tIndianTableAdapter tIndianTableAdapter;
        private dset1xsdTableAdapters.tKoreanTableAdapter tKoreanTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource3;
        private dset1xsdTableAdapters.tMalayTableAdapter tMalayTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource4;
    }
}

