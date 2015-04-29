using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WTF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const int MAPSIZEX = 12;
        const int MAPSIZEY = 16;
        FieldObject[,] map;
        Vector currentPosition;

        public MainWindow()
        {

            InitializeComponent();

        }

        private void createNewCityClick(object sender, RoutedEventArgs e)
        {

            Vector tmpPosition;
            Vector firestationPos;
            int streetFieldAmount = (int) MAPSIZEX * MAPSIZEY / 4; //amount of streetfields
            this.map = new FieldObject[MAPSIZEX, MAPSIZEY];
            createRiver();

            //create firestation position
            Random rnd = new Random();
            int x = rnd.Next(0, MAPSIZEX);
            int y = rnd.Next(0, MAPSIZEY);
            this.currentPosition = new Vector(x, y);
            firestationPos = this.currentPosition;

            this.map[x, y] = new Firestation(currentPosition);

            for (int i = 0; i < streetFieldAmount - 1; i++)
            {

                tmpPosition = getNextField();

                if (tmpPosition == null)
                {

                    this.currentPosition = firestationPos;

                }
                else {

                    this.currentPosition = tmpPosition;
                
                }
                if (i == streetFieldAmount / 2)
                {

                    this.currentPosition = firestationPos;

                }

            }

            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {

                    if (map[i, j] == null)
                    {

                        map[i, j] = new Tree(new Vector(i, j), false);

                    }

                }

            }

            CreateMap.Print(canvasMap, map);

        }

        public Vector getNextField()
        {

            List<Vector> possibleFields = new List<Vector>();
            Random rnd = new Random();
            Vector newPos;

            if (checkTop() != null)
            {
                possibleFields.Add(checkTop());
            }

            if (checkRight() != null)
            {
                possibleFields.Add(checkRight());
            }

            if (checkLeft() != null)
            {
                possibleFields.Add(checkLeft());
            }

            if (checkBottom() != null)
            {
                possibleFields.Add(checkBottom());
            }

            if (possibleFields.Count == 0)
            {

                return null;

            }
            else if (possibleFields.Count > 1)
            {

                int randomField = rnd.Next(0, possibleFields.Count);
                int x = possibleFields[randomField].getPositonX();
                int y = possibleFields[randomField].getPositonY();
                newPos = new Vector(x, y);

                this.map[x, y] = new Street(map, new Vector(x, y));

                possibleFields.RemoveAt(randomField);

                randomField = rnd.Next(0, possibleFields.Count);
                x = possibleFields[randomField].getPositonX();
                y = possibleFields[randomField].getPositonY();

                this.map[x, y] = new House(new Vector(x, y));

                return newPos;

            }
            else
            {

                int x = possibleFields[0].getPositonX();
                int y = possibleFields[0].getPositonY();
                newPos = new Vector(x, y);

                this.map[x, y] = new Street(map, new Vector(x, y));

                return newPos;

            }

        }

        public void createRiver(){

            Random rnd = new Random();
            int startField;

            //check if horizontal or vertical
            if(rnd.Next(0,2) == 0){

                startField = rnd.Next(0, (MAPSIZEX - 1));
                
                for (int i = 0; i < (MAPSIZEY - 1); i++)
                {

                    this.map[startField, i] = new River(new Vector(startField, i));

                }

            }
            else
            {

                startField = rnd.Next(0, (MAPSIZEY - 1));

                for (int i = 0; i < (MAPSIZEX - 1); i++)
                {

                    this.map[i, startField] = new River(new Vector(startField, i));

                }

            }

        }

        public Vector checkTop()
        {
            int x = this.currentPosition.getPositonX();
            int y = this.currentPosition.getPositonY() - 1;

            if (y > 0 && this.map[x, y] == null)
                return new Vector(x, y);
            else if (y > 0 && this.map[x, y].getObjectType() == "river")
                return new Vector(x, y);

            return null;
        }

        public Vector checkLeft()
        {
            int x = this.currentPosition.getPositonX() - 1;
            int y = this.currentPosition.getPositonY();

            if (x > 0 && this.map[x, y] == null)
                return new Vector(x, y);
            else if (x > 0 && this.map[x, y].getObjectType() == "river")
                return new Vector(x, y);

            return null;
        }

        public Vector checkRight()
        {

            int x = this.currentPosition.getPositonX() + 1;
            int y = this.currentPosition.getPositonY();

            if (x < this.map.GetLength(0) && this.map[x, y] == null)
                return new Vector(x, y);
            else if (x < this.map.GetLength(0) && this.map[x, y].getObjectType() == "river")
                return new Vector(x, y);

            return null;

        }

        public Vector checkBottom()
        {

            int x = this.currentPosition.getPositonX();
            int y = this.currentPosition.getPositonY() + 1;

            if (y < this.map.GetLength(1) && this.map[x, y] == null)
                return new Vector(x, y);
            else if (y < this.map.GetLength(1) && this.map[x, y].getObjectType() == "river")
                return new Vector(x, y);

            return null;

        }

        private void startFireClick(object sender, RoutedEventArgs e)
        {
            


        }

        private void showMissionsClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void exitProgramClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void startProgramClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
    
}
