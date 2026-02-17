-- Schemat bazy danych SQLite - FinanceApp2
-- Przykladowe dane do testowania aplikacji

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

-- Domyslne kategorie
INSERT INTO Kategorie (Nazwa) VALUES ('Jedzenie');
INSERT INTO Kategorie (Nazwa) VALUES ('Transport');
INSERT INTO Kategorie (Nazwa) VALUES ('Rozrywka');
INSERT INTO Kategorie (Nazwa) VALUES ('Rachunki');
INSERT INTO Kategorie (Nazwa) VALUES ('Wynagrodzenie');
INSERT INTO Kategorie (Nazwa) VALUES ('Inne');

-- Przykladowe transakcje
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
