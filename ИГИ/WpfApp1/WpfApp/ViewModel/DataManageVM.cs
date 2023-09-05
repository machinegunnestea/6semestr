using BLL.DTO;
using BLL.Interfaces.EntityServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp.Model;
using WpfApp.View;
using ВLL.DTO;
using ВLL.Interfaces.EntityServices;

namespace WpfApp.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        private IMovieService _movieService;
        private IMovieTypeService _movieTypeService;
        private IUserService _userService;
        public DataManageVM()
        {

        }
        public DataManageVM(IMovieService movieService, IMovieTypeService movieTypeService, IUserService userService)
        {
            _movieService = movieService;
            _movieTypeService = movieTypeService;
            _userService = userService;
            movieDTO = _movieService.Get().ToList();
            movieTypeDTOs = _movieTypeService.Get().ToList();
            userDTOs = new ObservableCollection<UserDTO>(_userService.Get().ToList());
            movieDTOs = MovieViewModel.CreateList(movieDTO, movieTypeDTOs);
        }
        private List<MovieDTO> movieDTO;
        private List<MovieViewModel> movieDTOs;
        public List<MovieViewModel> AllMovie
        {
            get
            {

                return movieDTOs;
            }
            set
            {
                movieDTOs = value;
                NotifyPropertyChanged("AllMovie");
            }
        }
        private List<MovieTypeDTO> movieTypeDTOs;
        public List<MovieTypeDTO> AllMovieType
        {
            get { return movieTypeDTOs; }
            set
            {
                movieTypeDTOs = value;
                NotifyPropertyChanged("AllMovieType");
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
        private ObservableCollection<MovieViewModel> findMovieCol;
        public ObservableCollection<MovieViewModel> FindMovieCol
        {
            get { return findMovieCol; }
            set
            {
                findMovieCol = value;
                NotifyPropertyChanged("FindMovieCol");
            }
        }
        #region Command To Delete
        public TabItem SelectedTabItem { get; set; }
        public UserDTO SelectedUser { get; set; }
        public MovieViewModel SelectedMovie { get; set; }
        public MovieTypeDTO SelectedMovieType { get; set; }
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Choose something!";
                    //movie
                    if (SelectedTabItem.Name == "MovieTab" && SelectedMovie != null)
                    {
                        _movieService.Delete(SelectedMovie.Id);
                        resultStr = "Movie is deleting succesfuly";
                        UpdateAllDataView();
                    }
                    //movieType
                    if (SelectedTabItem.Name == "MovieTypeTab" && SelectedMovieType != null)
                    {
                        _movieTypeService.Delete(SelectedMovieType.Id);
                        resultStr = "MovieType is deleting succesfuly";
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
                        var finUser = _userService.Find(LoginToFind);
                        if (finUser.Count() != 0)
                        {
                            FindUserCol = new ObservableCollection<UserDTO>(finUser.ToList());
                            WpfApp.View.FindUser.FindUsers.ItemsSource = null;
                            WpfApp.View.FindUser.FindUsers.Items.Clear();
                            WpfApp.View.FindUser.FindUsers.ItemsSource = FindUserCol;
                            WpfApp.View.FindUser.FindUsers.Items.Refresh();
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
        private RelayCommand findMovie;
        public RelayCommand FindMovie
        {
            get
            {
                return findMovie ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string findResultStr = "Movie is finding succesfuly";
                    string unfindResultStr = "Movie isn't finding succesfuly";

                    bool costCondition = CostToFind <= 0;

                    if (costCondition)
                    {
                        SetColorBlockControll(wnd, "CostMovie", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "CostMovie", colorGreen);
                    }
                    if (!costCondition)
                    {
                        var finMovie = _movieService.Find(CostToFind);
                        if (finMovie.Count() != 0)
                        {
                            FindMovieCol = new ObservableCollection<MovieViewModel>(MovieViewModel.CreateList(finMovie.ToList(), movieTypeDTOs));
                            WpfApp.View.FindMovie.FindMovies.ItemsSource = null;
                            WpfApp.View.FindMovie.FindMovies.Items.Clear();
                            WpfApp.View.FindMovie.FindMovies.ItemsSource = FindMovieCol;
                            WpfApp.View.FindMovie.FindMovies.Items.Refresh();
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
        private RelayCommand findMovieWnd;
        public RelayCommand FindMovieWnd
        {
            get
            {
                return findMovieWnd ?? new RelayCommand(obj =>
                {

                    OpenFindMovieWindowMethod();

                }
                );
            }
        }
        private RelayCommand findMovieTypeWnd;
        public RelayCommand FindMovieTypeWnd
        {
            get
            {
                return findMovieTypeWnd ?? new RelayCommand(obj =>
                {

                    OpenFindMovieTypeWindowMethod();

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
                    bool roleCondition = NewRole == null || NewRole.Replace(" ", "").Length == 0;
                    bool passwordCondition = NewPassword == null || NewPassword.Replace(" ", "").Length == 0;

                    if (loginCondition)
                    {
                        SetColorBlockControll(wnd, "LoginBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "LoginBlock", colorGreen);
                    }
                    if (passwordCondition)
                    {
                        SetColorBlockControll(wnd, "PasswordBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "PasswordBlock", colorGreen);
                    }
                    if (roleCondition)
                    {
                        SetColorBlockControll(wnd, "RoleBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "RoleBlock", colorGreen);
                    }
                    if (!loginCondition && !passwordCondition && !roleCondition)
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
        public string NewMovieName { get; set; }
        public double NewMovieCost { get; set; }
        public MovieTypeDTO NewMovieType { get; set; }
        private RelayCommand addMovie;
        public RelayCommand AddMovie
        {
            get
            {
                return addMovie ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string resultStr = "Movie is adding succesfuly";
                    bool movieNameCondition = NewMovieName == null || NewMovieName.Replace(" ", "").Length == 0;
                    bool movieCostCondition = NewMovieCost <= 0;
                    bool movieTypeCondition = NewMovieType == null;

                    if (movieNameCondition)
                    {
                        SetColorBlockControll(wnd, "MovieNameBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "MovieNameBlock", colorGreen);
                    }
                    if (movieCostCondition)
                    {
                        SetColorBlockControll(wnd, "MovieCostBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "MovieCostBlock", colorGreen);
                    }
                    if (movieTypeCondition)
                    {

                        MessageBox.Show(wnd, "Choose type");
                    }
                    if (!movieNameCondition && !movieCostCondition && !movieTypeCondition)
                    {
                        _movieService.Create(new MovieDTO() { Title = NewMovieName, Cost = NewMovieCost, MovieTypeId = NewMovieType.Id });
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        public string NewMovieTypeAdd { get; set; }
        private RelayCommand addMovieType;
        public RelayCommand AddMovieType
        {
            get
            {
                return addMovieType ?? new RelayCommand(obj =>
                {
                    Color colorRed = Color.FromRgb(255, 0, 0);
                    Color colorGreen = Color.FromRgb(0, 128, 0);
                    Window wnd = obj as Window;
                    string resultStr = "MovieType is adding succesfuly";
                    bool movieTypeCondition = NewMovieTypeAdd == null || NewMovieTypeAdd.Replace(" ", "").Length == 0;

                    if (movieTypeCondition)
                    {
                        SetColorBlockControll(wnd, "movieTypeBlock", colorRed);
                    }
                    else
                    {
                        SetColorBlockControll(wnd, "movieTypeBlock", colorGreen);
                    }
                    if (!movieTypeCondition)
                    {
                        _movieTypeService.Create(new MovieTypeDTO() { Title = NewMovieTypeAdd });
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewMovie;
        public RelayCommand AddNewMovieWnd
        {
            get
            {
                return addNewMovie ?? new RelayCommand(obj =>
                {
                    OpenAddMovieWindowMethod();
                }
                );
            }
        }
        private RelayCommand addNewMovieType;
        public RelayCommand AddNewMovieTypeWnd
        {
            get
            {
                return addNewMovieType ?? new RelayCommand(obj =>
                {
                    OpenAddMovieTypeWindowMethod();
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
        private void OpenFindMovieTypeWindowMethod()
        {
            FindMovieType findMovieType = new FindMovieType() { DataContext = this };
            WpfApp.View.FindMovieType.FindMovieTypes.ItemsSource = null;
            WpfApp.View.FindMovieType.FindMovieTypes.Items.Clear();
            WpfApp.View.FindMovieType.FindMovieTypes.Items.Refresh();
            SetCenterPositionAndOpen(findMovieType);
        }
        private void OpenFindMovieWindowMethod()
        {
            FindMovie findMovie = new FindMovie() { DataContext = this };
            WpfApp.View.FindMovie.FindMovies.ItemsSource = null;
            WpfApp.View.FindMovie.FindMovies.Items.Clear();
            WpfApp.View.FindMovie.FindMovies.Items.Refresh();
            SetCenterPositionAndOpen(findMovie);
        }
        private void OpenFindUserWindowMethod()
        {
            FindUser findUser = new FindUser() { DataContext = this };
            WpfApp.View.FindUser.FindUsers.ItemsSource = null;
            WpfApp.View.FindUser.FindUsers.Items.Clear();
            WpfApp.View.FindUser.FindUsers.Items.Refresh();
            SetCenterPositionAndOpen(findUser);
        }
        private void OpenAddMovieWindowMethod()
        {
            AddNewMovie addNewMovie = new AddNewMovie() { DataContext = this };
            SetCenterPositionAndOpen(addNewMovie);
        }
        private void OpenAddMovieTypeWindowMethod()
        {
            AddNewMovieType addNewMovieType = new AddNewMovieType() { DataContext = this };
            SetCenterPositionAndOpen(addNewMovieType);
        }
        private void OpenAddUserWindowMethod()
        {
            AddNewUser addNewUser = new AddNewUser() { DataContext = this };
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
            UpdateAllMovieView();
            UpdateAllMovieTypeView();
        }

        private void UpdateAllUserView()
        {
            AllUser = new ObservableCollection<UserDTO>(_userService.Get().ToList());
            MainWindow.AllUsers.ItemsSource = null;
            MainWindow.AllUsers.Items.Clear();
            MainWindow.AllUsers.ItemsSource = AllUser;
            MainWindow.AllUsers.Items.Refresh();
        }
        private void UpdateAllMovieView()
        {
            List<MovieViewModel> movieViewModels = new List<MovieViewModel>();
            _movieService.Get().ToList().ForEach(x => movieViewModels.Add(new MovieViewModel(x, movieTypeDTOs.FirstOrDefault(type => type.Id == x.MovieTypeId))));
            AllMovie = new List<MovieViewModel>(movieViewModels);
            MainWindow.AllMovies.ItemsSource = null;
            MainWindow.AllMovies.Items.Clear();
            MainWindow.AllMovies.ItemsSource = AllMovie;
            MainWindow.AllMovies.Items.Refresh();
        }
        private void UpdateAllMovieTypeView()
        {
            AllMovieType = _movieTypeService.Get().ToList();
            MainWindow.AllMovieTypes.ItemsSource = null;
            MainWindow.AllMovieTypes.Items.Clear();
            MainWindow.AllMovieTypes.ItemsSource = AllMovieType;
            MainWindow.AllMovieTypes.Items.Refresh();
        }
        private void SetNullValuesToProperties()
        {
            //for user
            LoginToFind = null;
            NewLogin = null;
            NewPassword = null;
            NewRole = null;
            //for movie
            CostToFind = 0;
            NewMovieCost = 0;
            NewMovieName = null;
            NewMovieType = null;
            //for movieType
            NewMovieTypeAdd = null;


        }
        #endregion
        #region Other Settings
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }
        private void SetColorBlockControll(Window wnd, string blockName, Color color)
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
