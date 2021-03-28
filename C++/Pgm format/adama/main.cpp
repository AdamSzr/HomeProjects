#include <fstream>
#include <iostream>
#include <string>
#include "header.h"
using namespace std;
int main(int argc, char *argv[])
{
	cout << "to jest ten plik";
	//
	////   ----------------------------------------Tworzenie pustej grafiki-------------------------------------------
	//image test("tak.txt", "P2", 30, 30, 30, 0);
	//test.print_header();
	//test.create_table_of_img();
	//test.set_value_in_img_table();
	//test.print_table();
	//test.write_file();
	//test.delete_table();
	//// ------------------------------------------Edycja stworzonej grafiki-----------------------------------------
	img_with_drawind test("ta.pgm");
	test.print_header();









	system("pause");
	return(0);
}