using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listOfDishes
{
    internal class PageController
    {

        private static DishCreationPage _dishCreationPage;
        public static DishCreationPage DishCreationPage
        {
            get
            {
                if (_dishCreationPage == null) 
                {
                    _dishCreationPage = new DishCreationPage();
                }
                return _dishCreationPage;
            }
        }

        private static MainPage _mainPage;
        public static MainPage MainPage
        {
            get
            {
                if (_mainPage == null)
                {
                    _mainPage = new MainPage();
                }
                return _mainPage;
            }
        }
    }
}
