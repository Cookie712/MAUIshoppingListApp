## Zrzut ekranu aplikacji 📸

![Screenshot 2025-01-06 111349](https://github.com/user-attachments/assets/6f302c15-1732-415e-8ef4-d18333a99a53)

# Lista Zakupów 🛍️

Aplikacja **Lista Zakupów** to praktyczne narzędzie do zarządzania listą zakupów.
Aplikacja wykorzystuje platformę .NET MAUI, co pozwala na jej działanie na wielu urządzeniach.

## Funkcjonalności 🔗

### Główne cechy aplikacji:

-   🗋 **Przechowywanie danych:**

    -   Lista zakupów jest zapisywana w formacie plików JSON, co zapewnia trwałość i łatwość modyfikacji.

-   🕹️ **Podział na widoki i modele danych:**
    -   Projekt został podzielony na oddzielne warstwy widoków (Views) i modeli danych (Models) dla przejrzystości i łatwego rozwoju.

## Właściwości interfejsu 🎨

Każdy produkt na liście zakupów jest reprezentowany za pomocą komponentu **ContentView**, posiadającego:

-   🔹 **Nazwę produktu**: np. "Mleko", "Chleb"
-   🔹 **Jednostkę miary**: np. szt., l, kg
-   🔹 **Zaznaczenie produktu jako kupionego**:
    -   Kupione produkty są wyszarzone i przenoszone na koniec listy.
-   🔹 **Określenie ilości**:
    -   Można wprowadzić wartość liczbową z klawiatury lub skorzystać z przycisków "+" i "-" w celu zmiany ilości o jeden.
-   🔹 **Usuwanie produktu**:
    -   Produkty można całkowicie usunąć z listy.

## Technologie i narzędzia ⚙️

-   **Framework:** .NET MAUI
-   **Język programowania:** C#
-   **Format przechowywania danych:** JSON
-   **IDE:** Microsoft Visual Studio

## Instrukcja użytkowania 🔄

1. **Dodanie produktu:**

    - Wprowadź nazwę produktu, jednostkę miary oraz ilość. Kliknij przycisk "Add".

2. **Edytowanie ilości:**

    - Użyj przycisków "+" i "-", aby zmienić ilość produktu.

3. **Zaznaczenie jako kupionego:**

    - Kliknij przycisk "Bought", aby oznaczyć produkt jako kupiony. Zostanie on wyszarzony i przeniesiony na koniec listy.

4. **Usunięcie produktu:**
    - Kliknij przycisk "Delete", aby usunąć produkt z listy.

## Wymagania systemowe 🛠️

-   **System operacyjny:** Windows 10, macOS, Android, iOS
-   **Wersja .NET:** .NET 8.0
-   **Wolne miejsce na dysku:** Min. 50 MB

## Jak uruchomić projekt? ⚔️

1. **Klonowanie repozytorium:**

    ```bash
    git clone https://github.com/Cookie712/MAUIshoppingListApp
    cd MAUIshoppingListApp
    ```

2. **Otwórz projekt w Visual Studio.**

3. **Uruchom aplikację:**
    - Wybierz docelową platformę (np. Windows, Android) i kliknij przycisk "Run".

## Autor 🎮

-   **Imię i nazwisko**: Dawid Chwist
-   **Kontakt:** https://github.com/Cookie712

## Licencja 🔒

Ten projekt jest licencjonowany na zasadach licencji MIT.

---

Dziękuje za skorzystanie z aplikacji i życzę udanych zakupów! ✨
