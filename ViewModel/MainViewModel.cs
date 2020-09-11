using Elements_of_higher_mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Navigation;

namespace ViewModel
{
    public class MainViewModel : NavigateViewModel
    {

       // public RelayCommand SelectListCommand { get; set; }

        public MainViewModel()
        {
            //SelectListCommand = new RelayCommand(GoToSelectUserMethod);
        }


        //public void GoToSelectUserMethod(object param)
        //{
        //    Navigate("Pages/MatrixesPage.xaml");
        //}

    }
}
