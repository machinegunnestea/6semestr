using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UI.Model;
using UI.View;
using ВLL.DTO;
using ВLL.Interfaces.EntityServices;
using BLL.Interfaces.EntityServices;

namespace UI.ViewModel
{
    public class DataMangeVM:INotifyPropertyChanged
    {
        private ICarService _carService;
        private ICarTypeService _carTypeService;
        private IUserService _userService;
        public DataMangeVM(ICarService carService, ICarTypeService carTypeService, IUserService userService)
        {
            _carService = carService;
            _carTypeService = carTypeService;
            _userService = userService;
            carDTO = _carService.Get().ToList();
            carTypeDTOs=_carTypeService.Get().ToList();
            userDTOs=new ObservableCollection<UserDTO>(_userService.Get().ToList());
            carDTOs = CarViewModel.CreateList(carDTO, carTypeDTOs);
        }
        private List<CarDTO> carDTO;
        private List<CarViewModel> carDTOs;
        public List<CarViewModel> AllCar
        {
            get {

                return carDTOs; 
            }
            set
            {
                carDTOs = value;
                NotifyPropertyChanged("AllCar");
            }
        }
        private List<CarTypeDTO> carTypeDTOs;
        public List<CarTypeDTO> AllCarType
        {
            get { return carTypeDTOs; }
            set
            {
                carTypeDTOs = value;
                NotifyPropertyChanged("AllCarType");
            }
        }
        private ObservableCollection<UserDTO> userDTOs;
        public ObservableCollection<UserDTO> AllUser
        {
            get { return userDTOs; }
            set
            {
                userDTOs = value;
                NotifyPropertyChanged("AllUser");
            }
        }
        private ObservableCollection<UserDTO> findUserCol;
        public ObservableCollection<UserDTO> FindUserCol
        {
            get { return findUserCol; }
            set
            {
                findUserCol = value;
                NotifyPropertyChanged("FindUserCol");
            }
        }
        private ObservableCollection<CarViewModel> findCarCol;
        public ObservableCollection<CarViewModel> FindCarCol
        {
            get { return findCarCol; }
            set
            {
                findCarCol = value;
                NotifyPropertyChanged("FindCarCol");
            }
        }
        #region Command To Delete
        public TabItem SelectedTabItem { get; set; }
        public UserDTO SelectedUser { get; set; }
        public CarViewModel SelectedCar { get; set; }
        public CarTypeDTO SelectedCarType { get; set; }
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Choose something!";
                    //car
                    if (SelectedTabItem.Name == "CarTab" && SelectedCar != null)
                    {
                        _carService.Delete(SelectedCar.Id);
                        resultStr = "Car is deleting succesfuly";
                        UpdateAllDataView();
                    }
                    //carType
                    if (SelectedTabItem.Name == "CarTypeTab" && SelectedCarType != null)
                    {
                        _carTypeService.Delete(SelectedCarType.Id);
                        resultStr = "CarType is deleting succesfuly";
                        UpdateAllDataView();
                    }
                    //User
                    if (SelectedTabItem.Name == "UsersTab" && SelectedUser != null)
                    {
                        _userService.Delete(SelectedUser.Id);
                        resultStr = "User is deleting succesfuly";
                        UpdateAllDataView();
                    }
                    //обновление
                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }
        #endregion
        #region COMMANDS TO Find
        public string LoginToFind { get; set; }
        private RelayCommand findUser;
        public RelayCommand FindUser
        {
            get
            {
                return findUser ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string findResultStr = "User is finding succesfuly";
                    string unfindResultStr = "user isn't finding succesfuly";

                    bool loginCondition = LoginToFind == null || LoginToFind.Replace(" ", "").Length == 0;

                    if (loginCondition)
                    {
                        SetColorBlockControll(wnd, "LoginFindBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "LoginFindBlock", colorGreen);
                    }
                    if (!loginCondition)
                    {
                        var finUser=_userService.Find(LoginToFind);
                        if (finUser.Count() != 0)
                        {
                            FindUserCol =new ObservableCollection<UserDTO>(finUser.ToList());
                            UI.View.FindUser.FindUsers.ItemsSource = null;
                            UI.View.FindUser.FindUsers.Items.Clear();
                            UI.View.FindUser.FindUsers.ItemsSource = FindUserCol;
                            UI.View.FindUser.FindUsers.Items.Refresh();
                            ShowMessageToUser(findResultStr);
                            SetNullValuesToProperties();
                        }
                        else
                        {
                            ShowMessageToUser(unfindResultStr);
                            SetNullValuesToProperties();
                        }
                        
                    }
                }
                );
            }
        }
        public int CostToFind { get; set; }
        private RelayCommand findCar;
        public RelayCommand FindCar
        {
            get
            {
                return findCar ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string findResultStr = "Car is finding succesfuly";
                    string unfindResultStr = "Car isn't finding succesfuly";

                    bool costCondition = CostToFind <=0;

                    if (costCondition)
                    {
                        SetColorBlockControll(wnd, "CostCar", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "CostCar", colorGreen);
                    }
                    if (!costCondition)
                    {
                        var finCar = _carService.Find(CostToFind);
                        if (finCar.Count() != 0)
                        {
                            FindCarCol = new ObservableCollection<CarViewModel>(CarViewModel.CreateList(finCar.ToList(),carTypeDTOs));
                            UI.View.FindCar.FindCars.ItemsSource = null;
                            UI.View.FindCar.FindCars.Items.Clear();
                            UI.View.FindCar.FindCars.ItemsSource = FindCarCol;
                            UI.View.FindCar.FindCars.Items.Refresh();
                            ShowMessageToUser(findResultStr);
                            SetNullValuesToProperties();
                        }
                        else
                        {
                            ShowMessageToUser(unfindResultStr);
                            SetNullValuesToProperties();
                        }

                    }
                }
                );
            }
        }

        private RelayCommand findUserWnd;
        public RelayCommand FindUserWnd
        {
            get
            {
                return findUserWnd ?? new RelayCommand(obj =>
                {
                    
                    OpenFindUserWindowMethod();

                }
                );
            }
        }
        private RelayCommand findCarWnd;
        public RelayCommand FindCarWnd
        {
            get
            {
                return findCarWnd ?? new RelayCommand(obj =>
                {

                    OpenFindCarWindowMethod();

                }
                );
            }
        }
        private RelayCommand findCarTypeWnd;
        public RelayCommand FindCarTypeWnd
        {
            get
            {
                return findCarTypeWnd ?? new RelayCommand(obj =>
                {

                    OpenFindCarTypeWindowMethod();

                }
                );
            }
        }
        #endregion
        #region COMMANDS TO ADD
        public string NewLogin { get; set; }
        public string NewPassword { get; set; }
        public string NewRole { get; set; }
        private RelayCommand addUser;
        public RelayCommand AddUser
        {
            get
            {
                return addUser ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string resultStr = "User is adding succesfuly";
                    bool loginCondition = NewLogin == null || NewLogin.Replace(" ", "").Length == 0;
                    bool roleCondition = NewRole == null || NewRole.Replace(" ", "").Length == 0 ;
                    bool passwordCondition = NewPassword == null || NewPassword.Replace(" ", "").Length == 0;

                    if (loginCondition)
                    {
                        SetColorBlockControll(wnd, "LoginBlock",colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "LoginBlock", colorGreen);
                    }
                    if(passwordCondition)
                    {
                        SetColorBlockControll(wnd, "PasswordBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "PasswordBlock", colorGreen);
                    }
                    if(roleCondition)
                    {
                        SetColorBlockControll(wnd, "RoleBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "RoleBlock", colorGreen);
                    }
                    if(!loginCondition&& !passwordCondition&& !roleCondition)
                    { 
                        _userService.Create(new UserDTO() { Login = NewLogin, Password = NewPassword, Role = NewRole });
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        public string NewCarName { get; set; }
        public double NewCarCost { get; set; }
        public CarTypeDTO NewCarType { get; set; }
        private RelayCommand addCar;
        public RelayCommand AddCar
        {
            get
            {
                return addCar ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string resultStr = "Car is adding succesfuly";
                    bool carNameCondition = NewCarName == null || NewCarName.Replace(" ", "").Length == 0;
                    bool carCostCondition = NewCarCost <=0 ;
                    bool carTypeCondition = NewCarType == null;

                    if (carNameCondition)
                    {
                        SetColorBlockControll(wnd, "CarNameBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "CarNameBlock", colorGreen);
                    }
                    if (carCostCondition)
                    {
                        SetColorBlockControll(wnd, "CarCostBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "CarCostBlock", colorGreen);
                    }
                    if (carTypeCondition)
                    {
        
                        MessageBox.Show(wnd,"Choose type");
                    }
                    if (!carNameCondition && !carCostCondition && !carTypeCondition)
                    {
                        _carService.Create(new CarDTO() { Title= NewCarName,Cost=NewCarCost,CarTypeId=NewCarType.Id});
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        public string NewCarTypeAdd { get; set; }
        private RelayCommand addCarType;
        public RelayCommand AddCarType
        {
            get
            {
                return addCarType ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string resultStr = "CarType is adding succesfuly";
                    bool carTypeCondition = NewCarTypeAdd == null || NewCarTypeAdd.Replace(" ", "").Length == 0;

                    if (carTypeCondition)
                    {
                        SetColorBlockControll(wnd, "carTypeBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "carTypeBlock", colorGreen);
                    }
                    if (!carTypeCondition)
                    {
                        _carTypeService.Create(new CarTypeDTO() { Title=NewCarTypeAdd });
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewCar;
        public RelayCommand AddNewCarWnd
        {
            get
            {
                return addNewCar ?? new RelayCommand(obj =>
                {
                    OpenAddCarWindowMethod();
                }
                );
            }
        }
        private RelayCommand addNewCarType;
        public RelayCommand AddNewCarTypeWnd
        {
            get
            {
                return addNewCarType ?? new RelayCommand(obj =>
                {
                    OpenAddCarTypeWindowMethod();
                });
            }
        }
        private RelayCommand addNewUser;
        public RelayCommand AddNewUserWnd
        {
            get
            {
                return addNewUser ?? new RelayCommand(obj =>
                {
                   
                    OpenAddUserWindowMethod();
                }
                );
            }
        }
        #endregion
        #region Open Window
        private void OpenFindCarTypeWindowMethod()
        {
            FindCarType findCarType = new FindCarType() { DataContext = this };
            UI.View.FindCarType.FindCarTypes.ItemsSource = null;
            UI.View.FindCarType.FindCarTypes.Items.Clear();
            UI.View.FindCarType.FindCarTypes.Items.Refresh();
            SetCenterPositionAndOpen(findCarType);
        }
        private void OpenFindCarWindowMethod()
        {
            FindCar findCar = new FindCar() { DataContext = this };
            UI.View.FindCar.FindCars.ItemsSource = null;
            UI.View.FindCar.FindCars.Items.Clear();
            UI.View.FindCar.FindCars.Items.Refresh();
            SetCenterPositionAndOpen(findCar);
        }
        private void OpenFindUserWindowMethod()
        {
            FindUser findUser = new FindUser() { DataContext = this };
            UI.View.FindUser.FindUsers.ItemsSource = null;
            UI.View.FindUser.FindUsers.Items.Clear();
            UI.View.FindUser.FindUsers.Items.Refresh();
            SetCenterPositionAndOpen(findUser);
        }
        private void OpenAddCarWindowMethod()
        {
            AddNewCar addNewCar = new AddNewCar() { DataContext = this };
            SetCenterPositionAndOpen(addNewCar);
        }
        private void OpenAddCarTypeWindowMethod()
        {
            AddNewCarType addNewCarType = new AddNewCarType() { DataContext=this};
            SetCenterPositionAndOpen(addNewCarType);
        }
        private void OpenAddUserWindowMethod()
        {
            AddNewUser addNewUser = new AddNewUser() { DataContext=this};
            SetCenterPositionAndOpen(addNewUser);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion
        #region Update Data
        private void UpdateAllDataView()
        {
            UpdateAllUserView();
            UpdateAllCarView();
            UpdateAllCarTypeView();
        }

        private void UpdateAllUserView()
        {
            AllUser = new ObservableCollection<UserDTO>(_userService.Get().ToList());
            MainWindow.AllUsers.ItemsSource = null;
            MainWindow.AllUsers.Items.Clear();
            MainWindow.AllUsers.ItemsSource = AllUser;
            MainWindow.AllUsers.Items.Refresh();
        }
        private void UpdateAllCarView()
        {
            List<CarViewModel> carViewModels = new List<CarViewModel>();
            _carService.Get().ToList().ForEach(x => carViewModels.Add(new CarViewModel(x, carTypeDTOs.FirstOrDefault(type => type.Id == x.CarTypeId))));
            AllCar = new List<CarViewModel>(carViewModels);
            MainWindow.AllCars.ItemsSource = null;
            MainWindow.AllCars.Items.Clear();
            MainWindow.AllCars.ItemsSource = AllCar;
            MainWindow.AllCars.Items.Refresh();
        }
        private void UpdateAllCarTypeView()
        {
            AllCarType = _carTypeService.Get().ToList();
            MainWindow.AllCarTypes.ItemsSource = null;
            MainWindow.AllCarTypes.Items.Clear();
            MainWindow.AllCarTypes.ItemsSource = AllCarType;
            MainWindow.AllCarTypes.Items.Refresh();
        }
        private void SetNullValuesToProperties()
        {
            //for user
            LoginToFind = null;
            NewLogin = null;
            NewPassword = null;
            NewRole = null;
            //for car
            CostToFind = 0;
            NewCarCost = 0;
            NewCarName = null;
            NewCarType = null;
            //for carType
            NewCarTypeAdd = null;


        }
        #endregion
        #region Other Settings
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }
        private void SetColorBlockControll(Window wnd, string blockName,Color color)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = new SolidColorBrush(color);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
