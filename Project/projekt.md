# Projekt

## **Hormonogram pracy dla Sklepu Akwarystycznego**

**Okno Logowania**
   1. Pole do wprowadzania danych logowania oraz przycisk do logowania
   2. Komunikaty błędów logowania (nieprawidłowy login lub hasło)
   3. Tymczasowe dane logowania (admin/admin)

**Tabele**
  1. Tabelka z produktami(Produkt)
      1. Zawartość tabel
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

  2. Tabelka z zamówieniami(Zamowienia)
      1. Zawartość tabel
          1. id_zamowienia
          2. id_produktu
          3. sztuk
      2. Pola do tworzenia
          1. ID Zamowienia
          2. Ilosc
          3. Odebrano 0/1
      3. Przyciski
          1. Wyślij
          2. Refresh 

  3. Tabelka z klientami(Klienci)
      1. Zawartość tabel
          1. id_klient
          2. imie
          3. nazwisko
          4. telefon
          5. dres_email
          6. adres
          7. kodpocztowy
          8. miejscowośc
          9. klient_staly
      2. Pola do tworzenia
          1. imie
          2. nazwisko
          3. telefon   
          4. adres_email
          5. kodpocztowy
          6. miejscowośc
          7. lient_staly
      3. Przyciski
          1. Wyślij
          2. Refresh

  4. Tabelka z users(Users)
      1. Zawartość tabel
          1. id_user
          2. login
          3. password
      2. Pola do tworzenia
          1. Username
          2. Password
      3. Przyciski
          1. Log in

#### Techniczne

1. **Baza danych**
    1. Tabela Produkt
    2. Tabela Zamowienia
    3. Tabela Klienci
    4. Tabelka Users
2. **ORM - operacje na bazie**
    1. Dodawanie rekordów w bazie
    2. Pobieranie rekordów z bazy
    3. Usuwanie rekordów z bazy
    4. Aktualizacja rekordów z bazy
3. **Walidacja danych**
    1. Podczas logowania
    2. Podczas dodawania danych

