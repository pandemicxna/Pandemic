using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Data;


namespace Pandemic
{
    class CityList
    {
        
        
        public CityList()//Конструктор 
        {
            
        }

        public List<City> Create()// инициализирует данные и создаёт лист City
        {
            
            List<City> listcity = new List<City>();// Список city

            DataTable dt= new DataTable();
            DataTable dt2=new DataTable();
            //подключение к БД
            _mySQLMethods LoadBase= new _mySQLMethods("127.0.0.1","pandemic_bd","root","");
            _mySQLMethods LoadBase2 = new _mySQLMethods("127.0.0.1", "pandemic_bd", "root", "");
            
            dt = LoadBase.Display("SELECT * FROM neighbors");// таблица соседей
            dt2 = LoadBase2.Display("SELECT * FROM city");// таблица городов(координаты, цвет)
            
            
            for (int i = 0; i < dt.Rows.Count/2; i++)
            {
                 City city = new City();// временный город(для записи)
                
                 city.NameCity = dt.Rows[i][0].ToString();//Запись имени города
                
                // запись соседей
                city.Neighbor=new List<string>();
                string s = dt.Rows[i][1].ToString();
                string[] zn = new string[] { " " };
                string[] mas = s.Split(zn, StringSplitOptions.None);
                foreach (var ma in mas)
                {
                   city.Neighbor.Add(ma); 
                }

                listcity.Add(city);//Заполнение листа City
            }

            //запись координат городов
           for (int i = 0; i < dt2.Rows.Count; i++)
            {
                foreach (var city in listcity)
                {
                    if (city.NameCity==dt2.Rows[i][0].ToString())
                    {
                        city.CityPosX = Convert.ToInt32(dt2.Rows[i][1].ToString());
                        city.CityPosY = Convert.ToInt32(dt2.Rows[i][2].ToString());

                    }
                    
                }
                
            }

            return listcity;



        }

    }
}
