#include <iostream>
#include <string>

using namespace std;

typedef struct skladnik_kolejki *wsk_do_skladnika_kolejki;

struct skladnik_kolejki
{
	string imie, nazwisko;
	wsk_do_skladnika_kolejki wsk_do_nast_elementu;
};

wsk_do_skladnika_kolejki z_kolejki(wsk_do_skladnika_kolejki x)
{
	wsk_do_skladnika_kolejki wsk_pom;
	wsk_pom=x->wsk_do_nast_elementu;
	cout<<"Imie usunietego elementu - "<<x->imie<<endl;
	cout<<"Nazwisko usunietego elementu - " <<x->nazwisko<<endl;
	delete x;
	return wsk_pom;
};

wsk_do_skladnika_kolejki do_kolejki(wsk_do_skladnika_kolejki x, skladnik_kolejki y) {
	wsk_do_skladnika_kolejki wsk_pom;
	wsk_pom = new skladnik_kolejki;
	wsk_pom->imie = y.imie;
	wsk_pom->nazwisko = y.nazwisko;
	if(x!=0) x->wsk_do_nast_elementu = wsk_pom;
	wsk_pom->wsk_do_nast_elementu = 0;
	return wsk_pom;
}

skladnik_kolejki stworz_skladnik_kolejki() {
	skladnik_kolejki nowy_skladnik;
	cout<<"Podaj Imie: ";
	cin >> nowy_skladnik.imie;
	cout<<"Podaj nazwisko: ";
	cin >> nowy_skladnik.nazwisko;
	return nowy_skladnik;
}

int main()
{
	wsk_do_skladnika_kolejki pierwszy = 0, ostatni = 0;
	char c = 0;
	while(c != 'w') {
		cout << "d - dodaj element do kolejki" << endl;
		cout << "u - usun element z kolejki" << endl;
		cout << "w - wyjscie" << endl;
		c = getchar();
		system("CLS");
		switch(c) {
		case 'd':
			ostatni = do_kolejki(ostatni, stworz_skladnik_kolejki());
			if(pierwszy == 0) {
				pierwszy = ostatni;
			}
			break;
		case 'u':
			if(pierwszy != 0) {
				pierwszy = z_kolejki(pierwszy);
			}
			else {
				cout << "kolejka jest pusta" << endl;
			}
			system("PAUSE");
		default:
			cout << "niepoprawna opcja" << endl;
			break;
		}
		system("CLS");
	}
	return 0;
}
