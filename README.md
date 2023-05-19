# Struktura-Drzewiasta

Opis projektu: 
Projekt polegał na oprogramowaniu mechanizmu zarządzania strukturą drzewiastą wraz z implementacją poprawnej obsługi formularzy.

Technologie:
Backend: .NET 6.0
Frontend: Blazor WebAssembly
Baza danych: PostgreSQL

Jak uruchomić projekt?
Programy:
	1. Przeglądarka internetowa (np. Google Chrome)
	2. Baza danych PostgreSQL
	3. Program do zarządzania bazą danych: pgAdmin
	4. IDE (opcjonalnie) (np. Visual Studio, JetBrains Rider)

Przygotowanie do uruchomienia:
	1. W aplikacji pgAdmin należy utworzyć użytkownika: 
		a) w zadkładkach po lewej stronie na polu "Login/Group Roles" klikamy prawym przyciskiem myszy i wybieramy "Create"
		b) w zakładce General w polu "Name" wpisujemy: "admin"
		c) w zakładce Definition w polu "Password" wpisujemy: "1qazxsW@"
		d) w zakładce Privileges zaznaczamy wszystkie opcje
		e) klikamy przycisk Save
	2. W aplikacji pgAdmin należy utworzyć bazę danych 
		a) w zadkładkach po lewej stronie na polu Databases klikamy prawym przyciskiem myszy i wybieramy Create
		b) w zakładce General 
			- w polu Database wpisujemy: "StrukturaDrzewiasta"
			- w polu Owner wybieramy wcześniej stworzonego użytkownika "admin"
		c) klikamy przycisk Save

Uruchomienie:
	1. uruchomić IDE zainstalowane na swoim komputerze
	2. otworzyć solucję o nazwie "StrukturaDrzewiasta.sln"
	3.1 używając Visual Studio w polu "Package Manager Console" wpisać komendę "update-database"
	3.2 używając JetBrains Rider w zakładce u góry ekranu o nazwie "Tools" wybrać kolejno: "Entity Framework Core" -> "Update Database" -> "OK"
	4. skompilować projekt o nazwie "StrukturaDrzewiasta.App"
	5. backend aplikacji znajduje się pod adresem "https://localhost:[numer portu]/swagger/index.html"
	6. frontend aplikacji znajduje się pod adresem "https://localhost:[numer portu]"

W razie problemów z uruchomieniem aplikacji proszę o kontakt.

Informacje o autorze
imię i nazwisko: Mikołaj Kuszowski
email: mikolaj.kuszowski@gmail.com
		
