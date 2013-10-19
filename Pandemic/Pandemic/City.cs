using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    class City
    {
        //Количество кубиков в годе
        public int RedCube;
        public int BlueCube;
        public int YellowCube;
        public int BlackCube;
        
        //Координаты города
        public int CityPosX;
        public int CityPosY;

        public string NameCity;// Имя города

        public bool PlayerPos; //нахождение игрока
        public bool Laboratory; //есть ли лаборатория
        public bool Flash; // была ли тут вспышка

        public List<string> Neighbor; //соседи

        public City()
        {
        }


    }
}
