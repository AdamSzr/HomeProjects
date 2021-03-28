#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>

struct header {
	std::string magicNumb;
	int width;
	int height;
	int grayScale;

};

class image
{
public:
	header _header;
	std::string fileName;
	int value_of_actual_color;
	int **img;

	image() {};
	image(std::string Fname, std::string MagicNumber, int width, int height, int GS, int val_act_color)
	{
		this->fileName = Fname;
		this->_header.magicNumb = MagicNumber;
		this->_header.width = width;
		this->_header.height = height;
		this->_header.grayScale = GS;
		this->value_of_actual_color = val_act_color;
	}


	//void set_header(std::string Fname, std::string MagicNumber, int width, int height, int GS, int val_act_color )
	//{
	//	this->fileName = Fname;
	//	this->_header.magicNumb = MagicNumber;
	//	this->_header.width = width;
	//	this->_header.height = height;
	//	this->_header.grayScale = GS;
	//	this->value_of_actual_color = val_act_color;
	//};

	void create_table_of_img()
	{
		this->img = new int*[this->_header.width];
		for (int i = 0; i < this->_header.height; ++i) {
			this->img[i] = new int[this->_header.height];
		}
	}
	void delete_table()
	{
		for (int i = 0; i < this->_header.width; ++i) {
			delete[] this->img[i];
		}
		delete[] img;
	}
	void print_table()
	{
		for (int x = 0; x < this->_header.width; x++)
		{
			for (int y = 0; y < this->_header.height; y++)
			{
				std::cout << img[x][y]<<" ";
			}
			std::cout << "\n";
		}
	}
	void print_header()
	{
		std::cout << "File name: " << fileName;
		std::cout << "\nMagic Number: " << _header.magicNumb;
		std::cout << "\nWidth: " << _header.width;
		std::cout << "\nHeight: " << _header.height;
		std::cout << "\nGray Scale: " << _header.grayScale;
	};
	void write_file()
	{
		std::fstream plik;

		plik.open(this->fileName, std::ios::out); 
		plik << _header.magicNumb<<'\n';
		plik << _header.width << " " << _header.height<<'\n';
		plik << _header.grayScale << '\n';

		for (int x = 0; x < this->_header.width; x++)
		{
			for (int y = 0; y < this->_header.height; y++)
			{
				plik << img[x][y] << " ";
			}
			plik<< '\n';
		}

		plik.close(); //zamyka plik
		plik.clear(); //czysci dane z pamieci

	}
	void set_value_in_img_table()
	{
		for (int x = 0; x < this->_header.width; x++)
		{
			for (int y = 0; y < this->_header.height; y++)
			{
				this->img[x][y] = this->value_of_actual_color;
			}
			std::cout << "\n";
		}
	}
};




class img_with_drawind:public  image
{
	public:
		img_with_drawind(std::string Fname)
		{
			this->fileName = Fname;
			std::fstream plik;
			plik.open(this->fileName, std::ios::in);

			if (plik.bad() == true)
			{
				std::cout << "plik bad\n";
			}
			if (plik.good()==true)
			{
				std::cout << "plik good\n";
			}
			if (plik.is_open()==true)
			{
				std::cout << "plik is_open\n";
			}

			getline(plik, this->_header.magicNumb);
			
			std::string pomoc = "";
			plik >> pomoc;
			this->_header.width = string_to_int(pomoc);
			plik >> pomoc;
			this->_header.height = string_to_int(pomoc);
			plik >> pomoc;
			this->_header.grayScale = string_to_int(pomoc);
			for (int i = 0; i < this->_header.height; i++)
			{
				for (int x = 0; x < this->_header.width; x++)
				{
					plik >> pomoc;
					img[i][x] =this->string_to_int(pomoc);
				}
			}
			this->print_header();
			plik.clear();
			plik.close();
		};



	int math_pow(int val, int numb)
	{
		int value = 1;
		for (int i = 0; i < numb; i++)
		{
			value = val * value;
		}
		return value;
	}

	int string_to_int(std::string val)
	{

		int value = 0;
		int val_size = val.size();
		for (int i = 0; i < val.size(); i++)
		{
			value += ((val[i] - 48) * math_pow(10, (val.size() - (i + 1))));
		}
		return value;
	}
};


