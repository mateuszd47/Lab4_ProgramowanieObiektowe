# Projekt

## **Hormonogram pracy dla Sklepu Akwarystycznego**

1. **Okno Logowania**
    1. Pole do wprowadzania danych logowania oraz przycisk do logowania
    2. Komunikaty błędów logowania (nieprawidłowy login lub hasło)
    3. Tymczasowe dane logowania (admin/admin)

2. **Tabele**
    1. Tabelka z produktami(Produkt)
        1. id_produktu
        2. nazwa_produktu
        3. cenna_netto
        4. cenna_brutto
        5. id_kategoria (klucz obcy połączony z tabelą Kategoria)
        6. dostepnych_sztuk
        7. dostepny
    2. Pola do tworzenia
        1. Nazwa Produktu
        2. Kategoria podawana w cyfrach 1-9 zgodna z tabelą Kategoria
        3. Cena Netto
        4. Cena Brutto
        5. Ilosc
        6. Dostepnosc
    3. Przyciski
        1. Send(create)
        2. Update
        3. Delete

#### Techniczne

1. **Baza danych**
    1. Tabela Klienci
    2. Tabela Produkt
    3. Tabelka Users
    4. Tabela Zamowienia
2. **ORM - operacje na bazie**
    1. Dodawanie rekordów w bazie
    2. Pobieranie rekordów z bazy
    3. Usuwanie rekordów z bazy
    4. Aktualizacja rekordów z bazy
3. **Walidacja danych**
    1. Podczas logowania
    2. Podczas dodawania danych
