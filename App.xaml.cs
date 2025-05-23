﻿using RestaurantAppFullImp.Project.Views;
namespace RestaurantAppFullImp
{
    using RestaurantAppFullImp.Project.Controllers;

    public partial class App : Application
    {
        public static MenuController Menu;
        public static CartController Cart;

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new KioskStartPage()));
        }
        static App()
        {
            Menu = new MenuController();
            Cart = new CartController();
        }
    }
}