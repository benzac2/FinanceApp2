namespace FinanceApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            dgvTransakcje = new DataGridView();
            btnWczytaj = new Button();
            btnDodajTransakcje = new Button();
            btnUsunTransakcje = new Button();
            btnEdytuj = new Button();
            btnZapisz = new Button();
            lblOpis = new Label();
            txtOpis = new TextBox();
            lblKwota = new Label();
            numKwota = new NumericUpDown();
            lblKategoria = new Label();
            cmbKategoria = new ComboBox();
            lblTyp = new Label();
            cmbTyp = new ComboBox();
            lblData = new Label();
            dtpData = new DateTimePicker();
            lblFiltrOd = new Label();
            dtpOd = new DateTimePicker();
            lblFiltrDo = new Label();
            dtpDo = new DateTimePicker();
            btnFiltruj = new Button();
            txtSzukaj = new TextBox();
            btnSzukaj = new Button();
            btnRaport = new Button();
            groupBox2 = new GroupBox();
            dgvKategorie = new DataGridView();
            btnWczytajKategorie = new Button();
            lblNazwaKategorii = new Label();
            txtNazwaKategorii = new TextBox();
            btnDodajKategorie = new Button();
            btnUsunKategorie = new Button();
            lblPodsumowanie = new Label();
            lblPrzychody = new Label();
            lblWydatki = new Label();
            lblSaldo = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransakcje).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKwota).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKategorie).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRaport);
            groupBox1.Controls.Add(btnSzukaj);
            groupBox1.Controls.Add(txtSzukaj);
            groupBox1.Controls.Add(btnFiltruj);
            groupBox1.Controls.Add(dtpDo);
            groupBox1.Controls.Add(lblFiltrDo);
            groupBox1.Controls.Add(dtpOd);
            groupBox1.Controls.Add(lblFiltrOd);
            groupBox1.Controls.Add(dtpData);
            groupBox1.Controls.Add(lblData);
            groupBox1.Controls.Add(cmbTyp);
            groupBox1.Controls.Add(lblTyp);
            groupBox1.Controls.Add(cmbKategoria);
            groupBox1.Controls.Add(lblKategoria);
            groupBox1.Controls.Add(numKwota);
            groupBox1.Controls.Add(lblKwota);
            groupBox1.Controls.Add(txtOpis);
            groupBox1.Controls.Add(lblOpis);
            groupBox1.Controls.Add(btnZapisz);
            groupBox1.Controls.Add(btnEdytuj);
            groupBox1.Controls.Add(btnUsunTransakcje);
            groupBox1.Controls.Add(btnDodajTransakcje);
            groupBox1.Controls.Add(btnWczytaj);
            groupBox1.Controls.Add(dgvTransakcje);
            groupBox1.Location = new Point(3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1154, 315);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Transakcje";
            // 
            // dgvTransakcje
            // 
            dgvTransakcje.AllowUserToAddRows = false;
            dgvTransakcje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransakcje.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransakcje.Location = new Point(12, 25);
            dgvTransakcje.Name = "dgvTransakcje";
            dgvTransakcje.ReadOnly = true;
            dgvTransakcje.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransakcje.Size = new Size(780, 250);
            dgvTransakcje.TabIndex = 0;
            // 
            // btnWczytaj
            // 
            btnWczytaj.Location = new Point(800, 25);
            btnWczytaj.Name = "btnWczytaj";
            btnWczytaj.Size = new Size(100, 25);
            btnWczytaj.TabIndex = 1;
            btnWczytaj.Text = "Wczytaj";
            btnWczytaj.UseVisualStyleBackColor = true;
            btnWczytaj.Click += btnWczytaj_Click;
            // 
            // btnDodajTransakcje
            // 
            btnDodajTransakcje.Location = new Point(800, 56);
            btnDodajTransakcje.Name = "btnDodajTransakcje";
            btnDodajTransakcje.Size = new Size(100, 25);
            btnDodajTransakcje.TabIndex = 2;
            btnDodajTransakcje.Text = "Dodaj";
            btnDodajTransakcje.UseVisualStyleBackColor = true;
            btnDodajTransakcje.Click += btnDodajTransakcje_Click;
            // 
            // btnUsunTransakcje
            // 
            btnUsunTransakcje.Location = new Point(800, 87);
            btnUsunTransakcje.Name = "btnUsunTransakcje";
            btnUsunTransakcje.Size = new Size(100, 25);
            btnUsunTransakcje.TabIndex = 3;
            btnUsunTransakcje.Text = "Usuń";
            btnUsunTransakcje.UseVisualStyleBackColor = true;
            btnUsunTransakcje.Click += btnUsunTransakcje_Click;
            // 
            // btnEdytuj
            // 
            btnEdytuj.Location = new Point(800, 118);
            btnEdytuj.Name = "btnEdytuj";
            btnEdytuj.Size = new Size(100, 25);
            btnEdytuj.TabIndex = 4;
            btnEdytuj.Text = "Edytuj";
            btnEdytuj.UseVisualStyleBackColor = true;
            btnEdytuj.Click += btnEdytuj_Click;
            // 
            // btnZapisz
            // 
            btnZapisz.Location = new Point(800, 149);
            btnZapisz.Name = "btnZapisz";
            btnZapisz.Size = new Size(100, 25);
            btnZapisz.TabIndex = 5;
            btnZapisz.Text = "Zapisz";
            btnZapisz.UseVisualStyleBackColor = true;
            btnZapisz.Click += btnZapisz_Click;
            // 
            // lblOpis
            // 
            lblOpis.AutoSize = true;
            lblOpis.Location = new Point(920, 28);
            lblOpis.Name = "lblOpis";
            lblOpis.Size = new Size(31, 15);
            lblOpis.TabIndex = 6;
            lblOpis.Text = "Opis";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(990, 25);
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(150, 23);
            txtOpis.TabIndex = 7;
            // 
            // lblKwota
            // 
            lblKwota.AutoSize = true;
            lblKwota.Location = new Point(920, 57);
            lblKwota.Name = "lblKwota";
            lblKwota.Size = new Size(42, 15);
            lblKwota.TabIndex = 8;
            lblKwota.Text = "Kwota";
            // 
            // numKwota
            // 
            numKwota.DecimalPlaces = 2;
            numKwota.Location = new Point(990, 54);
            numKwota.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numKwota.Name = "numKwota";
            numKwota.Size = new Size(150, 23);
            numKwota.TabIndex = 9;
            // 
            // lblKategoria
            // 
            lblKategoria.AutoSize = true;
            lblKategoria.Location = new Point(920, 86);
            lblKategoria.Name = "lblKategoria";
            lblKategoria.Size = new Size(58, 15);
            lblKategoria.TabIndex = 10;
            lblKategoria.Text = "Kategoria";
            // 
            // cmbKategoria
            // 
            cmbKategoria.FormattingEnabled = true;
            cmbKategoria.Location = new Point(990, 83);
            cmbKategoria.Name = "cmbKategoria";
            cmbKategoria.Size = new Size(150, 23);
            cmbKategoria.TabIndex = 11;
            // 
            // lblTyp
            // 
            lblTyp.AutoSize = true;
            lblTyp.Location = new Point(920, 115);
            lblTyp.Name = "lblTyp";
            lblTyp.Size = new Size(26, 15);
            lblTyp.TabIndex = 12;
            lblTyp.Text = "Typ";
            // 
            // cmbTyp
            // 
            cmbTyp.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTyp.FormattingEnabled = true;
            cmbTyp.Items.AddRange(new object[] { "Przychod", "Wydatek" });
            cmbTyp.Location = new Point(990, 112);
            cmbTyp.Name = "cmbTyp";
            cmbTyp.Size = new Size(150, 23);
            cmbTyp.TabIndex = 13;
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(920, 144);
            lblData.Name = "lblData";
            lblData.Size = new Size(32, 15);
            lblData.TabIndex = 14;
            lblData.Text = "Data";
            // 
            // dtpData
            // 
            dtpData.Location = new Point(990, 141);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(150, 23);
            dtpData.TabIndex = 15;
            // 
            // lblFiltrOd
            // 
            lblFiltrOd.AutoSize = true;
            lblFiltrOd.Location = new Point(920, 178);
            lblFiltrOd.Name = "lblFiltrOd";
            lblFiltrOd.Size = new Size(22, 15);
            lblFiltrOd.TabIndex = 16;
            lblFiltrOd.Text = "Od";
            // 
            // dtpOd
            // 
            dtpOd.Location = new Point(990, 175);
            dtpOd.Name = "dtpOd";
            dtpOd.Size = new Size(150, 23);
            dtpOd.TabIndex = 17;
            dtpOd.Value = DateTime.Now.AddMonths(-1);
            // 
            // lblFiltrDo
            // 
            lblFiltrDo.AutoSize = true;
            lblFiltrDo.Location = new Point(920, 207);
            lblFiltrDo.Name = "lblFiltrDo";
            lblFiltrDo.Size = new Size(22, 15);
            lblFiltrDo.TabIndex = 18;
            lblFiltrDo.Text = "Do";
            // 
            // dtpDo
            // 
            dtpDo.Location = new Point(990, 204);
            dtpDo.Name = "dtpDo";
            dtpDo.Size = new Size(150, 23);
            dtpDo.TabIndex = 19;
            // 
            // btnFiltruj
            // 
            btnFiltruj.Location = new Point(990, 233);
            btnFiltruj.Name = "btnFiltruj";
            btnFiltruj.Size = new Size(150, 25);
            btnFiltruj.TabIndex = 20;
            btnFiltruj.Text = "Filtruj wg dat";
            btnFiltruj.UseVisualStyleBackColor = true;
            btnFiltruj.Click += btnFiltruj_Click;
            // 
            // txtSzukaj
            // 
            txtSzukaj.Location = new Point(12, 281);
            txtSzukaj.Name = "txtSzukaj";
            txtSzukaj.PlaceholderText = "Szukaj po opisie...";
            txtSzukaj.Size = new Size(200, 23);
            txtSzukaj.TabIndex = 21;
            // 
            // btnSzukaj
            // 
            btnSzukaj.Location = new Point(218, 281);
            btnSzukaj.Name = "btnSzukaj";
            btnSzukaj.Size = new Size(80, 25);
            btnSzukaj.TabIndex = 22;
            btnSzukaj.Text = "Szukaj";
            btnSzukaj.UseVisualStyleBackColor = true;
            btnSzukaj.Click += btnSzukaj_Click;
            // 
            // btnRaport
            // 
            btnRaport.Location = new Point(310, 281);
            btnRaport.Name = "btnRaport";
            btnRaport.Size = new Size(120, 25);
            btnRaport.TabIndex = 23;
            btnRaport.Text = "Generuj raport";
            btnRaport.UseVisualStyleBackColor = true;
            btnRaport.Click += btnRaport_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnUsunKategorie);
            groupBox2.Controls.Add(btnDodajKategorie);
            groupBox2.Controls.Add(txtNazwaKategorii);
            groupBox2.Controls.Add(lblNazwaKategorii);
            groupBox2.Controls.Add(btnWczytajKategorie);
            groupBox2.Controls.Add(dgvKategorie);
            groupBox2.Location = new Point(3, 325);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(640, 185);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kategorie";
            // 
            // dgvKategorie
            // 
            dgvKategorie.AllowUserToAddRows = false;
            dgvKategorie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategorie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKategorie.Location = new Point(12, 25);
            dgvKategorie.Name = "dgvKategorie";
            dgvKategorie.ReadOnly = true;
            dgvKategorie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKategorie.Size = new Size(400, 150);
            dgvKategorie.TabIndex = 0;
            // 
            // btnWczytajKategorie
            // 
            btnWczytajKategorie.Location = new Point(420, 25);
            btnWczytajKategorie.Name = "btnWczytajKategorie";
            btnWczytajKategorie.Size = new Size(100, 25);
            btnWczytajKategorie.TabIndex = 1;
            btnWczytajKategorie.Text = "Wczytaj";
            btnWczytajKategorie.UseVisualStyleBackColor = true;
            btnWczytajKategorie.Click += btnWczytajKategorie_Click;
            // 
            // lblNazwaKategorii
            // 
            lblNazwaKategorii.AutoSize = true;
            lblNazwaKategorii.Location = new Point(420, 65);
            lblNazwaKategorii.Name = "lblNazwaKategorii";
            lblNazwaKategorii.Size = new Size(42, 15);
            lblNazwaKategorii.TabIndex = 2;
            lblNazwaKategorii.Text = "Nazwa";
            // 
            // txtNazwaKategorii
            // 
            txtNazwaKategorii.Location = new Point(470, 62);
            txtNazwaKategorii.Name = "txtNazwaKategorii";
            txtNazwaKategorii.Size = new Size(150, 23);
            txtNazwaKategorii.TabIndex = 3;
            // 
            // btnDodajKategorie
            // 
            btnDodajKategorie.Location = new Point(420, 91);
            btnDodajKategorie.Name = "btnDodajKategorie";
            btnDodajKategorie.Size = new Size(100, 25);
            btnDodajKategorie.TabIndex = 4;
            btnDodajKategorie.Text = "Dodaj";
            btnDodajKategorie.UseVisualStyleBackColor = true;
            btnDodajKategorie.Click += btnDodajKategorie_Click;
            // 
            // btnUsunKategorie
            // 
            btnUsunKategorie.Location = new Point(420, 122);
            btnUsunKategorie.Name = "btnUsunKategorie";
            btnUsunKategorie.Size = new Size(100, 25);
            btnUsunKategorie.TabIndex = 5;
            btnUsunKategorie.Text = "Usun";
            btnUsunKategorie.UseVisualStyleBackColor = true;
            btnUsunKategorie.Click += btnUsunKategorie_Click;
            // 
            // lblPodsumowanie
            // 
            lblPodsumowanie.AutoSize = true;
            lblPodsumowanie.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPodsumowanie.Location = new Point(660, 340);
            lblPodsumowanie.Name = "lblPodsumowanie";
            lblPodsumowanie.Size = new Size(113, 19);
            lblPodsumowanie.TabIndex = 2;
            lblPodsumowanie.Text = "Podsumowanie:";
            // 
            // lblPrzychody
            // 
            lblPrzychody.AutoSize = true;
            lblPrzychody.Font = new Font("Segoe UI", 9.5F);
            lblPrzychody.ForeColor = Color.Green;
            lblPrzychody.Location = new Point(660, 368);
            lblPrzychody.Name = "lblPrzychody";
            lblPrzychody.Size = new Size(120, 17);
            lblPrzychody.TabIndex = 3;
            lblPrzychody.Text = "Przychody: 0,00 zl";
            // 
            // lblWydatki
            // 
            lblWydatki.AutoSize = true;
            lblWydatki.Font = new Font("Segoe UI", 9.5F);
            lblWydatki.ForeColor = Color.Red;
            lblWydatki.Location = new Point(660, 393);
            lblWydatki.Name = "lblWydatki";
            lblWydatki.Size = new Size(107, 17);
            lblWydatki.TabIndex = 4;
            lblWydatki.Text = "Wydatki: 0,00 zl";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSaldo.Location = new Point(660, 418);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(96, 19);
            lblSaldo.TabIndex = 5;
            lblSaldo.Text = "Saldo: 0,00 zl";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 520);
            Controls.Add(lblSaldo);
            Controls.Add(lblWydatki);
            Controls.Add(lblPrzychody);
            Controls.Add(lblPodsumowanie);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "FinanseOsobiste";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransakcje).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKwota).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKategorie).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvTransakcje;
        private Button btnWczytaj;
        private Button btnDodajTransakcje;
        private Button btnUsunTransakcje;
        private Button btnEdytuj;
        private Button btnZapisz;
        private Label lblOpis;
        private TextBox txtOpis;
        private Label lblKwota;
        private NumericUpDown numKwota;
        private Label lblKategoria;
        private ComboBox cmbKategoria;
        private Label lblTyp;
        private ComboBox cmbTyp;
        private Label lblData;
        private DateTimePicker dtpData;
        private Label lblFiltrOd;
        private DateTimePicker dtpOd;
        private Label lblFiltrDo;
        private DateTimePicker dtpDo;
        private Button btnFiltruj;
        private TextBox txtSzukaj;
        private Button btnSzukaj;
        private Button btnRaport;
        private GroupBox groupBox2;
        private DataGridView dgvKategorie;
        private Button btnWczytajKategorie;
        private Label lblNazwaKategorii;
        private TextBox txtNazwaKategorii;
        private Button btnDodajKategorie;
        private Button btnUsunKategorie;
        private Label lblPodsumowanie;
        private Label lblPrzychody;
        private Label lblWydatki;
        private Label lblSaldo;
    }
}
