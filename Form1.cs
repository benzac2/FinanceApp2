using System;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace FinanceApp2
{
    public partial class Form1 : Form
    {
        // Connection string do lokalnej bazy
        string polaczenie = "Data Source=finanse.db";

        int idEdytowanejTransakcji = 0;

        public Form1()
        {
            InitializeComponent();
            UtworzBaze();
            ZaladujKategorie();
            OdswiezTransakcje();
            OdswiezKategorie();
            OdswiezPodsumowanie();
        }

        // Tworzenie tabel w SQLite przy pierwszym uruchomieniu
        private void UtworzBaze()
        {
            using (var conn = new SqliteConnection(polaczenie))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Kategorie (
                        ID_Kategorii INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nazwa TEXT NOT NULL UNIQUE
                    );

                    CREATE TABLE IF NOT EXISTS Transakcje (
                        ID_Transakcji INTEGER PRIMARY KEY AUTOINCREMENT,
                        Opis TEXT NOT NULL,
                        Kwota REAL NOT NULL,
                        Typ TEXT NOT NULL,
                        Data TEXT NOT NULL,
                        ID_Kategorii INTEGER,
                        FOREIGN KEY (ID_Kategorii) REFERENCES Kategorie(ID_Kategorii)
                    );

                    CREATE TABLE IF NOT EXISTS Konto (
                        ID_Konta INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nazwa TEXT NOT NULL,
                        Saldo REAL DEFAULT 0
                    );
                ";
                cmd.ExecuteNonQuery();

                // Wstawiamy domyslne kategorie jesli tabela pusta
                cmd.CommandText = "SELECT COUNT(*) FROM Kategorie";
                long count = (long)cmd.ExecuteScalar()!;
                if (count == 0)
                {
                    cmd.CommandText = @"
                        INSERT INTO Kategorie (Nazwa) VALUES ('Jedzenie');
                        INSERT INTO Kategorie (Nazwa) VALUES ('Transport');
                        INSERT INTO Kategorie (Nazwa) VALUES ('Rozrywka');
                        INSERT INTO Kategorie (Nazwa) VALUES ('Rachunki');
                        INSERT INTO Kategorie (Nazwa) VALUES ('Wynagrodzenie');
                        INSERT INTO Kategorie (Nazwa) VALUES ('Inne');
                    ";
                    cmd.ExecuteNonQuery();
                }

                // Wstawiamy przykladowe transakcje jesli tabela pusta
                cmd.CommandText = "SELECT COUNT(*) FROM Transakcje";
                long countT = (long)cmd.ExecuteScalar()!;
                if (countT == 0)
                {
                    cmd.CommandText = @"
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Wyplata za styczen', 4500.00, 'Przychod', '2026-01-10', 5);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Zakupy spozywcze Biedronka', 187.50, 'Wydatek', '2026-01-12', 1);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Bilet miesiczny MPK', 110.00, 'Wydatek', '2026-01-15', 2);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Rachunek za prad', 220.00, 'Wydatek', '2026-01-18', 4);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Kino z przyjaciolmi', 45.00, 'Wydatek', '2026-01-20', 3);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Zakupy Lidl', 132.80, 'Wydatek', '2026-01-22', 1);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Premia kwartalna', 1200.00, 'Przychod', '2026-01-25', 5);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Internet i telefon', 89.00, 'Wydatek', '2026-01-28', 4);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Wyplata za luty', 4500.00, 'Przychod', '2026-02-10', 5);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Zakupy spozywcze', 205.30, 'Wydatek', '2026-02-11', 1);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Paliwo do samochodu', 280.00, 'Wydatek', '2026-02-13', 2);
                        INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii) VALUES ('Rachunek za gaz', 175.00, 'Wydatek', '2026-02-15', 4);
                    ";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Pobieranie kategorii do comboboxa
        private void ZaladujKategorie()
        {
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT ID_Kategorii, Nazwa FROM Kategorie ORDER BY Nazwa";

                    DataTable dt = new DataTable();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }

                    cmbKategoria.DataSource = dt;
                    cmbKategoria.DisplayMember = "Nazwa";
                    cmbKategoria.ValueMember = "ID_Kategorii";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad ladowania kategorii: " + ex.Message);
            }
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            OdswiezTransakcje();
            OdswiezPodsumowanie();
        }

        // Wyswietlanie transakcji w tabeli, JOIN zeby pokazac nazwe kategorii zamiast ID
        private void OdswiezTransakcje()
        {
            string sql = @"SELECT t.ID_Transakcji, t.Opis, t.Kwota, t.Typ, t.Data, 
                          k.Nazwa AS Kategoria
                          FROM Transakcje t
                          LEFT JOIN Kategorie k ON t.ID_Kategorii = k.ID_Kategorii
                          ORDER BY t.Data DESC";
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;

                    DataTable dt = new DataTable();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    dgvTransakcje.DataSource = dt;

                    if (dgvTransakcje.Columns.Contains("ID_Transakcji"))
                        dgvTransakcje.Columns["ID_Transakcji"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad wyswietlania: " + ex.Message);
            }
        }

        // Dodawanie transakcji
        private void btnDodajTransakcje_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text) || cmbTyp.SelectedIndex < 0)
            {
                MessageBox.Show("Uzupelnij opis i wybierz typ!");
                return;
            }

            string sql = @"INSERT INTO Transakcje (Opis, Kwota, Typ, Data, ID_Kategorii)
                          VALUES (@opis, @kwota, @typ, @data, @idK)";
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@opis", txtOpis.Text);
                        cmd.Parameters.AddWithValue("@kwota", (double)numKwota.Value);
                        cmd.Parameters.AddWithValue("@typ", cmbTyp.SelectedItem!.ToString()!);
                        cmd.Parameters.AddWithValue("@data", dtpData.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@idK", cmbKategoria.SelectedValue!);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Dodano transakcje!");
                OdswiezTransakcje();
                OdswiezPodsumowanie();
                WyczyscFormularz();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad zapisu: " + ex.Message);
            }
        }

        private void btnUsunTransakcje_Click(object sender, EventArgs e)
        {
            if (dgvTransakcje.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz transakcje do usuniecia!");
                return;
            }

            // Pobieramy ID zaznaczonej transakcji
            int idDoUsuniecia = Convert.ToInt32(dgvTransakcje.SelectedRows[0].Cells["ID_Transakcji"].Value);

            DialogResult decyzja = MessageBox.Show($"Czy na pewno usunac transakcje o ID: {idDoUsuniecia}?",
                "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (decyzja == DialogResult.No) return;

            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Transakcje WHERE ID_Transakcji = @id";
                    cmd.Parameters.AddWithValue("@id", idDoUsuniecia);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Transakcja usunieta!");
                OdswiezTransakcje();
                OdswiezPodsumowanie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie mozna usunac: " + ex.Message);
            }
        }

        // Przycisk Edytuj - pobiera dane do formularza
        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dgvTransakcje.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz transakcje do edycji!");
                return;
            }

            // Pobieramy wiersz
            DataGridViewRow wiersz = dgvTransakcje.SelectedRows[0];

            // Wyciagamy ID do zmiennej zeby wiedziec co nadpisac
            idEdytowanejTransakcji = Convert.ToInt32(wiersz.Cells["ID_Transakcji"].Value);
            txtOpis.Text = wiersz.Cells["Opis"].Value?.ToString() ?? "";
            numKwota.Value = Convert.ToDecimal(wiersz.Cells["Kwota"].Value);
            cmbTyp.Text = wiersz.Cells["Typ"].Value?.ToString() ?? "";
            cmbKategoria.Text = wiersz.Cells["Kategoria"].Value?.ToString() ?? "";

            string dataStr = wiersz.Cells["Data"].Value?.ToString() ?? "";
            if (DateTime.TryParse(dataStr, out DateTime parsedDate))
                dtpData.Value = parsedDate;
        }

        // Przycisk Zapisz - aktualizuje dane po edycji
        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (idEdytowanejTransakcji == 0)
            {
                MessageBox.Show("Najpierw kliknij 'Edytuj', zeby pobrac transakcje!");
                return;
            }

            string sql = @"UPDATE Transakcje 
                          SET Opis=@opis, Kwota=@kwota, Typ=@typ, Data=@data, ID_Kategorii=@idK
                          WHERE ID_Transakcji = @id";
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@opis", txtOpis.Text);
                        cmd.Parameters.AddWithValue("@kwota", (double)numKwota.Value);
                        cmd.Parameters.AddWithValue("@typ", cmbTyp.SelectedItem!.ToString()!);
                        cmd.Parameters.AddWithValue("@data", dtpData.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@idK", cmbKategoria.SelectedValue!);
                        cmd.Parameters.AddWithValue("@id", idEdytowanejTransakcji);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Dane zaktualizowane!");
                OdswiezTransakcje();
                OdswiezPodsumowanie();
                WyczyscFormularz();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad edycji: " + ex.Message);
            }
        }

        // Filtrowanie transakcji po zakresie dat
        private void btnFiltruj_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT t.ID_Transakcji, t.Opis, t.Kwota, t.Typ, t.Data,
                          k.Nazwa AS Kategoria
                          FROM Transakcje t
                          LEFT JOIN Kategorie k ON t.ID_Kategorii = k.ID_Kategorii
                          WHERE t.Data BETWEEN @od AND @do
                          ORDER BY t.Data DESC";
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@od", dtpOd.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@do", dtpDo.Value.ToString("yyyy-MM-dd"));

                    DataTable dt = new DataTable();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    dgvTransakcje.DataSource = dt;

                    if (dgvTransakcje.Columns.Contains("ID_Transakcji"))
                        dgvTransakcje.Columns["ID_Transakcji"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad filtrowania: " + ex.Message);
            }
        }

        // Wyszukiwanie po opisie
        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT t.ID_Transakcji, t.Opis, t.Kwota, t.Typ, t.Data,
                          k.Nazwa AS Kategoria
                          FROM Transakcje t
                          LEFT JOIN Kategorie k ON t.ID_Kategorii = k.ID_Kategorii
                          WHERE t.Opis LIKE @szukaj
                          ORDER BY t.Data DESC";
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@szukaj", "%" + txtSzukaj.Text + "%");

                    DataTable dt = new DataTable();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    dgvTransakcje.DataSource = dt;

                    if (dgvTransakcje.Columns.Contains("ID_Transakcji"))
                        dgvTransakcje.Columns["ID_Transakcji"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad wyszukiwania: " + ex.Message);
            }
        }

        // Generowanie raportu do pliku txt za wybrany okres
        private void btnRaport_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT t.Opis, t.Kwota, t.Typ, t.Data, k.Nazwa AS Kategoria
                          FROM Transakcje t
                          LEFT JOIN Kategorie k ON t.ID_Kategorii = k.ID_Kategorii
                          WHERE t.Data BETWEEN @od AND @do
                          ORDER BY t.Data";
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@od", dtpOd.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@do", dtpDo.Value.ToString("yyyy-MM-dd"));

                    decimal przychody = 0, wydatki = 0;
                    var linie = new System.Collections.Generic.List<string>();
                    linie.Add($"RAPORT FINANSOWY: {dtpOd.Value:yyyy-MM-dd} - {dtpDo.Value:yyyy-MM-dd}");
                    linie.Add(new string('-', 70));
                    linie.Add(string.Format("{0,-25} {1,10} {2,-10} {3,-12} {4,-15}", "Opis", "Kwota", "Typ", "Data", "Kategoria"));
                    linie.Add(new string('-', 70));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string typ = reader.GetString(2);
                            decimal kwota = Convert.ToDecimal(reader.GetDouble(1));
                            if (typ == "Przychod") przychody += kwota;
                            else wydatki += kwota;

                            linie.Add(string.Format("{0,-25} {1,10:N2} {2,-10} {3,-12} {4,-15}",
                                reader.GetString(0), kwota, typ, reader.GetString(3),
                                reader.IsDBNull(4) ? "-" : reader.GetString(4)));
                        }
                    }

                    linie.Add(new string('-', 70));
                    linie.Add($"Przychody: {przychody:N2} zl");
                    linie.Add($"Wydatki:   {wydatki:N2} zl");
                    linie.Add($"Saldo:     {(przychody - wydatki):N2} zl");

                    // Okno zapisu pliku
                    var sfd = new SaveFileDialog();
                    sfd.Filter = "Plik tekstowy|*.txt";
                    sfd.FileName = $"raport_{dtpOd.Value:yyyyMMdd}_{dtpDo.Value:yyyyMMdd}.txt";
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllLines(sfd.FileName, linie);
                        MessageBox.Show($"Raport zapisany do pliku:\n{sfd.FileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad generowania raportu: " + ex.Message);
            }
        }

        private void btnWczytajKategorie_Click(object sender, EventArgs e)
        {
            OdswiezKategorie();
        }

        // Wyswietlanie kategorii w tabeli
        private void OdswiezKategorie()
        {
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT ID_Kategorii, Nazwa FROM Kategorie ORDER BY Nazwa";

                    DataTable dt = new DataTable();
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    dgvKategorie.DataSource = dt;

                    if (dgvKategorie.Columns.Contains("ID_Kategorii"))
                        dgvKategorie.Columns["ID_Kategorii"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad wczytywania kategorii: " + ex.Message);
            }
        }

        private void btnDodajKategorie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazwaKategorii.Text))
            {
                MessageBox.Show("Podaj nazwe kategorii!");
                return;
            }

            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Kategorie (Nazwa) VALUES (@nazwa)";
                    cmd.Parameters.AddWithValue("@nazwa", txtNazwaKategorii.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Kategoria dodana!");
                txtNazwaKategorii.Text = "";
                OdswiezKategorie();
                ZaladujKategorie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad dodawania kategorii: " + ex.Message);
            }
        }

        private void btnUsunKategorie_Click(object sender, EventArgs e)
        {
            if (dgvKategorie.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz kategorie do usuniecia!");
                return;
            }

            int idKat = Convert.ToInt32(dgvKategorie.SelectedRows[0].Cells["ID_Kategorii"].Value);

            if (MessageBox.Show("Usunac te kategorie?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Kategorie WHERE ID_Kategorii = @id";
                    cmd.Parameters.AddWithValue("@id", idKat);
                    cmd.ExecuteNonQuery();
                }
                OdswiezKategorie();
                ZaladujKategorie();
                MessageBox.Show("Kategoria usunieta.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad usuwania: " + ex.Message);
            }
        }

        // Podsumowanie przychodow i wydatkow
        private void OdswiezPodsumowanie()
        {
            try
            {
                using (var conn = new SqliteConnection(polaczenie))
                {
                    conn.Open();

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT COALESCE(SUM(Kwota),0) FROM Transakcje WHERE Typ='Przychod'";
                    decimal przychody = Convert.ToDecimal(cmd.ExecuteScalar());

                    cmd.CommandText = "SELECT COALESCE(SUM(Kwota),0) FROM Transakcje WHERE Typ='Wydatek'";
                    decimal wydatki = Convert.ToDecimal(cmd.ExecuteScalar());

                    decimal saldo = przychody - wydatki;

                    lblPrzychody.Text = $"Przychody: {przychody:N2} zl";
                    lblWydatki.Text = $"Wydatki: {wydatki:N2} zl";
                    lblSaldo.Text = $"Saldo: {saldo:N2} zl";
                    lblSaldo.ForeColor = saldo >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podsumowania: " + ex.Message);
            }
        }

        private void WyczyscFormularz()
        {
            // Czysc pola
            txtOpis.Text = "";
            numKwota.Value = 0;

            // Listy rozwijane - ustawienie na -1 = nic nie wybrane
            cmbTyp.SelectedIndex = -1;
            cmbKategoria.SelectedIndex = -1;

            dtpData.Value = DateTime.Now;
            idEdytowanejTransakcji = 0;
        }
    }
}
